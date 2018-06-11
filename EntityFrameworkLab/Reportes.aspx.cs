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
    public partial class Reportes : System.Web.UI.Page
    {
        DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {

            BL_Cliente cliente = new BL_Cliente();
            if (IsPostBack)
            {
                cliente.listaClientes = (List<BL_Cliente>)ViewState["ListaCedula"];
                Calendar2.SelectedDate = (DateTime)ViewState["secondDate"];
                dt = (DataTable)ViewState["DataTable"];
            }
            else
            {

                cliente.loadClients();
                ddlClientes.DataSource = cliente.listaClientes;
                ddlClientes.DataValueField = "Cedula";
                ddlClientes.DataTextField = "Cedula";
                ddlClientes.DataBind();
                ddlClientes.Items.Add(new ListItem("Seleccionar"));
                ddlClientes.SelectedValue = "Seleccionar";
                ViewState["ListaCedula"] = ddlClientes.DataSource;
                Calendar2.SelectedDate = DateTime.Today;
                ViewState["secondDate"] = Calendar2.SelectedDate;
                dt = new DataTable();
                dt.Columns.Add("Codigo");
                dt.Columns.Add("Descripcion");
                dt.Columns.Add("Precio");
                dt.Columns.Add("Cantidad");
                dt.Columns.Add("Total_Producto");
                ViewState["DataTable"] = dt;

            }
            refreshGrid();
        }
        protected void refreshGrid()
        {
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            if (Calendar1.SelectedDate > DateTime.Today)
            {
                Calendar1.SelectedDate = DateTime.Today;
            }
            Calendar2.Enabled = true;
        }

        protected void Calendar2_SelectionChanged(object sender, EventArgs e)
        {
            if (Calendar1.SelectedDate>Calendar2.SelectedDate || Calendar2.SelectedDate > DateTime.Today)
            {
                Calendar2.SelectedDate = DateTime.Today;
            }
        }

        protected int calcularTotal()
        {
            int sum = 0;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                sum += Convert.ToInt32(GridView1.Rows[i].Cells[dt.Columns.IndexOf("Total_Producto")].Text);
            }

            return sum;
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (ddlClientes.Text != "Seleccionar")
            {
                BL_Reporte facturas = new BL_Reporte();
                facturas.client = ddlClientes.SelectedValue;
                facturas.desde = Calendar1.SelectedDate;
                facturas.hasta = Calendar2.SelectedDate;
                facturas.listaFacturas = new List<BL_Factura>();
                facturas.getFacturasConRango();
                llenarFacturaDrop(facturas.listaFacturas);
            }
            DropDownList2.Enabled = true;
        }

        private void llenarFacturaDrop(List<BL_Factura> list)
        {

                DropDownList2.DataSource = list;
                DropDownList2.DataValueField = "Codigo";
                DropDownList2.DataTextField = "Codigo";
                DropDownList2.DataBind();
                DropDownList2.Items.Add(new ListItem("Seleccionar"));
                DropDownList2.SelectedValue = "Seleccionar";


        }
        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            dt = new DataTable();
            dt.Columns.Add("Codigo");
            dt.Columns.Add("Descripcion");
            dt.Columns.Add("Precio");
            dt.Columns.Add("Cantidad");
            dt.Columns.Add("Total_Producto");

            BL_Factura fact = new BL_Factura();
            fact.Codigo = DropDownList2.SelectedValue;
            fact.ListaProductos = new List<BL_Producto>();
            fact.selectAFactura();
            if (DropDownList2.Text != "Seleccionar")
            {
                foreach (var prod in fact.ListaProductos)
                {
                    DataRow row = dt.NewRow();
                    row["Codigo"] = prod.Codigo;
                    row["Precio"] = prod.Precio;
                    row["Cantidad"] = prod.Cantidad_En_Factura;
                    row["Descripcion"] = prod.Descripcion;
                    row["Total_Producto"] = (prod.Precio * prod.Cantidad_En_Factura);
                    dt.Rows.Add(row);
                }
                ViewState["DataTable"] = dt;
                refreshGrid();
                TextBox3.Text = calcularTotal().ToString();
                }
            }
    }


}