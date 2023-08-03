
using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace CapaDatos
{
    public class CD_Estadisticas
    {
        // ==================================================
        //  Permite devolver todos los clientes activos de la BD
        // ==================================================
        private CD_Conexion conexion = new CD_Conexion();

        MySqlDataReader leer;
        DataTable tabla = new DataTable();
        MySqlCommand comando = new MySqlCommand();



        public DataTable ventasVendedor(string FechaInicio, string FechaFin)
        {
#pragma warning disable CS0219 // La variable está asignada pero nunca se usa su valor
            string rpta = "";
#pragma warning restore CS0219 // La variable está asignada pero nunca se usa su valor
#pragma warning disable CS0168 // La variable está declarada pero nunca se usa
            try
            {

                    comando.Parameters.Clear();
                comando.Connection = conexion.AbrirConexion();
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "bsp_ventas_vendedor";

                MySqlParameter pFechaInicio = new MySqlParameter();
                pFechaInicio.ParameterName = "@pFechaInicio";
                pFechaInicio.MySqlDbType = MySqlDbType.VarChar;
                pFechaInicio.Size = 60;
                pFechaInicio.Value = FechaInicio;
                comando.Parameters.Add(pFechaInicio);

                MySqlParameter pFechaFin = new MySqlParameter();
                pFechaFin.ParameterName = "@pFechaFin";
                pFechaFin.MySqlDbType = MySqlDbType.VarChar;
                pFechaFin.Size = 60;
                pFechaFin.Value = FechaFin;
                comando.Parameters.Add(pFechaFin);

                leer = comando.ExecuteReader();
                tabla.Load(leer);
                comando.Parameters.Clear();
                conexion.CerrarConexion();
            }
            catch (Exception e)
            {
                tabla = null;
            }
#pragma warning restore CS0168 // La variable está declarada pero nunca se usa
            return tabla;
        }
        public DataTable dameProductosMasVendidos(string FechaInicio, string FechaFin)
        {
#pragma warning disable CS0219 // La variable está asignada pero nunca se usa su valor
            string rpta = "";
#pragma warning restore CS0219 // La variable está asignada pero nunca se usa su valor
#pragma warning disable CS0168 // La variable está declarada pero nunca se usa
            try
            {

                comando.Parameters.Clear();
                comando.Connection = conexion.AbrirConexion();
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "bsp_productos_mas_vendidos";

                MySqlParameter pFechaInicio = new MySqlParameter();
                pFechaInicio.ParameterName = "@pFechaInicio";
                pFechaInicio.MySqlDbType = MySqlDbType.VarChar;
                pFechaInicio.Size = 60;
                pFechaInicio.Value = FechaInicio;
                comando.Parameters.Add(pFechaInicio);

                MySqlParameter pFechaFin = new MySqlParameter();
                pFechaFin.ParameterName = "@pFechaFin";
                pFechaFin.MySqlDbType = MySqlDbType.VarChar;
                pFechaFin.Size = 60;
                pFechaFin.Value = FechaFin;
                comando.Parameters.Add(pFechaFin);

                leer = comando.ExecuteReader();
                tabla.Load(leer);
                comando.Parameters.Clear();
                conexion.CerrarConexion();
            }
            catch (Exception e)
            {
                tabla = null;
            }
#pragma warning restore CS0168 // La variable está declarada pero nunca se usa
            return tabla;
        }

       

        public DataTable dameArticulosComprados(string FechaInicio, string FechaFin)
        {
#pragma warning disable CS0219 // La variable está asignada pero nunca se usa su valor
            string rpta = "";
#pragma warning restore CS0219 // La variable está asignada pero nunca se usa su valor
#pragma warning disable CS0168 // La variable está declarada pero nunca se usa
            try
            {

                comando.Parameters.Clear();
                comando.Connection = conexion.AbrirConexion();
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "bsp_articulos_comprados";

                MySqlParameter pFechaInicio = new MySqlParameter();
                pFechaInicio.ParameterName = "@pFechaInicio";
                pFechaInicio.MySqlDbType = MySqlDbType.VarChar;
                pFechaInicio.Size = 60;
                pFechaInicio.Value = FechaInicio;
                comando.Parameters.Add(pFechaInicio);

                MySqlParameter pFechaFin = new MySqlParameter();
                pFechaFin.ParameterName = "@pFechaFin";
                pFechaFin.MySqlDbType = MySqlDbType.VarChar;
                pFechaFin.Size = 60;
                pFechaFin.Value = FechaFin;
                comando.Parameters.Add(pFechaFin);

                leer = comando.ExecuteReader();
                tabla.Load(leer);
                comando.Parameters.Clear();
                conexion.CerrarConexion();
            }
            catch (Exception e)
            {
                tabla = null;
            }
#pragma warning restore CS0168 // La variable está declarada pero nunca se usa
            return tabla;
        }

        public DataTable dameComprasProveedor()
        {
#pragma warning disable CS0219 // La variable está asignada pero nunca se usa su valor
            string rpta = "";
#pragma warning restore CS0219 // La variable está asignada pero nunca se usa su valor
#pragma warning disable CS0168 // La variable está declarada pero nunca se usa
            try
            {

                comando.Parameters.Clear();
                comando.Connection = conexion.AbrirConexion();
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "bsp_compras_proveedor";

                leer = comando.ExecuteReader();
                tabla.Load(leer);
                comando.Parameters.Clear();
                conexion.CerrarConexion();
            }
            catch (Exception e)
            {
                tabla = null;
            }
#pragma warning restore CS0168 // La variable está declarada pero nunca se usa
            return tabla;
        }
    }
}
