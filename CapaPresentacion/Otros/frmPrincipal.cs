using CapaNegocio;
using CapaPresentacion.Caja;
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
            //lblUsuario.Text = usuario;
            this.IdRol = IdRol;
            this.IdUsuario = IdUsuario;
            //cargarDatosEmpresa();
            // Chequear permisos y ocultar botones
            if (this.IdRol != 1) // ¿Es admin?
            {
                //this.btnUsuarios.Visible = false;
                //this.lblUsuarios.Visible = false;
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

        private void btnEmpleados_Click(object sender, EventArgs e)
        {
            formEmpleados frm = new formEmpleados();
            frm.MdiParent = this.MdiParent;
            frm.Show();
        }

        private void txtSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
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

        private void frmPrincipal_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F1:
                    formClientes frm = new formClientes();
                    frm.MdiParent = this.MdiParent;
                    frm.Show();
                    break;
                case Keys.F2:
                    formNuevaVenta frm2 = new formNuevaVenta(this.IdUsuario, this.Usuario);
                    frm2.MdiParent = this.MdiParent;
                    frm2.Show();
                    break;
                case Keys.F3:
                    formServicios frm3 = new formServicios();
                    frm3.MdiParent = this.MdiParent;
                    frm3.Show();
                    break;
                case Keys.F4:
                    formCaja frm4 = new formCaja(this.IdUsuario, this.Usuario);
                    frm4.MdiParent = this.MdiParent;
                    frm4.Show();
                    break;
                case Keys.F5:
                    formEmpleados frm5 = new formEmpleados();
                    frm5.MdiParent = this.MdiParent;
                    frm5.Show();
                    break;
                case Keys.F6:
                    formConfiguraciones frm6 = new formConfiguraciones();
                    frm6.MdiParent = this.MdiParent;
                    frm6.Show();
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

        private void btnEmpleados_Click_1(object sender, EventArgs e)
        {
            formEmpleados frm5 = new formEmpleados();
            frm5.MdiParent = this.MdiParent;
            frm5.Show();
        }

        private void btnServicios_Click(object sender, EventArgs e)
        {
            formServicios frm5 = new formServicios();
            frm5.MdiParent = this.MdiParent;
            frm5.Show();
        }
    }
}
