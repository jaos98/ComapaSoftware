namespace ComapaSoftware.Vistas
{
    partial class RegBomba
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
            this.mainPanel = new System.Windows.Forms.Panel();
            this.cmbPosicion = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtObservaciones = new System.Windows.Forms.TextBox();
            this.cmbEstatus = new System.Windows.Forms.ComboBox();
            this.cmbTipo = new System.Windows.Forms.ComboBox();
            this.txtModelo = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.btnReg = new System.Windows.Forms.Button();
            this.txtFpm = new System.Windows.Forms.TextBox();
            this.txtRpm = new System.Windows.Forms.TextBox();
            this.txtDinamica = new System.Windows.Forms.TextBox();
            this.txtGastolps = new System.Windows.Forms.TextBox();
            this.txtDiametro = new System.Windows.Forms.TextBox();
            this.txtVoltaje = new System.Windows.Forms.TextBox();
            this.txtHp = new System.Windows.Forms.TextBox();
            this.txtMarca = new System.Windows.Forms.TextBox();
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbPlanta = new System.Windows.Forms.ComboBox();
            this.cmbEstacion = new System.Windows.Forms.ComboBox();
            this.cmbCategoria = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.btnVolver = new System.Windows.Forms.Button();
            this.mainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.cmbPosicion);
            this.mainPanel.Controls.Add(this.label15);
            this.mainPanel.Controls.Add(this.txtObservaciones);
            this.mainPanel.Controls.Add(this.cmbEstatus);
            this.mainPanel.Controls.Add(this.cmbTipo);
            this.mainPanel.Controls.Add(this.txtModelo);
            this.mainPanel.Controls.Add(this.label14);
            this.mainPanel.Controls.Add(this.button2);
            this.mainPanel.Controls.Add(this.btnReg);
            this.mainPanel.Controls.Add(this.txtFpm);
            this.mainPanel.Controls.Add(this.txtRpm);
            this.mainPanel.Controls.Add(this.txtDinamica);
            this.mainPanel.Controls.Add(this.txtGastolps);
            this.mainPanel.Controls.Add(this.txtDiametro);
            this.mainPanel.Controls.Add(this.txtVoltaje);
            this.mainPanel.Controls.Add(this.txtHp);
            this.mainPanel.Controls.Add(this.txtMarca);
            this.mainPanel.Controls.Add(this.label13);
            this.mainPanel.Controls.Add(this.label12);
            this.mainPanel.Controls.Add(this.label11);
            this.mainPanel.Controls.Add(this.label10);
            this.mainPanel.Controls.Add(this.label9);
            this.mainPanel.Controls.Add(this.label8);
            this.mainPanel.Controls.Add(this.label7);
            this.mainPanel.Controls.Add(this.label6);
            this.mainPanel.Controls.Add(this.label5);
            this.mainPanel.Controls.Add(this.label4);
            this.mainPanel.Controls.Add(this.label3);
            this.mainPanel.Enabled = false;
            this.mainPanel.Location = new System.Drawing.Point(233, 12);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(723, 399);
            this.mainPanel.TabIndex = 0;
            // 
            // cmbPosicion
            // 
            this.cmbPosicion.FormattingEnabled = true;
            this.cmbPosicion.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.cmbPosicion.Location = new System.Drawing.Point(170, 23);
            this.cmbPosicion.Name = "cmbPosicion";
            this.cmbPosicion.Size = new System.Drawing.Size(121, 21);
            this.cmbPosicion.TabIndex = 30;
            this.cmbPosicion.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged_2);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(461, 286);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(78, 13);
            this.label15.TabIndex = 29;
            this.label15.Text = "Observaciones";
            // 
            // txtObservaciones
            // 
            this.txtObservaciones.Location = new System.Drawing.Point(461, 305);
            this.txtObservaciones.Multiline = true;
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.Size = new System.Drawing.Size(243, 80);
            this.txtObservaciones.TabIndex = 28;
            // 
            // cmbEstatus
            // 
            this.cmbEstatus.FormattingEnabled = true;
            this.cmbEstatus.Items.AddRange(new object[] {
            "Operando",
            "Fuera de servicio",
            "Sin especificar"});
            this.cmbEstatus.Location = new System.Drawing.Point(461, 199);
            this.cmbEstatus.Name = "cmbEstatus";
            this.cmbEstatus.Size = new System.Drawing.Size(121, 21);
            this.cmbEstatus.TabIndex = 27;
            this.cmbEstatus.Text = "--Seleccione Estatus--";
            // 
            // cmbTipo
            // 
            this.cmbTipo.FormattingEnabled = true;
            this.cmbTipo.Items.AddRange(new object[] {
            "Sumergible",
            "Horizontal",
            "Vertical",
            "Pozo Profundo",
            "Anfibias"});
            this.cmbTipo.Location = new System.Drawing.Point(170, 155);
            this.cmbTipo.Name = "cmbTipo";
            this.cmbTipo.Size = new System.Drawing.Size(121, 21);
            this.cmbTipo.TabIndex = 26;
            this.cmbTipo.Text = "--Seleccione Tipo--";
            // 
            // txtModelo
            // 
            this.txtModelo.Location = new System.Drawing.Point(170, 112);
            this.txtModelo.Name = "txtModelo";
            this.txtModelo.Size = new System.Drawing.Size(100, 20);
            this.txtModelo.TabIndex = 25;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(32, 119);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(42, 13);
            this.label14.TabIndex = 24;
            this.label14.Text = "Modelo";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(249, 352);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(155, 23);
            this.button2.TabIndex = 23;
            this.button2.Text = "Volver";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnReg
            // 
            this.btnReg.Location = new System.Drawing.Point(33, 352);
            this.btnReg.Name = "btnReg";
            this.btnReg.Size = new System.Drawing.Size(157, 23);
            this.btnReg.TabIndex = 22;
            this.btnReg.Text = "Registrar Bomba";
            this.btnReg.UseVisualStyleBackColor = true;
            this.btnReg.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtFpm
            // 
            this.txtFpm.Location = new System.Drawing.Point(461, 248);
            this.txtFpm.Name = "txtFpm";
            this.txtFpm.Size = new System.Drawing.Size(100, 20);
            this.txtFpm.TabIndex = 21;
            // 
            // txtRpm
            // 
            this.txtRpm.Location = new System.Drawing.Point(461, 156);
            this.txtRpm.Name = "txtRpm";
            this.txtRpm.Size = new System.Drawing.Size(100, 20);
            this.txtRpm.TabIndex = 19;
            // 
            // txtDinamica
            // 
            this.txtDinamica.Location = new System.Drawing.Point(461, 116);
            this.txtDinamica.Name = "txtDinamica";
            this.txtDinamica.Size = new System.Drawing.Size(100, 20);
            this.txtDinamica.TabIndex = 18;
            // 
            // txtGastolps
            // 
            this.txtGastolps.Location = new System.Drawing.Point(461, 68);
            this.txtGastolps.Name = "txtGastolps";
            this.txtGastolps.Size = new System.Drawing.Size(100, 20);
            this.txtGastolps.TabIndex = 17;
            // 
            // txtDiametro
            // 
            this.txtDiametro.Location = new System.Drawing.Point(461, 29);
            this.txtDiametro.Name = "txtDiametro";
            this.txtDiametro.Size = new System.Drawing.Size(100, 20);
            this.txtDiametro.TabIndex = 16;
            // 
            // txtVoltaje
            // 
            this.txtVoltaje.Location = new System.Drawing.Point(170, 244);
            this.txtVoltaje.Name = "txtVoltaje";
            this.txtVoltaje.Size = new System.Drawing.Size(100, 20);
            this.txtVoltaje.TabIndex = 15;
            // 
            // txtHp
            // 
            this.txtHp.Location = new System.Drawing.Point(170, 200);
            this.txtHp.Name = "txtHp";
            this.txtHp.Size = new System.Drawing.Size(100, 20);
            this.txtHp.TabIndex = 14;
            // 
            // txtMarca
            // 
            this.txtMarca.Location = new System.Drawing.Point(170, 68);
            this.txtMarca.Name = "txtMarca";
            this.txtMarca.Size = new System.Drawing.Size(100, 20);
            this.txtMarca.TabIndex = 12;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(322, 251);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(29, 13);
            this.label13.TabIndex = 11;
            this.label13.Text = "FPM";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(322, 201);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(42, 13);
            this.label12.TabIndex = 10;
            this.label12.Text = "Estatus";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(322, 159);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(31, 13);
            this.label11.TabIndex = 9;
            this.label11.Text = "RPM";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(322, 119);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(82, 13);
            this.label10.TabIndex = 8;
            this.label10.Text = "Carga Dinamica";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(322, 75);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(58, 13);
            this.label9.TabIndex = 7;
            this.label9.Text = "Gasto LPS";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(322, 32);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(111, 13);
            this.label8.TabIndex = 6;
            this.label8.Text = "Diametro de descarga";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(32, 251);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "Voltaje";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(32, 201);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(21, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Hp";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(32, 163);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(28, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Tipo";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Marca";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Posicion";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 175);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Estacion";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Planta";
            // 
            // cmbPlanta
            // 
            this.cmbPlanta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPlanta.Enabled = false;
            this.cmbPlanta.FormattingEnabled = true;
            this.cmbPlanta.Location = new System.Drawing.Point(26, 140);
            this.cmbPlanta.Name = "cmbPlanta";
            this.cmbPlanta.Size = new System.Drawing.Size(121, 21);
            this.cmbPlanta.TabIndex = 3;
            this.cmbPlanta.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // cmbEstacion
            // 
            this.cmbEstacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstacion.Enabled = false;
            this.cmbEstacion.FormattingEnabled = true;
            this.cmbEstacion.Location = new System.Drawing.Point(26, 205);
            this.cmbEstacion.Name = "cmbEstacion";
            this.cmbEstacion.Size = new System.Drawing.Size(121, 21);
            this.cmbEstacion.TabIndex = 4;
            this.cmbEstacion.SelectedIndexChanged += new System.EventHandler(this.cmbIdPlanta_SelectedIndexChanged);
            // 
            // cmbCategoria
            // 
            this.cmbCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategoria.FormattingEnabled = true;
            this.cmbCategoria.Items.AddRange(new object[] {
            "Potable",
            "Residual",
            "PTAR",
            "EBAR",
            "EBAP"});
            this.cmbCategoria.Location = new System.Drawing.Point(26, 79);
            this.cmbCategoria.Name = "cmbCategoria";
            this.cmbCategoria.Size = new System.Drawing.Size(121, 21);
            this.cmbCategoria.TabIndex = 6;
            this.cmbCategoria.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged_1);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(26, 47);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(52, 13);
            this.label16.TabIndex = 7;
            this.label16.Text = "Categoria";
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(29, 363);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(118, 23);
            this.btnVolver.TabIndex = 8;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // RegBomba
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(968, 433);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.cmbCategoria);
            this.Controls.Add(this.cmbEstacion);
            this.Controls.Add(this.cmbPlanta);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.mainPanel);
            this.Name = "RegBomba";
            this.Text = "RegBomba";
            this.Load += new System.EventHandler(this.RegBomba_Load);
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbPlanta;
        private System.Windows.Forms.ComboBox cmbEstacion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtFpm;
        private System.Windows.Forms.TextBox txtRpm;
        private System.Windows.Forms.TextBox txtDinamica;
        private System.Windows.Forms.TextBox txtGastolps;
        private System.Windows.Forms.TextBox txtDiametro;
        private System.Windows.Forms.TextBox txtVoltaje;
        private System.Windows.Forms.TextBox txtHp;
        private System.Windows.Forms.TextBox txtMarca;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnReg;
        private System.Windows.Forms.ComboBox cmbTipo;
        private System.Windows.Forms.TextBox txtModelo;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cmbEstatus;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtObservaciones;
        private System.Windows.Forms.ComboBox cmbCategoria;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox cmbPosicion;
        private System.Windows.Forms.Button btnVolver;
    }
}