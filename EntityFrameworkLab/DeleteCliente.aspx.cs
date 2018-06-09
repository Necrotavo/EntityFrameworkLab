using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL;

namespace EntityFrameworkLab
{
    public partial class DeleteCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            enableTxtBox(false);
            if (IsPostBack)
            {
                ddlClientes.DataSource = ViewState["ListaCedula"];
            }
            else {
                BL_Cliente cliente = new BL_Cliente();
                cliente.loadClients();
                ddlClientes.DataSource = cliente.listaClientes;
                ddlClientes.DataValueField = "Cedula";
                ddlClientes.DataTextField = "Cedula";
                ddlClientes.DataBind();
                ViewState["ListaCedula"] = ddlClientes.DataSource;
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            BL_Cliente cliente = new BL_Cliente();
            cliente.Cedula = ddlClientes.SelectedValue;
            cliente.deleteClient();
            clearTxtBox();
        }

        protected void enableTxtBox(Boolean value)
        {
            txtName.Enabled = value;
            txtLastName.Enabled = value;
            txtMail.Enabled = value;
            txtTelefono.Enabled = value;
        }

        protected void clearTxtBox()
        {
            txtName.Text = "";
            txtLastName.Text = "";
            txtMail.Text = "";
            txtTelefono.Text = "";
        }

        protected void ddlClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            BL_Cliente cliente = new BL_Cliente();
            cliente.Cedula = ddlClientes.SelectedValue;
            cliente.loadClient();
            txtName.Text = cliente.Nombre;
            txtLastName.Text = cliente.Apellido;
            txtMail.Text = cliente.Correo;
            txtTelefono.Text = cliente.Telefono;
            if (!cliente.hasEmpty())
            {
                enableTxtBox(true);
            }
        }

    }
}