namespace CapaPresentacion
{
    partial class frmPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrincipal));
            this.ttAyuda = new System.Windows.Forms.ToolTip(this.components);
            this.btnConfiguracion = new System.Windows.Forms.Button();
            this.btnAyuda = new System.Windows.Forms.Button();
            this.btnCaja = new System.Windows.Forms.Button();
            this.btnVentas = new System.Windows.Forms.Button();
            this.btnClientes = new System.Windows.Forms.Button();
            this.pbImagenEmpresa = new System.Windows.Forms.PictureBox();
            this.btnCalculadora = new System.Windows.Forms.Button();
            this.btnServicios = new System.Windows.Forms.Button();
            this.btnEmpleados = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbImagenEmpresa)).BeginInit();
            this.SuspendLayout();
            // 
            // btnConfiguracion
            // 
            this.btnConfiguracion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfiguracion.Image = ((System.Drawing.Image)(resources.GetObject("btnConfiguracion.Image")));
            this.btnConfiguracion.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnConfiguracion.Location = new System.Drawing.Point(644, 209);
            this.btnConfiguracion.Name = "btnConfiguracion";
            this.btnConfiguracion.Size = new System.Drawing.Size(196, 160);
            this.btnConfiguracion.TabIndex = 6;
            this.btnConfiguracion.Text = "Configuraciones - F6";
            this.btnConfiguracion.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnConfiguracion.UseVisualStyleBackColor = true;
            this.btnConfiguracion.Click += new System.EventHandler(this.btnConfiguracion_Click);
            // 
            // btnAyuda
            // 
            this.btnAyuda.Image = global::CapaPresentacion.Properties.Resources.info;
            this.btnAyuda.Location = new System.Drawing.Point(795, 403);
            this.btnAyuda.Name = "btnAyuda";
            this.btnAyuda.Size = new System.Drawing.Size(45, 42);
            this.btnAyuda.TabIndex = 8;
            this.btnAyuda.UseVisualStyleBackColor = true;
            this.btnAyuda.Click += new System.EventHandler(this.button1_Click_1);
            this.btnAyuda.MouseHover += new System.EventHandler(this.button1_MouseHover);
            // 
            // btnCaja
            // 
            this.btnCaja.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCaja.Image = ((System.Drawing.Image)(resources.GetObject("btnCaja.Image")));
            this.btnCaja.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCaja.Location = new System.Drawing.Point(254, 209);
            this.btnCaja.Name = "btnCaja";
            this.btnCaja.Size = new System.Drawing.Size(198, 160);
            this.btnCaja.TabIndex = 4;
            this.btnCaja.Text = "Caja - F4";
            this.btnCaja.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCaja.UseVisualStyleBackColor = true;
            this.btnCaja.Click += new System.EventHandler(this.btnCaja_Click);
            // 
            // btnVentas
            // 
            this.btnVentas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVentas.Image = ((System.Drawing.Image)(resources.GetObject("btnVentas.Image")));
            this.btnVentas.Location = new System.Drawing.Point(458, 39);
            this.btnVentas.Name = "btnVentas";
            this.btnVentas.Size = new System.Drawing.Size(180, 164);
            this.btnVentas.TabIndex = 2;
            this.btnVentas.Text = "Ventas - F2";
            this.btnVentas.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnVentas.UseVisualStyleBackColor = true;
            this.btnVentas.Click += new System.EventHandler(this.btnVentas_Click);
            // 
            // btnClientes
            // 
            this.btnClientes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClientes.Image = ((System.Drawing.Image)(resources.GetObject("btnClientes.Image")));
            this.btnClientes.Location = new System.Drawing.Point(254, 39);
            this.btnClientes.Name = "btnClientes";
            this.btnClientes.Size = new System.Drawing.Size(198, 164);
            this.btnClientes.TabIndex = 1;
            this.btnClientes.Text = "Clientes - F1";
            this.btnClientes.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnClientes.UseVisualStyleBackColor = true;
            this.btnClientes.Click += new System.EventHandler(this.button1_Click);
            // 
            // pbImagenEmpresa
            // 
            this.pbImagenEmpresa.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pbImagenEmpresa.ErrorImage = null;
            this.pbImagenEmpresa.Image = ((System.Drawing.Image)(resources.GetObject("pbImagenEmpresa.Image")));
            this.pbImagenEmpresa.Location = new System.Drawing.Point(21, 39);
            this.pbImagenEmpresa.Name = "pbImagenEmpresa";
            this.pbImagenEmpresa.Size = new System.Drawing.Size(202, 143);
            this.pbImagenEmpresa.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbImagenEmpresa.TabIndex = 3;
            this.pbImagenEmpresa.TabStop = false;
            // 
            // btnCalculadora
            // 
            this.btnCalculadora.Image = ((System.Drawing.Image)(resources.GetObject("btnCalculadora.Image")));
            this.btnCalculadora.Location = new System.Drawing.Point(12, 391);
            this.btnCalculadora.Name = "btnCalculadora";
            this.btnCalculadora.Size = new System.Drawing.Size(63, 54);
            this.btnCalculadora.TabIndex = 7;
            this.btnCalculadora.UseVisualStyleBackColor = true;
            this.btnCalculadora.Click += new System.EventHandler(this.btnCalculadora_Click);
            // 
            // btnServicios
            // 
            this.btnServicios.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnServicios.Image = ((System.Drawing.Image)(resources.GetObject("btnServicios.Image")));
            this.btnServicios.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnServicios.Location = new System.Drawing.Point(644, 39);
            this.btnServicios.Name = "btnServicios";
            this.btnServicios.Size = new System.Drawing.Size(196, 164);
            this.btnServicios.TabIndex = 3;
            this.btnServicios.Text = "Servicios - F3";
            this.btnServicios.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnServicios.UseVisualStyleBackColor = true;
            this.btnServicios.Click += new System.EventHandler(this.btnServicios_Click);
            // 
            // btnEmpleados
            // 
            this.btnEmpleados.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEmpleados.Image = ((System.Drawing.Image)(resources.GetObject("btnEmpleados.Image")));
            this.btnEmpleados.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnEmpleados.Location = new System.Drawing.Point(458, 209);
            this.btnEmpleados.Name = "btnEmpleados";
            this.btnEmpleados.Size = new System.Drawing.Size(180, 160);
            this.btnEmpleados.TabIndex = 5;
            this.btnEmpleados.Text = "Empleados - F5";
            this.btnEmpleados.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEmpleados.UseVisualStyleBackColor = true;
            this.btnEmpleados.Click += new System.EventHandler(this.btnEmpleados_Click_1);
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(858, 457);
            this.Controls.Add(this.btnEmpleados);
            this.Controls.Add(this.btnServicios);
            this.Controls.Add(this.btnCalculadora);
            this.Controls.Add(this.btnConfiguracion);
            this.Controls.Add(this.btnAyuda);
            this.Controls.Add(this.btnCaja);
            this.Controls.Add(this.btnVentas);
            this.Controls.Add(this.btnClientes);
            this.Controls.Add(this.pbImagenEmpresa);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPrincipal";
            this.Text = "                                                                                 " +
    "                                                      ..:: Estetica ::..";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmPrincipal_FormClosing);
            this.Load += new System.EventHandler(this.frmPrincipal_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmPrincipal_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pbImagenEmpresa)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbImagenEmpresa;
        private System.Windows.Forms.Button btnClientes;
        private System.Windows.Forms.Button btnVentas;
        private System.Windows.Forms.Button btnCaja;
        private System.Windows.Forms.Button btnAyuda;
        private System.Windows.Forms.ToolTip ttAyuda;
        private System.Windows.Forms.Button btnConfiguracion;
        private System.Windows.Forms.Button btnCalculadora;
        private System.Windows.Forms.Button btnServicios;
        private System.Windows.Forms.Button btnEmpleados;
    }
}