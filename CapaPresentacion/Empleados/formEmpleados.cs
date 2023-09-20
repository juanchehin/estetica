﻿using System;
using System.Windows.Forms;
using CapaNegocio;
using CapaPresentacion.Empleados;

namespace CapaPresentacion
{
    public partial class formEmpleados : Form
    {
        CN_Empleados objetoCN = new CN_Empleados();
        string apellidos_empleado;
        string nombres_empleado;
        string dni_empleado;

        private int IdEmpleado;
        private int desde = 0;
#pragma warning disable CS0414 // El campo 'formUsuarios.IsNuevo' está asignado pero su valor nunca se usa
        private bool IsNuevo = false;
#pragma warning restore CS0414 // El campo 'formUsuarios.IsNuevo' está asignado pero su valor nunca se usa
#pragma warning disable CS0414 // El campo 'formUsuarios.IsEditar' está asignado pero su valor nunca se usa
        private bool IsEditar = false;
#pragma warning restore CS0414 // El campo 'formUsuarios.IsEditar' está asignado pero su valor nunca se usa
        public formEmpleados()
        {
            InitializeComponent();
        }

        private void formEmpleados_Load(object sender, EventArgs e)
        {
            MostrarEmpleados();
        }
        private void MostrarEmpleados()
        {
            dataListadoEmpleados.DataSource = objetoCN.ListarEmpleados(this.desde);
            // Oculto el IdEmpleado. Lo puedo seguir usando como parametro de eliminacion
            dataListadoEmpleados.Columns[0].Visible = false;
            lblTotalEmpleados.Text = "Total de Registros: " + Convert.ToString(dataListadoEmpleados.Rows.Count);
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

        private void dataListadoEmpleados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Console.WriteLine("e.ColumnIndex " + e.ColumnIndex);    // Dice que columna se hizo click
            if (e.ColumnIndex == dataListadoEmpleados.Columns["Marcar"].Index)
            {
                DataGridViewCheckBoxCell ChkEliminar = (DataGridViewCheckBoxCell)dataListadoEmpleados.Rows[e.RowIndex].Cells["Marcar"];
                ChkEliminar.Value = !Convert.ToBoolean(ChkEliminar.Value);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.BuscarEmpleado();
        }

        private void BuscarEmpleado()
        {
            this.dataListadoEmpleados.DataSource = objetoCN.BuscarEmpleado(this.txtBuscar.Text);
            // this.OcultarColumnas();
            lblTotalEmpleados.Text = "Total de Registros: " + Convert.ToString(dataListadoEmpleados.Rows.Count);
        }

        private void btnNuevoEmpleado_Click(object sender, EventArgs e)
        {
            formNuevoEditarEmpleado frm = new formNuevoEditarEmpleado(0,true);
            frm.MdiParent = this.MdiParent;
            frm.Show();
            this.Close();
        }

        private void botonEditarListado_Click(object sender, EventArgs e)
        {
            formNuevoEditarEmpleado frm = new formNuevoEditarEmpleado(this.IdEmpleado,false);
            frm.MdiParent = this.MdiParent;
            frm.Show();
            this.Close();
        }

        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            try
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("Realmente Desea Eliminar el empleado", "Estetica", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (Opcion == DialogResult.OK)
                {
                    CN_Empleados.Eliminar(this.IdEmpleado);
                    this.MostrarEmpleados();
                    this.MensajeOk("Se elimino de forma correcta el registro");
                }
                txtBuscar.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void dataListadoEmpleados_SelectionChanged(object sender, EventArgs e)
        {
            if (dataListadoEmpleados.SelectedCells.Count > 0)
            {
                int selectedrowindex = dataListadoEmpleados.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataListadoEmpleados.Rows[selectedrowindex];
                this.IdEmpleado = Convert.ToInt32(selectedRow.Cells["IdPersona"].Value);

                this.apellidos_empleado = selectedRow.Cells["Apellidos"].Value.ToString();
                this.nombres_empleado = selectedRow.Cells["Nombres"].Value.ToString();
                this.dni_empleado = selectedRow.Cells["DNI"].Value.ToString();
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
            this.MostrarEmpleados();
            this.txtBuscar.Clear();
        }

        private void btnListarTrabajos_Click(object sender, EventArgs e)
        {
            formListarTrabajosEmpleado frm = new formListarTrabajosEmpleado(this.IdEmpleado,this.apellidos_empleado,this.nombres_empleado,this.dni_empleado);
            frm.MdiParent = this.MdiParent;
            frm.Show();
            //this.Close();
        }
    }

}
