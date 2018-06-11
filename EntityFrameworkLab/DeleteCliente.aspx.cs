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
                lblError.Text = "";
                if ((Boolean)ViewState["HeEliminado"]) {
                    loadList();
                }
            }
            else {
                loadList();
            }
        }

        protected void loadList() {
            BL_Cliente cliente = new BL_Cliente();
            cliente.loadClients();
            ddlClientes.DataSource = cliente.listaClientes;//Aqu[i puse el foreach que le dije
            ddlClientes.DataValueField = "Cedula";
            ddlClientes.DataTextField = "Cedula";
            ddlClientes.DataBind();
            ddlClientes.Items.Add(new ListItem("Seleccionar"));
            ddlClientes.SelectedValue = "Seleccionar";
            ViewState["HeEliminado"] = false;
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (ddlClientes.SelectedValue.Trim() != "Seleccionar")
            {
                BL_Cliente cliente = new BL_Cliente();
                cliente.Cedula = ddlClientes.SelectedValue;
                try
                {
                    cliente.deleteClient();
                    loadList();
                    ViewState["HeEliminado"] = true;
                    clearTxtBox();
                }
                catch (Exception)
                {
                    lblError.Text = "Este cliente tiene facturas, no se puede elminar";
                    loadList();
                    ViewState["HeEliminado"] = false;
                    clearTxtBox();
                }
            }
            
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
            //if (!cliente.hasEmpty())
            //{
            //    enableTxtBox(true);
            //}
            ViewState["HeEliminado"] = false;
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Response.Redirect("MenuClientes.aspx");
        }
    }
}