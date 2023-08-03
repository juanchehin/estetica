using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.IO;

namespace CapaDatos
{
    public class CD_Configuraciones
    {

        //Constructores
        public CD_Configuraciones()
        {

        }

        private CD_Conexion conexion = new CD_Conexion();

        MySqlDataReader leer;
        DataTable tabla = new DataTable();
        MySqlCommand comando = new MySqlCommand();

        // ==================================================
        //  Backup
        // ==================================================
        public string Backup(string file)
        {
            string rpta = "";
            try
            {
                using (MySqlConnection conn = new MySqlConnection(conexion.dame_cadena()))
                {
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        using (MySqlBackup mb = new MySqlBackup(cmd))
                        {
                            cmd.Connection = conn;
                            conn.Open();
                            mb.ExportToFile(file);
                            conn.Close();
                        }
                    }
                }
                rpta = "Ok";
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
        // ==================================================
        //  Restaurar BD
        // ==================================================
        public string Restore(string ruta)
        {
            string rpta = "";
            try
            {
                using (MySqlConnection conn = new MySqlConnection(conexion.dame_cadena()))
                {
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        using (MySqlBackup mb = new MySqlBackup(cmd))
                        {
                            cmd.Connection = conn;
                            conn.Open();
                            mb.ImportFromFile(ruta);
                            conn.Close();
                        }
                    }
                }
                rpta = "Ok";
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

        // ==================================================
        //  
        // ==================================================

        public string ejecutarScript()
        {
            string rpta = "";
            try
            {
                MySqlCommand comando = new MySqlCommand();
                comando.Connection = conexion.AbrirConexion();
                comando.CommandText = File.ReadAllText("script-04-10-22.sql");
                comando.ExecuteNonQuery();
                rpta = "Ok";
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

        public string dameEmpresa()
        {
            string rpta = "";
            MySqlCommand comando = new MySqlCommand();

            comando.Connection = conexion.AbrirConexion();
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "bsp_dame_empresa";

            rpta = comando.ExecuteScalar().ToString();

            comando.Parameters.Clear();
            conexion.CerrarConexion();
            return rpta;
        }

        public Boolean testConexion()
        {
#pragma warning disable CS0168 // La variable está declarada pero nunca se usa
            try
            {
                string rpta = "";
                MySqlCommand comando = new MySqlCommand();

                comando.Connection = conexion.AbrirConexion();
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "bsp_test_conexion";

                rpta = comando.ExecuteScalar().ToString();

                comando.Parameters.Clear();
                conexion.CerrarConexion();

                if (rpta == "OK")
                    return true;
                else
                    return false;
            }
            catch(Exception e)
            {
                return false;
            }
#pragma warning restore CS0168 // La variable está declarada pero nunca se usa
           
        }

        public string dameDireccion()
        {
            string rpta = "";
            MySqlCommand comando = new MySqlCommand();

            comando.Connection = conexion.AbrirConexion();
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "bsp_dame_direccion";

            rpta = comando.ExecuteScalar().ToString();

            comando.Parameters.Clear();
            conexion.CerrarConexion();
            return rpta;
        }

        public DataTable dameDatosEmpresa()
        {

            comando.Connection = conexion.AbrirConexion();
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "bsp_dame_datos_empresa";

            tabla.Clear();
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;

        }
        //Métodos
        //Insertar
        public string InsertarDatosEmpresa(string NombreEmpresa, string rutaImagen, string Domicilio, string Telefono, string CUIT, string IngBrutos)
        {
            string rpta = "";
            comando.Parameters.Clear();// si no ponerlo al comienzo de esta funcion
            try
            {
                comando.Connection = conexion.AbrirConexion();
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "bsp_insertar_datos_empresa";

                MySqlParameter pEmpresa = new MySqlParameter();
                pEmpresa.ParameterName = "@pNombreEmpresa";
                pEmpresa.MySqlDbType = MySqlDbType.VarChar;
                pEmpresa.Size = 60;
                pEmpresa.Value = NombreEmpresa;
                comando.Parameters.Add(pEmpresa);

                MySqlParameter pImagen = new MySqlParameter();
                pImagen.ParameterName = "@pImagen";
                pImagen.MySqlDbType = MySqlDbType.VarChar;
                pImagen.Size = 255;
                pImagen.Value = rutaImagen;
                comando.Parameters.Add(pImagen);

                MySqlParameter pDomicilio = new MySqlParameter();
                pDomicilio.ParameterName = "@pDomicilio";
                pDomicilio.MySqlDbType = MySqlDbType.VarChar;
                pDomicilio.Size = 60;
                pDomicilio.Value = Domicilio;
                comando.Parameters.Add(pDomicilio);

                MySqlParameter pTelefono = new MySqlParameter();
                pTelefono.ParameterName = "@pTelefono";
                pTelefono.MySqlDbType = MySqlDbType.VarChar;
                pTelefono.Size = 45;
                pTelefono.Value = Telefono;
                comando.Parameters.Add(pTelefono);

                MySqlParameter pCUIT = new MySqlParameter();
                pCUIT.ParameterName = "@pCUIT";
                pCUIT.MySqlDbType = MySqlDbType.VarChar;
                pCUIT.Size = 45;
                pCUIT.Value = CUIT;
                comando.Parameters.Add(pCUIT);

                MySqlParameter pIngBrutos = new MySqlParameter();
                pIngBrutos.ParameterName = "@pIngBrutos";
                pIngBrutos.MySqlDbType = MySqlDbType.VarChar;
                pIngBrutos.Size = 45;
                pIngBrutos.Value = IngBrutos;
                comando.Parameters.Add(pIngBrutos);

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
