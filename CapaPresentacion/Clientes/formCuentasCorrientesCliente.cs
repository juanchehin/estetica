using CapaNegocio;
using System;
using System.Data;
using System.Windows.Forms;

namespace CapaPresentacion.Clientes
{
    public partial class formCuentasCorrientesCliente : Form
    {
        int id_cliente;
        string apellidos;
        string nombres;
        string telefono;
        string direccion;
        CN_Clientes objetoCN = new CN_Clientes();
        DataSet cuentas;

        public formCuentasCorrientesCliente(int IdCliente,string apellidos,string nombres,string telefono,string direccion,string dni)
        {
            InitializeComponent();

            lblCliente.Text = apellidos + ' ' + nombres;
            lblDireccionCliente.Text = direccion;
            lblTelefonoCliente.Text = telefono;
            lblDNI.Text = dni;
            lblTotalMovimientos.Text = "Total de Registros: 0";

            this.id_cliente = IdCliente;
            this.cuenta_cliente();
        }

        // listar cc del cliente + datos cliente
        public void cuenta_cliente()
        {
            dataListadoCCClientes.DataSource = objetoCN.cuentas_corrientes_cliente(this.id_cliente);
            

            if (dataListadoCCClientes.RowCount > 0)
            {
                dataListadoCCClientes.Columns[0].Visible = false;
                dataListadoCCClientes.Columns[3].Visible = false;
                dataListadoCCClientes.Columns[4].Visible = false;
                lblSaldo.Text = dataListadoCCClientes.Rows[0].Cells[4].Value.ToString();
                lblTotalMovimientos.Text = "Total de Registros: " + Convert.ToString(dataListadoCCClientes.Rows.Count);
            }
        }

        private void btnDepositar_Click(object sender, EventArgs e)
        {
            formDepositar frm = new formDepositar(this.id_cliente);
            frm.MdiParent = this.MdiParent;
            frm.Show();
            this.Close();
        }
    }
}
