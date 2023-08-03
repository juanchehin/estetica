using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion.Movimientos
{
    public partial class formVentas : Form
    {
        public formVentas()
        {
            InitializeComponent();
        }


        private void btnMisVentas_Click(object sender, EventArgs e)
        {
            formMisVentas frm = new formMisVentas();
            frm.MdiParent = this.MdiParent;
            frm.Show();
        }

        private void btnNuevaVenta_Click(object sender, EventArgs e)
        {
            //formNuevaVenta frm = new formNuevaVenta();
            //frm.MdiParent = this.MdiParent;
            //frm.Show();
        }
    }
}
