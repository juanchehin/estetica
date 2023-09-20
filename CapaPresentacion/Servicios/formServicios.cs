using System;
using System.Windows.Forms;
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class formServicios : Form
    {
        CN_Servicios objetoCN = new CN_Servicios();

        private int IdServicio;
#pragma warning disable CS0414 // El campo 'formUsuarios.IsNuevo' está asignado pero su valor nunca se usa
        private bool IsNuevo = false;
#pragma warning restore CS0414 // El campo 'formUsuarios.IsNuevo' está asignado pero su valor nunca se usa
#pragma warning disable CS0414 // El campo 'formUsuarios.IsEditar' está asignado pero su valor nunca se usa
        private bool IsEditar = false;
#pragma warning restore CS0414 // El campo 'formUsuarios.IsEditar' está asignado pero su valor nunca se usa
        public formServicios()
        {
            InitializeComponent();
        }

        private void formServicios_Load(object sender, EventArgs e)
        {
            MostrarServicios();
        }
        private void MostrarServicios()
        {
            dataListadoServicios.DataSource = objetoCN.ListarServicios(0);
            // Oculto el IdServicio. Lo puedo seguir usando como parametro de eliminacion
            //dataListadoServicios.Columns[0].Visible = false;
            lblTotalServicios.Text = "Total de Registros: " + Convert.ToString(dataListadoServicios.Rows.Count);
        }

        private void btnGuardar_Click_1(object sender, EventArgs e)
        {

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {

        }
        //Limpiar todos los controles del formulario

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

        private void dataListadoServicios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataListadoServicios.Columns["Marcar"].Index)
            {
                DataGridViewCheckBoxCell ChkEliminar = (DataGridViewCheckBoxCell)dataListadoServicios.Rows[e.RowIndex].Cells["Marcar"];
                ChkEliminar.Value = !Convert.ToBoolean(ChkEliminar.Value);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.BuscarServicio();
        }

        private void BuscarServicio()
        {
            this.dataListadoServicios.DataSource = objetoCN.BuscarServicio(this.txtBuscar.Text);
            // this.OcultarColumnas();
            lblTotalServicios.Text = "Total de Registros: " + Convert.ToString(dataListadoServicios.Rows.Count);
        }

        private void btnNuevoServicio_Click(object sender, EventArgs e)
        {
            formNuevoEditarServicio frm = new formNuevoEditarServicio(this.IdServicio,true);
            frm.MdiParent = this.MdiParent;
            frm.Show();
            this.Close();
        }

        private void botonEditarListado_Click(object sender, EventArgs e)
        {
            formNuevoEditarServicio frm = new formNuevoEditarServicio(this.IdServicio,false);
            frm.MdiParent = this.MdiParent;
            frm.Show();
            this.Close();
        }

        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            try
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("Realmente Desea Eliminar el servicio", "Estetica", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (Opcion == DialogResult.OK)
                {
                    CN_Servicios.Eliminar(this.IdServicio);
                    this.MostrarServicios();
                    this.MensajeOk("Se elimino de forma correcta el registro");
                }
                txtBuscar.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void dataListadoServicios_SelectionChanged(object sender, EventArgs e)
        {
            if (dataListadoServicios.SelectedCells.Count > 0)
            {
                int selectedrowindex = dataListadoServicios.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataListadoServicios.Rows[selectedrowindex];
                this.IdServicio = Convert.ToInt32(selectedRow.Cells["id_servicio"].Value);
            }
        }




        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnBuscar_Click(this, new EventArgs());
            }
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            this.MostrarServicios();
            txtBuscar.Clear();
        }

        private void btnNuevoServicio_Click_1(object sender, EventArgs e)
        {
            formNuevoEditarServicio frm = new formNuevoEditarServicio(this.IdServicio, true);
            frm.MdiParent = this.MdiParent;
            frm.Show();
            this.Close();
        }

        private void formServicios_Load_1(object sender, EventArgs e)
        {
            MostrarServicios();
        }

        private void dataListadoServicios_SelectionChanged_1(object sender, EventArgs e)
        {
            if (dataListadoServicios.SelectedCells.Count > 0)
            {
                int selectedrowindex = dataListadoServicios.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataListadoServicios.Rows[selectedrowindex];
                this.IdServicio = Convert.ToInt32(selectedRow.Cells["id_servicio"].Value);
            }
        }
    }

}
