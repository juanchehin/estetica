using System;
using System.Windows.Forms;
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class formClientes : Form
    {
        CN_Clientes objetoCN = new CN_Clientes();

        private int IdCliente;
        private int desde = 0;
        int totalClientes = 0;

        public formClientes()
        {
            InitializeComponent();
            MostrarClientes();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MostrarClientes();
        }
        public void MostrarClientes()
        {
            dataListadoClientes.DataSource = objetoCN.MostrarClientes(this.desde);
            dataListadoClientes.Columns[0].Visible = false;
            totalClientes = dataListadoClientes.Rows.Count;
            lblTotalClientes.Text = "Total de Registros: " + Convert.ToString(dataListadoClientes.Rows.Count);
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {

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

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("Realmente Desea Eliminar el cliente", "Estetica", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (Opcion == DialogResult.OK)
                {
                    CN_Clientes.Eliminar(this.IdCliente);
                    this.MostrarClientes();
                }
                this.MensajeOk("Se elimino de forma correcta el registro");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
            this.Close();
        }

        private void BuscarCliente()
        {
            this.dataListadoClientes.DataSource = objetoCN.BuscarCliente(this.txtBuscar.Text);
            // this.OcultarColumnas();
            lblTotalClientes.Text = "Total de Registros: " + Convert.ToString(dataListadoClientes.Rows.Count);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.BuscarCliente();
        }

        private void btnNuevoCliente_Click(object sender, EventArgs e)
        {
            formNuevoEditarClientes frm = new formNuevoEditarClientes(this.IdCliente, true);
            frm.MdiParent = this.MdiParent;
            frm.Show();
            this.Close();
        }

        private void dataListadoClientes_SelectionChanged(object sender, EventArgs e)
        {
            if (dataListadoClientes.SelectedCells.Count > 0)
            {
                int selectedrowindex = dataListadoClientes.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataListadoClientes.Rows[selectedrowindex];
                this.IdCliente = Convert.ToInt32(selectedRow.Cells["IdPersona"].Value);
            }
        }

        private void botonEditarListado_Click_1(object sender, EventArgs e)
        {
            formNuevoEditarClientes frm = new formNuevoEditarClientes(this.IdCliente, false);
            frm.MdiParent = this.MdiParent;
            frm.Show();
            this.Close();
        }

        private void formClientes_Load(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            try
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("Realmente Desea Eliminar el cliente", "Estetica", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (Opcion == DialogResult.OK)
                {
                    CN_Clientes.Eliminar(this.IdCliente);
                    this.MostrarClientes();
                    this.MensajeOk("Se elimino de forma correcta el registro");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
            this.Close();
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
            this.MostrarClientes();
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {

        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            if ((desde + 20) >= Convert.ToInt32(totalClientes))
            {
                return;
            }

            if (desde < 0)
            {
                return;
            }

            this.desde += 20;
            this.MostrarClientes();
        }
    }

}
