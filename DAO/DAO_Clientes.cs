using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using TO;

namespace DAO
{
    public class DAO_Clientes
    {
        LAB_EF entidades = new LAB_EF();

        public void insertClient(TO_Cliente client)
        {
            CLIENTE entClient = new CLIENTE();
            entClient.Apellido = client.Apellido;
            entClient.Cedula = client.Cedula;
            entClient.Correo = client.Correo;
            entClient.Nombre = client.Nombre;
            entClient.Telefono = client.Telefono;

            entidades.CLIENTE.Add(entClient);
            entidades.SaveChanges();
        }

        public void selectClientes(TO_ClienteList list)
        {
            //var clientes = entidades.CLIENTEs.Select(c => c);//NO SE SI EL QUERY ESTA BIEN
            var clientes = from r in entidades.CLIENTE select r;
            foreach (var item in clientes)
            {
                TO_Cliente tempClient = new TO_Cliente();
                tempClient.Cedula = item.Cedula;
                tempClient.Nombre = item.Nombre;
                tempClient.Apellido = item.Apellido;
                tempClient.Correo = item.Correo;
                tempClient.Telefono = item.Telefono;
                list.listaClientes.Add(tempClient);
            }
        }

        public void selectACliente(TO_Cliente client)
        {
            var cliente = from r in entidades.CLIENTE where r.Cedula == client.Cedula select r;
            if (cliente.Count() > 0)
            {
                client.Nombre = cliente.First().Nombre;
                client.Apellido = cliente.First().Apellido;
                client.Correo = cliente.First().Correo;
                client.Telefono = cliente.First().Telefono;
            }
        }

        public void deleteClient(TO_Cliente client)
        {
            try
            {
                var cliente = from r in entidades.CLIENTE where r.Cedula == client.Cedula select r;
                if (cliente.Count() > 0)
                {
                    entidades.CLIENTE.Remove(cliente.First());
                    entidades.SaveChanges();
                }
            }
            catch (DbUpdateException)
            {

                throw;
            }
        }

        public void modifyClient(TO_Cliente client)
        {
            var clientes = from r in entidades.CLIENTE where r.Cedula == client.Cedula select r;

            clientes.First().Nombre = client.Nombre;
            clientes.First().Apellido = client.Apellido;
            clientes.First().Correo = client.Correo;
            clientes.First().Telefono = client.Telefono;
            entidades.SaveChanges();
        }
    }
}
