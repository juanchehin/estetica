// Agregados
using MySql.Data.MySqlClient;
using System;
using System.Data;


namespace CapaDatos
{
    public class CD_Productos
    {
        private int _IdProducto;
        private string _Producto;
        private string _Codigo;
        private string _Descripcion;
        private string _Stock;
        private string _PrecioCompra;
        private string _PrecioVenta;
        private string _EstadoProd;
        private string _TextoBuscar;
        private string _Categoria;


        public int IdProducto { get => _IdProducto; set => _IdProducto = value; }
        public string Producto { get => _Producto; set => _Producto = value; }
        public string Descripcion { get => _Descripcion; set => _Descripcion = value; }
        public string Stock { get => _Stock; set => _Stock = value; }
        public string EstadoProd { get => _EstadoProd; set => _EstadoProd = value; }
        public string TextoBuscar { get => _TextoBuscar; set => _TextoBuscar = value; }
        public string Codigo { get => _Codigo; set => _Codigo = value; }
        public string PrecioCompra { get => _PrecioCompra; set => _PrecioCompra = value; }
        public string PrecioVenta { get => _PrecioVenta; set => _PrecioVenta = value; }
        public string Categoria { get => _Categoria; set => _Categoria = value; }

        //Constructores
        public CD_Productos()
        {

        }

        public CD_Productos(int IdProducto, string Producto, string Codigo, string Descripcion, string PrecioVenta, string PrecioCompra, string Stock, string EstadoProd, string textobuscar)
        {
            this.IdProducto = IdProducto;
            this.Producto = Producto;
            this.Codigo = Codigo;
            this.PrecioVenta = PrecioVenta;
            this.PrecioCompra = PrecioCompra;
            this.Descripcion = Descripcion;
            this.Stock = Stock;
            this.EstadoProd = EstadoProd;
            this.TextoBuscar = textobuscar;
            this.Categoria = Categoria;
        }

        // ==================================================
        //  Permite devolver todos los productos de la BD
        // ==================================================
        private CD_Conexion conexion = new CD_Conexion();

        MySqlDataReader leer;
        DataTable tabla = new DataTable();
        DataTable categorias = new DataTable();
        MySqlCommand comando = new MySqlCommand();
        public DataSet ListarProductos(int pDesde)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "bsp_dame_productos";

            MySqlParameter desde = new MySqlParameter();
            desde.ParameterName = "@pDesde";
            desde.MySqlDbType = MySqlDbType.Int32;
            desde.Value = pDesde;
            comando.Parameters.Add(desde);

            MySqlDataAdapter da = new MySqlDataAdapter(comando);
            DataSet ds = new DataSet();
            da.Fill(ds);

            comando.Parameters.Clear();

            conexion.CerrarConexion();

            return ds;

        }

        // Devuelve un solo producto dado un ID
        public DataTable MostrarProducto(int IdProducto)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "bsp_dame_producto";

            MySqlParameter pIdProducto = new MySqlParameter();
            pIdProducto.ParameterName = "@pIdProducto";
            pIdProducto.MySqlDbType = MySqlDbType.Int32;
            // pIdProducto.Size = 60;
            pIdProducto.Value = IdProducto;
            comando.Parameters.Add(pIdProducto);

            tabla.Clear();
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            comando.Parameters.Clear();
            conexion.CerrarConexion();
            
            return tabla;

        }


        //Métodos
        //Insertar
        public string Insertar(CD_Productos Producto)
        {
            string rpta = "";
            try
            {
                comando.Connection = conexion.AbrirConexion();
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "bsp_alta_producto";

                MySqlParameter pProducto = new MySqlParameter();
                pProducto.ParameterName = "@pProducto";
                pProducto.MySqlDbType = MySqlDbType.VarChar;
                pProducto.Size = 60;
                pProducto.Value = Producto.Producto;
                comando.Parameters.Add(pProducto);

                MySqlParameter pCategoria = new MySqlParameter();
                pCategoria.ParameterName = "@pCategoria";
                pCategoria.MySqlDbType = MySqlDbType.VarChar;
                pCategoria.Size = 60;
                pCategoria.Value = Producto.Categoria;
                comando.Parameters.Add(pCategoria);

                MySqlParameter pCodigo = new MySqlParameter();
                pCodigo.ParameterName = "@pCodigo";
                pCodigo.MySqlDbType = MySqlDbType.VarChar;
                pCodigo.Size = 30;
                pCodigo.Value = Producto.Codigo;
                comando.Parameters.Add(pCodigo);

                MySqlParameter pStock = new MySqlParameter();
                pStock.ParameterName = "@pStock";
                pStock.MySqlDbType = MySqlDbType.Int16;
                pStock.Size = 40;
                pStock.Value = Producto.Stock;
                comando.Parameters.Add(pStock);

                MySqlParameter pPrecioCompra = new MySqlParameter();
                pPrecioCompra.ParameterName = "@pPrecioCompra";
                pPrecioCompra.MySqlDbType = MySqlDbType.Decimal;
                pPrecioCompra.Value = Producto.PrecioCompra;
                comando.Parameters.Add(pPrecioCompra);

                MySqlParameter pPrecioVenta = new MySqlParameter();
                pPrecioVenta.ParameterName = "@pPrecioVenta";
                pPrecioVenta.MySqlDbType = MySqlDbType.Decimal;
                pPrecioVenta.Value = Producto.PrecioVenta;
                comando.Parameters.Add(pPrecioVenta);

                MySqlParameter pDescripcion = new MySqlParameter();
                pDescripcion.ParameterName = "@pDescripcion";
                pDescripcion.MySqlDbType = MySqlDbType.VarChar;
                pDescripcion.Size = 60;
                pDescripcion.Value = Producto.Descripcion;
                comando.Parameters.Add(pDescripcion);

                rpta = comando.ExecuteScalar().ToString() == "OK" ? "OK" : "No se edito el Registro";
                comando.Parameters.Clear();
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                conexion.CerrarConexion();
            }
            
            return rpta;

        }
        // Metodo ELIMINAR Empleado (da de baja)
        public string Eliminar(CD_Productos Producto)
        {
            string rpta = "";
            try
            {
                comando.Connection = conexion.AbrirConexion();
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "bsp_eliminar_producto";

                MySqlParameter pIdProducto = new MySqlParameter();
                pIdProducto.ParameterName = "@pIdProducto";
                pIdProducto.MySqlDbType = MySqlDbType.Int32;
                // pIdEmpleado.Size = 60;
                pIdProducto.Value = Producto.IdProducto;
                comando.Parameters.Add(pIdProducto);

                //Ejecutamos nuestro comando

                rpta = comando.ExecuteNonQuery() == 1 ? "OK" : "NO se Elimino el Registro";

            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                //if (conexion. == ConnectionState.Open) 
                conexion.CerrarConexion();
            }
            comando.Parameters.Clear();
            return rpta;
        }

        public string Editar(CD_Productos Producto)
        {
            string rpta = "";
            comando.Parameters.Clear();// si no ponerlo al comienzo de esta funcion
            try
            {
                comando.Connection = conexion.AbrirConexion();
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "bsp_editar_producto";

                MySqlParameter pIdProducto = new MySqlParameter();
                pIdProducto.ParameterName = "@pIdProducto";
                pIdProducto.MySqlDbType = MySqlDbType.Int32;
                // pIdEmpleado.Size = 60;
                pIdProducto.Value = Producto.IdProducto;
                comando.Parameters.Add(pIdProducto);

                MySqlParameter pCategoria = new MySqlParameter();
                pCategoria.ParameterName = "@pCategoria";
                pCategoria.MySqlDbType = MySqlDbType.VarChar;
                pCategoria.Size = 60;
                pCategoria.Value = Producto.Categoria;
                comando.Parameters.Add(pCategoria);

                MySqlParameter pProducto = new MySqlParameter();
                pProducto.ParameterName = "@pProducto";
                pProducto.MySqlDbType = MySqlDbType.VarChar;
                pProducto.Size = 60;
                pProducto.Value = Producto.Producto;
                comando.Parameters.Add(pProducto);

                MySqlParameter pCodigo = new MySqlParameter();
                pCodigo.ParameterName = "@pCodigo";
                pCodigo.MySqlDbType = MySqlDbType.VarChar;
                pCodigo.Size = 30;
                pCodigo.Value = Producto.Codigo;
                comando.Parameters.Add(pCodigo);

                MySqlParameter pPrecioCompra = new MySqlParameter();
                pPrecioCompra.ParameterName = "@pPrecioCompra";
                pPrecioCompra.MySqlDbType = MySqlDbType.Decimal;
                // pPrecioCompra.Size = 60;
                pPrecioCompra.Value = Producto.PrecioCompra;
                comando.Parameters.Add(pPrecioCompra);

                MySqlParameter pPrecioVenta = new MySqlParameter();
                pPrecioVenta.ParameterName = "@pPrecioVenta";
                pPrecioVenta.MySqlDbType = MySqlDbType.Decimal;
                // pIdEmpleado.Size = 60;
                pPrecioVenta.Value = Producto.PrecioVenta;
                comando.Parameters.Add(pPrecioVenta);

                MySqlParameter pStock = new MySqlParameter();
                pStock.ParameterName = "@pStock";
                pStock.MySqlDbType = MySqlDbType.Int32;
                // pIdEmpleado.Size = 60;
                pStock.Value = Producto.Stock;
                comando.Parameters.Add(pStock);

                MySqlParameter pDescripcion = new MySqlParameter();
                pDescripcion.ParameterName = "@pDescripcion";
                pDescripcion.MySqlDbType = MySqlDbType.VarChar;
                pDescripcion.Size = 60;
                pDescripcion.Value = Producto.Descripcion;
                comando.Parameters.Add(pDescripcion);

                rpta = comando.ExecuteScalar().ToString() == "Ok" ? "OK" : "No se edito el Registro";
            }
            catch (Exception ex)
            {
                
                rpta = ex.Message;
                Console.WriteLine("rpta es : " + rpta);
            }
            finally
            {
                //if (conexion. == ConnectionState.Open) 
                conexion.CerrarConexion();
            }
            comando.Parameters.Clear();
            return rpta;
        }

        public DataTable BuscarProductoPorCodigo(CD_Productos Producto)
        {
#pragma warning disable CS0168 // La variable está declarada pero nunca se usa
            try
            {
                comando.Connection = conexion.AbrirConexion();
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "bsp_dame_producto_codigo";

                MySqlParameter pCodigo = new MySqlParameter();
                pCodigo.ParameterName = "@pCodigo";
                pCodigo.MySqlDbType = MySqlDbType.VarChar;
                pCodigo.Size = 30;
                pCodigo.Value = Producto.Codigo;
                comando.Parameters.Add(pCodigo);

                leer = comando.ExecuteReader();
                tabla.Load(leer);
                comando.Parameters.Clear();
                conexion.CerrarConexion();

                // return tabla;
            }
            catch (Exception ex)
            {
                tabla = null;
            }
#pragma warning restore CS0168 // La variable está declarada pero nunca se usa
            return tabla;

        }

        public DataTable BuscarProducto(CD_Productos Producto)
        {
#pragma warning disable CS0168 // La variable está declarada pero nunca se usa
            try
            {
                comando.Connection = conexion.AbrirConexion();
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "bsp_buscar_producto";

                MySqlParameter pTextoBuscar = new MySqlParameter();
                pTextoBuscar.ParameterName = "@pTextoBuscar";
                pTextoBuscar.MySqlDbType = MySqlDbType.VarChar;
                pTextoBuscar.Size = 30;
                pTextoBuscar.Value = Producto.TextoBuscar;
                comando.Parameters.Add(pTextoBuscar);

                leer = comando.ExecuteReader();
                tabla.Load(leer);
                comando.Parameters.Clear();
                conexion.CerrarConexion();

                // return tabla;
            }
            catch (Exception ex)
            {
                tabla = null;
            }
#pragma warning restore CS0168 // La variable está declarada pero nunca se usa
            return tabla;

        }

        public string ActualizacionPorcentual(decimal porcentaje,int desde,int hasta)
        {
            string rpta = "";
            try
            {
                comando.Connection = conexion.AbrirConexion();
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "bsp_incremento_porcentual";

                MySqlParameter pPorcentaje = new MySqlParameter();
                pPorcentaje.ParameterName = "@pPorcentaje";
                pPorcentaje.MySqlDbType = MySqlDbType.Decimal;
                pPorcentaje.Value = porcentaje;
                comando.Parameters.Add(pPorcentaje);

                MySqlParameter pDesde = new MySqlParameter();
                pDesde.ParameterName = "@pDesde";
                pDesde.MySqlDbType = MySqlDbType.Decimal;
                pDesde.Value = desde;
                comando.Parameters.Add(pDesde);

                MySqlParameter pHasta = new MySqlParameter();
                pHasta.ParameterName = "@pHasta";
                pHasta.MySqlDbType = MySqlDbType.Decimal;
                pHasta.Value = hasta;
                comando.Parameters.Add(pHasta);

                rpta = comando.ExecuteScalar().ToString() == "OK" ? "OK" : "No se edito el Registro";

                comando.Parameters.Clear();

            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                conexion.CerrarConexion();
            }

            return rpta;

        }

        public string ActualizacionLineal(decimal valor, int desde, int hasta)
        {
            string rpta = "";
            try
            {

                comando.Connection = conexion.AbrirConexion();
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "bsp_incremento_lineal";

                MySqlParameter pValor = new MySqlParameter();
                pValor.ParameterName = "@pValor";
                pValor.MySqlDbType = MySqlDbType.Decimal;
                pValor.Value = valor;
                comando.Parameters.Add(pValor);

                MySqlParameter pDesde = new MySqlParameter();
                pDesde.ParameterName = "@pDesde";
                pDesde.MySqlDbType = MySqlDbType.Decimal;
                pDesde.Value = desde;
                comando.Parameters.Add(pDesde);

                MySqlParameter pHasta = new MySqlParameter();
                pHasta.ParameterName = "@pHasta";
                pHasta.MySqlDbType = MySqlDbType.Decimal;
                pHasta.Value = hasta;
                comando.Parameters.Add(pHasta);

                rpta = comando.ExecuteScalar().ToString() == "OK" ? "OK" : "No se edito el Registro";

                comando.Parameters.Clear();

            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                conexion.CerrarConexion();
            }

            return rpta;

        }

        // ========================
        // Categorias
        // =======================
        public string AltaCategoria(string Categoria)
        {
            string rpta = "";
            try
            {
                comando.Connection = conexion.AbrirConexion();
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "bsp_alta_categoria";

                MySqlParameter pCategoria = new MySqlParameter();
                pCategoria.ParameterName = "@pCategoria";
                pCategoria.MySqlDbType = MySqlDbType.VarChar;
                pCategoria.Size = 60;
                pCategoria.Value = Categoria;
                comando.Parameters.Add(pCategoria);

                rpta = comando.ExecuteScalar().ToString() == "OK" ? "OK" : "No se edito el Registro";
                comando.Parameters.Clear();
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                conexion.CerrarConexion();
            }

            return rpta;

        }

        public DataTable DameCategorias()
        {
            comando.Parameters.Clear();
            comando.Connection = conexion.AbrirConexion();
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "bsp_dame_categorias";

            categorias.Clear();
            leer = comando.ExecuteReader();
            categorias.Load(leer);
            comando.Parameters.Clear();
            conexion.CerrarConexion();

            return categorias;

        }
        public string DameCategoria(string categoria)
        {
            string rpta = "";
            try
            {

                comando.Connection = conexion.AbrirConexion();
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "bsp_dame_categoria";

                MySqlParameter pCategoria = new MySqlParameter();
                pCategoria.ParameterName = "@pCategoria";
                pCategoria.MySqlDbType = MySqlDbType.VarChar;
                pCategoria.Size = 60;
                pCategoria.Value = categoria;
                comando.Parameters.Add(pCategoria);

                rpta = comando.ExecuteScalar().ToString() == "OK" ? "OK" : "Categoria Inexistente";

                comando.Parameters.Clear();

            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                conexion.CerrarConexion();
            }
            return rpta;
        }

        public string DameCategoriaPorId(int pIdCategoria)
        {
            string rpta = "";
            try
            {

                comando.Connection = conexion.AbrirConexion();
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "bsp_dame_categoria_id";

                MySqlParameter IdCategoria = new MySqlParameter();
                IdCategoria.ParameterName = "@pIdCategoria";
                IdCategoria.MySqlDbType = MySqlDbType.Int32;
                IdCategoria.Value = pIdCategoria;
                comando.Parameters.Add(IdCategoria);

                rpta = comando.ExecuteScalar().ToString() == "Ok" ? "Ok" : "Categoria Inexistente";

                comando.Parameters.Clear();

            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                conexion.CerrarConexion();
            }

            return rpta;

        }

        public string EditarCategoria(int pIdCategoria,string pCategoria)
        {
            string rpta = "";
            comando.Parameters.Clear();
            try
            {
                comando.Connection = conexion.AbrirConexion();
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "bsp_editar_categoria";

                MySqlParameter IdCategoria = new MySqlParameter();
                IdCategoria.ParameterName = "@pIdCategoria";
                IdCategoria.MySqlDbType = MySqlDbType.Int32;
                IdCategoria.Value = pIdCategoria;
                comando.Parameters.Add(IdCategoria);

                MySqlParameter Categoria = new MySqlParameter();
                Categoria.ParameterName = "@pCategoria";
                Categoria.MySqlDbType = MySqlDbType.VarChar;
                Categoria.Size = 60;
                Categoria.Value = pCategoria;
                comando.Parameters.Add(pCategoria);

                rpta = comando.ExecuteScalar().ToString() == "Ok" ? "OK" : "No se edito el Registro";
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                conexion.CerrarConexion();
            }
            comando.Parameters.Clear();
            return rpta;
        }

        public DataTable BuscarCategoria(string pCategoria)
        {
#pragma warning disable CS0168 // La variable está declarada pero nunca se usa
            try
            {
                comando.Connection = conexion.AbrirConexion();
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "bsp_buscar_categoria";

                MySqlParameter pTextoBuscar = new MySqlParameter();
                pTextoBuscar.ParameterName = "@pTextoBuscar";
                pTextoBuscar.MySqlDbType = MySqlDbType.VarChar;
                pTextoBuscar.Size = 30;
                pTextoBuscar.Value = pCategoria;
                comando.Parameters.Add(pTextoBuscar);

                leer = comando.ExecuteReader();
                tabla.Load(leer);
                comando.Parameters.Clear();
                conexion.CerrarConexion();

                // return tabla;
            }
            catch (Exception ex)
            {
                tabla = null;
            }
#pragma warning restore CS0168 // La variable está declarada pero nunca se usa
            return tabla;

        }

        public string EliminarCategoria(int pIdCategoria)
        {
            string rpta = "";
            try
            {
                comando.Connection = conexion.AbrirConexion();
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "bsp_eliminar_categoria";

                MySqlParameter IdCategoria = new MySqlParameter();
                IdCategoria.ParameterName = "@pIdCategoria";
                IdCategoria.MySqlDbType = MySqlDbType.Int32;
                IdCategoria.Value = pIdCategoria;
                comando.Parameters.Add(IdCategoria);

                //Ejecutamos nuestro comando

                rpta = comando.ExecuteScalar().ToString() == "Ok" ? "Ok" : "No se elimino el Registro";

            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            { 
                conexion.CerrarConexion();
            }
            comando.Parameters.Clear();
            return rpta;
        }

    }
}
