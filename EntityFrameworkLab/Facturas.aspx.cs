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
                ViewState["DataTable"] = dt;
                ViewState["DataTable"] = blProductoActual;
            }
            refreshGrid();
        }

        protected void refreshGrid() {
            dgvDetalleFactura.DataSource = dt;
            dgvDetalleFactura.DataBind();
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
                if (Convert.ToInt16(txtCantComprar.Text.Trim()) > 0)
                {
                    dt.Rows.Add(blProductoActual.Codigo, blProductoActual.Precio.ToString(), txtCantComprar.Text, (blProductoActual.Precio * Convert.ToInt16(txtCantComprar.Text.Trim())).ToString());
                    refreshGrid();
                }
            }
            ViewState["DataTable"] = dt;
            ViewState["ProductoActual"] = blProductoActual;
        }


    }
}