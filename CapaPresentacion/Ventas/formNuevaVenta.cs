using System;
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
        CN_Productos objetoCN_productos = new CN_Productos();

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
        DataTable productos;

        private int IdServicio;
        private int IdProducto;

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

            this.dataListadoServiciosProductos.Columns.Add("id_servicio_producto", "id");
            this.dataListadoServiciosProductos.Columns.Add("servicio_producto", "Servicio/Producto");
            this.dataListadoServiciosProductos.Columns.Add("cantidad", "Cantidad");
            this.dataListadoServiciosProductos.Columns.Add("precio_unitario", "Precio unitario");
            this.dataListadoServiciosProductos.Columns.Add("tipo", "Tipo");

            this.dataListadoServiciosProductos.Columns["id_servicio_producto"].Visible = false;

            this.lblCliente.Text = this.Apellidos + this.Nombres;
            this.llenarCBTiposPago();
            this.llenarCBServicios();
            this.llenarCBProductos();

        }

        private void llenarCBTiposPago()
        {
            tiposPagos = objetoCN.DameTiposPago();

            cbTiposPago.DataSource = tiposPagos;

            cbTiposPago.DisplayMember = "tipo_pago";

            cbTiposPago.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void llenarCBServicios()
        {
            servicios = objetoCN_servicios.ListarServicios(0);

            cbServicios.DataSource = servicios;

            cbServicios.DisplayMember = "servicio";

            cbServicios.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void llenarCBProductos()
        {
            productos = objetoCN_productos.ListarProductosTable(0);

            cbProductos.DataSource = productos;

            cbProductos.DisplayMember = "producto";

            cbProductos.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (lblTotal.Text == "0")
            {
                MensajeError("Debe cargar un producto/servicio");
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

            DataTable servicios_productos = new DataTable();
            servicios_productos.Columns.Add("id_servicio_producto", typeof(System.Int32));
            servicios_productos.Columns.Add("produto_servicio", typeof(System.String));
            servicios_productos.Columns.Add("precio", typeof(System.Decimal));
            servicios_productos.Columns.Add("cantidad", typeof(System.Int32));
            servicios_productos.Columns.Add("tipo", typeof(System.String));


            foreach (DataGridViewRow rowGrid in this.dataListadoServiciosProductos.Rows)
            {
                DataRow row = servicios_productos.NewRow();
                row["id_servicio_producto"] = Convert.ToDouble(rowGrid.Cells[0].Value);
                row["produto_servicio"] = rowGrid.Cells[1].Value;
                row["cantidad"] = rowGrid.Cells[2].Value;
                row["precio"] = rowGrid.Cells[3].Value;
                row["tipo"] = rowGrid.Cells[4].Value;

                servicios_productos.Rows.Add(row);
            }

            try
            {
                string rpta = "";
                if (this.dataListadoServiciosProductos.CurrentRow == null)
                {
                    MensajeError("Servicios inexistentes");
                    return;
                }

                rpta = CN_Ventas.AltaVenta(this.IdCliente,this.IdEmpleado, cbTiposPago.Text, servicios_productos, Convert.ToDecimal(this.precioTotal.ToString()));

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
            if (this.dataListadoServiciosProductos.CurrentRow == null)
            {
                MensajeError("Servicios inexistentes");
                return;
            }
            try
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("Realmente Desea Eliminar la fila", "Estetica", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (Opcion == DialogResult.OK)
                {
                    foreach (DataGridViewRow item in this.dataListadoServiciosProductos.SelectedRows)
                    {
                        decimal precio = decimal.Parse(this.dataListadoServiciosProductos.Rows[item.Index].Cells["precio_unitario"].Value.ToString());
                        int cantidad = int.Parse(this.dataListadoServiciosProductos.Rows[item.Index].Cells["cantidad"].Value.ToString());

                        this.dataListadoServiciosProductos.Rows.RemoveAt(item.Index);

                        this.precioTotal = this.precioTotal - (precio * cantidad);
                        this.lblTotal.Text = precioTotal.ToString();
                    }

                    this.MensajeOk("Se elimino de forma correcta la fila");
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
            dataListadoServiciosProductos.DataSource = objetoCN_servicios.ListarServicios(0);
            dataListadoServiciosProductos.Columns[0].Visible = false;
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
            if (txtPrecioUnitario.Text == "0" || txtPrecioUnitario.Text == "")
            {
                MensajeError("Debe cargar un servicio");
                return;
            }

            decimal dec = decimal.Parse(this.txtPrecioUnitario.Text);

            if (dataListadoServiciosProductos.Rows.Count == 0)
            {
                // Si no cargo la cantidad, cargo por defecto 1
                if (String.IsNullOrEmpty(this.txtCantidad.Text))
                {
                    this.dataListadoServiciosProductos.Rows.Insert(this.dataListadoServiciosProductos.RowCount, this.IdServicio, cbServicios.Text, 1, this.txtPrecioUnitario.Text,"Servicio");
                    this.precioTotal += dec;
                }
                else
                {
                    decimal cant = decimal.Parse(this.txtCantidad.Text);
                    this.dataListadoServiciosProductos.Rows.Insert(this.dataListadoServiciosProductos.RowCount, this.IdServicio, cbServicios.Text, this.txtCantidad.Text, this.txtPrecioUnitario.Text, "Servicio");
                    this.precioTotal += dec * cant;
                }
            }
            else
            {
                bool bandera = false;
                // Chequeo si ya existe el producto en el listado para poder aumentar la cantidad
                foreach (DataGridViewRow row in dataListadoServiciosProductos.Rows)
                {
                    if (Convert.ToInt32(row.Cells[0].Value) == this.IdServicio)
                    {
                        bandera = true;
                        // Si no cargo la cantidad, cargo por defecto 1
                        if (String.IsNullOrEmpty(this.txtCantidad.Text))
                        {
                            row.Cells["cantidad"].Value = 1 + Convert.ToInt32(row.Cells[2].Value);
                            row.Cells["tipo"].Value = "Servicio";

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
                        this.dataListadoServiciosProductos.Rows.Insert(this.dataListadoServiciosProductos.RowCount, this.IdServicio, cbServicios.Text, 1, this.txtPrecioUnitario.Text, "Servicio");
                        this.precioTotal += dec;
                    }
                    else
                    {
                        decimal cant = decimal.Parse(this.txtCantidad.Text);
                        this.dataListadoServiciosProductos.Rows.Insert(this.dataListadoServiciosProductos.RowCount, this.IdServicio, cbServicios.Text, this.txtCantidad.Text, this.txtPrecioUnitario.Text, "Servicio");
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
                    this.txtPrecioUnitario.Text = fila["precio"].ToString();
                }
            }

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

        private void btnAgregarCliente_Click(object sender, EventArgs e)
        {
            formNuevoEditarClientes frm = new formNuevoEditarClientes(this.IdCliente, true);
            frm.MdiParent = this.MdiParent;
            frm.Show();
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            this.MostrarClientes();
        }

        private void cbProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string valorBuscado = cbProductos.Text;

            // Filtrar las filas que coinciden con el valor buscado
            DataRow[] filasEncontradas = productos.Select("producto = '" + valorBuscado + "'");

            // Si encontró alguna fila que coincida, puedes acceder a los datos
            if (filasEncontradas.Length > 0)
            {
                foreach (DataRow fila in filasEncontradas)
                {
                    // Acceder a los valores de otras columnas de la fila
                    this.IdProducto = Convert.ToInt32(fila["id_producto"]);
                    this.txtPrecioUnitario.Text = fila["precio_venta"].ToString();
                }
            }
        }

        private void btnProducto_Click(object sender, EventArgs e)
        {
            if (txtPrecioUnitario.Text == "0" || txtPrecioUnitario.Text == "")
            {
                MensajeError("Debe cargar un producto");
                return;
            }

            decimal dec = decimal.Parse(this.txtPrecioUnitario.Text);
            bool bandera = false;

            if (dataListadoServiciosProductos.Rows.Count == 0)
            {
                // Si no cargo la cantidad, cargo por defecto 1
                if (String.IsNullOrEmpty(this.txtCantidad.Text))
                {
                    this.dataListadoServiciosProductos.Rows.Insert(this.dataListadoServiciosProductos.RowCount, this.IdProducto, cbProductos.Text, 1, this.txtPrecioUnitario.Text,"Producto");
                    this.precioTotal += dec;
                }
                else
                {
                    decimal cant = decimal.Parse(this.txtCantidad.Text);
                    this.dataListadoServiciosProductos.Rows.Insert(this.dataListadoServiciosProductos.RowCount, this.IdProducto, cbProductos.Text, this.txtCantidad.Text, this.txtPrecioUnitario.Text, "Producto");
                    this.precioTotal += dec * cant;
                }
            }
            else
            {
                bandera = false;
                // Chequeo si ya existe el producto en el listado para poder aumentar la cantidad
                foreach (DataGridViewRow row in dataListadoServiciosProductos.Rows)
                {
                    if (Convert.ToInt32(row.Cells[0].Value) == this.IdProducto)
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
                        this.dataListadoServiciosProductos.Rows.Insert(this.dataListadoServiciosProductos.RowCount, this.IdProducto, cbProductos.Text, 1, this.txtPrecioUnitario.Text, "Producto");
                        this.precioTotal += dec;
                    }
                    else
                    {
                        decimal cant = decimal.Parse(this.txtCantidad.Text);
                        this.dataListadoServiciosProductos.Rows.Insert(this.dataListadoServiciosProductos.RowCount, this.IdProducto, cbProductos.Text, this.txtCantidad.Text, this.txtPrecioUnitario.Text, "Producto");
                        this.precioTotal += dec * cant;
                    }
                }
            }

            this.lblTotal.Text = this.precioTotal.ToString();
        }

        private void btnBuscarClientes_Click(object sender, EventArgs e)
        {
            this.BuscarCliente();
        }

        private void BuscarCliente()
        {
            this.dataListadoClientes.DataSource = objetoCN_clientes.BuscarCliente(this.txtBuscarCliente.Text);
        }

        private void btnBuscarEmpleado_Click(object sender, EventArgs e)
        {
            this.BuscarEmpleado();
        }
        private void BuscarEmpleado()
        {
            this.dataListadoEmpleadosPanel.DataSource = objetoCN_empleados.BuscarEmpleado(this.txtBuscarEmpleado.Text);
        }
    }
}
