using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL;

namespace EntityFrameworkLab
{
    public partial class Productos : System.Web.UI.Page
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
                blProduct.selectClientes();
                dropClients.DataSource = blProduct.listaProductos;
                dropClients.DataBind();
                ViewState["ListaP"] = blProduct.listaProductos;
            }
        }

        protected void btnExecute_Click(object sender, EventArgs e)
        {
            switch (Convert.ToInt16(RadioButtonList1.SelectedValue))
            {
                case 1:
                    insert();
                    break;
                case 2:
                    update();
                    break;

                case 3:
                    delete();
                    break;
            }
        }
        /*Codigo, desc, precio, cant*/
        private void insert()
        {
            blProduct.Codigo = TextBox1.Text;
            blProduct.Descripcion = TextBox2.Text;
            blProduct.Precio = Convert.ToInt16(TextBox3.Text);
            blProduct.Cantidad_Inventario = Convert.ToInt16(TextBox4.Text);

            blProduct.insertProduct();
        }

        private void update()
        {
            blProduct.Codigo = TextBox1.Text;
            blProduct.Descripcion = TextBox2.Text;
            blProduct.Precio = Convert.ToInt16(TextBox3.Text);
            blProduct.Cantidad_Inventario = Convert.ToInt16(TextBox4.Text);

            blProduct.modifyProduct();
            clearBoxes();
        }


        private void delete()
        {
            blProduct.Codigo = TextBox1.Text;

            blProduct.deleteProduct();

            clearBoxes();
        }

        private void clearBoxes()
        {
            TextBox1.Text = "Listo";
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
        }

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt16(RadioButtonList1.SelectedValue) == 2 || Convert.ToInt16(RadioButtonList1.SelectedValue) == 3)
            {
                TextBox1.AutoPostBack = true;
                TextBox2.Enabled = false;
                TextBox3.Enabled = false;
                TextBox4.Enabled = false;
                
            }
            if(Convert.ToInt16(RadioButtonList1.SelectedValue) == 1)
            {
                TextBox1.AutoPostBack = false;
                TextBox1.Enabled = true;
                TextBox2.Enabled = true;
                TextBox3.Enabled = true;
                TextBox4.Enabled = true;
            }
        }


        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {
            blProduct.Codigo = TextBox1.Text;
            blProduct.selectAProduct();
            if (blProduct.Descripcion != null)
            {
                TextBox2.Text = blProduct.Descripcion;
                TextBox3.Text = blProduct.Precio.ToString();
                TextBox4.Text = blProduct.Cantidad_Inventario.ToString();

                if (Convert.ToInt16(RadioButtonList1.SelectedValue) == 2)
                {
                    TextBox2.Enabled = true;
                    TextBox3.Enabled = true;
                    TextBox4.Enabled = true;
                }
            }

        }
    }
}