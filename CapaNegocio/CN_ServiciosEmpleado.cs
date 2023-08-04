using System;
using System.Data;
using CapaDatos;

namespace CapaNegocio
{
    public class CN_ServiciosEmpleado
    {
        private CD_ServiciosEmpleado objetoCD = new CD_ServiciosEmpleado();
        string estadoCaja;
        string resp = "";

        public DataSet listarServiciosEmpleado(int idEmpleado,string pFechaInicio, string pFechaFin)
        {
            DataSet tabla = new DataSet();
            tabla = objetoCD.listarServiciosEmpleado(idEmpleado,pFechaInicio, pFechaFin);
            return tabla;
        }

    }
}
