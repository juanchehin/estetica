using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public static string depositar(int IdCliente,string monto,string tipo_pago)
        {
            CD_Ventas Obj = new CD_Ventas();

            return Obj.depositar(IdCliente,monto, tipo_pago);
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


        public static string Editar(int IdVenta, string Producto, string Titular, int IdEmpleado, string cantidad)
        {
            CD_Ventas Obj = new CD_Ventas();
            Obj.IdVenta = IdVenta;

            Obj.Producto = Producto;
            Obj.IdEmpleado = IdEmpleado;
            Obj.Cantidad = cantidad;

            return Obj.Editar(Obj);
        }
    }
}
