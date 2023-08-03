using CapaDatos;
using System.Data;


namespace CapaNegocio
{
    public class CN_Productos
    {
        private CD_Productos objetoCD = new CD_Productos();

        //Método Insertar que llama al método Insertar de la clase DArticulo
        //de la CapaDatos
        public static string Insertar(string nombre, string Codigo, string PrecioCompra, string PrecioVenta, string Descripcion, string Stock, string Categoria)
        {
            CD_Productos Obj = new CD_Productos();
            Obj.Producto = nombre;
            Obj.Descripcion = Descripcion;
            Obj.Codigo = Codigo;
            Obj.PrecioCompra = PrecioCompra;
            Obj.PrecioVenta = PrecioVenta;
            Obj.Stock = Stock;
            Obj.Categoria = Categoria;

            return Obj.Insertar(Obj);
        }

        public DataSet ListarProductos(int pDesde)
        {

            DataSet tabla = new DataSet();
            tabla = objetoCD.ListarProductos(pDesde);
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


        public static string Editar(int IdProducto, string Producto, string Codigo, string PrecioCompra, string PrecioVenta, string Descripcion, string Stock, string Categoria)
        {
            CD_Productos Obj = new CD_Productos();
            Obj.IdProducto = IdProducto;

            Obj.Producto = Producto;
            Obj.Codigo = Codigo;
            Obj.PrecioCompra = PrecioCompra;
            Obj.PrecioVenta = PrecioVenta;
            Obj.Descripcion = Descripcion;
            Obj.Stock = Stock;
            Obj.Categoria = Categoria;

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


        public static string ActualizacionPorcentual(decimal pPorcentaje, int desde, int hasta)
        {
            CD_Productos Obj = new CD_Productos();

            return Obj.ActualizacionPorcentual(pPorcentaje, desde, hasta);
        }

        public static string ActualizacionLineal(decimal pValor, int desde, int hasta)
        {
            CD_Productos Obj = new CD_Productos();

            return Obj.ActualizacionLineal(pValor, desde, hasta);
        }

        // =========================
        // Categorias
        // =======================

        public DataTable DameCategorias()
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.DameCategorias();
            return tabla;
        }

        public static string AltaCategoria(string Categoria)
        {
            CD_Productos Obj = new CD_Productos();

            return Obj.AltaCategoria(Categoria);
        }

        public static string DameCategoria(string Categoria)
        {
            CD_Productos Obj = new CD_Productos();

            return Obj.DameCategoria(Categoria);
        }

        public static string DameCategoriaPorId(int IdCategoria)
        {
            CD_Productos Obj = new CD_Productos();

            return Obj.DameCategoriaPorId(IdCategoria);
        }

        public static string EditarCategoria(int IdCategoria, string Categoria)
        {
            CD_Productos Obj = new CD_Productos();

            return Obj.EditarCategoria(IdCategoria, Categoria);
        }

        public DataTable BuscarCategoria(string textobuscar)
        {
            CD_Productos Obj = new CD_Productos();

            return Obj.BuscarCategoria(textobuscar);
        }
        public static string EliminarCategoria(int IdCategoria)
        {
            CD_Productos Obj = new CD_Productos();

            return Obj.EliminarCategoria(IdCategoria);
        }

    }
}
