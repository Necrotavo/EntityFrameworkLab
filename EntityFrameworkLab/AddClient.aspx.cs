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

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            BL_Cliente client = new BL_Cliente();
            client.Cedula = TextBox1.Text;
            client.Nombre = TextBox2.Text;
            client.Apellido = TextBox3.Text;
            client.Correo = TextBox4.Text;
            client.Telefono = TextBox5.Text;

            client.insertClient();
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Response.Redirect("MenuClientes.aspx");
        }
    }
}