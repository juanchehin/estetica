using CapaNegocio;
using System;
using System.Windows.Forms;

namespace CapaPresentacion.Empleados
{
    public partial class formListarTrabajosEmpleado : Form
    {
        int IdEmpleado;
        string mes_seleccionado;
        CN_Empleados objetoCN = new CN_Empleados();
        public formListarTrabajosEmpleado(int IdEmpleado,string apellidos,string nombres, string dni)
        {
            InitializeComponent();
            this.IdEmpleado = IdEmpleado;
            lblApellidosNombres.Text = apellidos + ' ' + nombres;
            lblDNI.Text = dni;
            lblRegistros.Text = "Total de Registros: 0";
            lblComision.Text = "0";

            // Agregar los meses del año al ComboBox
            cbMeses.Items.AddRange(new string[]
            {
                "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio",
                "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"
            });
            cbMeses.DropDownStyle = ComboBoxStyle.DropDownList;
            listar_trabajos_empleado();
        }

        private void listar_trabajos_empleado()
        {
            dataListadoTrabajosEmpleado.DataSource = objetoCN.listar_trabajos_empleado(this.IdEmpleado, mes_seleccionado);

            if (dataListadoTrabajosEmpleado.SelectedCells.Count > 0)
            {
                dataListadoTrabajosEmpleado.Columns[3].Visible = false;
                dataListadoTrabajosEmpleado.Columns[4].Visible = false;

                lblComision.Text = dataListadoTrabajosEmpleado.Rows[0].Cells[3].Value.ToString();

                // this.OcultarColumnas();
                lblRegistros.Text = "Total de Registros: " + Convert.ToString(dataListadoTrabajosEmpleado.Rows.Count);
            }else
            {
                lblRegistros.Text = "Total de Registros: 0";
                lblComision.Text = "0";
            }
        }

        private void cbMeses_SelectedIndexChanged(object sender, EventArgs e)
        {
            mes_seleccionado = cbMeses.SelectedItem.ToString();
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            listar_trabajos_empleado();
        }
    }
}
