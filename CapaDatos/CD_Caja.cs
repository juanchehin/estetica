﻿using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace CapaDatos
{
    public class CD_Caja
    {
        private int _IdCaja;
        private string _SaldoInicial;
        private string _Serial;
        private string _TextoBuscar;


        public int IdCliente { get => _IdCaja; set => _IdCaja = value; }
        public string SaldoInicial { get => _SaldoInicial; set => _SaldoInicial = value; }
        public string Serial { get => _Serial; set => _Serial = value; }
        public string TextoBuscar { get => _TextoBuscar; set => _TextoBuscar = value; }

        //Constructores
        public CD_Caja()
        {

        }

        // ==================================================
        //  Permite devolver todos los clientes activos de la BD
        // ==================================================
        private CD_Conexion conexion = new CD_Conexion();

        MySqlDataReader leer;
        DataTable tabla = new DataTable();
        MySqlCommand comando = new MySqlCommand();

        public DataSet ListarTransacciones(int pDesde, string FechaInicio, string FechaFin)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.Parameters.Clear();// si no ponerlo al comienzo de esta funcion
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "bsp_listar_transacciones";

            MySqlParameter desde = new MySqlParameter();
            desde.ParameterName = "@pDesde";
            desde.MySqlDbType = MySqlDbType.Int32;
            desde.Value = pDesde;
            comando.Parameters.Add(desde);

            MySqlParameter pFechaInicio = new MySqlParameter();
            pFechaInicio.ParameterName = "@pFechaInicio";
            pFechaInicio.MySqlDbType = MySqlDbType.String;
            pFechaInicio.Value = FechaInicio;
            comando.Parameters.Add(pFechaInicio);

            MySqlParameter pFechaFin = new MySqlParameter();
            pFechaFin.ParameterName = "@pFechaFin";
            pFechaFin.MySqlDbType = MySqlDbType.String;
            pFechaFin.Value = FechaFin;
            comando.Parameters.Add(pFechaFin);

            MySqlDataAdapter da = new MySqlDataAdapter(comando);
            DataSet ds = new DataSet();
            da.Fill(ds);

            comando.Parameters.Clear();

            conexion.CerrarConexion();

            return ds;

        }
        public DataTable Mostrar()
        {

            comando.Connection = conexion.AbrirConexion();
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "bsp_dame_clientes";

            tabla.Clear();
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;

        }

        // devuelve solo 1 cliente de la BD
        public DataTable MostrarCliente(int IdCliente)
        {
            Console.WriteLine("IdCliente en capa datos es : " + IdCliente);
            comando.Connection = conexion.AbrirConexion();
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "bsp_dame_cliente";

            MySqlParameter pIdCliente = new MySqlParameter();
            pIdCliente.ParameterName = "@pIdCliente";
            pIdCliente.MySqlDbType = MySqlDbType.Int32;
            pIdCliente.Value = IdCliente;
            comando.Parameters.Add(pIdCliente);

            tabla.Clear();
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            comando.Parameters.Clear();
            conexion.CerrarConexion();

            return tabla;

        }


        // Metodo ELIMINAR Empleado (da de baja)
        public string Eliminar(int IdTransaccion)
        {
            string rpta = "";
            // SqlConnection SqlCon = new SqlConnection();
            try
            {

                comando.Connection = conexion.AbrirConexion();
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "bsp_baja_transaccion";

                MySqlParameter pIdTransaccion = new MySqlParameter();
                pIdTransaccion.ParameterName = "@pIdTransaccion";
                pIdTransaccion.MySqlDbType = MySqlDbType.Int32;
                // pIdEmpleado.Size = 60;
                pIdTransaccion.Value = IdTransaccion;
                comando.Parameters.Add(pIdTransaccion);

                //Ejecutamos nuestro comando

                //Ejecutamos nuestro comando
                rpta = comando.ExecuteScalar().ToString();

                // rpta = comando.ExecuteNonQuery() == 1 ? "Ok" : "NO se Elimino el Registro";


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
            return rpta;
        }

        public DataTable BuscarCliente(CD_Clientes Cliente)
        {
#pragma warning disable CS0168 // La variable está declarada pero nunca se usa
            try
            {
                comando.Connection = conexion.AbrirConexion();
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "bsp_buscar_cliente";

                MySqlParameter pTextoBuscar = new MySqlParameter();
                pTextoBuscar.ParameterName = "@pTextoBuscar";
                pTextoBuscar.MySqlDbType = MySqlDbType.VarChar;
                pTextoBuscar.Size = 30;
                pTextoBuscar.Value = Cliente.TextoBuscar;
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

        public string dameEstadoCaja()
        {
            string rpta = "";
            // SqlConnection SqlCon = new SqlConnection();
            try
            {
                comando.Connection = conexion.AbrirConexion();
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "bsp_dame_estado_caja";

                //Ejecutamos nuestro comando
                rpta = comando.ExecuteScalar().ToString();
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
            return rpta;
        }

        public string abrirCaja(int IdUsuario,decimal montoInicial)
        {
            string rpta = "";
            comando.Parameters.Clear();// si no ponerlo al comienzo de esta funcion
            try
            {

                comando.Connection = conexion.AbrirConexion();
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "bsp_apertura_caja";

                MySqlParameter pIdUsuario = new MySqlParameter();
                pIdUsuario.ParameterName = "@pIdUsuario";
                pIdUsuario.MySqlDbType = MySqlDbType.Int32;
                pIdUsuario.Value = IdUsuario;
                comando.Parameters.Add(pIdUsuario);

                MySqlParameter pMontoInicial = new MySqlParameter();
                pMontoInicial.ParameterName = "@pMontoInicial";
                pMontoInicial.MySqlDbType = MySqlDbType.Decimal;
                pMontoInicial.Value = montoInicial;
                comando.Parameters.Add(pMontoInicial);

                //Ejecutamos nuestro comando
                rpta = comando.ExecuteScalar().ToString();

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

        public string cerrarCaja(int IdUsuario)
        {
            string rpta = "";
            comando.Parameters.Clear();// si no ponerlo al comienzo de esta funcion
            try
            {

                comando.Connection = conexion.AbrirConexion();
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "bsp_cierre_caja";

                MySqlParameter pIdUsuario = new MySqlParameter();
                pIdUsuario.ParameterName = "@pIdUsuario";
                pIdUsuario.MySqlDbType = MySqlDbType.Int32;
                pIdUsuario.Value = IdUsuario;
                comando.Parameters.Add(pIdUsuario);

                //Ejecutamos nuestro comando
                rpta = comando.ExecuteScalar().ToString();

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

    }
}
