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
            this.lbl_ventas_total = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lbl_credito = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lbl_debito = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lbl_transferencias = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.lbl_efectivo = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label26 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.lblPagos = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.lblGastos = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.lblAdelantos = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.lbl_voucher = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataListadoCaja)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(768, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(71, 66);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 29;
            this.pictureBox1.TabStop = false;
            // 
            // btnRefrescar
            // 
            this.btnRefrescar.Image = global::CapaPresentacion.Properties.Resources.refresh;
            this.btnRefrescar.Location = new System.Drawing.Point(709, 260);
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
            this.dataListadoCaja.Location = new System.Drawing.Point(12, 304);
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
            this.pictureBox2.Location = new System.Drawing.Point(768, 85);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(71, 70);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 45;
            this.pictureBox2.TabStop = false;
            // 
            // dtFechaInicio
            // 
            this.dtFechaInicio.Location = new System.Drawing.Point(12, 278);
            this.dtFechaInicio.Name = "dtFechaInicio";
            this.dtFechaInicio.Size = new System.Drawing.Size(200, 20);
            this.dtFechaInicio.TabIndex = 46;
            this.dtFechaInicio.ValueChanged += new System.EventHandler(this.dtFechaInicio_ValueChanged);
            // 
            // dtFechaFin
            // 
            this.dtFechaFin.Location = new System.Drawing.Point(237, 278);
            this.dtFechaFin.Name = "dtFechaFin";
            this.dtFechaFin.Size = new System.Drawing.Size(200, 20);
            this.dtFechaFin.TabIndex = 47;
            this.dtFechaFin.ValueChanged += new System.EventHandler(this.dtFechaFin_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 260);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 48;
            this.label1.Text = "Fecha inicio :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(237, 259);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 49;
            this.label2.Text = "Fecha fin :";
            // 
            // btnEliminarTransaccion
            // 
            this.btnEliminarTransaccion.Location = new System.Drawing.Point(547, 275);
            this.btnEliminarTransaccion.Name = "btnEliminarTransaccion";
            this.btnEliminarTransaccion.Size = new System.Drawing.Size(75, 23);
            this.btnEliminarTransaccion.TabIndex = 50;
            this.btnEliminarTransaccion.Text = "Eliminar";
            this.btnEliminarTransaccion.UseVisualStyleBackColor = true;
            this.btnEliminarTransaccion.Click += new System.EventHandler(this.btnEliminarTransaccion_Click);
            // 
            // btnEgreso
            // 
            this.btnEgreso.Location = new System.Drawing.Point(443, 275);
            this.btnEgreso.Name = "btnEgreso";
            this.btnEgreso.Size = new System.Drawing.Size(98, 23);
            this.btnEgreso.TabIndex = 53;
            this.btnEgreso.Text = "Nuevo egreso";
            this.btnEgreso.UseVisualStyleBackColor = true;
            this.btnEgreso.Click += new System.EventHandler(this.btnEgreso_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Location = new System.Drawing.Point(628, 275);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(75, 23);
            this.btnEditar.TabIndex = 54;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbl_ventas_total);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(15, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(169, 100);
            this.groupBox1.TabIndex = 55;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Venta total";
            // 
            // lbl_ventas_total
            // 
            this.lbl_ventas_total.AutoSize = true;
            this.lbl_ventas_total.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ventas_total.Location = new System.Drawing.Point(33, 61);
            this.lbl_ventas_total.Name = "lbl_ventas_total";
            this.lbl_ventas_total.Size = new System.Drawing.Size(20, 24);
            this.lbl_ventas_total.TabIndex = 2;
            this.lbl_ventas_total.Text = "0";
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
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(7, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "Ventas total";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lbl_credito);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(540, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(169, 100);
            this.groupBox2.TabIndex = 56;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Credito";
            // 
            // lbl_credito
            // 
            this.lbl_credito.AutoSize = true;
            this.lbl_credito.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_credito.Location = new System.Drawing.Point(32, 61);
            this.lbl_credito.Name = "lbl_credito";
            this.lbl_credito.Size = new System.Drawing.Size(20, 24);
            this.lbl_credito.TabIndex = 4;
            this.lbl_credito.Text = "0";
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
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 17);
            this.label5.TabIndex = 1;
            this.label5.Text = "Credito";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lbl_debito);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Location = new System.Drawing.Point(365, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(169, 100);
            this.groupBox3.TabIndex = 56;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Debito";
            // 
            // lbl_debito
            // 
            this.lbl_debito.AutoSize = true;
            this.lbl_debito.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_debito.Location = new System.Drawing.Point(32, 61);
            this.lbl_debito.Name = "lbl_debito";
            this.lbl_debito.Size = new System.Drawing.Size(20, 24);
            this.lbl_debito.TabIndex = 3;
            this.lbl_debito.Text = "0";
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
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(6, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 17);
            this.label6.TabIndex = 2;
            this.label6.Text = "Debito";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lbl_transferencias);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Location = new System.Drawing.Point(257, 118);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(169, 127);
            this.groupBox4.TabIndex = 56;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Transferencia";
            // 
            // lbl_transferencias
            // 
            this.lbl_transferencias.AutoSize = true;
            this.lbl_transferencias.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_transferencias.Location = new System.Drawing.Point(32, 61);
            this.lbl_transferencias.Name = "lbl_transferencias";
            this.lbl_transferencias.Size = new System.Drawing.Size(20, 24);
            this.lbl_transferencias.TabIndex = 5;
            this.lbl_transferencias.Text = "0";
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
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(6, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(109, 17);
            this.label7.TabIndex = 3;
            this.label7.Text = "Transferencia";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.lbl_efectivo);
            this.groupBox5.Controls.Add(this.label12);
            this.groupBox5.Controls.Add(this.label13);
            this.groupBox5.Location = new System.Drawing.Point(190, 12);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(169, 100);
            this.groupBox5.TabIndex = 57;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Efectivo";
            // 
            // lbl_efectivo
            // 
            this.lbl_efectivo.AutoSize = true;
            this.lbl_efectivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_efectivo.Location = new System.Drawing.Point(52, 61);
            this.lbl_efectivo.Name = "lbl_efectivo";
            this.lbl_efectivo.Size = new System.Drawing.Size(20, 24);
            this.lbl_efectivo.TabIndex = 5;
            this.lbl_efectivo.Text = "0";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(6, 61);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(20, 24);
            this.label12.TabIndex = 3;
            this.label12.Text = "$";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(6, 20);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(66, 17);
            this.label13.TabIndex = 3;
            this.label13.Text = "Efectivo";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label26);
            this.groupBox6.Controls.Add(this.label25);
            this.groupBox6.Controls.Add(this.label24);
            this.groupBox6.Controls.Add(this.lblPagos);
            this.groupBox6.Controls.Add(this.label23);
            this.groupBox6.Controls.Add(this.lblGastos);
            this.groupBox6.Controls.Add(this.label21);
            this.groupBox6.Controls.Add(this.lblAdelantos);
            this.groupBox6.Controls.Add(this.label15);
            this.groupBox6.Controls.Add(this.label16);
            this.groupBox6.Location = new System.Drawing.Point(15, 118);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(233, 127);
            this.groupBox6.TabIndex = 57;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Egresos";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(24, 101);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(43, 13);
            this.label26.TabIndex = 12;
            this.label26.Text = "Pagos :";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(21, 77);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(46, 13);
            this.label25.TabIndex = 11;
            this.label25.Text = "Gastos :";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(7, 51);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(60, 13);
            this.label24.TabIndex = 10;
            this.label24.Text = "Adelantos :";
            // 
            // lblPagos
            // 
            this.lblPagos.AutoSize = true;
            this.lblPagos.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPagos.Location = new System.Drawing.Point(105, 99);
            this.lblPagos.Name = "lblPagos";
            this.lblPagos.Size = new System.Drawing.Size(16, 17);
            this.lblPagos.TabIndex = 9;
            this.lblPagos.Text = "0";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(83, 99);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(16, 17);
            this.label23.TabIndex = 8;
            this.label23.Text = "$";
            // 
            // lblGastos
            // 
            this.lblGastos.AutoSize = true;
            this.lblGastos.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGastos.Location = new System.Drawing.Point(105, 75);
            this.lblGastos.Name = "lblGastos";
            this.lblGastos.Size = new System.Drawing.Size(16, 17);
            this.lblGastos.TabIndex = 7;
            this.lblGastos.Text = "0";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(83, 75);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(16, 17);
            this.label21.TabIndex = 6;
            this.label21.Text = "$";
            // 
            // lblAdelantos
            // 
            this.lblAdelantos.AutoSize = true;
            this.lblAdelantos.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdelantos.Location = new System.Drawing.Point(105, 51);
            this.lblAdelantos.Name = "lblAdelantos";
            this.lblAdelantos.Size = new System.Drawing.Size(16, 17);
            this.lblAdelantos.TabIndex = 5;
            this.lblAdelantos.Text = "0";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(83, 51);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(16, 17);
            this.label15.TabIndex = 3;
            this.label15.Text = "$";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(6, 20);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(67, 17);
            this.label16.TabIndex = 3;
            this.label16.Text = "Egresos";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.lbl_voucher);
            this.groupBox7.Controls.Add(this.label18);
            this.groupBox7.Controls.Add(this.label19);
            this.groupBox7.Location = new System.Drawing.Point(437, 118);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(169, 127);
            this.groupBox7.TabIndex = 57;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Voucher";
            // 
            // lbl_voucher
            // 
            this.lbl_voucher.AutoSize = true;
            this.lbl_voucher.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_voucher.Location = new System.Drawing.Point(32, 61);
            this.lbl_voucher.Name = "lbl_voucher";
            this.lbl_voucher.Size = new System.Drawing.Size(20, 24);
            this.lbl_voucher.TabIndex = 5;
            this.lbl_voucher.Text = "0";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(6, 61);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(20, 24);
            this.label18.TabIndex = 3;
            this.label18.Text = "$";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(6, 20);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(68, 17);
            this.label19.TabIndex = 3;
            this.label19.Text = "Voucher";
            // 
            // formCaja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(851, 672);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
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
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
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
        private System.Windows.Forms.Label lbl_ventas_total;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lbl_credito;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lbl_debito;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lbl_transferencias;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label lbl_efectivo;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label lblAdelantos;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Label lbl_voucher;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label lblPagos;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label lblGastos;
        private System.Windows.Forms.Label label21;
    }
}