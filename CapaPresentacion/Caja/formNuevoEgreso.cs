using CapaNegocio;
using System;
using System.Data;
using System.Windows.Forms;

namespace CapaPresentacion.Caja
{
    public partial class formNuevoEgreso : Form
    {
        int IdCliente;
        CN_Ventas objetoCN_ventas = new CN_Ventas();
        DataTable tiposPagos;

        public formNuevoEgreso()
        {
            InitializeComponent();
            this.llenarCBTiposPago();

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //Mostrar Mensaje de Confirmación
        private void MensajeOk(string mensaje)
        {
            MessageBox.Show(mensaje, "Estetica", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }


        //Mostrar Mensaje de Error
        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Estetica", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void llenarCBTiposPago()
        {
            tiposPagos = objetoCN_ventas.DameTiposPago();

            tiposPagos.Rows.RemoveAt(5);    // quito "cuenta corriente"

            cbTiposPago.DataSource = tiposPagos;

            cbTiposPago.DisplayMember = "tipo_pago";
        }
        
        //
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";
                if (this.txtMonto.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos");
                }
                else
                {
                    rpta = CN_Ventas.alta_egreso(this.txtMonto.Text.Trim(), this.cbTiposPago.Text, this.rtbDescripcion.Text.Trim());
                    if (rpta.Equals("Ok"))
                    {
                        this.MensajeOk("Se Insertó de forma correcta el registro");
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
    }
}
