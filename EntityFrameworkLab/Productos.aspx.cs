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
    }
}