using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL;

namespace EntityFrameworkLab
{
    public partial class Reportes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BL_Cliente cliente = new BL_Cliente();
            if (IsPostBack)
            {
                cliente.listaClientes = (List<BL_Cliente>)ViewState["ListaCedula"];
                Calendar2.SelectedDate = (DateTime)ViewState["secondDate"];
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

            }
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (ddlClientes.Text != "Seleccionar")
            {
                BL_Reporte facturas = new BL_Reporte();
                facturas.client = ddlClientes.SelectedValue;
                facturas.desde = Calendar1.SelectedDate;
                facturas.hasta = Calendar2.SelectedDate;
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
            //Esto con un autopostback carga los datos de la factura en el grid.
            //tambien requiere calcular el total de la factura y luego llenar el textbox del total.
        }
    }
}