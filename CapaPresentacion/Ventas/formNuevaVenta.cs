﻿using System;
using System.Data;
using System.Windows.Forms;
using CapaNegocio;
using CapaPresentacion.Reportes;

namespace CapaPresentacion.Ventas
{
    public partial class formNuevaVenta : Form
    {
        CN_Ventas objetoCN = new CN_Ventas();
        CN_Empleados objetoCN_empleado = new CN_Empleados();

        CN_Productos objetoCN_productos = new CN_Productos();
        CN_Clientes objetoCN_clientes = new CN_Clientes();

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
        private int IdCliente = 2;  // Cliente generico si no se especifica otro
        public string Apellidos = "Publico ";
        public string Nombres = "en general";
        public string Usuario;
#pragma warning disable CS0169 // El campo 'formNuevaVenta.tipoPago' nunca se usa
        private string tipoPago;
#pragma warning restore CS0169 // El campo 'formNuevaVenta.tipoPago' nunca se usa
        private int pDesde = 0;

        private int IdProducto;

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
            panelProductos.Visible = false;

            this.IdUsuario = IdUsuario;
            this.Usuario = usuario;
            // Creo las columnas de el listado de ventas

            this.dataListadoProductos.Columns.Add("IdProducto", "IdProducto");
            this.dataListadoProductos.Columns.Add("Codigo","Codigo");
            this.dataListadoProductos.Columns.Add("Producto", "Producto");
            this.dataListadoProductos.Columns.Add("Cantidad", "Cantidad");
            this.dataListadoProductos.Columns.Add("PrecioUnitario", "Precio unitario");

            this.dataListadoProductos.Columns["IdProducto"].Visible = false;   // Oculto "IdProducto"

            this.lblUsuario.Text = usuario;
            this.IdUsuario = IdUsuario;

            this.lblCliente.Text = this.Apellidos + this.Nombres;
            this.llenarCBTiposPago();
        }

        private void llenarCBTiposPago()
        {
            tiposPagos = objetoCN.DameTiposPago();

            cbTiposPago.DataSource = tiposPagos;

            cbTiposPago.DisplayMember = "TipoPago";
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            DataTable productos = new DataTable();
            productos.Columns.Add("IdProducto", typeof(System.Int32));
            productos.Columns.Add("Cantidad", typeof(System.Int32));


            foreach (DataGridViewRow rowGrid in this.dataListadoProductos.Rows)
            {
                DataRow row = productos.NewRow();
                row["IdProducto"] = Convert.ToDouble(rowGrid.Cells[0].Value);
                row["Cantidad"] = rowGrid.Cells[3].Value;

                productos.Rows.Add(row);
            }

            try
            {
                string rpta = "";
                if (this.dataListadoProductos.CurrentRow == null)
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

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            panelProductos.Visible = true;
            this.dataListadoProductosPanel.DataSource = objetoCN_productos.ListarProductos(this.pDesde).Tables[0];
        }

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.BuscarProductoPorCodigo();
            }
        }

        private void btnSeleccionarCliente_Click(object sender, EventArgs e)
        {
            panelClientes.Visible = !panelClientes.Visible;
            MostrarClientes();
        }

        private void btnBuscarProd_Click(object sender, EventArgs e)
        {
            this.BuscarProductoPorCodigo();
        }
        // Devuelve los datos de un solo producto. Si no devuelve un mensaje de 'no encontrado'
        private void BuscarProductoPorCodigo()
        {
            this.dtRespuesta = objetoCN_productos.BuscarProductoPorCodigo(this.txtBuscar.Text);

            if (this.dtRespuesta.Rows[0][0].ToString() == "Producto con codigo inexistente")
            {
                this.MensajeError("Producto con codigo inexistente");
                return;
            }

            // Sacar de 'respuesta' los datos para completar en el form
            this.IdProducto = Convert.ToInt32(this.dtRespuesta.Rows[0][0]);
            this.lblNombreProd.Text = this.dtRespuesta.Rows[0][1].ToString();
            this.lblPrecioUnitario.Text = this.dtRespuesta.Rows[0][3].ToString();
            

        }

        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            if (this.lblNombreProd.Text == "" || this.lblPrecioUnitario.Text == "")
            {
                MensajeError("Debe cargar un producto");
                return;
            }

            decimal dec = decimal.Parse(this.lblPrecioUnitario.Text);
            bool bandera = false;

            if (dataListadoProductos.Rows.Count == 0)
            {
                // Si no cargo la cantidad, cargo por defecto 1
                if (String.IsNullOrEmpty(this.txtCantidad.Text))
                {
                    this.dataListadoProductos.Rows.Insert(this.dataListadoProductos.RowCount, this.IdProducto, this.txtBuscar.Text, this.lblNombreProd.Text, 1, this.lblPrecioUnitario.Text);
                    this.precioTotal += dec;
                }
                else
                {
                    decimal cant = decimal.Parse(this.txtCantidad.Text);
                    this.dataListadoProductos.Rows.Insert(this.dataListadoProductos.RowCount, this.IdProducto, this.txtBuscar.Text, this.lblNombreProd.Text, this.txtCantidad.Text, this.lblPrecioUnitario.Text);
                    this.precioTotal += dec * cant;
                }
            }
            else
            {
                bandera = false;
                // Chequeo si ya existe el producto en el listado para poder aumentar la cantidad
                foreach (DataGridViewRow row in dataListadoProductos.Rows)
                {
                        if (Convert.ToInt32(row.Cells[0].Value) == this.IdProducto)
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
                        this.dataListadoProductos.Rows.Insert(this.dataListadoProductos.RowCount, this.IdProducto, this.txtBuscar.Text, this.lblNombreProd.Text, 1, this.lblPrecioUnitario.Text);
                        this.precioTotal += dec;
                    }
                    else
                    {
                        decimal cant = decimal.Parse(this.txtCantidad.Text);
                        this.dataListadoProductos.Rows.Insert(this.dataListadoProductos.RowCount, this.IdProducto, this.txtBuscar.Text, this.lblNombreProd.Text, this.txtCantidad.Text, this.lblPrecioUnitario.Text);
                        this.precioTotal += dec * cant;
                    }
                }
            }
                        
            this.lblTotal.Text = this.precioTotal.ToString();
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if (this.dataListadoProductos.CurrentRow == null)
            {
                MensajeError("Productos inexistentes");
                return;
            }
            try
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("Realmente Desea Eliminar el producto", "SGF", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (Opcion == DialogResult.OK)
                {
                    foreach (DataGridViewRow item in this.dataListadoProductos.SelectedRows)
                    {
                        decimal precio = decimal.Parse(this.dataListadoProductos.Rows[item.Index].Cells["PrecioUnitario"].Value.ToString());
                        int cantidad = int.Parse(this.dataListadoProductos.Rows[item.Index].Cells["Cantidad"].Value.ToString());

                        this.dataListadoProductos.Rows.RemoveAt(item.Index);

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
            MessageBox.Show(mensaje, "SGF", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
        //Mostrar Mensaje de Error
        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "SGF", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            formTicket frm = new formTicket(this.IdUsuario, this.IdCliente, this.dataListadoProductos);
            frm.MdiParent = this.MdiParent;
            frm.Show();

            this.Close();
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
            this.dataListadoProductosPanel.DataSource = objetoCN_productos.BuscarProducto(this.txtBuscarProductoPanel.Text);
        }

        private void btnNuevoProducto_Click(object sender, EventArgs e)
        {
            formNuevoEditarProducto frm = new formNuevoEditarProducto(0, true);
            frm.MdiParent = this.MdiParent;
            frm.Show();
        }

        private void btnSeleccionarProducto_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataListadoProductosPanel.SelectedCells.Count > 0)
                {
                    int selectedrowindex = dataListadoProductosPanel.SelectedCells[0].RowIndex;
                    DataGridViewRow selectedRow = dataListadoProductosPanel.Rows[selectedrowindex];

                    this.IdProducto = Convert.ToInt32(selectedRow.Cells["IdProducto"].Value);
                    this.lblNombreProd.Text = selectedRow.Cells["Producto"].Value.ToString();
                    this.lblPrecioUnitario.Text = selectedRow.Cells["PrecioVenta"].Value.ToString();
                    this.txtBuscar.Text = selectedRow.Cells["Codigo"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
            panelProductos.Visible = false;
        }

        private void txtBuscarProducto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.BuscarProducto();
            }
        }

        private void btnCancelarPanelProductos_Click(object sender, EventArgs e)
        {
            panelProductos.Visible = false;
        }
    }
}
