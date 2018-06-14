using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL;
using System.Data;

namespace EntityFrameworkLab
{
    public partial class Facturas : System.Web.UI.Page
    {

        private BL_Producto blProductoActual;
        DataTable dt;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                blProductoActual = (BL_Producto)ViewState["ProductoActual"];
                dt = (DataTable)ViewState["DataTable"];


            }
            else
            {
                loadClientList();
                loadProductList();
                createDataTable();
                dt = new DataTable();
                dt.Columns.Add("Codigo");
                dt.Columns.Add("Precio");
                dt.Columns.Add("Cantidad");
                dt.Columns.Add("Total_Producto");
                ViewState["DataTable"] = dt;
            }
            refreshGrid();
        }

        protected void refreshGrid() {
            dgvDetalleFactura.DataSource = dt;
            dgvDetalleFactura.DataBind();
        }

        protected int calcularTotal()
        {
            int sum = 0;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                sum += Convert.ToInt32(dgvDetalleFactura.Rows[i].Cells[dt.Columns.IndexOf("Total_Producto")].Text);
            }

            return sum;
        }

        protected bool existe()
        {
           
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dgvDetalleFactura.Rows[i].Cells[dt.Columns.IndexOf("Codigo")].Text.Trim() == blProductoActual.Codigo.Trim() )
                {
                    return true;
                } 
            }

            return false;
        }

        protected void createDataTable() {
            dt = new DataTable();
            dt.Columns.Add("Codigo de Producto", Type.GetType("System.String"));
            dt.Columns.Add("Precio", Type.GetType("System.String"));
            dt.Columns.Add("Cantidad Comprada", Type.GetType("System.String"));
            dt.Columns.Add("Sub Total", Type.GetType("System.String"));
        }

        protected void loadClientList()
        {
            BL_Cliente cliente = new BL_Cliente();
            cliente.loadClients();
            ddlClientes.DataSource = cliente.listaClientes;
            ddlClientes.DataValueField = "Cedula";
            ddlClientes.DataTextField = "Cedula";
            ddlClientes.DataBind();
            ddlClientes.Items.Add(new ListItem("Seleccionar"));
            ddlClientes.SelectedValue = "Seleccionar";
        }

        protected void loadProductList()
        {
            BL_Producto blProduct = new BL_Producto();
            blProduct.selectProductos();
            ddlProductos.DataSource = blProduct.listaProductos;
            ddlProductos.DataValueField = "Codigo";
            ddlProductos.DataTextField = "Codigo";
            ddlProductos.DataBind();
            ddlProductos.Items.Add(new ListItem("Seleccionar"));
            ddlProductos.SelectedValue = "Seleccionar";
        }

        protected void ddlClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            BL_Cliente cliente = new BL_Cliente();
            cliente.Cedula = ddlClientes.SelectedValue;
            cliente.loadClient();
            txtNombreCliente.Text = cliente.Nombre.Trim() + " " + cliente.Apellido.Trim();
        }

        protected void ddlProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlProductos.SelectedValue != "Seleccionar")
            {
                BL_Producto blProducto = new BL_Producto();
                blProducto.Codigo = ddlProductos.SelectedValue;
                blProducto.selectAProduct();
                txtPrecio.Text = blProducto.Precio.ToString();
                txtCantDisponibles.Text = blProducto.Cantidad_Inventario.ToString();
                if (blProducto.Codigo != null)
                {
                    if (blProducto.Codigo.Trim() != "")
                    {
                        ViewState["ProductoActual"] = blProducto;
                        ViewState["DataTable"] = dt;
                    }
                }
            }
            else {
                ViewState["DataTable"] = dt;
                ViewState["ProductoActual"] = blProductoActual;
            }     
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtCantComprar.Text.Trim() != "" && blProductoActual != null)
            {
                if (Convert.ToInt16(txtCantComprar.Text.Trim()) > 0 
                    && Convert.ToInt16(txtCantComprar.Text.Trim()) < Convert.ToInt16(txtCantDisponibles.Text.Trim())
                    && !existe())
                {
                    DataRow row = dt.NewRow();
                    row["Codigo"] = blProductoActual.Codigo;
                    row["Precio"] = blProductoActual.Precio.ToString();
                    row["Cantidad"] = txtCantComprar.Text;
                    row["Total_Producto"] = (blProductoActual.Precio * Convert.ToInt16(txtCantComprar.Text.Trim())).ToString();
                    dt.Rows.Add(row);
                    refreshGrid();

                }
            }
            ViewState["DataTable"] = dt;
            ViewState["ProductoActual"] = blProductoActual;
            txtTotal.Text = calcularTotal().ToString();
        }

        protected void btnUp_Click(object sender, EventArgs e)
        {
            changeSelectedRow(true);
        }
        protected void changeSelectedRow(Boolean upDown)
        {
            if (upDown)
            {
                if (dgvDetalleFactura.SelectedIndex > 0)
                {
                    dgvDetalleFactura.SelectedIndex--;
                }
                
            }
            else
            {
                if (dgvDetalleFactura.SelectedIndex < dgvDetalleFactura.Rows.Count - 1)
                {
                    dgvDetalleFactura.SelectedIndex++;
                }

            }
        }

        protected void btnDown_Click(object sender, EventArgs e)
        {
            changeSelectedRow(false);
        }

        protected void btnRemoveFromList_Click(object sender, EventArgs e)
        {
            dt.Rows.RemoveAt(dgvDetalleFactura.SelectedIndex);
            refreshGrid();
        }

        protected void btnAddFactura_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text.Trim() != "" && ddlClientes.SelectedValue.Trim() != "Seleccionar")
            {
                BL_Factura factura = new BL_Factura();
                factura.Codigo = txtCodigo.Text;
                factura.Cedula_Cliente = ddlClientes.SelectedValue;
                factura.ListaProductos = new List<BL_Producto>();
                foreach (DataRow dRow in dt.Rows)
                {
                    BL_Producto blProd = new BL_Producto();
                    blProd.Codigo = (String)dRow["Codigo"];
                    blProd.Cantidad_En_Factura = Convert.ToInt16(dRow["Cantidad"]);
                    factura.ListaProductos.Add(blProd);
                }
                factura.addFactura();
            }
        }

        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = (Convert.ToInt16(txtCantDisponibles.Text) > Convert.ToInt16(txtCantComprar.Text));

        }
    }
}