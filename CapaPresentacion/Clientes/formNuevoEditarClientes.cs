using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CapaNegocio;

namespace CapaPresentacion
{
    public partial class formNuevoEditarClientes : Form
    {
        CN_Clientes objetoCN = new CN_Clientes();
        DataTable respuesta;
        // int parametroActual;
        bool bandera;
        bool IsNuevo = false;
#pragma warning disable CS0414 // El campo 'formNuevoEditarClientes.IsEditar' está asignado pero su valor nunca se usa
        bool IsEditar = false;
#pragma warning restore CS0414 // El campo 'formNuevoEditarClientes.IsEditar' está asignado pero su valor nunca se usa

        private int IdCliente;
        private string Apellidos;
        private string Nombres;
        private string Telefono;
        private string DNI;
        private string Email;
        private string Direccion;
        private string FechaNac;
        private string Observaciones;

        public formNuevoEditarClientes(int parametro, bool IsNuevoEditar)
        {
            InitializeComponent();
            this.IdCliente = parametro;
            this.bandera = IsNuevoEditar;
        }

        private void formNuevoEditarClientes_Load(object sender, EventArgs e)
        {
            this.ActiveControl = txtNombres;
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
                this.MostrarCliente(this.IdCliente);
            }
        }

        // Carga los valores en los campos de texto del formulario para que se modifiquen los que se desean
        private void MostrarCliente(int IdCliente)
        {
            respuesta = objetoCN.MostrarCliente(IdCliente);

            foreach (DataRow row in respuesta.Rows)
            {
                IdCliente = Convert.ToInt32(row["IdPersona"]);
                Apellidos = Convert.ToString(row["Apellidos"]);
                Nombres = Convert.ToString(row["Nombres"]);
                Telefono = Convert.ToString(row["Telefono"]);
                DNI = Convert.ToString(row["DNI"]);
                Email = Convert.ToString(row["Email"]);
                Direccion = Convert.ToString(row["Direccion"]);
                FechaNac = Convert.ToString(row["FechaNac"]);
                Observaciones = Convert.ToString(row["observaciones"]);

                txtApellidos.Text = Apellidos;
                txtNombres.Text = Nombres;
                txtTelefono.Text = Telefono;
                txtDNI.Text = DNI;
                txtEmail.Text = Email;
                txtDireccion.Text = Direccion;
                dtpFechaNac.Text = FechaNac;
                txtObservaciones.Text = Observaciones;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
                try
                {
                    string rpta = "";
                    if (this.txtNombres.Text == string.Empty || this.txtApellidos.Text == string.Empty)
                    {
                        MensajeError("Falta ingresar algunos datos");
                    }
                    else
                    {
                        if (this.IsNuevo)
                        {
                            var año = this.dtpFechaNac.Value.Year;
                            var mes = this.dtpFechaNac.Value.Month;
                            var dia = this.dtpFechaNac.Value.Day;
                            var fechaNac = año + "-" + mes + "-" + dia;

                            rpta = CN_Clientes.Insertar(this.txtNombres.Text.Trim(), this.txtApellidos.Text.Trim(), this.txtDNI.Text.Trim(),
                                this.txtDireccion.Text.Trim(), this.txtTelefono.Text.Trim(), fechaNac, txtEmail.Text.Trim(), txtObservaciones.Text.Trim());
                        }
                        else
                        {
                            var año = this.dtpFechaNac.Value.Year;
                            var mes = this.dtpFechaNac.Value.Month;
                            var dia = this.dtpFechaNac.Value.Day;
                            var fecha = año + "-" + mes + "-" + dia;

                            rpta = CN_Clientes.Editar(this.IdCliente, this.txtNombres.Text.Trim(), this.txtApellidos.Text.Trim(),
                                this.txtDNI.Text.Trim(), this.txtDireccion.Text.Trim(), this.txtTelefono.Text.Trim(), fecha, txtObservaciones.Text.Trim());
                        }

                        if (rpta.Equals("Ok"))
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
        //Mostrar Mensaje de Error
        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Estetica", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void MensajeOk(string mensaje)
        {
            MessageBox.Show(mensaje, "Estetica", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
