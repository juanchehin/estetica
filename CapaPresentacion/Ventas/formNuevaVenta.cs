using System;
using System.Data;
using System.Windows.Forms;
using CapaNegocio;
using CapaPresentacion.Caja;

namespace CapaPresentacion.Ventas
{
    public partial class formNuevaVenta : Form
    {
        CN_Ventas objetoCN = new CN_Ventas();
        CN_Empleados objetoCN_empleados = new CN_Empleados();

        CN_Clientes objetoCN_clientes = new CN_Clientes();
        CN_Servicios objetoCN_servicios = new CN_Servicios();

        DataTable respuesta;
        DataTable tiposPagos;

        // Cliente
        private int IdCliente = 2;  // Cliente generico si no se especifica otro
        private int IdUsuario;  //

        public string Apellidos = "Publico ";
        public string Nombres = "en general";
        // Empleado
        private int IdEmpleado = 2;  // Cliente generico si no se especifica otro
        public string ApellidosEmpleado = "Empleado";
        public string NombresEmpleado = "";
        //
        public string Usuario;

        DataTable servicios;
        private int IdServicio;

        private decimal precioTotal = 0;
        private int desde = 0;

        public formNuevaVenta(int IdUsuario,string usuario)
        {
            InitializeComponent();
            panelClientes.Visible = false;
            panelVuelto.Visible = false;
            panelEmpleados.Visible = false;
            
            cbServicios.Items.Clear();

            this.IdUsuario = IdUsuario;
            this.Usuario = usuario;
            // Creo las columnas de el listado de ventas

            this.dataListadoServicios.Columns.Add("id_servicio", "id_servicio");
            this.dataListadoServicios.Columns.Add("servicio", "servicio");
            this.dataListadoServicios.Columns.Add("cantidad", "cantidad");
            this.dataListadoServicios.Columns.Add("PrecioUnitario", "Precio unitario");

            this.dataListadoServicios.Columns["id_servicio"].Visible = false;   // Oculto "IdProducto"


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
            servicios = objetoCN_servicios.ListarServicios(0);

            cbServicios.DataSource = servicios;

            cbServicios.DisplayMember = "servicio";
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (lblTotal.Text == "0")
            {
                MensajeError("Debe cargar un servicio");
                return;
            }

            if (this.IdCliente == 2)
            {
                MensajeError("Debe cargar un cliente");
                return;
            }

            if (this.IdEmpleado == 2)
            {
                MensajeError("Debe cargar un empleado");
                return;
            }

            DataTable servicios = new DataTable();
            servicios.Columns.Add("id_servicio", typeof(System.Int32));
            servicios.Columns.Add("cantidad", typeof(System.Int32));


            foreach (DataGridViewRow rowGrid in this.dataListadoServicios.Rows)
            {
                DataRow row = servicios.NewRow();
                row["id_servicio"] = Convert.ToDouble(rowGrid.Cells[0].Value);
                row["cantidad"] = rowGrid.Cells[2].Value;

                servicios.Rows.Add(row);
            }

            try
            {
                string rpta = "";
                if (this.dataListadoServicios.CurrentRow == null)
                {
                    MensajeError("Servicios inexistentes");
                    return;
                }

                rpta = CN_Ventas.AltaVenta(this.IdCliente,this.IdEmpleado, cbTiposPago.Text, servicios, Convert.ToDecimal(this.precioTotal.ToString()));

                if (rpta.Equals("Ok"))
                {
                    this.MensajeOk("Venta cargada");
                    this.btnCancelar.PerformClick();
                    //panelVuelto.Visible = true;
                    //this.lblImporte.Text = this.precioTotal.ToString();

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
                MensajeError("Servicios inexistentes");
                return;
            }
            try
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("Realmente Desea Eliminar el servicio", "Estetica", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

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

                    this.MensajeOk("Se elimino de forma correcta el servicio");
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
            dataListadoClientes.DataSource = objetoCN_clientes.MostrarClientes(this.desde);
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
            if (lblPrecioUnitario_.Text == "0")
            {
                MensajeError("Debe cargar un servicio");
                return;
            }

            decimal dec = decimal.Parse(this.lblPrecioUnitario_.Text);
            bool bandera = false;

            if (dataListadoServicios.Rows.Count == 0)
            {
                // Si no cargo la cantidad, cargo por defecto 1
                if (String.IsNullOrEmpty(this.txtCantidad.Text))
                {
                    this.dataListadoServicios.Rows.Insert(this.dataListadoServicios.RowCount, this.IdServicio, cbServicios.Text, 1, this.lblPrecioUnitario_.Text);
                    this.precioTotal += dec;
                }
                else
                {
                    decimal cant = decimal.Parse(this.txtCantidad.Text);
                    this.dataListadoServicios.Rows.Insert(this.dataListadoServicios.RowCount, this.IdServicio, cbServicios.Text, this.txtCantidad.Text, this.lblPrecioUnitario_.Text);
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
                            row.Cells["cantidad"].Value = 1 + Convert.ToInt32(row.Cells[2].Value);
                            this.precioTotal += dec;
                        }
                        else
                        {
                            decimal cant = decimal.Parse(this.txtCantidad.Text);
                            row.Cells["cantidad"].Value = 1 + Convert.ToInt32(row.Cells[2].Value);
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
                        this.dataListadoServicios.Rows.Insert(this.dataListadoServicios.RowCount, this.IdServicio, cbServicios.Text, 1, this.lblPrecioUnitario_.Text);
                        this.precioTotal += dec;
                    }
                    else
                    {
                        decimal cant = decimal.Parse(this.txtCantidad.Text);
                        this.dataListadoServicios.Rows.Insert(this.dataListadoServicios.RowCount, this.IdServicio, cbServicios.Text, this.txtCantidad.Text, this.lblPrecioUnitario_.Text);
                        this.precioTotal += dec * cant;
                    }
                }
            }

            this.lblTotal.Text = this.precioTotal.ToString();
        }

        private void cbServicios_SelectedIndexChanged(object sender, EventArgs e)
        {
            string valorBuscado = cbServicios.Text;


            // Valor que deseas buscar
            // string valorBuscado = valorSeleccionado;

            // Filtrar las filas que coinciden con el valor buscado
            DataRow[] filasEncontradas = servicios.Select("servicio = '" + valorBuscado + "'");

            // Si encontró alguna fila que coincida, puedes acceder a los datos
            if (filasEncontradas.Length > 0)
            {
                foreach (DataRow fila in filasEncontradas)
                {
                    // Acceder a los valores de otras columnas de la fila
                    this.IdServicio = Convert.ToInt32(fila["id_servicio"]);
                    this.lblPrecioUnitario_.Text = fila["precio"].ToString();
                }
            }


            // obtener precio del servicio
            // this.lblPrecioUnitario_.Text = objetoCN_servicios.dame_precio_servicio(valorSeleccionado);


        }

        private void lblTotal_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void formNuevaVenta_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F8:
                    btnRegistrar.PerformClick();
                    break;
                default:
                    // code block
                    break;
            }
        }
    }
}
