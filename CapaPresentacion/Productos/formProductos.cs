using CapaNegocio;
using System;
using System.Data;
using System.Windows.Forms;

namespace CapaPresentacion.Productos
{
    public partial class formProductos : Form
    {
        CN_Productos objetoCN_productos = new CN_Productos();

        public formProductos()
        {
            InitializeComponent();
            ListarProductos(0);
        }

        private int IdProducto;
        int desde = 0;
        int totalProductos = 0;
        DataSet dsProductos = new DataSet();

        private void Form1_Load(object sender, EventArgs e)
        {
            ListarProductos(0);
        }
        public void ListarProductos(int pDesde)
        {
            dsProductos = objetoCN_productos.ListarProductos(pDesde);
            dataListadoProductos.DataSource = dsProductos.Tables[0];
            totalProductos = Convert.ToInt32(dsProductos.Tables[1].Rows[0][0]);
            lblTotalProductos.Text = "Total de productos : " + totalProductos.ToString();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.BuscarProducto();
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

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("Realmente Desea Eliminar el producto", "Estetica", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (Opcion == DialogResult.OK)
                {
                    CN_Productos.Eliminar(this.IdProducto);
                    this.ListarProductos(0);
                    this.MensajeOk("Se elimino de forma correcta el producto");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }


        private void botonEditarListado_Click(object sender, EventArgs e)
        {
            formNuevoEditarProducto frm = new formNuevoEditarProducto(this.IdProducto, false);
            frm.MdiParent = this.MdiParent;
            frm.Show();
        }

        private void dataListadoProductos_SelectionChanged(object sender, EventArgs e)
        {
            if (dataListadoProductos.SelectedCells.Count > 0)
            {
                int selectedrowindex = dataListadoProductos.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataListadoProductos.Rows[selectedrowindex];
                this.IdProducto = Convert.ToInt32(selectedRow.Cells["id_producto"].Value);
            }
        }

        private void BuscarProducto()
        {
            this.dataListadoProductos.DataSource = objetoCN_productos.BuscarProducto(this.txtBuscar.Text);
            lblTotalProductos.Text = "Total de Registros: " + Convert.ToString(dataListadoProductos.Rows.Count);
        }

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(this, new EventArgs());
            }
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            ListarProductos(0);
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            if ((desde + 20) >= Convert.ToInt32(totalProductos))
            {
                return;
            }

            if (desde < 0)
            {
                return;
            }

            this.desde += 20;
            this.ListarProductos(this.desde);
        }

        private void btnNuevoProducto_Click_1(object sender, EventArgs e)
        {
            formNuevoEditarProducto frm = new formNuevoEditarProducto(this.IdProducto, true);
            frm.MdiParent = this.MdiParent;
            frm.Show();
        }

        private void botonEditarListado_Click_1(object sender, EventArgs e)
        {
            formNuevoEditarProducto frm = new formNuevoEditarProducto(this.IdProducto, false);
            frm.MdiParent = this.MdiParent;
            frm.Show();
        }

        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            try
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("Realmente Desea Eliminar el producto", "Estetica", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (Opcion == DialogResult.OK)
                {
                    CN_Productos.Eliminar(this.IdProducto);
                    this.ListarProductos(0);
                    this.MensajeOk("Se elimino de forma correcta el producto");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.BuscarProducto();
        }

        private void txtBuscar_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(this, new EventArgs());
            }
        }

        private void btnRefrescar_Click_1(object sender, EventArgs e)
        {
            ListarProductos(0);
            txtBuscar.Clear();
        }

        private void dataListadoProductos_SelectionChanged_1(object sender, EventArgs e)
        {
            if (dataListadoProductos.SelectedCells.Count > 0)
            {
                int selectedrowindex = dataListadoProductos.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataListadoProductos.Rows[selectedrowindex];
                this.IdProducto = Convert.ToInt32(selectedRow.Cells["id_producto"].Value);
            }
        }
    }
}
