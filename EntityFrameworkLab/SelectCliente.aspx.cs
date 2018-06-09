using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL;

namespace EntityFrameworkLab
{
    public partial class SelectCliente : System.Web.UI.Page
    {
        BL_Cliente blClient = new BL_Cliente();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (IsPostBack)
            {
                blClient.listaClientes = (List<BL_Cliente>)ViewState["ListaP"];
            }
            else
            {
                blClient.loadClients();
                ddlCedulas.DataSource = blClient.listaClientes;
                ddlCedulas.DataValueField = "Cedula";
                ddlCedulas.DataTextField = "Cedula";

                ddlCedulas.DataBind();
                ddlCedulas.Items.Add(new ListItem("Seleccionar"));
                ddlCedulas.SelectedValue = "Seleccionar";
                ViewState["ListaP"] = blClient.listaClientes;
            }
        }

        protected void loadList()
        {
            BL_Cliente cliente = new BL_Cliente();
            cliente.loadClients();
            ddlCedulas.DataSource = cliente.listaClientes;//Aqu[i puse el foreach que le dije
            ddlCedulas.DataValueField = "Cedula";
            ddlCedulas.DataTextField = "Cedula";
            ddlCedulas.DataBind();
            ddlCedulas.Items.Add(new ListItem("Seleccionar"));
            ddlCedulas.SelectedValue = "Seleccionar";
        }

        protected void enableTxtBox(Boolean value)
        {
            txtName.Enabled = value;
            txtLastName.Enabled = value;
            txtMail.Enabled = value;
            txtTelefono.Enabled = value;
        }

        protected void ddlCedulas_SelectedIndexChanged(object sender, EventArgs e)
        {

            blClient.Cedula = ddlCedulas.SelectedValue;
            blClient.loadClient();
            txtName.Text = blClient.Nombre;
            txtLastName.Text = blClient.Apellido;
            txtMail.Text = blClient.Correo;
            txtTelefono.Text = blClient.Telefono;

        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Response.Redirect("MenuClientes.aspx");
        }
    }
}