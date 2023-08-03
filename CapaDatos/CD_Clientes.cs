using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace CapaDatos
{
    public class CD_Clientes
    {
        private int _IdCliente;
        private string _Nombres;
        private string _Apellidos;
        private string _DNI;
        private string _EstadoEmp;
        private string _Direccion;
        private string _Telefono;
        private string _FechaNac;

        private string _TextoBuscar;


        public int IdCliente { get => _IdCliente; set => _IdCliente = value; }
        public string Nombres { get => _Nombres; set => _Nombres = value; }
        public string Apellidos { get => _Apellidos; set => _Apellidos = value; }
        public string DNI { get => _DNI; set => _DNI = value; }
        public string EstadoEmp { get => _EstadoEmp; set => _EstadoEmp = value; }
        public string Direccion { get => _Direccion; set => _Direccion = value; }
        public string Telefono { get => _Telefono; set => _Telefono = value; }
        public string TextoBuscar { get => _TextoBuscar; set => _TextoBuscar = value; }
        public string FechaNac { get => _FechaNac; set => _FechaNac = value; }

        //Constructores
        public CD_Clientes()
        {

        }

        public CD_Clientes(int IdCliente, string Nombre, string Apellidos, string DNI, string EstadoEmp, string Direccion, string Telefono, string FechaNac)
        {
            this.IdCliente = IdCliente;
            this.Nombres = Nombres;
            this.Apellidos = Apellidos;
            this.Apellidos = Apellidos;
            this.DNI = DNI;
            this.EstadoEmp = EstadoEmp;
            this.Direccion = Direccion;
            this.Telefono = Telefono;
            this.FechaNac = FechaNac;
        }

        // ==================================================
        //  Permite devolver todos los clientes activos de la BD
        // ==================================================
        private CD_Conexion conexion = new CD_Conexion();

        MySqlDataReader leer;
        DataTable tabla = new DataTable();
        MySqlCommand comando = new MySqlCommand();


        public DataTable Mostrar(int desde)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "bsp_dame_clientes";

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

        // devuelve solo 1 cliente de la BD
        public DataTable MostrarCliente(int IdCliente)
        {
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

        public string Editar(CD_Clientes Cliente)
        {
            string rpta = "";
            comando.Parameters.Clear();// si no ponerlo al comienzo de esta funcion
            try
            {
                comando.Connection = conexion.AbrirConexion();
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "bsp_editar_cliente";

                MySqlParameter pIdCliente = new MySqlParameter();
                pIdCliente.ParameterName = "@pIdCliente";
                pIdCliente.MySqlDbType = MySqlDbType.Int32;
                // pIdCliente.Size = 60;
                pIdCliente.Value = Cliente.IdCliente;
                comando.Parameters.Add(pIdCliente);

                MySqlParameter pNombre = new MySqlParameter();
                pNombre.ParameterName = "@pNombre";
                pNombre.MySqlDbType = MySqlDbType.VarChar;
                pNombre.Size = 60;
                pNombre.Value = Cliente.Nombres;
                comando.Parameters.Add(pNombre);

                MySqlParameter pApellidos = new MySqlParameter();
                pApellidos.ParameterName = "@pApellidos";
                pApellidos.MySqlDbType = MySqlDbType.VarChar;
                pApellidos.Size = 60;
                pApellidos.Value = Cliente.Apellidos;
                comando.Parameters.Add(pApellidos);

                MySqlParameter pDNI = new MySqlParameter();
                pDNI.ParameterName = "@pDNI";
                pDNI.MySqlDbType = MySqlDbType.VarChar;
                pDNI.Size = 45;
                pDNI.Value = Cliente.DNI;
                comando.Parameters.Add(pDNI);

                MySqlParameter pDireccion = new MySqlParameter();
                pDireccion.ParameterName = "@pDireccion";
                pDireccion.MySqlDbType = MySqlDbType.VarChar;
                pDireccion.Size = 60;
                pDireccion.Value = Cliente.Direccion;
                comando.Parameters.Add(pDireccion);

                MySqlParameter pTelefono = new MySqlParameter();
                pTelefono.ParameterName = "@pTelefono";
                pTelefono.MySqlDbType = MySqlDbType.VarChar;
                pTelefono.Size = 15;
                pTelefono.Value = Cliente.Telefono;
                comando.Parameters.Add(pTelefono);

                MySqlParameter pFechaNac = new MySqlParameter();
                pFechaNac.ParameterName = "@pFechaNac";
                pFechaNac.MySqlDbType = MySqlDbType.VarChar;
                pFechaNac.Size = 60;
                pFechaNac.Value = Cliente.FechaNac;
                comando.Parameters.Add(pFechaNac);

                rpta = comando.ExecuteScalar().ToString() == "Ok" ? "OK" : "No se edito el Registro";



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
        //Métodos
        //Insertar
        public string Insertar(string Nombre, string Apellidos, string DNI,
                           string Direccion, string Telefono, string fechaNac,
                           string Email, string Observaciones)
        {
            string rpta = "";
            comando.Parameters.Clear();// si no ponerlo al comienzo de esta funcion
            try
            {

                comando.Connection = conexion.AbrirConexion();
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "bsp_alta_cliente";


                MySqlParameter pNombres = new MySqlParameter();
                pNombres.ParameterName = "@pNombres";
                pNombres.MySqlDbType = MySqlDbType.VarChar;
                pNombres.Size = 60;
                pNombres.Value = Nombre;
                comando.Parameters.Add(pNombres);

                MySqlParameter pApellidos = new MySqlParameter();
                pApellidos.ParameterName = "@pApellidos";
                pApellidos.MySqlDbType = MySqlDbType.VarChar;
                pApellidos.Size = 60;
                pApellidos.Value = Apellidos;
                comando.Parameters.Add(pApellidos);

                MySqlParameter pDNI = new MySqlParameter();
                pDNI.ParameterName = "@pDNI";
                pDNI.MySqlDbType = MySqlDbType.VarChar;
                pDNI.Size = 45;
                pDNI.Value = DNI;
                comando.Parameters.Add(pDNI);

                MySqlParameter pEmail = new MySqlParameter();
                pEmail.ParameterName = "@pEmail";
                pEmail.MySqlDbType = MySqlDbType.VarChar;
                pEmail.Size = 60;
                pEmail.Value = Email;
                comando.Parameters.Add(pEmail);

                MySqlParameter pDireccion = new MySqlParameter();
                pDireccion.ParameterName = "@pDireccion";
                pDireccion.MySqlDbType = MySqlDbType.VarChar;
                pDireccion.Size = 60;
                pDireccion.Value = Direccion;
                comando.Parameters.Add(pDireccion);

                MySqlParameter pFechaNac = new MySqlParameter();
                pFechaNac.ParameterName = "@pFechaNac";
                pFechaNac.MySqlDbType = MySqlDbType.VarChar;
                pFechaNac.Size = 60;
                pFechaNac.Value = fechaNac;
                comando.Parameters.Add(pFechaNac);

                MySqlParameter pTelefono = new MySqlParameter();
                pTelefono.ParameterName = "@pTelefono";
                pTelefono.MySqlDbType = MySqlDbType.VarChar;
                pTelefono.Size = 15;
                pTelefono.Value = Telefono;
                comando.Parameters.Add(pTelefono);

                MySqlParameter pObservaciones = new MySqlParameter();
                pObservaciones.ParameterName = "@pObservaciones";
                pObservaciones.MySqlDbType = MySqlDbType.VarChar;
                pObservaciones.Size = 255;
                pObservaciones.Value = Observaciones;
                comando.Parameters.Add(pObservaciones);

                // Console.WriteLine("rpta es : " + rpta);

                rpta = (string)comando.ExecuteScalar();

                if (rpta == "OK")
                {
                    rpta = "Ok";
                }
                else
                {
                    rpta = "NO se Ingreso el Registro";
                }
                // == "Ok" ? "OK" : "NO se Ingreso el Registro";

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

        // Metodo ELIMINAR Cliente (da de baja)
        public string Eliminar(CD_Clientes Cliente)
        {
            string rpta = "";
            try
            {

                comando.Connection = conexion.AbrirConexion();
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "bsp_eliminar_cliente";

                MySqlParameter pIdCliente = new MySqlParameter();
                pIdCliente.ParameterName = "@pIdCliente";
                pIdCliente.MySqlDbType = MySqlDbType.Int32;
                pIdCliente.Value = Cliente.IdCliente;
                comando.Parameters.Add(pIdCliente);

                //Ejecutamos nuestro comando
                rpta = comando.ExecuteNonQuery() == 1 ? "OK" : "NO se Elimino el Registro";


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

            }
            catch (Exception ex)
            {
                tabla = null;
            }
#pragma warning restore CS0168 // La variable está declarada pero nunca se usa
            return tabla;

        }
    }
}
