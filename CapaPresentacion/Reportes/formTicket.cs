﻿using Microsoft.Reporting.WinForms;
using System;
using System.Collections.ObjectModel;
using System.Windows.Forms;

namespace CapaPresentacion.Reportes
{
    public partial class formTicket : Form
    {
        DataGridView dataListadoProductos = new DataGridView();
        public formTicket(int pIdUsuario,int IdCliente, DataGridView pProductos)
        {
            InitializeComponent();
            this.dataListadoProductos = pProductos;
        }


        private void formTicket_Load(object sender, EventArgs e)
        {
            var ticketVenta = new ObservableCollection<TicketVenta>();

            foreach (DataGridViewRow dr in this.dataListadoProductos.Rows)
            {
                string producto = dr.Cells[2].Value.ToString();
                string cantidad = dr.Cells[3].Value.ToString();
                decimal precio = Convert.ToDecimal(dr.Cells[4].Value);

                ticketVenta.Add(new TicketVenta { Producto = producto, Cantidad = cantidad, Precio = precio });
            }

            // this.reportViewer1.LocalReport.ReportPath = "../../Reportes/TicketVenta.rdlc";
            this.reportViewer1.LocalReport.ReportPath = "TicketVenta.rdlc"; // Para publicacion del soft
            ReportDataSource source = new ReportDataSource("DataSetTicketVenta", ticketVenta);
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(source);
            this.reportViewer1.RefreshReport();

        }
    }
}
