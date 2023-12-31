﻿using System;
using System.Windows.Forms;

using CapaNegocio;
using CapaPresentacion.Clientes;

namespace CapaPresentacion
{
    public partial class formClientes : Form
    {
        CN_Clientes objetoCN = new CN_Clientes();
        private int IdCliente;
        private int desde = 0;
        private string nombre_cliente;
        private string apellidos_cliente;
        private string direccion_cliente;
        private string telefono_cliente;
        private string dni;
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
                this.apellidos_cliente = selectedRow.Cells["Apellidos"].Value.ToString();
                this.nombre_cliente = selectedRow.Cells["Nombres"].Value.ToString();
                this.telefono_cliente = selectedRow.Cells["Telefono"].Value.ToString();
                this.direccion_cliente = selectedRow.Cells["Direccion"].Value.ToString();
                this.dni = selectedRow.Cells["DNI"].Value.ToString();

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
            this.txtBuscar.Clear();
        }

        private void lblCC_Click(object sender, EventArgs e)
        {
            formCuentasCorrientesCliente frm = new formCuentasCorrientesCliente(this.IdCliente,this.apellidos_cliente,this.nombre_cliente,this.telefono_cliente,this.direccion_cliente,this.dni);
            frm.MdiParent = this.MdiParent;
            frm.Show();
            this.Close();
        }
    }

}
