using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL;

namespace EntityFrameworkLab
{
    public partial class UpdateClient : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            enableTxtBox(false);
            if (IsPostBack)
            {

            }
            else {
                loadList();
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

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            BL_Cliente cliente = new BL_Cliente();
            cliente.Cedula = ddlCedulas.SelectedValue;
            cliente.Nombre = txtName.Text;
            cliente.Correo = txtMail.Text;
            cliente.Telefono = txtTelefono.Text;
            cliente.Apellido = txtLastName.Text;
            cliente.modifyClient();
        }

        protected void enableTxtBox(Boolean value) {
            txtName.Enabled = value;
            txtLastName.Enabled = value;
            txtMail.Enabled = value;
            txtTelefono.Enabled = value;
        }

        protected void ddlCedulas_SelectedIndexChanged(object sender, EventArgs e)
        {
            BL_Cliente cliente = new BL_Cliente();
            cliente.Cedula = ddlCedulas.SelectedValue;
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