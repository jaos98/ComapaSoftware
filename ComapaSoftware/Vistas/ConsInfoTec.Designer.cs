﻿namespace ComapaSoftware.Vistas
{
    partial class ConsInfoTec
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.btnVolver = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.controladorInfoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.controladorPlantasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.controladorPlantasBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.controladorPlantasBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.controladorInfoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.controladorPlantasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.controladorPlantasBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.controladorPlantasBindingSource2)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1073, 237);
            this.dataGridView1.TabIndex = 9;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentDoubleClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 400);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(155, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "Editar Informacion Tecnica";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(352, 400);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(155, 23);
            this.btnVolver.TabIndex = 11;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 270);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Observaciones";
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(565, 256);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(520, 173);
            this.panel1.TabIndex = 14;
            // 
            // controladorInfoBindingSource
            // 
            this.controladorInfoBindingSource.DataSource = typeof(ComapaSoftware.Controlador.ControladorInfo);
            // 
            // controladorPlantasBindingSource
            // 
            this.controladorPlantasBindingSource.DataSource = typeof(ComapaSoftware.Controlador.ControladorPlantas);
            // 
            // controladorPlantasBindingSource1
            // 
            this.controladorPlantasBindingSource1.DataSource = typeof(ComapaSoftware.Controlador.ControladorPlantas);
            // 
            // controladorPlantasBindingSource2
            // 
            this.controladorPlantasBindingSource2.DataSource = typeof(ComapaSoftware.Controlador.ControladorPlantas);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(127, 270);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(380, 96);
            this.richTextBox1.TabIndex = 15;
            this.richTextBox1.Text = "";
            // 
            // ConsInfoTec
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1097, 441);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "ConsInfoTec";
            this.Text = "ConsInfoTec";
            this.Load += new System.EventHandler(this.ConsInfoTec_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.controladorInfoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.controladorPlantasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.controladorPlantasBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.controladorPlantasBindingSource2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.BindingSource controladorInfoBindingSource;
        private System.Windows.Forms.BindingSource controladorPlantasBindingSource;
        private System.Windows.Forms.BindingSource controladorPlantasBindingSource1;
        private System.Windows.Forms.BindingSource controladorPlantasBindingSource2;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}