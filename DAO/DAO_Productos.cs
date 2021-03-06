﻿using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TO;

namespace DAO
{
    public class DAO_Productos
    {
        LAB_EF entidades = new LAB_EF();

        public void selectProducts(TO_ProductList toProductoList)
        {
            try
            {
                var products = from r in entidades.PRODUCTO select r;
                foreach (var producto in products)
                {
                    TO_Producto toProduct = new TO_Producto();
                    toProduct.Codigo = producto.Codigo;
                    toProduct.Descripcion = producto.Descripcion;
                    toProduct.Precio = Convert.ToInt16(producto.Precio);
                    toProduct.Cantidad_Inventario = Convert.ToInt16(producto.Cantidad_Inventario);
                    toProductoList.toProductList.Add(toProduct);
                }
            }
            catch (DbUpdateException)
            {

                throw;
            }

        }

        public void selectAProduct(TO_Producto toProducto)
        {
            try
            {
                var product = from r in entidades.PRODUCTO where r.Codigo == toProducto.Codigo select r;
                if (product.Count() > 0)
                {
                    toProducto.Descripcion = product.First().Descripcion;
                    toProducto.Precio = Convert.ToInt16(product.First().Precio);
                    toProducto.Cantidad_Inventario = Convert.ToInt16(product.First().Cantidad_Inventario);
                }
            }
            catch (DbUpdateException)
            {

                throw;
            }

        }

        public void insertProduct(TO_Producto toProducto)
        {
            try
            {
                PRODUCTO producto = new PRODUCTO();
                producto.Codigo = toProducto.Codigo;
                producto.Descripcion = toProducto.Descripcion;
                producto.Precio = toProducto.Precio;
                producto.Cantidad_Inventario = toProducto.Cantidad_Inventario;
                entidades.PRODUCTO.Add(producto);
                entidades.SaveChanges();
            }
            catch (DbUpdateException)
            {

                throw;
            }

        }

        public void deleteProduct(TO_Producto toProducto)
        {
            try
            {
                var producto = from r in entidades.PRODUCTO where r.Codigo == toProducto.Codigo select r;
                if (producto.Count() > 0)
                {
                    entidades.PRODUCTO.Remove(producto.First());
                    entidades.SaveChanges();
                }
            }
            catch (DbUpdateException)
            {

                throw;
            }

        }

        public void modifyProduct(TO_Producto toProducto)
        {
            try
            {
                var producto = from r in entidades.PRODUCTO where r.Codigo == toProducto.Codigo select r;
                if (producto.Count() > 0)
                {
                    producto.First().Descripcion = toProducto.Descripcion;
                    producto.First().Precio = toProducto.Precio;
                    producto.First().Cantidad_Inventario = toProducto.Cantidad_Inventario;
                    entidades.SaveChanges();
                }
            }
            catch (DbUpdateException)
            {

                throw;
            }

        }
    }
}
