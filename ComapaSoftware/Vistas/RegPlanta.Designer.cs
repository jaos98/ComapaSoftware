namespace ComapaSoftware.Vistas
{
    partial class FormPlanta
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label14 = new System.Windows.Forms.Label();
            this.txtKva = new System.Windows.Forms.TextBox();
            this.txtLongitud = new System.Windows.Forms.MaskedTextBox();
            this.txtLatitud = new System.Windows.Forms.MaskedTextBox();
            this.cmbSector = new System.Windows.Forms.ComboBox();
            this.cmbColonia = new System.Windows.Forms.ComboBox();
            this.cmbEstatus = new System.Windows.Forms.ComboBox();
            this.btnVolver = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.cmbServicio = new System.Windows.Forms.ComboBox();
            this.cmbTipoPlanta = new System.Windows.Forms.ComboBox();
            this.txtDomicilio = new System.Windows.Forms.TextBox();
            this.txtElevacion = new System.Windows.Forms.TextBox();
            this.txtDescFunciones = new System.Windows.Forms.TextBox();
            this.txtNumServ = new System.Windows.Forms.TextBox();
            this.txtNumMed = new System.Windows.Forms.TextBox();
            this.txtPlanta = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.txtKva);
            this.panel1.Controls.Add(this.txtLongitud);
            this.panel1.Controls.Add(this.txtLatitud);
            this.panel1.Controls.Add(this.cmbSector);
            this.panel1.Controls.Add(this.cmbColonia);
            this.panel1.Controls.Add(this.cmbEstatus);
            this.panel1.Controls.Add(this.btnVolver);
            this.panel1.Controls.Add(this.btnAgregar);
            this.panel1.Controls.Add(this.cmbServicio);
            this.panel1.Controls.Add(this.cmbTipoPlanta);
            this.panel1.Controls.Add(this.txtDomicilio);
            this.panel1.Controls.Add(this.txtElevacion);
            this.panel1.Controls.Add(this.txtDescFunciones);
            this.panel1.Controls.Add(this.txtNumServ);
            this.panel1.Controls.Add(this.txtNumMed);
            this.panel1.Controls.Add(this.txtPlanta);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(-1, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 457);
            this.panel1.TabIndex = 0;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(444, 237);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(26, 13);
            this.label14.TabIndex = 36;
            this.label14.Text = "Kva";
            // 
            // txtKva
            // 
            this.txtKva.Location = new System.Drawing.Point(519, 234);
            this.txtKva.Name = "txtKva";
            this.txtKva.Size = new System.Drawing.Size(237, 20);
            this.txtKva.TabIndex = 35;
            // 
            // txtLongitud
            // 
            this.txtLongitud.Location = new System.Drawing.Point(519, 116);
            this.txtLongitud.Mask = "00°00\'00.00\"O";
            this.txtLongitud.Name = "txtLongitud";
            this.txtLongitud.Size = new System.Drawing.Size(237, 20);
            this.txtLongitud.TabIndex = 34;
            this.txtLongitud.Click += new System.EventHandler(this.txtLongitud_Click);
            // 
            // txtLatitud
            // 
            this.txtLatitud.Location = new System.Drawing.Point(519, 69);
            this.txtLatitud.Mask = "00°00\'00.00\"N";
            this.txtLatitud.Name = "txtLatitud";
            this.txtLatitud.Size = new System.Drawing.Size(237, 20);
            this.txtLatitud.TabIndex = 33;
            this.txtLatitud.Click += new System.EventHandler(this.txtLatitud_Click);
            // 
            // cmbSector
            // 
            this.cmbSector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSector.FormattingEnabled = true;
            this.cmbSector.Location = new System.Drawing.Point(172, 226);
            this.cmbSector.Name = "cmbSector";
            this.cmbSector.Size = new System.Drawing.Size(237, 21);
            this.cmbSector.TabIndex = 32;
            this.cmbSector.SelectedIndexChanged += new System.EventHandler(this.cmbSector_SelectedIndexChanged);
            // 
            // cmbColonia
            // 
            this.cmbColonia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbColonia.FormattingEnabled = true;
            this.cmbColonia.Location = new System.Drawing.Point(519, 32);
            this.cmbColonia.Name = "cmbColonia";
            this.cmbColonia.Size = new System.Drawing.Size(237, 21);
            this.cmbColonia.TabIndex = 31;
            this.cmbColonia.SelectedIndexChanged += new System.EventHandler(this.cmbColonia_SelectedIndexChanged);
            // 
            // cmbEstatus
            // 
            this.cmbEstatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstatus.FormattingEnabled = true;
            this.cmbEstatus.Items.AddRange(new object[] {
            "Activa",
            "Fuera de servicio"});
            this.cmbEstatus.Location = new System.Drawing.Point(172, 193);
            this.cmbEstatus.Name = "cmbEstatus";
            this.cmbEstatus.Size = new System.Drawing.Size(237, 21);
            this.cmbEstatus.TabIndex = 30;
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(591, 422);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(165, 23);
            this.btnVolver.TabIndex = 29;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(36, 422);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(165, 23);
            this.btnAgregar.TabIndex = 28;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // cmbServicio
            // 
            this.cmbServicio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbServicio.FormattingEnabled = true;
            this.cmbServicio.Items.AddRange(new object[] {
            "Bombeo",
            "Rebombeo",
            "Potabilizadora",
            "Tanque",
            "Pozo",
            "Carcamo",
            "Sin sub-categoria"});
            this.cmbServicio.Location = new System.Drawing.Point(519, 193);
            this.cmbServicio.Name = "cmbServicio";
            this.cmbServicio.Size = new System.Drawing.Size(237, 21);
            this.cmbServicio.TabIndex = 27;
            // 
            // cmbTipoPlanta
            // 
            this.cmbTipoPlanta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoPlanta.FormattingEnabled = true;
            this.cmbTipoPlanta.Items.AddRange(new object[] {
            "Potable",
            "Residual",
            "Obra de toma",
            "Tratamiento"});
            this.cmbTipoPlanta.Location = new System.Drawing.Point(172, 146);
            this.cmbTipoPlanta.Name = "cmbTipoPlanta";
            this.cmbTipoPlanta.Size = new System.Drawing.Size(237, 21);
            this.cmbTipoPlanta.TabIndex = 26;
            // 
            // txtDomicilio
            // 
            this.txtDomicilio.Location = new System.Drawing.Point(519, 279);
            this.txtDomicilio.MaxLength = 100;
            this.txtDomicilio.Multiline = true;
            this.txtDomicilio.Name = "txtDomicilio";
            this.txtDomicilio.Size = new System.Drawing.Size(237, 115);
            this.txtDomicilio.TabIndex = 25;
            // 
            // txtElevacion
            // 
            this.txtElevacion.Location = new System.Drawing.Point(519, 152);
            this.txtElevacion.MaxLength = 10;
            this.txtElevacion.Name = "txtElevacion";
            this.txtElevacion.Size = new System.Drawing.Size(237, 20);
            this.txtElevacion.TabIndex = 23;
            // 
            // txtDescFunciones
            // 
            this.txtDescFunciones.Location = new System.Drawing.Point(172, 279);
            this.txtDescFunciones.MaxLength = 100;
            this.txtDescFunciones.Multiline = true;
            this.txtDescFunciones.Name = "txtDescFunciones";
            this.txtDescFunciones.Size = new System.Drawing.Size(237, 115);
            this.txtDescFunciones.TabIndex = 18;
            // 
            // txtNumServ
            // 
            this.txtNumServ.Location = new System.Drawing.Point(172, 105);
            this.txtNumServ.MaxLength = 25;
            this.txtNumServ.Name = "txtNumServ";
            this.txtNumServ.Size = new System.Drawing.Size(237, 20);
            this.txtNumServ.TabIndex = 15;
            this.txtNumServ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumServ_KeyPress);
            // 
            // txtNumMed
            // 
            this.txtNumMed.Location = new System.Drawing.Point(172, 69);
            this.txtNumMed.MaxLength = 11;
            this.txtNumMed.Name = "txtNumMed";
            this.txtNumMed.Size = new System.Drawing.Size(237, 20);
            this.txtNumMed.TabIndex = 14;
            // 
            // txtPlanta
            // 
            this.txtPlanta.Location = new System.Drawing.Point(172, 32);
            this.txtPlanta.MaxLength = 15;
            this.txtPlanta.Name = "txtPlanta";
            this.txtPlanta.Size = new System.Drawing.Size(237, 20);
            this.txtPlanta.TabIndex = 13;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(444, 279);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(49, 13);
            this.label13.TabIndex = 12;
            this.label13.Text = "Domicilio";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(442, 200);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(45, 13);
            this.label12.TabIndex = 11;
            this.label12.Text = "Servicio";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(439, 158);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(54, 13);
            this.label11.TabIndex = 10;
            this.label11.Text = "Elevacion";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(439, 119);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(48, 13);
            this.label10.TabIndex = 9;
            this.label10.Text = "Longitud";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(437, 76);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(39, 13);
            this.label9.TabIndex = 8;
            this.label9.Text = "Latitud";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(32, 234);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Sector";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(439, 35);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Colonia";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(33, 282);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(127, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Descripcion de funciones";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(33, 193);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Status";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(33, 155);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Tipo de Plantas";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Numero de Servicio";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Numero de Medidor";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Id Planta";
            // 
            // toolTip1
            // 
            this.toolTip1.IsBalloon = true;
            // 
            // FormPlanta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 459);
            this.Controls.Add(this.panel1);
            this.Name = "FormPlanta";
            this.Text = "Agregar Planta";
            this.Load += new System.EventHandler(this.FormPlanta_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtDomicilio;
        private System.Windows.Forms.TextBox txtElevacion;
        private System.Windows.Forms.TextBox txtDescFunciones;
        private System.Windows.Forms.TextBox txtNumServ;
        private System.Windows.Forms.TextBox txtNumMed;
        private System.Windows.Forms.TextBox txtPlanta;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.ComboBox cmbServicio;
        private System.Windows.Forms.ComboBox cmbTipoPlanta;
        private System.Windows.Forms.ComboBox cmbEstatus;
        private System.Windows.Forms.ComboBox cmbSector;
        private System.Windows.Forms.ComboBox cmbColonia;
        private System.Windows.Forms.MaskedTextBox txtLongitud;
        private System.Windows.Forms.MaskedTextBox txtLatitud;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtKva;
    }
}