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

                
            }
        }
    }
}