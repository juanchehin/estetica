using CapaNegocio;
using System;
using System.Data;
using System.Windows.Forms;

namespace CapaPresentacion.servicios_empleados
{
    public partial class formServiciosEmpleado : Form
    {
        CN_ServiciosEmpleado objeto_serv = new CN_ServiciosEmpleado();

        int desde = 0;
        int IdEmpleado;
        DataSet servicios_empleado;
        public formServiciosEmpleado(int IdEmpleado)
        {
            InitializeComponent();
            this.IdEmpleado = IdEmpleado;

            listarServiciosEmpleado();
        }

        private void listarServiciosEmpleado()
        {
            var añoInicio = dtFechaInicio.Value.Year;
            var mesInicio = dtFechaInicio.Value.Month;
            var diaInicio = dtFechaInicio.Value.Day;
            var fechaInicio = añoInicio + "-" + mesInicio + "-" + diaInicio;


            var añoFin = dtFechaFin.Value.Year;
            var mesFin = dtFechaFin.Value.Month;
            var diaFin = dtFechaFin.Value.Day;
            var fechaFin = añoFin + "-" + mesFin + "-" + diaFin;

            servicios_empleado = objeto_serv.listarServiciosEmpleado(this.IdEmpleado,fechaInicio, fechaFin);

            dataListadoServiciosEmpleado.DataSource = servicios_empleado.Tables[0];
            dataListadoServiciosEmpleado.Columns["id_transaccion"].Visible = false;
        }

        private void btnCancelarPanel_Click(object sender, EventArgs e)
        {
            //this.panelMontoInicial.Visible = false;
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
            listarServiciosEmpleado();
        }

        private void dtFechaInicio_ValueChanged(object sender, EventArgs e)
        {
            listarServiciosEmpleado();
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            listarServiciosEmpleado();
        }
    }
}
