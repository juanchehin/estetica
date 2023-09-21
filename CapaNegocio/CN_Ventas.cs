using System.Data;
using CapaDatos;

namespace CapaNegocio
{
    public class CN_Ventas
    {
        private CD_Ventas objetoCD = new CD_Ventas();

        //Método Insertar que llama al método Insertar de la clase
        //de la CapaDatos
        public static string AltaVenta(int pIdCliente, int pIdEmpleado, string tipoPago,DataTable pListadoServicios,decimal pMontoTotal)
        {
            CD_Ventas Obj = new CD_Ventas();

            return Obj.AltaVenta(pIdCliente, pIdEmpleado,tipoPago, pListadoServicios, pMontoTotal);
            //return null;
        }

        public static string EditarVenta(string pIdTransaccion,int pIdCliente, int pIdEmpleado, string tipoPago, DataTable pListadoServicios, decimal pMontoTotal)
        {
            CD_Ventas Obj = new CD_Ventas();

            return Obj.EditarVenta(pIdTransaccion,pIdCliente, pIdEmpleado, tipoPago, pListadoServicios, pMontoTotal);
            //return null;
        }

        public static string depositar(int IdCliente, string monto, string tipo_pago)
        {
            CD_Ventas Obj = new CD_Ventas();

            return Obj.depositar(IdCliente, monto, tipo_pago);
            //return null;
        }

        public static string alta_egreso(string monto,int id_tipo_pago, string tipo, int id_empleado, string descripcion)
        {
            CD_Ventas Obj = new CD_Ventas();

            return Obj.alta_egreso(monto, id_tipo_pago, tipo, id_empleado, descripcion);
            //return null;
        }

        // Devuelve todas las compras habidas y por haber
        public DataTable MostrarVentas()
        {

            DataTable tabla = new DataTable();
            tabla = objetoCD.MostrarVentas();
            return tabla;
        }

        public DataTable DameTiposPago()
        {

            DataTable tabla = new DataTable();
            tabla = objetoCD.DameTiposPago();
            return tabla;
        }
        // Devuelve una compra (unica) dado un Id
        public DataTable MostrarVenta(int IdVenta)
        {

            DataTable tabla = new DataTable();
            tabla = objetoCD.MostrarVenta(IdVenta);
            return tabla;
        }
        public static string Eliminar(int IdVenta)
        {
            CD_Ventas Obj = new CD_Ventas();
            Obj.IdVenta = IdVenta;
            return Obj.Eliminar(Obj);
        }
        public DataSet cargar_datos(string IdTransaccion)
        {
            DataSet tabla = new DataSet();
            tabla = objetoCD.cargar_datos(IdTransaccion);
            return tabla;
        }

        public static string Editar(int IdVenta, string fecha, string Titular, int IdEmpleado, string cantidad)
        {
            CD_Ventas Obj = new CD_Ventas();
            Obj.IdVenta = IdVenta;

            //Obj.Producto = Producto;
            //Obj.IdEmpleado = IdEmpleado;
            //Obj.Cantidad = cantidad;

            return Obj.Editar(Obj);
        }
    }
}
