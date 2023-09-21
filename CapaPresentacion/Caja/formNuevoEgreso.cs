using CapaNegocio;
using System;
using System.Data;
using System.Windows.Forms;

namespace CapaPresentacion.Caja
{
    public partial class formNuevoEgreso : Form
    {
        int IdCliente;
        int IdEmpleadoAdelanto;
        int IdTipoPago;

        CN_Ventas objetoCN_ventas = new CN_Ventas();
        CN_Empleados objetoCN_empleados = new CN_Empleados();

        DataTable tiposPagos;
        DataTable empleados;

        public formNuevoEgreso()
        {            
            InitializeComponent();
            llenarCBTiposPago();
            llenarCBTipos();
            llenarCBEmpleados();
            cbEmpleados.Enabled = false;

            cbTiposPago.DropDownStyle = ComboBoxStyle.DropDownList;
            cbTipo.DropDownStyle = ComboBoxStyle.DropDownList;
            cbEmpleados.DropDownStyle = ComboBoxStyle.DropDownList;
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

        private void llenarCBTipos()
        {
            // Agregar elementos al ComboBox uno por uno
            cbTipo.Items.Add("Gastos");
            cbTipo.Items.Add("Pagos");
            cbTipo.Items.Add("Adelanto");
            // Puedes agregar más elementos según sea necesario
        }

        private void llenarCBEmpleados()
        {
            empleados = objetoCN_empleados.ListarEmpleadosCB(0);

            empleados.Rows.RemoveAt(0);

            cbEmpleados.DataSource = empleados;

            cbEmpleados.ValueMember = "IdPersona";

            cbEmpleados.DisplayMember = "ApellidosNombres";
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
                    rpta = CN_Ventas.alta_egreso(txtMonto.Text.Trim(), IdTipoPago, cbTipo.Text,IdEmpleadoAdelanto, rtbDescripcion.Text.Trim());
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

        //
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //Mostrar Mensaje de Confirmación
        private void MensajeOk(string mensaje)
        {
            MessageBox.Show(mensaje, "Estetica", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void cbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTipo.SelectedItem.ToString() == "Adelanto")
            {
                cbEmpleados.Enabled = true;
            }
            else
            {
                cbEmpleados.Enabled = false;
            }

        }

        private void cbEmpleados_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRowView filaSeleccionada = cbEmpleados.SelectedItem as DataRowView;

            // Verifica si se ha seleccionado una fila válida
            if (filaSeleccionada != null)
            {
                // Accede a las columnas por su nombre o índice y obtén los valores
                this.IdEmpleadoAdelanto = Convert.ToInt32(filaSeleccionada["IdPersona"]);
                // string nombre = filaSeleccionada["ApellidosNombres"].ToString();

                // Ahora puedes utilizar "id" y "nombre" para lo que necesites
            }
        }

        private void cbTiposPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRowView filaSeleccionada = cbTiposPago.SelectedItem as DataRowView;

            // Verifica si se ha seleccionado una fila válida
            if (filaSeleccionada != null)
            {
                // Accede a las columnas por su nombre o índice y obtén los valores
                this.IdTipoPago = Convert.ToInt32(filaSeleccionada["id_tipo_pago"]);
                // string nombre = filaSeleccionada["ApellidosNombres"].ToString();

                // Ahora puedes utilizar "id" y "nombre" para lo que necesites
            }
        }
    }
}
