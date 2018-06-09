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
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            BL_Cliente cliente = new BL_Cliente();
            cliente.Cedula = txtCed.Text;
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

        protected void txtCed_TextChanged(object sender, EventArgs e)
        {
            BL_Cliente cliente = new BL_Cliente();
            cliente.Cedula = txtCed.Text;
            cliente.loadClient();
            txtName.Text = cliente.Nombre;
            txtLastName.Text = cliente.Apellido;
            txtMail.Text = cliente.Correo;
            txtTelefono.Text = cliente.Telefono;

            enableTxtBox(true);
        }
    }
}