using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TO;

namespace DAO
{
    public class DAO_Facturas
    {
        LAB_EF entidades = new LAB_EF();

        public void selectFromClient(TOReporte report)
        {
            var facturas = from r in entidades.FACTURA
                           where ((r.Fecha >= report.desde && r.Fecha <= report.hasta) && r.Cedula_Cliente == report.client)
                           select r;

            if (facturas.Count() > 0)
            {
                foreach (FACTURA daoFactura in facturas)
                {
                    TO_Factura toFactura = new TO_Factura();
                    toFactura.Codigo = daoFactura.Codigo;
                    report.listaFacturas.Add(toFactura);
                }
            }
        }

        public void addFactura(TO_Factura factura)
        {
            FACTURA fact = new FACTURA();
            fact.Cedula_Cliente = factura.Cedula_Cliente;
            fact.Codigo = factura.Codigo;
            var dquery = entidades.Database.SqlQuery<DateTime>("Select getdate()");
            fact.Fecha = dquery.AsEnumerable().First();
            foreach (var item in factura.lista_Productos.toProductList)
            {
                DETALLE_FACTURA detalle = new DETALLE_FACTURA();
                detalle.Cantidad = item.Cantidad_En_Factura;
                detalle.Codigo_Factura = factura.Codigo;
                detalle.Codigo_Producto = item.Codigo;
                detalle.FACTURA = fact;
                detalle.PRODUCTO = (PRODUCTO) (from p in entidades.PRODUCTO where p.Codigo == item.Codigo select p).Single();
                fact.DETALLE_FACTURA.Add(detalle);
            }
            entidades.FACTURA.Add(fact);
            entidades.SaveChanges();


        }

        public void selectAFactura(TO_Factura toFactura)
        {
            var factura = from r in entidades.FACTURA where r.Codigo == toFactura.Codigo select r;
            if (factura.Count() > 0)
            {
                toFactura.Cedula_Cliente = factura.First().Cedula_Cliente;
                toFactura.Fecha = factura.First().Fecha;

                var detallesCompra = from r in entidades.DETALLE_FACTURA where r.Codigo_Factura == toFactura.Codigo select r;
                if (detallesCompra.Count() > 0)
                {
                    foreach (DETALLE_FACTURA detalleFactura in detallesCompra)
                    {
                        TO_Producto toProducto = new TO_Producto();
                        toProducto.Cantidad_En_Factura = Convert.ToInt16(detalleFactura.Cantidad);

                        var daoProductos = from r in entidades.PRODUCTO where r.Codigo == detalleFactura.Codigo_Producto select r;
                        if (daoProductos.Count() > 0)
                        {
                            toProducto.Codigo = daoProductos.First().Codigo;
                            toProducto.Descripcion = daoProductos.First().Descripcion;
                            toProducto.Precio = Convert.ToInt16(daoProductos.First().Precio);
                            toProducto.Cantidad_Inventario = Convert.ToInt16(daoProductos.First().Cantidad_Inventario);
                            toFactura.lista_Productos.toProductList.Add(toProducto);
                        }
                    }
                }
            }
        }

    }
}
