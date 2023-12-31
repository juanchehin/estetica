﻿using CapaNegocio;
using System;
using System.Data;
using System.Windows.Forms;

namespace CapaPresentacion.Caja
{
    public partial class formCaja : Form
    {
        CN_Caja objeto_Caja = new CN_Caja();
        int IdUsuario;
        int desde = 0;
        DataSet transacciones;
        private int IdTransaccion;

        public formCaja(int IdUsuario,string usuario)
        {
            InitializeComponent();
            this.IdUsuario = IdUsuario;
            dameEstadoCaja();
            listarTransacciones();
        }

        private void listarTransacciones()
        {
            var añoInicio = dtFechaInicio.Value.Year;
            var mesInicio = dtFechaInicio.Value.Month;
            var diaInicio = dtFechaInicio.Value.Day;
            var fechaInicio = añoInicio + "-" + mesInicio + "-" + diaInicio;


            var añoFin = dtFechaFin.Value.Year;
            var mesFin = dtFechaFin.Value.Month;
            var diaFin = dtFechaFin.Value.Day;
            var fechaFin = añoFin + "-" + mesFin + "-" + diaFin;


            transacciones = objeto_Caja.listarTransacciones(this.desde, fechaInicio, fechaFin);
            dataListadoCaja.DataSource = transacciones.Tables[0];

            dataListadoCaja.Columns["id_transaccion"].Visible = false;

            DataTable tabla_transacciones = transacciones.Tables["Table2"];

            // Verifica si la tabla contiene filas
            if (tabla_transacciones.Rows.Count > 0)
            {
                lblAdelantos.Text = tabla_transacciones.Rows[0][0].ToString();
                lblGastos.Text = tabla_transacciones.Rows[0][1].ToString();
                lblPagos.Text = tabla_transacciones.Rows[0][2].ToString();
                lbl_ventas_total.Text = tabla_transacciones.Rows[0][3].ToString();
                lbl_credito.Text = tabla_transacciones.Rows[0][4].ToString();
                lbl_debito.Text = tabla_transacciones.Rows[0][5].ToString();
                lbl_voucher.Text = tabla_transacciones.Rows[0][6].ToString();
                lbl_transferencias.Text = tabla_transacciones.Rows[0][7].ToString();
                lbl_efectivo.Text = tabla_transacciones.Rows[0][8].ToString();
            }

        }

        private string dameEstadoCaja()
        {
            string rpta = "";
            if(objeto_Caja.dameEstadoCaja() == "C")
            {
                rpta = "Cerrada";
            }
            if (objeto_Caja.dameEstadoCaja() == "A")
            {
                rpta = "Abierta";
            }
            return rpta;
        }

        private void btnAbrirCaja_Click(object sender, EventArgs e)
        {
            //this.panelMontoInicial.Visible = true;
        }


        private void btnCierreCaja_Click(object sender, EventArgs e)
        {

            if (objeto_Caja.cerrarCaja(this.IdUsuario) == "Ok")
            {
                MensajeOk("Caja cerrada");
            }
            else
            {
                MensajeError("Ocurrio un problema al cerrar la caja");
            }
        }


        private void btnCancelarPanel_Click(object sender, EventArgs e)
        {
            //this.panelMontoInicial.Visible = false;
        }

        private void btnOmitir_Click(object sender, EventArgs e)
        {
            if (objeto_Caja.abrirCaja(this.IdUsuario, 0) == "Ok")
            {
                MensajeOk("Caja aperturada");
                /*btnAbrirCaja.Enabled = false;
                btnCierreCaja.Enabled = true;
                this.panelMontoInicial.Visible = false;
                this.lblEstado.Text = "Abierta";*/
            }
            else
            {
                MensajeError("Ocurrio un problema al abrir la caja");
            }
        }

        private void btnAceptarPanel_Click(object sender, EventArgs e)
        {
            /*
            if(objeto_Caja.abrirCaja(this.IdUsuario,Convert.ToDecimal(txtMontoInicial.Text)) == "Ok")
            {
                MensajeOk("Caja aperturada");
                btnAbrirCaja.Enabled = false;
                btnCierreCaja.Enabled = true;
                this.panelMontoInicial.Visible = false;
                txtMontoInicial.Text = "";
                this.lblEstado.Text = "Abierta";
                listarTransacciones();
            }
            else
            {
                MensajeError("Ocurrio un problema al abrir la caja");
            }
            */
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

        private void dtFechaFin_ValueChanged(object sender, EventArgs e)
        {
            listarTransacciones();
        }

        private void dtFechaInicio_ValueChanged(object sender, EventArgs e)
        {
            listarTransacciones();
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            listarTransacciones();
        }

        private void btnEliminarTransaccion_Click(object sender, EventArgs e)
        {

            try
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("Realmente Desea Eliminar", "Estetica", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (Opcion == DialogResult.OK)
                {
                    objeto_Caja.Eliminar(this.IdTransaccion);
                    this.listarTransacciones();
                    this.MensajeOk("Se elimino de forma correcta el producto");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void dataListadoCaja_SelectionChanged(object sender, EventArgs e)
        {
            if (dataListadoCaja.SelectedCells.Count > 0)
            {
                int selectedrowindex = dataListadoCaja.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataListadoCaja.Rows[selectedrowindex];
                this.IdTransaccion = Convert.ToInt32(selectedRow.Cells["id_transaccion"].Value);
            }
        }

        private void btnEgreso_Click(object sender, EventArgs e)
        {
            formNuevoEgreso frm = new formNuevoEgreso();
            frm.MdiParent = this.MdiParent;
            frm.Show();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            formEditarCaja frm = new formEditarCaja(this.IdTransaccion);
            frm.MdiParent = this.MdiParent;
            frm.Show();
            //this.Close();
        }
    }
}
