using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//using BL;

namespace EntityFrameworkLab
{
    public partial class SelectCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            enableTxtBox(false);
            if (IsPostBack)
            {

            }
            else {
                //BL_Cliente cliente = new BL_Cliente();
            }

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

        }
    }
}