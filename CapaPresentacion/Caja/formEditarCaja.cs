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


        //
        public string Usuario;

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

            cbServicios.DisplayMember = "servicio";

            cbServicios.DropDownStyle = ComboBoxStyle.DropDownList;

            // Cargo los productos
            cbProductos.DataSource = datos_productos;

            cbProductos.DisplayMember = "producto";

            cbProductos.DropDownStyle = ComboBoxStyle.DropDownList;

            //Cargo los tipos de pago
            cbTiposPago.DataSource = datos_tipos_pago;

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


    }
}
