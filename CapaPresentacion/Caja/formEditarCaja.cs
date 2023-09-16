using CapaNegocio;
using System;
using System.Data;
using System.Windows.Forms;

namespace CapaPresentacion.Caja
{
    public partial class formEditarCaja : Form
    {
        CN_Ventas objetoCN = new CN_Ventas();
        DataSet datos_venta;

        CN_Clientes objetoCN_clientes = new CN_Clientes();
        CN_Empleados objetoCN_empleados = new CN_Empleados();

        // Cliente
        private int IdTransaccion;  // Cliente generico si no se especifica otro

        public string Apellidos = "Publico ";
        public string Nombres = "en general";
        // Empleado
        private int IdEmpleado = 2;  // Cliente generico si no se especifica otro
        public string ApellidosEmpleado = "Empleado";
        public string NombresEmpleado = "";
        private decimal precioTotal = 0;
        private int IdCliente;  // Cliente generico si no se especifica otro

        DataTable servicios;
        DataTable productos;
        DataTable tiposPagos;

        //
        public string Usuario;
        private int IdServicio;
        private int IdProducto;

        public formEditarCaja(int IdTransaccion)
        {
            InitializeComponent();

            panelClientes.Visible = false;
            panelVuelto.Visible = false;
            panelEmpleados.Visible = false;

            this.IdTransaccion = IdTransaccion;

            cbServicios.Items.Clear();

            this.dataListadoServiciosProductos.Columns.Add("id_servicio_producto", "id");
            this.dataListadoServiciosProductos.Columns.Add("servicio_producto", "Servicio/Producto");
            //this.dataListadoServiciosProductos.Columns.Add("producto", "producto");
            this.dataListadoServiciosProductos.Columns.Add("cantidad", "Cantidad");
            this.dataListadoServiciosProductos.Columns.Add("precio_unitario", "Precio unitario");
            this.dataListadoServiciosProductos.Columns.Add("tipo", "Tipo");

            this.dataListadoServiciosProductos.Columns["id_servicio_producto"].Visible = false;

            this.cargar_datos();
        }

        private void cargar_datos()
        {
            datos_venta = objetoCN.cargar_datos(this.IdTransaccion.ToString());

            if (!(datos_venta != null && datos_venta.Tables.Count > 0))
            {
                MensajeError("Ocurrio un error. Contactese con el administrador");
                return;
            }

            DataTable datos_transaccion = datos_venta.Tables[0];
            DataTable datos_servicios = datos_venta.Tables[1];
            DataTable datos_productos = datos_venta.Tables[2];
            DataTable datos_tipos_pago = datos_venta.Tables[3];
            DataTable datos_cliente = datos_venta.Tables[4];
            DataTable datos_empleado = datos_venta.Tables[5];
            DataTable datos_tipo_pago_trans = datos_venta.Tables[6];
            DataTable productos_productos_transaccion = datos_venta.Tables[7];
            DataTable productos_servicios_transaccion = datos_venta.Tables[8];

            // Cargo los servicios
            cbServicios.DataSource = datos_servicios;

            servicios = datos_servicios;

            cbServicios.DisplayMember = "servicio";

            cbServicios.DropDownStyle = ComboBoxStyle.DropDownList;

            // Cargo los productos
            cbProductos.DataSource = datos_productos;

            productos = datos_productos;

            cbProductos.DisplayMember = "producto";

            cbProductos.DropDownStyle = ComboBoxStyle.DropDownList;

            //Cargo los tipos de pago
            cbTiposPago.DataSource = datos_tipos_pago;

            tiposPagos = datos_tipos_pago;

            cbTiposPago.DisplayMember = "tipo_pago";

            cbTiposPago.DropDownStyle = ComboBoxStyle.DropDownList;


            // Datos transaccion
            lblTransaccion.Text = this.IdTransaccion.ToString();
            lblTotal.Text = datos_transaccion.Rows[0][0].ToString();
            this.precioTotal = Convert.ToDecimal(datos_transaccion.Rows[0][0].ToString());

            // Datos cliente
            this.IdCliente = Convert.ToInt32(datos_cliente.Rows[0][1].ToString());
            lblCliente.Text = datos_cliente.Rows[0][2].ToString() + " " + datos_cliente.Rows[0][3].ToString();

            // Datos empleado
            this.IdEmpleado = Convert.ToInt32(datos_empleado.Rows[0][0].ToString());
            lblEmpleado.Text = datos_empleado.Rows[0][2].ToString() + " " + datos_empleado.Rows[0][3].ToString();


            // Setear el tipo de pago
            string valorDeseado = datos_tipo_pago_trans.Rows[0][1].ToString();
            cbTiposPago.Text = valorDeseado;

            // Cargo los productos que se habian cargado en la transaccion
            foreach (DataRow row in productos_productos_transaccion.Rows)
            {
                this.dataListadoServiciosProductos.Rows.Insert(this.dataListadoServiciosProductos.RowCount, row["id_producto"], row["producto"], row["cantidad"], row["precio_venta"], "Producto");
                
            }
            foreach (DataRow row in productos_servicios_transaccion.Rows)
            {
                this.dataListadoServiciosProductos.Rows.Insert(this.dataListadoServiciosProductos.RowCount, row["id_servicio"], row["servicio"], row["cantidad"], row["precio"], "Servicio");
            }

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            //try
            //{
                //string rpta = "";
                //if (this.txtMonto.Text == string.Empty)
                //{
                //    MensajeError("Falta ingresar algunos datos");
                //}
                //else
                //{
                //    var año = this.dtpFechaTransaccion.Value.Year;
                //    var mes = this.dtpFechaTransaccion.Value.Month;
                //    var dia = this.dtpFechaTransaccion.Value.Day;
                //    var fecha = año + "-" + mes + "-" + dia;

                //    rpta = CN_Ventas.Editar(this.IdTransaccion, fecha, this.cbEmpleado.Text,this.cbCliente.Text,this.lbObservaciones.Text.Trim());

                //    if (rpta.Equals("Ok"))
                //    {
                //        this.MensajeOk("Se Actualizó de forma correcta el registro");
                        
                //        this.Close();
                //    }

                //    else
                //    {
                //        this.MensajeError(rpta);
                //    }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message + ex.StackTrace);
            //}
        }

        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Estetica", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void MensajeOk(string mensaje)
        {
            MessageBox.Show(mensaje, "Estetica", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if (this.dataListadoServiciosProductos.CurrentRow == null)
            {
                MensajeError("Filas inexistentes");
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

        private void btnSeleccionarCliente_Click(object sender, EventArgs e)
        {
            panelClientes.Visible = !panelClientes.Visible;
            MostrarClientes();
        }

        private void btnSeleccionarEmpleado_Click(object sender, EventArgs e)
        {
            panelEmpleados.Visible = !panelEmpleados.Visible;
            MostrarEmpleados();
        }

        public void MostrarClientes()
        {
            dataListadoClientes.DataSource = objetoCN_clientes.MostrarClientes(0);
            dataListadoClientes.Columns[0].Visible = false;
        }

        public void MostrarEmpleados()
        {
            dataListadoEmpleadosPanel.DataSource = objetoCN_empleados.ListarEmpleados(0);
            dataListadoEmpleadosPanel.Columns[0].Visible = false;
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
                    MensajeError("Filas inexistentes");
                    return;
                }

                rpta = CN_Ventas.EditarVenta(this.IdTransaccion.ToString(),this.IdCliente, this.IdEmpleado, cbTiposPago.Text, servicios_productos, Convert.ToDecimal(this.precioTotal.ToString()));

                if (rpta.Equals("Ok"))
                {
                    this.MensajeOk("Venta Modificada");
                    this.btnCancelar.PerformClick();
                    this.Close();
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

        private void cbServicios_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(servicios != null)
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
                        //this.lblPrecioUnitario_.Text = fila["precio"].ToString();
                    }
                }
            }
          
        }

        private void cbProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (productos != null)
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
                        //this.lblPrecioUnitario_.Text = fila["precio"].ToString();
                    }
                }
            }
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

        private void btnAgregarProducto_Click(object sender, EventArgs e)
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
    }
}
