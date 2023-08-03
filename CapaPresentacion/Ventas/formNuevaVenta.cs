﻿using System;
using System.Data;
using System.Windows.Forms;
using CapaNegocio;

namespace CapaPresentacion.Ventas
{
    public partial class formNuevaVenta : Form
    {
        CN_Ventas objetoCN = new CN_Ventas();
        CN_Empleados objetoCN_empleados = new CN_Empleados();

        CN_Clientes objetoCN_clientes = new CN_Clientes();
        CN_Servicios objetoCN_servicios = new CN_Servicios();


#pragma warning disable CS0169 // El campo 'formNuevaVenta.respuesta' nunca se usa
        DataTable respuesta;
#pragma warning restore CS0169 // El campo 'formNuevaVenta.respuesta' nunca se usa
        DataTable tiposPagos;

#pragma warning disable CS0169 // El campo 'formNuevaVenta.bandera' nunca se usa
        bool bandera;
#pragma warning restore CS0169 // El campo 'formNuevaVenta.bandera' nunca se usa
#pragma warning disable CS0414 // El campo 'formNuevaVenta.IsNuevo' está asignado pero su valor nunca se usa
        bool IsNuevo = false;
#pragma warning restore CS0414 // El campo 'formNuevaVenta.IsNuevo' está asignado pero su valor nunca se usa
#pragma warning disable CS0414 // El campo 'formNuevaVenta.IsEditar' está asignado pero su valor nunca se usa
        bool IsEditar = false;
#pragma warning restore CS0414 // El campo 'formNuevaVenta.IsEditar' está asignado pero su valor nunca se usa

#pragma warning disable CS0169 // El campo 'formNuevaVenta.IdVenta' nunca se usa
        private int IdVenta;
#pragma warning restore CS0169 // El campo 'formNuevaVenta.IdVenta' nunca se usa
        private int IdUsuario;  // IdEmpleado
        // Cliente
        private int IdCliente = 2;  // Cliente generico si no se especifica otro
        public string Apellidos = "Publico ";
        public string Nombres = "en general";
        // Empleado
        private int IdEmpleado = 2;  // Cliente generico si no se especifica otro
        public string ApellidosEmpleado = "Empleado";
        public string NombresEmpleado = "";
        //
        public string Usuario;
#pragma warning disable CS0169 // El campo 'formNuevaVenta.tipoPago' nunca se usa
        private string tipoPago;
#pragma warning restore CS0169 // El campo 'formNuevaVenta.tipoPago' nunca se usa
        private int pDesde = 0;

        private int IdServicio;

#pragma warning disable CS0169 // El campo 'formNuevaVenta.Fecha' nunca se usa
        private DateTime Fecha;
#pragma warning restore CS0169 // El campo 'formNuevaVenta.Fecha' nunca se usa

#pragma warning disable CS0169 // El campo 'formNuevaVenta.Cantidad' nunca se usa
        private string Cantidad;
#pragma warning restore CS0169 // El campo 'formNuevaVenta.Cantidad' nunca se usa

        private decimal precioTotal = 0;

        DataTable dtRespuesta = new DataTable();


        public formNuevaVenta(int IdUsuario,string usuario)
        {
            InitializeComponent();
            panelClientes.Visible = false;
            panelVuelto.Visible = false;
            panelEmpleados.Visible = false;

            this.IdUsuario = IdUsuario;
            this.Usuario = usuario;
            // Creo las columnas de el listado de ventas

            this.dataListadoServicios.Columns.Add("id_servicio", "id_servicio");
            this.dataListadoServicios.Columns.Add("servicio", "servicio");
            this.dataListadoServicios.Columns.Add("cantidad", "cantidad");
            this.dataListadoServicios.Columns.Add("PrecioUnitario", "Precio unitario");

            this.dataListadoServicios.Columns["id_servicio"].Visible = false;   // Oculto "IdProducto"

            this.lblUsuario.Text = usuario;
            this.IdUsuario = IdUsuario;

            this.lblCliente.Text = this.Apellidos + this.Nombres;
            this.llenarCBTiposPago();
            this.llenarCBServicios();
        }

        private void llenarCBTiposPago()
        {
            tiposPagos = objetoCN.DameTiposPago();

            cbTiposPago.DataSource = tiposPagos;

            cbTiposPago.DisplayMember = "tipo_pago";
        }

        private void llenarCBServicios()
        {
            tiposPagos = objetoCN_servicios.ListarServicios(0);

            cbServicios.DataSource = tiposPagos;

            cbServicios.DisplayMember = "servicio";
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            DataTable productos = new DataTable();
            productos.Columns.Add("IdProducto", typeof(System.Int32));
            productos.Columns.Add("Cantidad", typeof(System.Int32));


            foreach (DataGridViewRow rowGrid in this.dataListadoServicios.Rows)
            {
                DataRow row = productos.NewRow();
                row["IdProducto"] = Convert.ToDouble(rowGrid.Cells[0].Value);
                row["Cantidad"] = rowGrid.Cells[3].Value;

                productos.Rows.Add(row);
            }

            try
            {
                string rpta = "";
                if (this.dataListadoServicios.CurrentRow == null)
                {
                    MensajeError("Productos inexistentes");
                    return;
                }

                rpta = CN_Ventas.AltaVenta(this.IdUsuario,this.IdCliente, cbTiposPago.Text, productos, Convert.ToDecimal(this.precioTotal.ToString()));

                if (rpta.Equals("Ok"))
                {
                    panelVuelto.Visible = true;
                    this.lblImporte.Text = this.precioTotal.ToString();

                }
                else
                {
                    this.MensajeError(rpta);
                }
                //this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            Char chr = e.KeyChar;

            if (!Char.IsDigit(chr) && chr != 8)
            {
                e.Handled = true;
                MessageBox.Show("Debe ingresar valores numericos ");
            }
        }


        private void btnSeleccionarCliente_Click(object sender, EventArgs e)
        {
            panelClientes.Visible = !panelClientes.Visible;
            MostrarClientes();
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if (this.dataListadoServicios.CurrentRow == null)
            {
                MensajeError("Productos inexistentes");
                return;
            }
            try
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("Realmente Desea Eliminar el producto", "Estetica", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (Opcion == DialogResult.OK)
                {
                    foreach (DataGridViewRow item in this.dataListadoServicios.SelectedRows)
                    {
                        decimal precio = decimal.Parse(this.dataListadoServicios.Rows[item.Index].Cells["PrecioUnitario"].Value.ToString());
                        int cantidad = int.Parse(this.dataListadoServicios.Rows[item.Index].Cells["Cantidad"].Value.ToString());

                        this.dataListadoServicios.Rows.RemoveAt(item.Index);

                        this.precioTotal = this.precioTotal - (precio * cantidad);
                        this.lblTotal.Text = precioTotal.ToString();
                    }

                    this.MensajeOk("Se elimino de forma correcta el producto");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataListadoClientes.SelectedCells.Count > 0)
                {
                    int selectedrowindex = dataListadoClientes.SelectedCells[0].RowIndex;
                    DataGridViewRow selectedRow = dataListadoClientes.Rows[selectedrowindex];

                    this.IdCliente = Convert.ToInt32(selectedRow.Cells["IdPersona"].Value);
                    this.Apellidos = selectedRow.Cells["Apellidos"].Value.ToString();
                    this.Nombres = selectedRow.Cells["Nombres"].Value.ToString();
                }

                lblCliente.Text = this.Apellidos + " " + this.Nombres;

                panelClientes.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
        public void MostrarClientes()
        {
            dataListadoClientes.DataSource = objetoCN_clientes.MostrarClientes();
            dataListadoClientes.Columns[0].Visible = false;
        }

        public void MostrarServicios()
        {
            dataListadoServicios.DataSource = objetoCN_servicios.ListarServicios(0);
            dataListadoServicios.Columns[0].Visible = false;
        }

        public void MostrarEmpleados()
        {
            dataListadoEmpleadosPanel.DataSource = objetoCN_empleados.ListarEmpleados(0);
            dataListadoEmpleadosPanel.Columns[0].Visible = false;
        }

        private void txtEntrega_TextChanged(object sender, EventArgs e)
        {
            if (this.txtEntrega.Text != "")
            {
                decimal result = (this.precioTotal - Convert.ToDecimal(this.txtEntrega.Text)) * -1;
                this.lblVuelto.Text = result.ToString();
            }
            else
            {
                this.lblVuelto.Text = this.precioTotal.ToString();
            }
        }

        private void btnImprimirTicket_Click(object sender, EventArgs e)
        {
            /*
            formTicket frm = new formTicket(this.IdUsuario, this.IdCliente, this.dataListadoServicios);
            frm.MdiParent = this.MdiParent;
            frm.Show();

            this.Close();
            */
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            panelVuelto.Visible = false;
            this.Close();
        }

        private void btnBuscarProducto_Click(object sender, EventArgs e)
        {
            this.BuscarProducto();
        }

        private void BuscarProducto()
        {
            // this.dataListadoServiciosPanel.DataSource = objetoCN_productos.BuscarServicio(this.txtBuscarProductoPanel.Text);
        }


        private void txtBuscarProducto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.BuscarProducto();
            }
        }


        private void btnSeleccionarEmpleado_Click(object sender, EventArgs e)
        {
            panelEmpleados.Visible = !panelEmpleados.Visible;
            MostrarEmpleados();
        }

        private void btnCerrarPanelClientes_Click(object sender, EventArgs e)
        {
            panelClientes.Visible = false;

        }

        private void seleccionarEmpleado_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataListadoEmpleadosPanel.SelectedCells.Count > 0)
                {
                    int selectedrowindex = dataListadoEmpleadosPanel.SelectedCells[0].RowIndex;
                    DataGridViewRow selectedRow = dataListadoEmpleadosPanel.Rows[selectedrowindex];

                    this.IdEmpleado = Convert.ToInt32(selectedRow.Cells["IdPersona"].Value);
                    this.ApellidosEmpleado = selectedRow.Cells["Apellidos"].Value.ToString();
                    this.NombresEmpleado = selectedRow.Cells["Nombres"].Value.ToString();
                }

                lblEmpleado.Text = this.ApellidosEmpleado + " " + this.NombresEmpleado;

                panelEmpleados.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnCerrarPanelEmpleados_Click(object sender, EventArgs e)
        {
            panelEmpleados.Visible = false;

        }

        private void btnAgregarServicio_Click(object sender, EventArgs e)
        {
            /*if (this.lblNombreServicio.Text == "" || this.lblPrecioUnitario.Text == "")
            {
                MensajeError("Debe cargar un producto");
                return;
            }*/

            decimal dec = decimal.Parse(this.lblPrecioUnitario_.Text);
            bool bandera = false;

            if (dataListadoServicios.Rows.Count == 0)
            {
                // Si no cargo la cantidad, cargo por defecto 1
                if (String.IsNullOrEmpty(this.txtCantidad.Text))
                {
                    this.dataListadoServicios.Rows.Insert(this.dataListadoServicios.RowCount, this.IdServicio, cbServicios.SelectedItem.ToString(), 1, this.lblPrecioUnitario.Text);
                    this.precioTotal += dec;
                }
                else
                {
                    decimal cant = decimal.Parse(this.txtCantidad.Text);
                    this.dataListadoServicios.Rows.Insert(this.dataListadoServicios.RowCount, this.IdServicio, cbServicios.SelectedItem.ToString(), this.txtCantidad.Text, this.lblPrecioUnitario.Text);
                    this.precioTotal += dec * cant;
                }
            }
            else
            {
                bandera = false;
                // Chequeo si ya existe el producto en el listado para poder aumentar la cantidad
                foreach (DataGridViewRow row in dataListadoServicios.Rows)
                {
                    if (Convert.ToInt32(row.Cells[0].Value) == this.IdServicio)
                    {
                        bandera = true;
                        // Si no cargo la cantidad, cargo por defecto 1
                        if (String.IsNullOrEmpty(this.txtCantidad.Text))
                        {
                            row.Cells["Cantidad"].Value = 1 + Convert.ToInt32(row.Cells[3].Value);
                            this.precioTotal += dec;
                        }
                        else
                        {
                            decimal cant = decimal.Parse(this.txtCantidad.Text);
                            row.Cells["Cantidad"].Value = 1 + Convert.ToInt32(row.Cells[3].Value);
                            this.precioTotal += dec * cant;
                        }
                        break;
                    }
                }
                if (bandera == false)
                {
                    // Si no cargo la cantidad, cargo por defecto 1
                    if (String.IsNullOrEmpty(this.txtCantidad.Text))
                    {
                        this.dataListadoServicios.Rows.Insert(this.dataListadoServicios.RowCount, this.IdServicio, this.lblNombreProd.Text, 1, this.lblPrecioUnitario.Text);
                        this.precioTotal += dec;
                    }
                    else
                    {
                        decimal cant = decimal.Parse(this.txtCantidad.Text);
                        this.dataListadoServicios.Rows.Insert(this.dataListadoServicios.RowCount, this.IdServicio, this.lblNombreProd.Text, this.txtCantidad.Text, this.lblPrecioUnitario.Text);
                        this.precioTotal += dec * cant;
                    }
                }
            }

            this.lblTotal.Text = this.precioTotal.ToString();
        }

        private void cbServicios_SelectedIndexChanged(object sender, EventArgs e)
        {
            string valorSeleccionado = cbServicios.Text;

            // obtener precio del servicio
            this.lblPrecioUnitario_.Text = objetoCN_servicios.dame_precio_servicio(valorSeleccionado);


        }
    }
}
