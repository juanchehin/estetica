using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;

namespace CapaNegocio
{
    public class CN_Clientes
    {
        private CD_Clientes objetoCD = new CD_Clientes();

        //Método Insertar que llama al método Insertar de la clase DArticulo
        //de la CapaDatos
        public static string Insertar(string Nombre, string Apellidos, string DNI,
                             string Direccion, string Telefono, string fechaNac,
                             string Email,string Observaciones)
        {
            CD_Clientes Obj = new CD_Clientes();

            return Obj.Insertar(Nombre, Apellidos, DNI,
                            Direccion, Telefono, fechaNac,
                            Email,Observaciones);
        }

        public DataTable MostrarClientes(int pDesde)
        {

            DataTable tabla = new DataTable();
            tabla = objetoCD.Mostrar(pDesde);
            return tabla;
        }
        public static string Eliminar(int IdCliente)
        {
            CD_Clientes Obj = new CD_Clientes();
            Obj.IdCliente = IdCliente;
            return Obj.Eliminar(Obj);
        }

        // Devuelve solo un Cliente
        public DataTable MostrarCliente(int IdCliente)
        {

            DataTable tabla = new DataTable();
            tabla = objetoCD.MostrarCliente(IdCliente);
            return tabla;
        }

        public static string Editar(int IdCliente, string Nombre, string Apellidos, string DNI, string Direccion, string Telefono, string FechaNac)
        {
            CD_Clientes Obj = new CD_Clientes();
            Obj.IdCliente = IdCliente;

            Obj.Nombres = Nombre;
            Obj.Apellidos = Apellidos;
            Obj.DNI = DNI;
            Obj.Direccion = Direccion;
            Obj.Telefono = Telefono;
            // Obj.FechaNac = FechaNac;


            return Obj.Editar(Obj);
        }


        public DataTable BuscarCliente(string textobuscar)
        {
            Console.WriteLine("textobuscar en capa negocio es : " + textobuscar);
            CD_Clientes Obj = new CD_Clientes();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarCliente(Obj);
        }
    }
}
