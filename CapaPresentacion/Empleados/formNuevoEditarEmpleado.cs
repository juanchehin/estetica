﻿using System;
using System.Data;
using System.Windows.Forms;

using CapaNegocio;

namespace CapaPresentacion
{
    public partial class formNuevoEditarEmpleado : Form
    {
        CN_Empleados objetoCN = new CN_Empleados();
        DataTable respuesta;
        // int parametroActual;
        bool bandera;
        bool IsNuevo = false;
#pragma warning disable CS0414 // El campo 'formNuevoEditarEmpleado.IsEditar' está asignado pero su valor nunca se usa
        bool IsEditar = false;
#pragma warning restore CS0414 // El campo 'formNuevoEditarEmpleado.IsEditar' está asignado pero su valor nunca se usa

        private int IdEmpleado;
        private string Nombres;
        private string Apellidos;
        private string DNI;
        private string Direccion;
        private string Telefono;
        private string Email;
        private string Empleado;
        private DateTime FechaNac;
        private string Observaciones;


        public formNuevoEditarEmpleado(int pIdEmpleado,bool IsNuevoEditar)
        {
            InitializeComponent();
            this.IdEmpleado = pIdEmpleado;
            this.bandera = IsNuevoEditar;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MostrarEmpleado(int IdEmpleado)
        {
            respuesta = objetoCN.MostrarEmpleado(IdEmpleado);

            foreach (DataRow row in respuesta.Rows)
            {
                //IdEmpleado = Convert.ToInt32(row["IdEmpleado"]);
                Nombres = Convert.ToString(row["Nombres"]);
                Apellidos = Convert.ToString(row["Apellidos"]);
                DNI = Convert.ToString(row["DNI"]);
                Direccion = Convert.ToString(row["Direccion"]);
                Telefono = Convert.ToString(row["Telefono"]);
                Email = Convert.ToString(row["Email"]);
                Observaciones = Convert.ToString(row["Observaciones"]);
                // Empleado = Convert.ToString(row["Empleado"]);

                if (row["Fecha de nacimiento"] == DBNull.Value)
                {
                    FechaNac = Convert.ToDateTime("2010-12-25");
                    dtFechaNac.Value = FechaNac;
                }
                else
                {
                    FechaNac = Convert.ToDateTime(row["Fecha de nacimiento"]);
                    dtFechaNac.Value = FechaNac;
                    
                }

                txtNombre.Text = Nombres;
                txtApellidos.Text = Apellidos;
                txtDNI.Text = DNI;
                txtDireccion.Text = Direccion;
                txtTelefono.Text = Telefono;
                txtEmail.Text = Email;
                rtbObservaciones.Text = Observaciones;
            }

            //this.CargarRolesComboBox();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";
                if (this.txtNombre.Text == string.Empty || this.txtApellidos.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos");
                }
                else
                {
                    if (this.IsNuevo)
                    {
                        var año = this.dtFechaNac.Value.Year;
                        var mes = this.dtFechaNac.Value.Month;
                        var dia = this.dtFechaNac.Value.Day;
                        var fechaNac = año + "-" + mes + "-" + dia;

                        rpta = CN_Empleados.InsertarEmpleado(this.txtNombre.Text.Trim(), this.txtApellidos.Text.Trim(), this.txtDNI.Text.Trim(),
                            this.txtDireccion.Text.Trim(),this.txtTelefono.Text.Trim(), fechaNac,txtEmail.Text.Trim(), this.rtbObservaciones.Text.Trim());
                    }
                    else
                    {
                        var año = this.dtFechaNac.Value.Year;
                        var mes = this.dtFechaNac.Value.Month;
                        var dia = this.dtFechaNac.Value.Day;
                        var fecha = año + "-" + mes + "-" + dia;

                        rpta = CN_Empleados.Editar(this.IdEmpleado, this.txtNombre.Text.Trim(), this.txtApellidos.Text.Trim(),
                            this.txtDNI.Text.Trim(),this.txtDireccion.Text.Trim(), this.txtTelefono.Text.Trim(), fecha, this.rtbObservaciones.Text.Trim());
                    }

                    if (rpta.Equals("OK"))
                    {
                        if (this.IsNuevo)
                        {
                            this.MensajeOk("Se Insertó de forma correcta el registro");
                        }
                        else
                        {
                            this.MensajeOk("Se Actualizó de forma correcta el registro");
                        }
                        this.Close();
                    }
                    
                    else
                    {
                        this.MensajeError(rpta);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
            
        }

        private void formNuevoEditarEmpleado_Load(object sender, EventArgs e)
        {
            this.ActiveControl = txtNombre;
            if (this.bandera)
            {
                lblEditarNuevo.Text = "Nuevo";
                // this.MostrarProducto(this.IdProducto);
                this.IsNuevo = true;
                this.IsEditar = false;
            }
            else
            {
                lblEditarNuevo.Text = "Editar";
                this.IsNuevo = false;
                this.IsEditar = true;
                this.MostrarEmpleado(this.IdEmpleado);
            }
        }

        private void MensajeOk(string mensaje)
        {
            MessageBox.Show(mensaje, "Estetica", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }


        //Mostrar Mensaje de Error
        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Estetica", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
