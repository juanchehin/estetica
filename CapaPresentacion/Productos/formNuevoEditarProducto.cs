using CapaNegocio;
using System;
using System.Data;
using System.Windows.Forms;

namespace CapaPresentacion.Productos
{
    public partial class formNuevoEditarProducto : Form
    {
        CN_Productos objetoCN = new CN_Productos();
        DataTable respuesta;
        bool bandera;
        bool IsNuevo = false;
        bool IsEditar = false;

        private int IdProducto;
        private string Producto;
        private string Codigo;
        private string PrecioCompra;
        private string PrecioVenta;
        private string Stock;
        private string Descripcion;

        public formNuevoEditarProducto(int parametro, bool IsNuevoEditar)
        {
            InitializeComponent();
            this.IdProducto = parametro;
            this.bandera = IsNuevoEditar;
        }

        private void MostrarProducto(int IdProducto)
        {
            respuesta = objetoCN.MostrarProducto(IdProducto);

            foreach (DataRow row in respuesta.Rows)
            {
                IdProducto = Convert.ToInt32(row["id_producto"]);
                Producto = Convert.ToString(row["producto"]);
                Codigo = Convert.ToString(row["codigo"]);
                PrecioCompra = Convert.ToString(row["precio_compra"]);
                PrecioVenta = Convert.ToString(row["precio_venta"]);
                Stock = Convert.ToString(row["stock"]);
                Descripcion = Convert.ToString(row["descripcion"]);

                txtNombre.Text = Producto;
                txtCodigo.Text = Codigo;
                txtStock.Text = Stock;
                txtPrecioCompra.Text = PrecioCompra;
                txtPrecioVenta.Text = PrecioVenta;
                txtDescripcion.Text = Descripcion;
                //cbCategorias.Text = Categoria;

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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtPrecioCompra_KeyPress(object sender, KeyPressEventArgs e)
        {
            Char chr = e.KeyChar;

            if (!Char.IsDigit(chr) && chr != 8)
            {
                e.Handled = true;
                MessageBox.Show("Debe ingresar valores numericos ");
            }
        }

        private void txtStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            Char chr = e.KeyChar;

            if (!Char.IsDigit(chr) && chr != 8)
            {
                e.Handled = true;
                MessageBox.Show("Debe ingresar valores numericos ");
            }
        }

        private void txtPrecioVenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            Char chr = e.KeyChar;

            if (!Char.IsDigit(chr) && chr != 8)
            {
                e.Handled = true;
                MessageBox.Show("Debe ingresar valores numericos ");
            }
        }

        private void formNuevoEditarProducto_FormClosed(object sender, FormClosedEventArgs e)
        {
            formProductos formP = new formProductos();
            formP.ListarProductos(0);
        }

        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";
                if (this.txtNombre.Text == string.Empty || this.txtStock.Text == string.Empty || this.txtPrecioCompra.Text == string.Empty || this.txtPrecioVenta.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos");
                }
                else
                {
                    if (this.IsNuevo)
                    {
                        rpta = CN_Productos.Insertar(this.txtNombre.Text.Trim(), this.txtCodigo.Text.Trim(), this.txtPrecioCompra.Text.Trim(),
                            this.txtPrecioVenta.Text.Trim(), this.txtDescripcion.Text.Trim(),
                            this.txtStock.Text.Trim());
                    }
                    else
                    {
                        rpta = CN_Productos.Editar(this.IdProducto, this.txtNombre.Text.Trim(), this.txtCodigo.Text.Trim(),
                            this.txtPrecioCompra.Text.Trim(), this.txtPrecioVenta.Text.Trim(), this.txtDescripcion.Text.Trim()
                            , this.txtStock.Text.Trim());
                    }

                    if (rpta.Equals("Ok"))
                    {
                        if (this.IsNuevo)
                        {
                            this.MensajeOk("Se Insertó de forma correcta el registro");
                        }
                        else
                        {
                            this.MensajeOk("Se Actualizó de forma correcta el registro");
                        }
                    }
                    else
                    {
                        this.MensajeError(rpta);
                    }
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void formNuevoEditarProducto_Load(object sender, EventArgs e)
        {
            this.ActiveControl = txtNombre;
            if (this.bandera)
            {
                lblEditarNuevo.Text = "Nuevo";
                this.IsNuevo = true;
                this.IsEditar = false;
            }
            else
            {
                lblEditarNuevo.Text = "Editar";
                this.IsNuevo = false;
                this.IsEditar = true;
                this.MostrarProducto(this.IdProducto);
            }
        }
    }
}
