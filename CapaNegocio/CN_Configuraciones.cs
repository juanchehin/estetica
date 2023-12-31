﻿using CapaDatos;
using System;
using System.Data;

namespace CapaNegocio
{
    public class CN_Configuraciones
    {
        public static string Backup(string file)
        {

            CD_Configuraciones Obj = new CD_Configuraciones();

            return Obj.Backup(file);
        }
        public static string Restore(string ruta)
        {
            CD_Configuraciones Obj = new CD_Configuraciones();

            return Obj.Restore(ruta);
        }

        public static string ejecutarScript()
        {
            CD_Configuraciones Obj = new CD_Configuraciones();

            return Obj.ejecutarScript();
        }

        public static Boolean testConexion()
        {
            CD_Configuraciones Obj = new CD_Configuraciones();

            return Obj.testConexion();
        }

        public string dameEmpresa()
        {
            CD_Configuraciones Obj = new CD_Configuraciones();

            return Obj.dameEmpresa();
        }

        public string dameDireccion()
        {
            CD_Configuraciones Obj = new CD_Configuraciones();

            return Obj.dameDireccion();
        }

        public DataTable dameDatosEmpresa()
        {
            CD_Configuraciones Obj = new CD_Configuraciones();

            return Obj.dameDatosEmpresa();
        }

        public static string InsertarDatosEmpresa(string NombreEmpresa, string rutaImagen, string Domicilio, string Telefono,string CUIT,string IngBrutos)
        {
            CD_Configuraciones Obj = new CD_Configuraciones();

            return Obj.InsertarDatosEmpresa(NombreEmpresa, rutaImagen, Domicilio, Telefono, CUIT, IngBrutos);
        }

    }
}
