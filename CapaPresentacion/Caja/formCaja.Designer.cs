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
            this.btnEliminarTransaccion = new System.Windows.Forms.Button();
            this.btnEgreso = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lbl_venta = new System.Windows.Forms.Label();
            this.lbl_retiro = new System.Windows.Forms.Label();
            this.lbl_deposito = new System.Windows.Forms.Label();
            this.lbl_egresos = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataListadoCaja)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
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
            this.btnRefrescar.Location = new System.Drawing.Point(710, 211);
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
            this.dataListadoCaja.Location = new System.Drawing.Point(13, 255);
            this.dataListadoCaja.MultiSelect = false;
            this.dataListadoCaja.Name = "dataListadoCaja";
            this.dataListadoCaja.ReadOnly = true;
            this.dataListadoCaja.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataListadoCaja.Size = new System.Drawing.Size(732, 352);
            this.dataListadoCaja.TabIndex = 35;
            this.dataListadoCaja.SelectionChanged += new System.EventHandler(this.dataListadoCaja_SelectionChanged);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(680, 5);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(65, 70);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 45;
            this.pictureBox2.TabStop = false;
            // 
            // dtFechaInicio
            // 
            this.dtFechaInicio.Location = new System.Drawing.Point(7, 229);
            this.dtFechaInicio.Name = "dtFechaInicio";
            this.dtFechaInicio.Size = new System.Drawing.Size(200, 20);
            this.dtFechaInicio.TabIndex = 46;
            this.dtFechaInicio.ValueChanged += new System.EventHandler(this.dtFechaInicio_ValueChanged);
            // 
            // dtFechaFin
            // 
            this.dtFechaFin.Location = new System.Drawing.Point(238, 229);
            this.dtFechaFin.Name = "dtFechaFin";
            this.dtFechaFin.Size = new System.Drawing.Size(200, 20);
            this.dtFechaFin.TabIndex = 47;
            this.dtFechaFin.ValueChanged += new System.EventHandler(this.dtFechaFin_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 211);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 48;
            this.label1.Text = "Fecha inicio :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(238, 210);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 49;
            this.label2.Text = "Fecha fin :";
            // 
            // btnEliminarTransaccion
            // 
            this.btnEliminarTransaccion.Location = new System.Drawing.Point(548, 226);
            this.btnEliminarTransaccion.Name = "btnEliminarTransaccion";
            this.btnEliminarTransaccion.Size = new System.Drawing.Size(75, 23);
            this.btnEliminarTransaccion.TabIndex = 50;
            this.btnEliminarTransaccion.Text = "Eliminar";
            this.btnEliminarTransaccion.UseVisualStyleBackColor = true;
            this.btnEliminarTransaccion.Click += new System.EventHandler(this.btnEliminarTransaccion_Click);
            // 
            // btnEgreso
            // 
            this.btnEgreso.Location = new System.Drawing.Point(444, 226);
            this.btnEgreso.Name = "btnEgreso";
            this.btnEgreso.Size = new System.Drawing.Size(98, 23);
            this.btnEgreso.TabIndex = 53;
            this.btnEgreso.Text = "Nuevo egreso";
            this.btnEgreso.UseVisualStyleBackColor = true;
            this.btnEgreso.Click += new System.EventHandler(this.btnEgreso_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Location = new System.Drawing.Point(629, 226);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(75, 23);
            this.btnEditar.TabIndex = 54;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbl_venta);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(8, 95);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(169, 100);
            this.groupBox1.TabIndex = 55;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Venta";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lbl_deposito);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(183, 95);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(169, 100);
            this.groupBox2.TabIndex = 56;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Cta Cte Deposito";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lbl_retiro);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Location = new System.Drawing.Point(358, 95);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(169, 100);
            this.groupBox3.TabIndex = 56;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Cta Cte Retiro";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lbl_egresos);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Location = new System.Drawing.Point(533, 95);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(169, 100);
            this.groupBox4.TabIndex = 56;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Egresos";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(7, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "Ventas";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(130, 17);
            this.label5.TabIndex = 1;
            this.label5.Text = "Cta Cte Deposito";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(6, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(110, 17);
            this.label6.TabIndex = 2;
            this.label6.Text = "Cta Cte Retiro";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(6, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 17);
            this.label7.TabIndex = 3;
            this.label7.Text = "Egresos";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(7, 61);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(20, 24);
            this.label8.TabIndex = 1;
            this.label8.Text = "$";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(6, 61);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(20, 24);
            this.label9.TabIndex = 3;
            this.label9.Text = "$";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(6, 61);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(20, 24);
            this.label10.TabIndex = 4;
            this.label10.Text = "$";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(6, 61);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(20, 24);
            this.label11.TabIndex = 5;
            this.label11.Text = "$";
            // 
            // lbl_venta
            // 
            this.lbl_venta.AutoSize = true;
            this.lbl_venta.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_venta.Location = new System.Drawing.Point(53, 61);
            this.lbl_venta.Name = "lbl_venta";
            this.lbl_venta.Size = new System.Drawing.Size(20, 24);
            this.lbl_venta.TabIndex = 2;
            this.lbl_venta.Text = "0";
            // 
            // lbl_retiro
            // 
            this.lbl_retiro.AutoSize = true;
            this.lbl_retiro.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_retiro.Location = new System.Drawing.Point(60, 61);
            this.lbl_retiro.Name = "lbl_retiro";
            this.lbl_retiro.Size = new System.Drawing.Size(20, 24);
            this.lbl_retiro.TabIndex = 3;
            this.lbl_retiro.Text = "0";
            // 
            // lbl_deposito
            // 
            this.lbl_deposito.AutoSize = true;
            this.lbl_deposito.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_deposito.Location = new System.Drawing.Point(54, 61);
            this.lbl_deposito.Name = "lbl_deposito";
            this.lbl_deposito.Size = new System.Drawing.Size(20, 24);
            this.lbl_deposito.TabIndex = 4;
            this.lbl_deposito.Text = "0";
            // 
            // lbl_egresos
            // 
            this.lbl_egresos.AutoSize = true;
            this.lbl_egresos.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_egresos.Location = new System.Drawing.Point(70, 61);
            this.lbl_egresos.Name = "lbl_egresos";
            this.lbl_egresos.Size = new System.Drawing.Size(20, 24);
            this.lbl_egresos.TabIndex = 5;
            this.lbl_egresos.Text = "0";
            // 
            // formCaja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(757, 619);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnEgreso);
            this.Controls.Add(this.btnEliminarTransaccion);
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
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
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
        private System.Windows.Forms.Button btnEliminarTransaccion;
        private System.Windows.Forms.Button btnEgreso;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lbl_venta;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lbl_deposito;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lbl_retiro;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lbl_egresos;
        private System.Windows.Forms.Label label9;
    }
}