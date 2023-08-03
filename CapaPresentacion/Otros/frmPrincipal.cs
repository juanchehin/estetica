using CapaNegocio;
using CapaPresentacion.Caja;
using CapaPresentacion.Compras;
using CapaPresentacion.Estadisticas;
using CapaPresentacion.Otros;
using CapaPresentacion.Ventas;
using System;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class frmPrincipal : Form
    {
        string Usuario;
        int IdRol;
        int IdUsuario;

        CN_Configuraciones objetoCN_configuraciones = new CN_Configuraciones();
        DataTable resp;
        string rutaImagen = "";

        public frmPrincipal(int IdUsuario,string usuario,int IdRol)
        {
            InitializeComponent();
            this.Usuario = usuario;
            lblUsuario.Text = usuario;
            this.IdRol = IdRol;
            this.IdUsuario = IdUsuario;
            cargarDatosEmpresa();
            // Chequear permisos y ocultar botones
            if (this.IdRol != 1) // ¿Es admin?
            {
                this.btnUsuarios.Visible = false;
                //this.lblUsuarios.Visible = false;
                this.btnEstadisticas.Visible = false;
                //this.lblEstadisticas.Visible = false;
            }
        }

        private void cargarDatosEmpresa()
        {
            resp = objetoCN_configuraciones.dameDatosEmpresa();

            foreach (DataRow row in resp.Rows)
            {
                pbImagenEmpresa.ImageLocation = Convert.ToString(row["imagen"]);
                this.rutaImagen = Convert.ToString(row["imagen"]);
            }

            if (!Directory.Exists(this.rutaImagen))
            {
                pbImagenEmpresa.Image = Properties.Resources.logo;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            formClientes frm = new formClientes();
            frm.MdiParent = this.MdiParent;
            frm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            formProductos frm = new formProductos();
            frm.MdiParent = this.MdiParent;
            frm.Show();
        }

        private void btnEmpleados_Click(object sender, EventArgs e)
        {
            formUsuarios frm = new formUsuarios();
            frm.MdiParent = this.MdiParent;
            frm.Show();
        }

        private void txtSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnProveedores_Click(object sender, EventArgs e)
        {
            formProveedores frm = new formProveedores();
            frm.MdiParent = this.MdiParent;
            frm.Show();
        }

        private void btnCompras_Click(object sender, EventArgs e)
        {
            formNuevaCompra frm = new formNuevaCompra(this.IdUsuario, this.Usuario);
            frm.MdiParent = this.MdiParent;
            frm.Show();
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            formNuevaVenta frm = new formNuevaVenta(this.IdUsuario,this.Usuario);
            frm.MdiParent = this.MdiParent;
            frm.Show();
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            formInformacion frm = new formInformacion();
            frm.Show();
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            this.ttAyuda.SetToolTip(btnAyuda, "Ayuda");
        }

        private void frmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnConfiguracion_Click(object sender, EventArgs e)
        {
            formConfiguraciones frm = new formConfiguraciones();
            frm.Show();
        }

        private void btnCaja_Click(object sender, EventArgs e)
        {
            formCaja frm = new formCaja(this.IdUsuario,this.Usuario);
            frm.Show();
        }

        private void btnCalculadora_Click(object sender, EventArgs e)
        {
            formCalculadora frm = new formCalculadora();
            frm.Show();
        }

        private void btnEstadisticas_Click(object sender, EventArgs e)
        {
            formEstadisticas frm = new formEstadisticas();
            frm.Show();
        }

        private void frmPrincipal_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F1:
                    formProductos frm = new formProductos();
                    frm.MdiParent = this.MdiParent;
                    frm.Show();
                    break;
                case Keys.F2:
                    formProveedores frm1 = new formProveedores();
                    frm1.MdiParent = this.MdiParent;
                    frm1.Show();
                    break;
                case Keys.F3:
                    formUsuarios frm2 = new formUsuarios();
                    frm2.MdiParent = this.MdiParent;
                    frm2.Show();
                    break;
                case Keys.F4:
                    formEstadisticas frm3 = new formEstadisticas();
                    frm3.MdiParent = this.MdiParent;
                    frm3.Show();
                    break;
                case Keys.F5:
                    formConfiguraciones frm4 = new formConfiguraciones();
                    frm4.MdiParent = this.MdiParent;
                    frm4.Show();
                    break;
                case Keys.F6:
                    formCaja frm5 = new formCaja(this.IdUsuario,this.Usuario);
                    frm5.MdiParent = this.MdiParent;
                    frm5.Show();
                    break;
                case Keys.F7:
                    formNuevaCompra frm6 = new formNuevaCompra(this.IdUsuario, this.Usuario);
                    frm6.MdiParent = this.MdiParent;
                    frm6.Show();
                    break;
                case Keys.F8:
                    formNuevaVenta frm7 = new formNuevaVenta(this.IdUsuario, this.Usuario);
                    frm7.MdiParent = this.MdiParent;
                    frm7.Show();
                    break;
                case Keys.F9:
                    formClientes frm9 = new formClientes();
                    frm9.MdiParent = this.MdiParent;
                    frm9.Show();
                    break;
                default:
                    // code block
                    break;
            }

        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            //this.KeyDown += new KeyEventHandler(frmPrincipal_KeyDown);
        }
    }
}
