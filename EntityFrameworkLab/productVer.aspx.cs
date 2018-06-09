﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL;

namespace EntityFrameworkLab
{
    public partial class productVer : System.Web.UI.Page
    {
        BL_Producto blProduct = new BL_Producto();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                blProduct.listaProductos = (List<BL_Producto>)ViewState["ListaP"];
            }
            else
            {
                blProduct.selectProductos();
                dropClients.DataSource = blProduct.listaProductos;
                dropClients.DataValueField = "Codigo";
                dropClients.DataTextField = "Descripcion";

                dropClients.DataBind();
                dropClients.Items.Add(new ListItem("Seleccionar"));
                dropClients.SelectedValue = "Seleccionar";
                ViewState["ListaP"] = blProduct.listaProductos;
            }
        }

        protected void dropClients_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dropClients.SelectedItem.Text == "Seleccionar")
            {
                TextBox2.Text = "";
                TextBox3.Text = "";
                TextBox4.Text = "";
            }
            else
            {
                blProduct.Codigo = dropClients.SelectedValue;
                blProduct.selectAProduct();
                TextBox2.Text = blProduct.Descripcion;
                TextBox3.Text = blProduct.Precio.ToString();
                TextBox4.Text = blProduct.Cantidad_Inventario.ToString();
            }

        }
    }
}