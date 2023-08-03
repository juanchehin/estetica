namespace CapaPresentacion.Caja
{
    partial class formCaja
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formCaja));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnRefrescar = new System.Windows.Forms.Button();
            this.dataListadoCaja = new System.Windows.Forms.DataGridView();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.dtFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.dtFechaFin = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblEstado = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnAbrirCaja = new System.Windows.Forms.Button();
            this.btnCierreCaja = new System.Windows.Forms.Button();
            this.panelMontoInicial = new System.Windows.Forms.Panel();
            this.btnOmitir = new System.Windows.Forms.Button();
            this.txtMontoInicial = new System.Windows.Forms.TextBox();
            this.btnCancelarPanel = new System.Windows.Forms.Button();
            this.btnAceptarPanel = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataListadoCaja)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panelMontoInicial.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.Image = global::CapaPresentacion.Properties.Resources.logo;
            this.pictureBox1.Location = new System.Drawing.Point(10, 9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(71, 66);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 29;
            this.pictureBox1.TabStop = false;
            // 
            // btnRefrescar
            // 
            this.btnRefrescar.Image = global::CapaPresentacion.Properties.Resources.refresh;
            this.btnRefrescar.Location = new System.Drawing.Point(683, 88);
            this.btnRefrescar.Name = "btnRefrescar";
            this.btnRefrescar.Size = new System.Drawing.Size(33, 38);
            this.btnRefrescar.TabIndex = 42;
            this.btnRefrescar.UseVisualStyleBackColor = true;
            this.btnRefrescar.Click += new System.EventHandler(this.btnRefrescar_Click);
            // 
            // dataListadoCaja
            // 
            this.dataListadoCaja.AllowUserToAddRows = false;
            this.dataListadoCaja.AllowUserToDeleteRows = false;
            this.dataListadoCaja.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataListadoCaja.Location = new System.Drawing.Point(12, 152);
            this.dataListadoCaja.MultiSelect = false;
            this.dataListadoCaja.Name = "dataListadoCaja";
            this.dataListadoCaja.ReadOnly = true;
            this.dataListadoCaja.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataListadoCaja.Size = new System.Drawing.Size(704, 312);
            this.dataListadoCaja.TabIndex = 35;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox2.Image = global::CapaPresentacion.Properties.Resources.cash_register;
            this.pictureBox2.Location = new System.Drawing.Point(651, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(65, 70);
            this.pictureBox2.TabIndex = 45;
            this.pictureBox2.TabStop = false;
            // 
            // dtFechaInicio
            // 
            this.dtFechaInicio.Location = new System.Drawing.Point(13, 100);
            this.dtFechaInicio.Name = "dtFechaInicio";
            this.dtFechaInicio.Size = new System.Drawing.Size(200, 20);
            this.dtFechaInicio.TabIndex = 46;
            this.dtFechaInicio.ValueChanged += new System.EventHandler(this.dtFechaInicio_ValueChanged);
            // 
            // dtFechaFin
            // 
            this.dtFechaFin.Location = new System.Drawing.Point(244, 100);
            this.dtFechaFin.Name = "dtFechaFin";
            this.dtFechaFin.Size = new System.Drawing.Size(200, 20);
            this.dtFechaFin.TabIndex = 47;
            this.dtFechaFin.ValueChanged += new System.EventHandler(this.dtFechaFin_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 48;
            this.label1.Text = "Fecha inicio :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(244, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 49;
            this.label2.Text = "Fecha fin :";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft YaHei", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(87, 12);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(102, 27);
            this.label10.TabIndex = 50;
            this.label10.Text = "Usuario : ";
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Font = new System.Drawing.Font("Microsoft YaHei", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstado.Location = new System.Drawing.Point(561, 12);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(69, 27);
            this.lblEstado.TabIndex = 53;
            this.lblEstado.Text = "label3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft YaHei", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(462, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 27);
            this.label4.TabIndex = 52;
            this.label4.Text = "Estado : ";
            // 
            // btnAbrirCaja
            // 
            this.btnAbrirCaja.Location = new System.Drawing.Point(11, 470);
            this.btnAbrirCaja.Name = "btnAbrirCaja";
            this.btnAbrirCaja.Size = new System.Drawing.Size(75, 50);
            this.btnAbrirCaja.TabIndex = 54;
            this.btnAbrirCaja.Text = "Abrir caja";
            this.btnAbrirCaja.UseVisualStyleBackColor = true;
            this.btnAbrirCaja.Click += new System.EventHandler(this.btnAbrirCaja_Click);
            // 
            // btnCierreCaja
            // 
            this.btnCierreCaja.Location = new System.Drawing.Point(92, 470);
            this.btnCierreCaja.Name = "btnCierreCaja";
            this.btnCierreCaja.Size = new System.Drawing.Size(75, 50);
            this.btnCierreCaja.TabIndex = 55;
            this.btnCierreCaja.Text = "Cierre caja";
            this.btnCierreCaja.UseVisualStyleBackColor = true;
            this.btnCierreCaja.Click += new System.EventHandler(this.btnCierreCaja_Click);
            // 
            // panelMontoInicial
            // 
            this.panelMontoInicial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelMontoInicial.Controls.Add(this.btnOmitir);
            this.panelMontoInicial.Controls.Add(this.txtMontoInicial);
            this.panelMontoInicial.Controls.Add(this.btnCancelarPanel);
            this.panelMontoInicial.Controls.Add(this.btnAceptarPanel);
            this.panelMontoInicial.Controls.Add(this.label3);
            this.panelMontoInicial.Location = new System.Drawing.Point(233, 126);
            this.panelMontoInicial.Name = "panelMontoInicial";
            this.panelMontoInicial.Size = new System.Drawing.Size(348, 175);
            this.panelMontoInicial.TabIndex = 56;
            // 
            // btnOmitir
            // 
            this.btnOmitir.Location = new System.Drawing.Point(261, 63);
            this.btnOmitir.Name = "btnOmitir";
            this.btnOmitir.Size = new System.Drawing.Size(75, 23);
            this.btnOmitir.TabIndex = 4;
            this.btnOmitir.Text = "Omitir";
            this.btnOmitir.UseVisualStyleBackColor = true;
            this.btnOmitir.Click += new System.EventHandler(this.btnOmitir_Click);
            // 
            // txtMontoInicial
            // 
            this.txtMontoInicial.Location = new System.Drawing.Point(144, 65);
            this.txtMontoInicial.Name = "txtMontoInicial";
            this.txtMontoInicial.Size = new System.Drawing.Size(100, 20);
            this.txtMontoInicial.TabIndex = 3;
            // 
            // btnCancelarPanel
            // 
            this.btnCancelarPanel.Location = new System.Drawing.Point(261, 134);
            this.btnCancelarPanel.Name = "btnCancelarPanel";
            this.btnCancelarPanel.Size = new System.Drawing.Size(75, 23);
            this.btnCancelarPanel.TabIndex = 2;
            this.btnCancelarPanel.Text = "Cancelar";
            this.btnCancelarPanel.UseVisualStyleBackColor = true;
            this.btnCancelarPanel.Click += new System.EventHandler(this.btnCancelarPanel_Click);
            // 
            // btnAceptarPanel
            // 
            this.btnAceptarPanel.Location = new System.Drawing.Point(14, 134);
            this.btnAceptarPanel.Name = "btnAceptarPanel";
            this.btnAceptarPanel.Size = new System.Drawing.Size(75, 23);
            this.btnAceptarPanel.TabIndex = 1;
            this.btnAceptarPanel.Text = "Aceptar";
            this.btnAceptarPanel.UseVisualStyleBackColor = true;
            this.btnAceptarPanel.Click += new System.EventHandler(this.btnAceptarPanel_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Ingrese el monto inicial : ";
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUser.Location = new System.Drawing.Point(195, 17);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(58, 20);
            this.lblUser.TabIndex = 57;
            this.lblUser.Text = "lblUser";
            // 
            // formCaja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(736, 526);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.panelMontoInicial);
            this.Controls.Add(this.btnCierreCaja);
            this.Controls.Add(this.btnAbrirCaja);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtFechaFin);
            this.Controls.Add(this.dtFechaInicio);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.btnRefrescar);
            this.Controls.Add(this.dataListadoCaja);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "formCaja";
            this.Text = "Caja";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataListadoCaja)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panelMontoInicial.ResumeLayout(false);
            this.panelMontoInicial.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnRefrescar;
        private System.Windows.Forms.DataGridView dataListadoCaja;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.DateTimePicker dtFechaInicio;
        private System.Windows.Forms.DateTimePicker dtFechaFin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnAbrirCaja;
        private System.Windows.Forms.Button btnCierreCaja;
        private System.Windows.Forms.Panel panelMontoInicial;
        private System.Windows.Forms.TextBox txtMontoInicial;
        private System.Windows.Forms.Button btnCancelarPanel;
        private System.Windows.Forms.Button btnAceptarPanel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnOmitir;
        private System.Windows.Forms.Label lblUser;
    }
}