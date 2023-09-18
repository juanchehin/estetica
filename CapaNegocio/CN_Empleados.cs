using System.Data;
// Agregados
using CapaDatos;

namespace CapaNegocio
{
    public class CN_Empleados
    {
        private CD_Empleados objetoCD = new CD_Empleados();

        //Método Insertar que llama al método Insertar de la clase DArticulo
        //de la CapaDatos
        public static string InsertarEmpleado(string Nombre, string Apellidos,string DNI,
                            string Direccion,string Telefono,string fechaNac,string Email,string Observaciones)
        {
            CD_Empleados Obj = new CD_Empleados();

            return Obj.InsertarEmpleado(Nombre, Apellidos, DNI,
                            Direccion, Telefono, fechaNac,Email, Observaciones);
        }

        public DataTable MostrarEmp()
        {

            DataTable tabla = new DataTable();
            tabla = objetoCD.Mostrar();
            return tabla;
        }
        public static string Eliminar(int IdEmpleado)
        {
            CD_Empleados Obj = new CD_Empleados();
            Obj.IdEmpleado = IdEmpleado;
            return Obj.Eliminar(Obj);
        }

        public DataTable MostrarEmpleado(int IdEmpleado)
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.MostrarEmpleado(IdEmpleado);
            return tabla;
        }

        public DataTable listar_trabajos_empleado(int IdEmpleado,string mes)
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.listar_trabajos_empleado(IdEmpleado,mes);
            return tabla;
        }


        public static string Editar(int IdEmpleado, string Nombre, string Apellidos, string DNI, string Direccion, string Telefono,string FechaNac, string Observaciones)
        {
            CD_Empleados Obj = new CD_Empleados();
            Obj.IdEmpleado = IdEmpleado;

            Obj.Nombre = Nombre;
            Obj.Apellidos = Apellidos;
            Obj.DNI = DNI;
            Obj.Direccion = Direccion;
            Obj.Telefono = Telefono;
            Obj.FechaNac = FechaNac;
            Obj.Observaciones = Observaciones;

            return Obj.Editar(Obj);
        }

        public DataTable BuscarEmpleado(string textobuscar)
        {
            CD_Empleados Obj = new CD_Empleados();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarEmpleado(Obj);
        }

        public DataTable ListarEmpleados(int pDesde)
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.ListarEmpleados(pDesde);
            return tabla;
        }

    }
}
