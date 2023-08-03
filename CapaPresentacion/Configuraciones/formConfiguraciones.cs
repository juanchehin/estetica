using CapaPresentacion.Configuraciones;
using CapaPresentacion.Configuraciones.Empresa;
using System;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class formConfiguraciones : Form
    {
        public formConfiguraciones()
        {
            InitializeComponent();
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            formBackup frm = new formBackup();
            frm.Show();
        }

        private void btnImportar_Click(object sender, EventArgs e)
        {
            formImportacionBD frm = new formImportacionBD();
            frm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            formEmpresa frm = new formEmpresa();
            frm.Show();
        }

        private void btnIP_Click(object sender, EventArgs e)
        {
            formIP frm = new formIP();
            frm.Show();
        }

        private void btnBackend_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("backend.exe");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ocurrio un problema, contactese con el administrador");
            }
        }
    }
}
