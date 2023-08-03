using CapaDatos;
using System.Data;


namespace CapaNegocio
{
    public class CN_Servicios
    {
        private CD_Servicios objetoCD = new CD_Servicios();

        //Método Insertar que llama al método Insertar de la clase DArticulo
        //de la CapaDatos
        public static string Insertar(string nombre,string Precio,string Descripcion)
        {
            CD_Servicios Obj = new CD_Servicios();
            Obj.Servicio = nombre;
            Obj.Precio = Precio;
            Obj.Descripcion = Descripcion;

            return Obj.Insertar(Obj);
        }

        public DataTable ListarServicios(int pDesde)
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.ListarServicios(pDesde);
            return tabla;
        }
        // Devuelve solo un producto
        public DataTable MostrarServicio(int IdServicio)
        {

            DataTable tabla = new DataTable();
            tabla = objetoCD.MostrarServicio(IdServicio);
            return tabla;
        }
        public static string Eliminar(int IdServicio)
        {
            CD_Servicios Obj = new CD_Servicios();
            Obj.IdServicio = IdServicio;
            return Obj.Eliminar(Obj);
        }


        public static string Editar(int IdServicio, string Servicio,string Precio, string Descripcion)
        {
            CD_Servicios Obj = new CD_Servicios();
            Obj.IdServicio = IdServicio;
            Obj.Servicio = Servicio;
            Obj.Precio = Precio;

            return Obj.Editar(Obj);
        }

        public DataTable BuscarServicio(string textobuscar)
        {
            CD_Servicios Obj = new CD_Servicios();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarServicio(Obj);
        }


    }
}
