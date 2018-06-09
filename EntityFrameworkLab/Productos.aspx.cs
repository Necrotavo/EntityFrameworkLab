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
        }

        private void select()
        {

        }

        private void delete()
        {

        }

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt16(RadioButtonList1.SelectedValue) == 2)
            {
                TextBox1.AutoPostBack = true;
                TextBox2.Enabled = false;
                TextBox3.Enabled = false;
                TextBox4.Enabled = false;
                
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