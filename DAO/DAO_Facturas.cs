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

        public void selectFromClient(TO_FacturaList toFacturaList, DateTime dateOne, DateTime dateTwo, TO_Cliente tocliente) {
            //(c => DateTaime.Now)
            var facturas = from r in entidades.FACTURA
                           where ((r.Fecha >= dateOne && r.Fecha <= dateTwo) && r.Cedula_Cliente == tocliente.Cedula)
                           select r;

            if (facturas.Count() > 0)
            {
                foreach (FACTURA daoFactura in facturas) {
                    TO_Factura toFactura = new TO_Factura();
                    toFactura.Codigo = daoFactura.Codigo;
                    toFacturaList.toFacturaList.Add(toFactura);
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
                fact.DETALLE_FACTURA.Add(detalle);
            }

            entidades.SaveChanges();
            

        }

        public void selectFacturasConRango(TOReporte listFact)
        {
            
            var factura = from r in entidades.FACTURA where r.Cedula_Cliente == listFact.client.Cedula 
                          && r.Fecha >= listFact.desde 
                          && r.Fecha <= listFact.hasta select r;
            foreach (var item in factura)
            {
                TO_Factura facture = new TO_Factura();
                facture.Codigo = item.Codigo;
                facture.Fecha = item.Fecha;
                facture.Cedula_Cliente = item.Cedula_Cliente;
                facture.lista_Productos = new TO_ProductList();
                facture.lista_Productos.toProductList = new List<TO_Producto>();
                foreach (var cosa in item.DETALLE_FACTURA)
                {
                    var prod = from p in entidades.PRODUCTO where p.Codigo == cosa.Codigo_Producto select p;
                    foreach (var producto in prod)
                    {
                        TO_Producto pr = new TO_Producto();
                        pr.Codigo = producto.Codigo;
                        pr.Cantidad_En_Factura = Convert.ToInt16(cosa.Cantidad);
                        pr.Cantidad_Inventario = Convert.ToInt16(producto.Cantidad_Inventario);
                        pr.Descripcion = producto.Descripcion;
                        pr.Precio = Convert.ToInt16(producto.Precio);

                        facture.lista_Productos.toProductList.Add(pr);
                    }
                }

                listFact.listaFacturas.Add(facture);
            }
        }

        public void selectAFactura(TO_Factura toFactura) {
            var factura = from r in entidades.FACTURA where r.Codigo == toFactura.Codigo select r;
            if (factura.Count() > 0)
            {
                toFactura.Cedula_Cliente = factura.First().Cedula_Cliente;
                toFactura.Fecha = factura.First().Fecha;

                var detallesCompra = from r in entidades.DETALLE_FACTURA where r.Codigo_Factura == toFactura.Codigo select r;
                if (detallesCompra.Count() > 0)
                {
                    foreach (DETALLE_FACTURA detalleFactura in detallesCompra) {
                        TO_Producto toProducto = new TO_Producto();
                        toProducto.Cantidad_En_Factura = Convert.ToInt16(detalleFactura.Cantidad);

                        var daoProductos = from r in entidades.PRODUCTO where r.Codigo == detalleFactura.Codigo_Producto select r;
                        if (daoProductos.Count() > 0) {
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
