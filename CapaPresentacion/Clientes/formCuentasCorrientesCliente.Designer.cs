namespace CapaPresentacion.Clientes
{
    partial class formCuentasCorrientesCliente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formCuentasCorrientesCliente));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblCliente = new System.Windows.Forms.Label();
            this.lblDireccionCliente = new System.Windows.Forms.Label();
            this.lblTelefonoCliente = new System.Windows.Forms.Label();
            this.dataListadoCCClientes = new System.Windows.Forms.DataGridView();
            this.lblTotalMovimientos = new System.Windows.Forms.Label();
            this.lblDNI = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblSaldo = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnDepositar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataListadoCCClientes)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblSaldo);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.lblDNI);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.lblTelefonoCliente);
            this.groupBox1.Controls.Add(this.lblDireccionCliente);
            this.groupBox1.Controls.Add(this.lblCliente);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(44, 56);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(705, 109);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cliente";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(196, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(416, 47);
            this.label1.TabIndex = 6;
            this.label1.Text = "Cuentas corrientes";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Cliente : ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Direccion : ";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(329, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Telefono : ";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Location = new System.Drawing.Point(97, 26);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(49, 13);
            this.lblCliente.TabIndex = 3;
            this.lblCliente.Text = "lblCliente";
            // 
            // lblDireccionCliente
            // 
            this.lblDireccionCliente.AutoSize = true;
            this.lblDireccionCliente.Location = new System.Drawing.Point(97, 72);
            this.lblDireccionCliente.Name = "lblDireccionCliente";
            this.lblDireccionCliente.Size = new System.Drawing.Size(94, 13);
            this.lblDireccionCliente.TabIndex = 4;
            this.lblDireccionCliente.Text = "lblDireccionCliente";
            // 
            // lblTelefonoCliente
            // 
            this.lblTelefonoCliente.AutoSize = true;
            this.lblTelefonoCliente.Location = new System.Drawing.Point(393, 26);
            this.lblTelefonoCliente.Name = "lblTelefonoCliente";
            this.lblTelefonoCliente.Size = new System.Drawing.Size(91, 13);
            this.lblTelefonoCliente.TabIndex = 5;
            this.lblTelefonoCliente.Text = "lblTelefonoCliente";
            // 
            // dataListadoCCClientes
            // 
            this.dataListadoCCClientes.AllowUserToAddRows = false;
            this.dataListadoCCClientes.AllowUserToDeleteRows = false;
            this.dataListadoCCClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataListadoCCClientes.Location = new System.Drawing.Point(46, 205);
            this.dataListadoCCClientes.MultiSelect = false;
            this.dataListadoCCClientes.Name = "dataListadoCCClientes";
            this.dataListadoCCClientes.ReadOnly = true;
            this.dataListadoCCClientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataListadoCCClientes.Size = new System.Drawing.Size(703, 296);
            this.dataListadoCCClientes.TabIndex = 11;
            // 
            // lblTotalMovimientos
            // 
            this.lblTotalMovimientos.AutoSize = true;
            this.lblTotalMovimientos.Location = new System.Drawing.Point(601, 189);
            this.lblTotalMovimientos.Name = "lblTotalMovimientos";
            this.lblTotalMovimientos.Size = new System.Drawing.Size(100, 13);
            this.lblTotalMovimientos.TabIndex = 12;
            this.lblTotalMovimientos.Text = "lblTotalMovimientos";
            // 
            // lblDNI
            // 
            this.lblDNI.AutoSize = true;
            this.lblDNI.Location = new System.Drawing.Point(393, 72);
            this.lblDNI.Name = "lblDNI";
            this.lblDNI.Size = new System.Drawing.Size(36, 13);
            this.lblDNI.TabIndex = 7;
            this.lblDNI.Text = "lblDNI";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(350, 72);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "DNI :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSaldo
            // 
            this.lblSaldo.AutoSize = true;
            this.lblSaldo.Location = new System.Drawing.Point(590, 26);
            this.lblSaldo.Name = "lblSaldo";
            this.lblSaldo.Size = new System.Drawing.Size(13, 13);
            this.lblSaldo.TabIndex = 9;
            this.lblSaldo.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(526, 26);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "Saldo : ";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnDepositar
            // 
            this.btnDepositar.Location = new System.Drawing.Point(46, 176);
            this.btnDepositar.Name = "btnDepositar";
            this.btnDepositar.Size = new System.Drawing.Size(102, 23);
            this.btnDepositar.TabIndex = 13;
            this.btnDepositar.Text = "Depositar";
            this.btnDepositar.UseVisualStyleBackColor = true;
            this.btnDepositar.Click += new System.EventHandler(this.btnDepositar_Click);
            // 
            // formCuentasCorrientesCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 513);
            this.Controls.Add(this.btnDepositar);
            this.Controls.Add(this.lblTotalMovimientos);
            this.Controls.Add(this.dataListadoCCClientes);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "formCuentasCorrientesCliente";
            this.Text = "Cuenta corriente";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataListadoCCClientes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTelefonoCliente;
        private System.Windows.Forms.Label lblDireccionCliente;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataListadoCCClientes;
        private System.Windows.Forms.Label lblTotalMovimientos;
        private System.Windows.Forms.Label lblDNI;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblSaldo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnDepositar;
    }
}