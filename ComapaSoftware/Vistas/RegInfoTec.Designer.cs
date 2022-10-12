namespace ComapaSoftware.Vistas
{
    partial class RegInfoTec
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
            this.cmbId = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmbServicio = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbTipo = new System.Windows.Forms.ComboBox();
            this.txtInst = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.txtProm = new System.Windows.Forms.TextBox();
            this.txtGarant = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.txtEquinst = new System.Windows.Forms.TextBox();
            this.txtOpmin = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCap = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbCategoria = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtObservacion = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbId
            // 
            this.cmbId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbId.FormattingEnabled = true;
            this.cmbId.Location = new System.Drawing.Point(9, 173);
            this.cmbId.Name = "cmbId";
            this.cmbId.Size = new System.Drawing.Size(141, 21);
            this.cmbId.TabIndex = 0;
            this.cmbId.SelectedIndexChanged += new System.EventHandler(this.cmbId_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.txtObservacion);
            this.panel1.Controls.Add(this.cmbServicio);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.cmbTipo);
            this.panel1.Controls.Add(this.txtInst);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.txtProm);
            this.panel1.Controls.Add(this.txtGarant);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.txtEquinst);
            this.panel1.Controls.Add(this.txtOpmin);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtCap);
            this.panel1.Location = new System.Drawing.Point(188, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(659, 449);
            this.panel1.TabIndex = 1;
            this.panel1.Visible = false;
            // 
            // cmbServicio
            // 
            this.cmbServicio.FormattingEnabled = true;
            this.cmbServicio.Items.AddRange(new object[] {
            "Bombeo",
            "Rebombeo",
            "Potabilizadora",
            "Tanque",
            "Pozo",
            "Carcamo",
            "Sin sub-categoria"});
            this.cmbServicio.Location = new System.Drawing.Point(449, 105);
            this.cmbServicio.Name = "cmbServicio";
            this.cmbServicio.Size = new System.Drawing.Size(134, 21);
            this.cmbServicio.TabIndex = 17;
            this.cmbServicio.Text = "--Seleccione servicio--";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(446, 62);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(45, 13);
            this.label13.TabIndex = 16;
            this.label13.Text = "Servicio";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(24, 16);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(201, 13);
            this.label10.TabIndex = 15;
            this.label10.Text = "Introduzca la informacion general tecnica";
            // 
            // cmbTipo
            // 
            this.cmbTipo.FormattingEnabled = true;
            this.cmbTipo.Items.AddRange(new object[] {
            "Manual",
            "Automatico"});
            this.cmbTipo.Location = new System.Drawing.Point(279, 200);
            this.cmbTipo.Name = "cmbTipo";
            this.cmbTipo.Size = new System.Drawing.Size(121, 21);
            this.cmbTipo.TabIndex = 14;
            this.cmbTipo.Text = "--Seleccione Tipo--";
            // 
            // txtInst
            // 
            this.txtInst.Location = new System.Drawing.Point(279, 346);
            this.txtInst.Name = "txtInst";
            this.txtInst.Size = new System.Drawing.Size(121, 20);
            this.txtInst.TabIndex = 13;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(443, 413);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(200, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Volver";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtProm
            // 
            this.txtProm.Location = new System.Drawing.Point(279, 300);
            this.txtProm.Name = "txtProm";
            this.txtProm.Size = new System.Drawing.Size(121, 20);
            this.txtProm.TabIndex = 12;
            // 
            // txtGarant
            // 
            this.txtGarant.Location = new System.Drawing.Point(279, 253);
            this.txtGarant.Name = "txtGarant";
            this.txtGarant.Size = new System.Drawing.Size(121, 20);
            this.txtGarant.TabIndex = 11;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(79, 413);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(201, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Agregar Informacion";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtEquinst
            // 
            this.txtEquinst.Location = new System.Drawing.Point(279, 152);
            this.txtEquinst.Name = "txtEquinst";
            this.txtEquinst.Size = new System.Drawing.Size(121, 20);
            this.txtEquinst.TabIndex = 9;
            // 
            // txtOpmin
            // 
            this.txtOpmin.Location = new System.Drawing.Point(279, 106);
            this.txtOpmin.Name = "txtOpmin";
            this.txtOpmin.Size = new System.Drawing.Size(121, 20);
            this.txtOpmin.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(23, 353);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(110, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "Gasto Instalado (LPS)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(23, 303);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(111, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Gasto Promedio (LPS)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 253);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(225, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Cantidad De Equipos P/ Garantizar Operacion";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 208);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Tipo";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 159);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Equipos Instalados";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(183, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Cantidad de Eq./P Operacion Minima";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Capacidad de Equipos";
            // 
            // txtCap
            // 
            this.txtCap.Location = new System.Drawing.Point(279, 62);
            this.txtCap.Name = "txtCap";
            this.txtCap.Size = new System.Drawing.Size(121, 20);
            this.txtCap.TabIndex = 0;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 141);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(76, 13);
            this.label8.TabIndex = 4;
            this.label8.Text = "ID de la planta";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 18);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(0, 13);
            this.label9.TabIndex = 5;
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
            "EBAP",
            "Obra de toma",
            "Rebombeo de agua cruda"});
            this.cmbCategoria.Location = new System.Drawing.Point(11, 87);
            this.cmbCategoria.Name = "cmbCategoria";
            this.cmbCategoria.Size = new System.Drawing.Size(139, 21);
            this.cmbCategoria.TabIndex = 6;
            this.cmbCategoria.SelectedIndexChanged += new System.EventHandler(this.comboBox3_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(8, 18);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(174, 13);
            this.label11.TabIndex = 7;
            this.label11.Text = "Llene los campos de categoria e ID";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(15, 51);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(52, 13);
            this.label12.TabIndex = 8;
            this.label12.Text = "Categoria";
            // 
            // txtObservacion
            // 
            this.txtObservacion.Location = new System.Drawing.Point(443, 254);
            this.txtObservacion.Multiline = true;
            this.txtObservacion.Name = "txtObservacion";
            this.txtObservacion.Size = new System.Drawing.Size(200, 112);
            this.txtObservacion.TabIndex = 18;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(446, 222);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(78, 13);
            this.label14.TabIndex = 19;
            this.label14.Text = "Observaciones";
            // 
            // RegInfoTec
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(849, 450);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.cmbCategoria);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cmbId);
            this.Name = "RegInfoTec";
            this.Text = "Agregar Informacion tecnica";
            this.Load += new System.EventHandler(this.RegInfoTec_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbId;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cmbTipo;
        private System.Windows.Forms.TextBox txtInst;
        private System.Windows.Forms.TextBox txtProm;
        private System.Windows.Forms.TextBox txtGarant;
        private System.Windows.Forms.TextBox txtEquinst;
        private System.Windows.Forms.TextBox txtOpmin;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCap;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbCategoria;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cmbServicio;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtObservacion;
    }
}