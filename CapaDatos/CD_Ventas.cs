using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace CapaDatos
{
    public class CD_Ventas
    {
        private int _IdVenta;
        private string _Producto;
        private int _IdEmpleado;
        private string _Cantidad;

        public int IdVenta { get => _IdVenta; set => _IdVenta = value; }
        public int IdEmpleado { get => _IdEmpleado; set => _IdEmpleado = value; }
        public string Cantidad { get => _Cantidad; set => _Cantidad = value; }
        public string Producto { get => _Producto; set => _Producto = value; }

        //Constructores
        public CD_Ventas()
        {

        }
        // ==================================================
        //  Permite devolver todos las compras de la BD ordenada por fecha
        // ==================================================
        private CD_Conexion conexion = new CD_Conexion();

        MySqlDataReader leer;
        DataTable tabla = new DataTable();
        MySqlCommand comando = new MySqlCommand();


        public DataTable DameTiposPago()
        {

            comando.Connection = conexion.AbrirConexion();
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "bsp_dame_tipos_pago";

            tabla.Clear();
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;

        }
        public DataTable MostrarVentas()
        {

            comando.Connection = conexion.AbrirConexion();
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "bsp_dame_ventas";

            tabla.Clear();
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;

        }

        // Devuelve un solo compra dado un ID
        public DataTable MostrarVenta(int IdVenta)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "bsp_dame_venta";

            MySqlParameter pIdVenta = new MySqlParameter();
            pIdVenta.ParameterName = "@pIdVenta";
            pIdVenta.MySqlDbType = MySqlDbType.Int32;
            // pIdProducto.Size = 60;
            pIdVenta.Value = IdVenta;
            comando.Parameters.Add(pIdVenta);

            leer = comando.ExecuteReader();
            tabla.Load(leer);
            comando.Parameters.Clear();
            conexion.CerrarConexion();

            return tabla;

        }

        //Métodos
        //Insertar
        public string AltaVenta(int pIdCliente, int pIdEmpleado, string pTipoPago, DataTable pListadoServicios,decimal pMontoTotal)
        {
            int idVenta;
            string rpta = "";
            try
            {
                comando.Connection = conexion.AbrirConexion();
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "bsp_alta_venta";


                MySqlParameter IdCliente = new MySqlParameter();
                IdCliente.ParameterName = "@pIdCliente";
                IdCliente.MySqlDbType = MySqlDbType.Int32;
                IdCliente.Value = pIdCliente;
                comando.Parameters.Add(IdCliente);

                MySqlParameter IdEmpleado = new MySqlParameter();
                IdEmpleado.ParameterName = "@pIdEmpleado";
                IdEmpleado.MySqlDbType = MySqlDbType.Int32;
                IdEmpleado.Value = pIdEmpleado;
                comando.Parameters.Add(IdEmpleado);

                MySqlParameter TipoPago = new MySqlParameter();
                TipoPago.ParameterName = "@pTipoPago";
                TipoPago.MySqlDbType = MySqlDbType.VarChar;
                TipoPago.Value = pTipoPago;
                comando.Parameters.Add(TipoPago);

                MySqlParameter MontoTotal = new MySqlParameter();
                MontoTotal.ParameterName = "@pMontoTotal";
                MontoTotal.MySqlDbType = MySqlDbType.Decimal;
                MontoTotal.Value = pMontoTotal;
                comando.Parameters.Add(MontoTotal);

                MySqlParameter Descripcion = new MySqlParameter();
                Descripcion.ParameterName = "@pDescripcion";
                Descripcion.MySqlDbType = MySqlDbType.VarChar;
                Descripcion.Value = "Venta";
                comando.Parameters.Add(Descripcion);

                idVenta = Convert.ToInt32(comando.ExecuteScalar());
                comando.Parameters.Clear();


               
            }
            catch(Exception ex)
            {
                rpta = ex.Message;
                conexion.CerrarConexion();
                return rpta;
            }

            try
            {
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "bsp_alta_linea_venta";

                for (int curRow = 0; curRow < pListadoServicios.Rows.Count; curRow++)
                {
                    MySqlParameter pIdVenta = new MySqlParameter();
                    pIdVenta.ParameterName = "@pIdVenta";
                    pIdVenta.MySqlDbType = MySqlDbType.Int32;
                    pIdVenta.Value = idVenta;
                    comando.Parameters.Add(pIdVenta);

                    MySqlParameter pIdServicio = new MySqlParameter();
                    pIdServicio.ParameterName = "@pIdServicio";
                    pIdServicio.MySqlDbType = MySqlDbType.Int32;
                    pIdServicio.Value = pListadoServicios.Rows[curRow][0];
                    comando.Parameters.Add(pIdServicio);

                    MySqlParameter pCantidad = new MySqlParameter();
                    pCantidad.ParameterName = "@pCantidad";
                    pCantidad.MySqlDbType = MySqlDbType.Int32;  // Ver por que esta definido como string
                    pCantidad.Value = pListadoServicios.Rows[curRow][1];
                    comando.Parameters.Add(pCantidad);

                    rpta = (string)comando.ExecuteScalar();//  == "Ok";//  : "NO se Ingreso el Registro";
                    comando.Parameters.Clear();

                }
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

        // Metodo ELIMINAR venta
        public string Eliminar(CD_Ventas Venta)
        {
            string rpta = "";
            try
            {
                comando.Connection = conexion.AbrirConexion();
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "bsp_eliminar_venta";

                MySqlParameter pIdVenta = new MySqlParameter();
                pIdVenta.ParameterName = "@pIdVenta";
                pIdVenta.MySqlDbType = MySqlDbType.Int32;
                pIdVenta.Value = Venta.IdVenta;
                comando.Parameters.Add(pIdVenta);

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

        public string Editar(CD_Ventas Venta)
        {
            string rpta = "";
            comando.Parameters.Clear();// si no ponerlo al comienzo de esta funcion
            try
            {
                comando.Connection = conexion.AbrirConexion();
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "bsp_editar_venta";

                MySqlParameter pIdVenta = new MySqlParameter();
                pIdVenta.ParameterName = "@pIdVenta";
                pIdVenta.MySqlDbType = MySqlDbType.Int32;
                pIdVenta.Value = Venta.IdVenta;
                comando.Parameters.Add(pIdVenta);

                MySqlParameter pProducto = new MySqlParameter();
                pProducto.ParameterName = "@pProducto";
                pProducto.MySqlDbType = MySqlDbType.VarChar;
                pProducto.Size = 60;
                pProducto.Value = Venta.Producto;
                comando.Parameters.Add(pProducto);

                MySqlParameter pIdEmpleado = new MySqlParameter();
                pIdEmpleado.ParameterName = "@pIdEmpleado";
                pIdEmpleado.MySqlDbType = MySqlDbType.Int32;
                pIdEmpleado.Value = Venta.IdEmpleado;
                comando.Parameters.Add(pIdEmpleado);

                MySqlParameter pCantidad = new MySqlParameter();
                pCantidad.ParameterName = "@pCantidad";
                pCantidad.MySqlDbType = MySqlDbType.Int32;
                pCantidad.Value = Venta.Cantidad;
                comando.Parameters.Add(pCantidad);


                //Ejecutamos nuestro comando

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
    }
}
