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
        DataSet set_tabla = new DataSet();
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

        public DataSet cargar_datos(string id_transaccion)
        {

            comando.Connection = conexion.AbrirConexion();
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "bsp_dame_venta";

            MySqlParameter pIdVenta = new MySqlParameter();
            pIdVenta.ParameterName = "@pIdVenta";
            pIdVenta.MySqlDbType = MySqlDbType.VarChar;
            pIdVenta.Size = 60;
            pIdVenta.Value = id_transaccion;
            comando.Parameters.Add(pIdVenta);


            MySqlDataAdapter da = new MySqlDataAdapter(comando);
            DataSet ds = new DataSet();
            da.Fill(ds);

            comando.Parameters.Clear();
            conexion.CerrarConexion();
            return ds;

            //set_tabla.Clear();
            //leer = comando.ExecuteReader();
            //set_tabla.Load(leer);
            //conexion.CerrarConexion();
            //return set_tabla;

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

                    MySqlParameter pIdServicioProducto = new MySqlParameter();
                    pIdServicioProducto.ParameterName = "@pIdServicioProducto";
                    pIdServicioProducto.MySqlDbType = MySqlDbType.Int32;
                    pIdServicioProducto.Value = pListadoServicios.Rows[curRow][0];
                    comando.Parameters.Add(pIdServicioProducto);

                    if (pListadoServicios.Rows[curRow][4].ToString() == "Producto")
                    {
                        MySqlParameter Tipo = new MySqlParameter();
                        Tipo.ParameterName = "@pTipo";
                        Tipo.MySqlDbType = MySqlDbType.VarChar;
                        Tipo.Value = "P";
                        comando.Parameters.Add(Tipo);
                    }
                    else
                    {
                        MySqlParameter Tipo = new MySqlParameter();
                        Tipo.ParameterName = "@pTipo";
                        Tipo.MySqlDbType = MySqlDbType.VarChar;
                        Tipo.Value = "S";
                        comando.Parameters.Add(Tipo);
                    }

                    MySqlParameter pPrecio = new MySqlParameter();
                    pPrecio.ParameterName = "@pPrecio";
                    pPrecio.MySqlDbType = MySqlDbType.Decimal;
                    pPrecio.Value = pListadoServicios.Rows[curRow][2];
                    comando.Parameters.Add(pPrecio);

                    MySqlParameter pCantidad = new MySqlParameter();
                    pCantidad.ParameterName = "@pCantidad";
                    pCantidad.MySqlDbType = MySqlDbType.Int32;  // Ver por que esta definido como string
                    pCantidad.Value = pListadoServicios.Rows[curRow][3];
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


        public string EditarVenta(string pIdTransaccion,int pIdCliente, int pIdEmpleado, string pTipoPago, DataTable pListadoServicios, decimal pMontoTotal)
        {
            int idVenta;
            string rpta = "";
            try
            {
                comando.Connection = conexion.AbrirConexion();
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "bsp_editar_venta";


                MySqlParameter IdTransaccion = new MySqlParameter();
                IdTransaccion.ParameterName = "@pIdTransaccion";
                IdTransaccion.MySqlDbType = MySqlDbType.Int32;
                IdTransaccion.Value = pIdTransaccion;
                comando.Parameters.Add(IdTransaccion);

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

                rpta = comando.ExecuteScalar().ToString();
                comando.Parameters.Clear();

                if(rpta != "Ok")
                {
                    conexion.CerrarConexion();
                    return rpta;
                }
            }
            catch (Exception ex)
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
                    pIdVenta.Value = pIdTransaccion;
                    comando.Parameters.Add(pIdVenta);

                    MySqlParameter pIdServicioProducto = new MySqlParameter();
                    pIdServicioProducto.ParameterName = "@pIdServicioProducto";
                    pIdServicioProducto.MySqlDbType = MySqlDbType.Int32;
                    pIdServicioProducto.Value = pListadoServicios.Rows[curRow][0];
                    comando.Parameters.Add(pIdServicioProducto);

                    if (pListadoServicios.Rows[curRow][4].ToString() == "Producto")
                    {
                        MySqlParameter Tipo = new MySqlParameter();
                        Tipo.ParameterName = "@pTipo";
                        Tipo.MySqlDbType = MySqlDbType.VarChar;
                        Tipo.Value = "P";
                        comando.Parameters.Add(Tipo);
                    }
                    else
                    {
                        MySqlParameter Tipo = new MySqlParameter();
                        Tipo.ParameterName = "@pTipo";
                        Tipo.MySqlDbType = MySqlDbType.VarChar;
                        Tipo.Value = "S";
                        comando.Parameters.Add(Tipo);
                    }

                    MySqlParameter pPrecio = new MySqlParameter();
                    pPrecio.ParameterName = "@pPrecio";
                    pPrecio.MySqlDbType = MySqlDbType.Decimal;
                    pPrecio.Value = pListadoServicios.Rows[curRow][2];
                    comando.Parameters.Add(pPrecio);

                    MySqlParameter pCantidad = new MySqlParameter();
                    pCantidad.ParameterName = "@pCantidad";
                    pCantidad.MySqlDbType = MySqlDbType.Int32;  // Ver por que esta definido como string
                    pCantidad.Value = pListadoServicios.Rows[curRow][3];
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

        public string depositar(int pIdCliente,string pMonto,string pTipoPago)
        {
            int idVenta;
            string rpta = "";
            try
            {
                comando.Connection = conexion.AbrirConexion();
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "bsp_depositar";

                MySqlParameter IdCliente = new MySqlParameter();
                IdCliente.ParameterName = "@pIdCliente";
                IdCliente.MySqlDbType = MySqlDbType.Int32;
                IdCliente.Value = pIdCliente;
                comando.Parameters.Add(IdCliente);

                MySqlParameter TipoPago = new MySqlParameter();
                TipoPago.ParameterName = "@pTipoPago";
                TipoPago.MySqlDbType = MySqlDbType.VarChar;
                TipoPago.Value = pTipoPago;
                comando.Parameters.Add(TipoPago);

                MySqlParameter MontoTotal = new MySqlParameter();
                MontoTotal.ParameterName = "@pMonto";
                MontoTotal.MySqlDbType = MySqlDbType.Decimal;
                MontoTotal.Value = pMonto;
                comando.Parameters.Add(MontoTotal);

                idVenta = Convert.ToInt32(comando.ExecuteScalar());
                comando.Parameters.Clear();
                rpta = "Ok";
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
                conexion.CerrarConexion();
                return rpta;
            }

            return rpta;

        }

        public string alta_egreso(string pMonto, string pTipoPago, string pDescripcion)
        {
            string rpta = "";
            try
            {
                comando.Connection = conexion.AbrirConexion();
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "bsp_alta_egreso";

                MySqlParameter MontoTotal = new MySqlParameter();
                MontoTotal.ParameterName = "@pMonto";
                MontoTotal.MySqlDbType = MySqlDbType.Decimal;
                MontoTotal.Value = pMonto;
                comando.Parameters.Add(MontoTotal);

                MySqlParameter TipoPago = new MySqlParameter();
                TipoPago.ParameterName = "@pTipoPago";
                TipoPago.MySqlDbType = MySqlDbType.VarChar;
                TipoPago.Value = pTipoPago;
                comando.Parameters.Add(TipoPago);

                MySqlParameter descripcion = new MySqlParameter();
                descripcion.ParameterName = "@pDescripcion";
                descripcion.MySqlDbType = MySqlDbType.VarChar;
                descripcion.Value = pDescripcion;
                comando.Parameters.Add(descripcion);

                rpta = (string)comando.ExecuteScalar();//  == "Ok";//  : "NO se Ingreso el Registro";
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
