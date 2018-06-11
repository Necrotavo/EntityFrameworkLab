using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL;

namespace EntityFrameworkLab
{

    public partial class Clientes : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            lblError.Text = "";
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (!hasEmptytxt())
            {
                BL_Cliente client = new BL_Cliente();
                client.Cedula = TextBox1.Text;
                client.Nombre = TextBox2.Text;
                client.Apellido = TextBox3.Text;
                client.Correo = TextBox4.Text;
                client.Telefono = TextBox5.Text;

                client.insertClient();
            }
            else {
                TextBox1.Text = "";
                TextBox2.Text = "";
                TextBox3.Text = "";
                TextBox4.Text = "";
                TextBox5.Text = "";
                lblError.Text = "Los campos de texto no deben estar sin texto";
            }
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Response.Redirect("MenuClientes.aspx");
        }

        protected Boolean hasEmptytxt() {
            if (TextBox1.Text.Trim() == "" || TextBox2.Text.Trim() == "" || TextBox3.Text.Trim() == "" ||
                TextBox4.Text.Trim() == "" || TextBox5.Text.Trim() == "")
            {
                return true;
            }
            else {
                return false;
            }
        }
    }
}