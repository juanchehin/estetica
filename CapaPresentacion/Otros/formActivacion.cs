﻿using System;
using System.Windows.Forms;

namespace CapaPresentacion.Otros
{
    public partial class formActivacion : Form
    {
        string activado;
        public formActivacion()
        {
            InitializeComponent();
        }

        private void btnAyuda_Click(object sender, EventArgs e)
        {
            formInformacion frm = new formInformacion();
            frm.Show();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtClave.Text))
            {
                this.MensajeError("Ingrese una clave");
            }
            else
            {
                this.activado = CapaNegocio.CN_Usuarios.activar_producto(txtClave.Text);

                if (this.activado == "Ok")
                {
                    this.MensajeOk("Producto Acticado!");
                    this.Close();
                }
                else
                {
                    this.MensajeError("Ingrese una clave correcta");
                }
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

        private void formActivacion_Load(object sender, EventArgs e)
        {
            txtClave.Focus();
        }
    }
}
