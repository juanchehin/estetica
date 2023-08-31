using CapaDatos;
using System.Data;


namespace CapaNegocio
{
    public class CN_Productos
    {
        private CD_Productos objetoCD = new CD_Productos();

        //Método Insertar que llama al método Insertar de la clase DArticulo
        //de la CapaDatos
        public static string Insertar(string nombre, string Codigo, string PrecioCompra, string PrecioVenta, string Descripcion, string Stock)
        {
            CD_Productos Obj = new CD_Productos();
            Obj.Producto = nombre;
            Obj.Descripcion = Descripcion;
            Obj.Codigo = Codigo;
            Obj.PrecioCompra = PrecioCompra;
            Obj.PrecioVenta = PrecioVenta;
            Obj.Stock = Stock;

            return Obj.Insertar(Obj);
        }

        public DataSet ListarProductos(int pDesde)
        {

            DataSet tabla = new DataSet();
            tabla = objetoCD.ListarProductos(pDesde);
            return tabla;
        }

        public DataTable ListarProductosTable(int pDesde)
        {

            DataTable tabla = new DataTable();
            tabla = objetoCD.ListarProductosTable(pDesde);
            return tabla;
        }
        // Devuelve solo un producto
        public DataTable MostrarProducto(int IdProducto)
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.MostrarProducto(IdProducto);
            return tabla;
        }
        public static string Eliminar(int IdProducto)
        {
            CD_Productos Obj = new CD_Productos();
            Obj.IdProducto = IdProducto;
            return Obj.Eliminar(Obj);
        }

        public static string Editar(int IdProducto, string Producto, string Codigo, string PrecioCompra, string PrecioVenta, string Descripcion, string Stock)
        {
            CD_Productos Obj = new CD_Productos();
            Obj.IdProducto = IdProducto;
            Obj.Producto = Producto;
            Obj.Codigo = Codigo;
            Obj.PrecioCompra = PrecioCompra;
            Obj.PrecioVenta = PrecioVenta;
            Obj.Descripcion = Descripcion;
            Obj.Stock = Stock;

            return Obj.Editar(Obj);
        }

        public DataTable BuscarProducto(string textobuscar)
        {
            CD_Productos Obj = new CD_Productos();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarProducto(Obj);
        }

        public DataTable BuscarProductoPorCodigo(string codigo)
        {
            CD_Productos Obj = new CD_Productos();
            Obj.Codigo = codigo;
            return Obj.BuscarProductoPorCodigo(Obj);
        }


    }
}
