﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL;
namespace EntityFrameworkLab
{
    public partial class productDelete : System.Web.UI.Page
    {
        BL_Producto blProduct = new BL_Producto();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                if ((Boolean)ViewState["HeEliminado"])
                {
                    loadList();
                }
            }
            else
            {

                loadList();
            }
        }

        protected void loadList()
        {
            blProduct.selectProductos();
            dropClients.DataSource = blProduct.listaProductos;
            dropClients.DataValueField = "Codigo";
            dropClients.DataTextField = "Codigo";
            dropClients.DataBind();
            dropClients.Items.Add(new ListItem("Seleccionar"));
            dropClients.SelectedValue = "Seleccionar";
            ViewState["HeEliminado"] = false;
        }


        protected void btnExecute_Click(object sender, EventArgs e)
        {
            if (dropClients.SelectedItem.Text != "Seleccionar")
            {
                blProduct.Codigo = dropClients.SelectedValue;
                blProduct.deleteProduct();
                loadList();
                ViewState["HeEliminado"] = true;
            }
          

        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Response.Redirect("MenuProductos.aspx");
        }
    }
}