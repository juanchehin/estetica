using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using CapaNegocio;
using CapaPresentacion.Productos;
using ExcelDataReader;

namespace CapaPresentacion
{
    public partial class formNuevoEditarProducto : Form
    {
        CN_Productos objetoCN = new CN_Productos();
        DataTable respuesta;
        bool bandera;
        bool IsNuevo = false;
#pragma warning disable CS0414 // El campo 'formNuevoEditarProducto.IsEditar' está asignado pero su valor nunca se usa
        bool IsEditar = false;
#pragma warning restore CS0414 // El campo 'formNuevoEditarProducto.IsEditar' está asignado pero su valor nunca se usa
        DataTable categorias;
        private string categoriaActual;
#pragma warning disable CS0169 // El campo 'formNuevoEditarProducto.IdCategoria' nunca se usa
        private int IdCategoria;
#pragma warning restore CS0169 // El campo 'formNuevoEditarProducto.IdCategoria' nunca se usa

        private int IdProducto;
        private string Producto;
        private string Codigo;
        private string PrecioCompra;
        private string PrecioVenta;
        private string Stock;
        private string Descripcion;
        private string Categoria;

        public formNuevoEditarProducto(int parametro,bool IsNuevoEditar)
        {
            InitializeComponent();
            this.IdProducto = parametro;
            this.bandera = IsNuevoEditar;

        }

        private void formNuevoEditarProducto_Load(object sender, EventArgs e)
        {
            panelCargando.Hide();
            panelNuevoEditarCategoria.Visible = false;
            this.ActiveControl = txtNombre;
            this.CargarCategoriasComboBox();
            if (this.bandera)
            {
                lblEditarNuevo.Text = "Nuevo";
                this.IsNuevo = true;
                this.IsEditar = false;
            }
            else
            {
                lblEditarNuevo.Text = "Editar";
                this.btnImportarExcel.Enabled = false;
                this.IsNuevo = false;
                this.IsEditar = true;
                this.MostrarProducto(this.IdProducto);
            }            
        }

        // Carga los valores en los campos de texto del formulario para que se modifiquen los que se desean
        private void MostrarProducto(int IdProducto)
        {
            respuesta = objetoCN.MostrarProducto(IdProducto);

            foreach (DataRow row in respuesta.Rows)
            {
                IdProducto = Convert.ToInt32(row["IdProducto"]);
                Producto = Convert.ToString(row["Producto"]);
                Codigo = Convert.ToString(row["Codigo"]);
                PrecioCompra = Convert.ToString(row["PrecioCompra"]);
                PrecioVenta = Convert.ToString(row["PrecioVenta"]);
                Stock = Convert.ToString(row["Stock"]);
                Descripcion = Convert.ToString(row["Descripcion"]);
                Categoria = Convert.ToString(row["Categoria"]);

                txtNombre.Text = Producto;
                txtCodigo.Text = Codigo;
                txtStock.Text = Stock;
                txtPrecioCompra.Text = PrecioCompra;
                txtPrecioVenta.Text = PrecioVenta;
                txtDescripcion.Text = Descripcion;
                cbCategorias.Text = Categoria;

            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
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
                                this.txtStock.Text.Trim(), this.cbCategorias.Text);
                        }
                        else
                        {
                            rpta = CN_Productos.Editar(this.IdProducto, this.txtNombre.Text.Trim(), this.txtCodigo.Text.Trim(),
                                this.txtPrecioCompra.Text.Trim(), this.txtPrecioVenta.Text.Trim(), this.txtDescripcion.Text.Trim()
                                , this.txtStock.Text.Trim(),this.cbCategorias.Text);
                    }

                        if (rpta.Equals("OK"))
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
 
        private void MensajeOk(string mensaje)
        {
            MessageBox.Show(mensaje, "SGF", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
        //Mostrar Mensaje de Error
        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "SGF", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtPrecioCompra_KeyPress(object sender, KeyPressEventArgs e)
        {

            Char chr = e.KeyChar;

            if(!Char.IsDigit(chr) && chr != 8)
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
            Console.WriteLine("Se debe mostrar cuando se cierre el formulario de editar");
            formProductos formP = new formProductos();
            formP.ListarProductos(0);
        }

        private void txtPrecioCompra_MouseHover(object sender, EventArgs e)
        {
            this.ttPrecioCompra.SetToolTip(txtPrecioCompra, "Precio al que se esta comprando actualmente el producto");
        }

        private void txtPrecioVenta_MouseHover(object sender, EventArgs e)
        {
            this.ttPrecioVenta.SetToolTip(txtPrecioCompra, "Precio al que se esta vendiendo actualmente el producto");
        }

        public void CargarCategoriasComboBox()
        {
            categorias = objetoCN.DameCategorias();
            cbCategorias.DataSource = categorias;
            cbCategorias.DisplayMember = "Categoria";
            this.categoriaActual = cbCategorias.ValueMember.ToString();
        }

        private void btnImportarExcel_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog oOpenFileDialog = new OpenFileDialog();
                oOpenFileDialog.Filter = "Excel Worbook|*.xlsx";

                if (oOpenFileDialog.ShowDialog() == DialogResult.OK)
                {

                    int i = 1;
                    int j = 0;
                    int regCargados = 0;
                    string rpta;

                    FileStream fsSource = new FileStream(oOpenFileDialog.FileName, FileMode.Open, FileAccess.Read);

                    //ExcelReaderFactory.CreateBinaryReader = formato XLS
                    //ExcelReaderFactory.CreateOpenXmlReader = formato XLSX
                    //ExcelReaderFactory.CreateReader = XLS o XLSX
                    IExcelDataReader excelReader = ExcelReaderFactory.CreateReader(fsSource);

                    DataSet result = excelReader.AsDataSet();
                    // excelReader.IsFirstRowAsColumnNames = true;
                    DataTable dt = result.Tables[0];

                    panelCargando.Show();

                    while (i < excelReader.RowCount)
                    {
                        string producto = dt.Rows[i][j].ToString();
                        j = j + 1;
                        string categoria = dt.Rows[i][j].ToString();

                        if (categoria == "" || categoria == null)
                        {
                            categoria = "Sin categoria";
                        }
                        else
                        {
                            string existe = CN_Productos.DameCategoria(categoria);

                            if (existe != "OK")
                            {
                                CN_Productos.AltaCategoria(categoria);
                            }
                        }

                        j = j + 1;
                        string codigo = dt.Rows[i][j].ToString();
                        j = j + 1;
                        string stock = dt.Rows[i][j].ToString();
                        j = j + 1;
                        string preciocompra = dt.Rows[i][j].ToString();
                        j = j + 1;
                        string precioventa = dt.Rows[i][j].ToString();
                        j = j + 1;
                        string descripcion = dt.Rows[i][j].ToString();
                        j = j + 1;

                        rpta = CN_Productos.Insertar(producto.Trim(), codigo.Trim(), preciocompra.Trim(), precioventa.Trim(),
                            descripcion.Trim(), stock.Trim(), categoria.Trim());

                        if (rpta == "Ok" || rpta == "OK")
                        {
                            regCargados++;
                        }
                        i = i + 1;
                        j = 0;
                    }

                    panelCargando.Dispose();
                    MensajeOk("Se cargaron " + regCargados + " registros en la Base de datos");
                }
            }
            catch (Exception ex)
            {
                MensajeError(ex.Message);
            }
            
        }

        private void btnAgregarCategoria_Click(object sender, EventArgs e)
        {
            panelNuevoEditarCategoria.Visible = true;
        }

        private void btnGuardarCategoria_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";
                if (this.txtCategoria.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos");
                }
                else
                {
                    rpta = CN_Productos.AltaCategoria(this.txtCategoria.Text.Trim());
                    if (rpta.Equals("OK"))
                    {
                        this.MensajeOk("Se Insertó de forma correcta el registro");
                        this.CargarCategoriasComboBox();
                        this.txtCategoria.Clear();
                    }
                    else
                    {
                        this.MensajeError(rpta);
                    }
                    panelNuevoEditarCategoria.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
    }
}
