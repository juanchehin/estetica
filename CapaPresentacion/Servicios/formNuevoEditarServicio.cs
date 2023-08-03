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
    public partial class formNuevoEditarServicio : Form
    {
        CN_Servicios objetoCN = new CN_Servicios();
        DataTable respuesta;
        // int parametroActual;
        bool bandera;
        bool IsNuevo = false;
#pragma warning disable CS0414 // El campo 'formNuevoEditarServicio.IsEditar' está asignado pero su valor nunca se usa
        bool IsEditar = false;
#pragma warning restore CS0414 // El campo 'formNuevoEditarServicio.IsEditar' está asignado pero su valor nunca se usa

        private int id_servicio;
        private string servicio;
        private string precio;
        private string descripcion;

        public formNuevoEditarServicio( bool IsNuevoEditar)
        {
            InitializeComponent();
            this.bandera = IsNuevoEditar;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MostrarServicio(int IdServicio)
        {
            respuesta = objetoCN.MostrarServicio(IdServicio);

            foreach (DataRow row in respuesta.Rows)
            {
                //IdServicio = Convert.ToInt32(row["IdServicio"]);
                servicio = Convert.ToString(row["servicio"]);
                precio = Convert.ToString(row["precio"]);
                descripcion = Convert.ToString(row["descripcion"]);

                txtServicio.Text = servicio;
                txtPrecio.Text = precio;
                rtbDescripcion.Text = descripcion;
            }

            //this.CargarRolesComboBox();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";
                if (this.txtServicio.Text == string.Empty || this.txtPrecio.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos");
                }
                else
                {
                    if (this.IsNuevo)
                    {
                        rpta = CN_Servicios.Insertar(this.txtServicio.Text.Trim(), this.txtPrecio.Text.Trim(), this.rtbDescripcion.Text.Trim());
                    }
                    else
                    {
                        rpta = CN_Servicios.Editar(this.id_servicio, this.txtServicio.Text.Trim(), this.txtPrecio.Text.Trim(), this.rtbDescripcion.Text.Trim());
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


        private void MensajeOk(string mensaje)
        {
            MessageBox.Show(mensaje, "Estetica", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }


        //Mostrar Mensaje de Error
        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Estetica", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void formNuevoEditarServicio_Load(object sender, EventArgs e)
        {
            this.ActiveControl = txtServicio;
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
                this.MostrarServicio(this.id_servicio);
            }
        }
    }
}
