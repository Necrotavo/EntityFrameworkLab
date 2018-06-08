using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TO;

namespace DAO
{
    public class DAO_Clientes
    {
        LAB_EFEntities1 entidades = new LAB_EFEntities1();

        public void insertClient(TO_Cliente client)
        {
            CLIENTE entClient = new CLIENTE();
            entClient.Apellido = client.Apellido;
            entClient.Cedula = client.Cedula;
            entClient.Correo = client.Correo;
            entClient.Nombre = client.Nombre;
            entClient.Telefono = client.telefono;

            entidades.CLIENTEs.Add(entClient);
            entidades.SaveChanges();
        }

        public void selectClientes(TO_ClienteList list)
        {
            var clientes = entidades.CLIENTEs.Select(c => c);//NO SE SI EL QUERY ESTA BIEN
            TO_Cliente tempClient = new TO_Cliente();
            foreach (var item in clientes)
            {
                tempClient.Cedula = item.Cedula;
                tempClient.Nombre = item.Nombre;
                tempClient.Apellido = item.Apellido;
                tempClient.Correo = item.Correo;
                tempClient.telefono = item.Telefono;
                list.listaClientes.Add(tempClient);
            }
        }

        public void deleteClient(TO_Cliente client) {

        }

        public void modifyClient(TO_Cliente client)
        {
            var clientes = entidades.CLIENTEs.First(c => c.Cedula == client.Cedula);
            //Prueba de q subi algo
            clientes.Nombre = client.Nombre;
            clientes.Apellido = client.Apellido;
            clientes.Correo = client.Correo;
            clientes.Telefono = client.telefono;
            entidades.SaveChanges();
        }
    }
}
