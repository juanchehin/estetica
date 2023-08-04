using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Security.Cryptography;

namespace CapaDatos
{
    public class CD_Servicios
    {
        private int _IdServicio;
        private string _Servicio;
        private string _Precio;
        private string _Descripcion;
        private string _TextoBuscar;


        public int IdServicio { get => _IdServicio; set => _IdServicio = value; }
        public string Servicio { get => _Servicio; set => _Servicio = value; }
        public string Precio { get => _Precio; set => _Precio = value; }
        public string Descripcion { get => _Descripcion; set => _Descripcion = value; }
        public string TextoBuscar { get => _TextoBuscar; set => _TextoBuscar = value; }

        //Constructores
        public CD_Servicios()
        {

        }

        public CD_Servicios(int IdServicio, string Servicio, string Precio)
        {
            this.IdServicio = IdServicio;
            this.Servicio = Servicio;
            this.Precio = Precio;
        }


        private CD_Conexion conexion = new CD_Conexion();

        MySqlDataReader leer;
        DataTable tabla = new DataTable();
        MySqlCommand comando = new MySqlCommand();


        // ==================================================
        //  Permite devolver todos los servicios de la BD
        // ==================================================
        public DataTable Mostrar()
        {

            comando.Connection = conexion.AbrirConexion();
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "bsp_dame_servicios";


            tabla.Clear();
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            return tabla;

        }

        //Métodos
        //Insertar
        public string Insertar(CD_Servicios Servicio)
        {
            string rpta = "";
            try
            {
                comando.Connection = conexion.AbrirConexion();
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "bsp_alta_servicio";

                MySqlParameter pServicio = new MySqlParameter();
                pServicio.ParameterName = "@pServicio";
                pServicio.MySqlDbType = MySqlDbType.VarChar;
                pServicio.Size = 60;
                pServicio.Value = Servicio.Servicio;
                comando.Parameters.Add(pServicio);


                MySqlParameter pPrecio = new MySqlParameter();
                pPrecio.ParameterName = "@pPrecio";
                pPrecio.MySqlDbType = MySqlDbType.VarChar;
                pPrecio.Size = 60;
                pPrecio.Value = Servicio.Precio;
                comando.Parameters.Add(pPrecio);

                MySqlParameter pDescripcion = new MySqlParameter();
                pDescripcion.ParameterName = "@pDescripcion";
                pDescripcion.MySqlDbType = MySqlDbType.VarChar;
                pDescripcion.Size = 255;
                pDescripcion.Value = Servicio.Servicio;
                comando.Parameters.Add(pDescripcion);

                rpta = (string)comando.ExecuteScalar();

                if (rpta == "El Servicio es obligatorio.")
                {
                    rpta = "El Servicio es obligatorio.";
                    return rpta;
                }
                if (rpta == "El servicio ya existe")
                {
                    rpta = "El servicio ya existe";
                    return rpta;
                }
                rpta = "OK";
                comando.Parameters.Clear();
                return rpta;


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
        public string Eliminar(CD_Servicios Servicio)
        {
            string rpta = "";
            try
            {
                comando.Connection = conexion.AbrirConexion();
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "bsp_baja_servicio";

                MySqlParameter pIdServicio = new MySqlParameter();
                pIdServicio.ParameterName = "@pIdServicio";
                pIdServicio.MySqlDbType = MySqlDbType.Int32;
                // pIdEmpleado.Size = 60;
                pIdServicio.Value = Servicio.IdServicio;
                comando.Parameters.Add(pIdServicio);

                //Ejecutamos nuestro comando

                rpta = comando.ExecuteNonQuery() == 1 ? "OK" : "NO se Elimino el Servicio";

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

        public DataTable MostrarServicio(int IdServicio)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "bsp_dame_servicio";

            MySqlParameter pIdServicio = new MySqlParameter();
            pIdServicio.ParameterName = "@pIdServicio";
            pIdServicio.MySqlDbType = MySqlDbType.Int32;
            pIdServicio.Value = IdServicio;
            comando.Parameters.Add(pIdServicio);


            leer = comando.ExecuteReader();
            tabla.Load(leer);
            comando.Parameters.Clear();
            conexion.CerrarConexion();

            return tabla;

        }

        public string dame_precio_servicio(string servicio)
        {
            string rpta = "";
            comando.Parameters.Clear();

            comando.Connection = conexion.AbrirConexion();
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "bsp_dame_precio_servicio";

            MySqlParameter pServicio = new MySqlParameter();
            pServicio.ParameterName = "@pServicio";
            pServicio.MySqlDbType = MySqlDbType.VarChar;
            pServicio.Size = 60;
            pServicio.Value = servicio;
            comando.Parameters.Add(pServicio);


            rpta = (string)comando.ExecuteScalar();

            // rpta = "OK";
            return rpta;

        }

        public string Editar(CD_Servicios Servicio)
        {
            string rpta = "";
            comando.Parameters.Clear();// si no ponerlo al comienzo de esta funcion
            try
            {
                comando.Connection = conexion.AbrirConexion();
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "bsp_editar_servicio";

                MySqlParameter pIdServicio = new MySqlParameter();
                pIdServicio.ParameterName = "@pIdServicio";
                pIdServicio.MySqlDbType = MySqlDbType.Int32;
                // pIdEmpleado.Size = 60;
                pIdServicio.Value = Servicio.IdServicio;
                comando.Parameters.Add(pIdServicio);

                MySqlParameter pServicio = new MySqlParameter();
                pServicio.ParameterName = "@pServicio";
                pServicio.MySqlDbType = MySqlDbType.VarChar;
                pServicio.Size = 60;
                pServicio.Value = Servicio.Servicio;
                comando.Parameters.Add(pServicio);

                MySqlParameter pPrecio = new MySqlParameter();
                pPrecio.ParameterName = "@pPrecio";
                pPrecio.MySqlDbType = MySqlDbType.Decimal;
                // pPrecio.Size = 30;
                pPrecio.Value = Servicio.Precio;
                comando.Parameters.Add(pPrecio);

                MySqlParameter pDescripcion = new MySqlParameter();
                pDescripcion.ParameterName = "@pDescripcion";
                pDescripcion.MySqlDbType = MySqlDbType.VarChar;
                pDescripcion.Size = 60;
                pDescripcion.Value = Servicio.Descripcion;
                comando.Parameters.Add(pDescripcion);

                rpta = (string)comando.ExecuteScalar();


                if (rpta == "El servicio esta dado de baja")
                {
                    rpta = "El servicio esta dado de baja";
                    return rpta;
                }
                rpta = "OK";
                return rpta;


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

        public DataTable BuscarServicio(CD_Servicios Servicio)
        {
#pragma warning disable CS0168 // La variable está declarada pero nunca se usa
            try
            {
                comando.Connection = conexion.AbrirConexion();
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "bsp_buscar_servicio";

                MySqlParameter pTextoBuscar = new MySqlParameter();
                pTextoBuscar.ParameterName = "@pTextoBuscar";
                pTextoBuscar.MySqlDbType = MySqlDbType.VarChar;
                pTextoBuscar.Size = 30;
                pTextoBuscar.Value = Servicio.TextoBuscar;
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

        public DataTable ListarServicios(int desde)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "bsp_listar_servicios";

            MySqlParameter pDesde = new MySqlParameter();
            pDesde.ParameterName = "@pDesde";
            pDesde.MySqlDbType = MySqlDbType.Int32;
            pDesde.Size = 30;
            pDesde.Value = desde;
            comando.Parameters.Add(pDesde);

            MySqlDataAdapter da = new MySqlDataAdapter(comando);
            DataTable ds = new DataTable();
            da.Fill(ds);

            comando.Parameters.Clear();

            conexion.CerrarConexion();

            return ds;

        }
    }
}
