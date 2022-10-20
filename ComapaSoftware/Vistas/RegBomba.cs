using ComapaSoftware.Controlador;
using ComapaSoftware.Modelo;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
namespace ComapaSoftware.Vistas
{

    public partial class RegBomba : Form
    {
        ControladorBombas controlador = new ControladorBombas();
        ModeloBombas modeloBombas = new ModeloBombas();
        public RegBomba()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (cmbCategoria.SelectedIndex >= 0)
            {
                
                cmbIdPlanta.Enabled = true;
                cmbIdPlanta.Items.Clear();
                foreach (CriterioRegistroBomba cr in modeloBombas.obtenerIdFicha3(cmbCategoria.Text))
                {
                    cmbIdPlanta.Items.Add(cr.IdPlantas + cr.Slug + cr.Servicio);
                    
                }

            }
            else
            {
                Console.WriteLine("Algo ha salido mal");
            }
        }

        private void RegBomba_Load(object sender, EventArgs e)
        {
            cmbIdPlanta.Enabled = false;
        }

        private void cmbIdPlanta_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbIdPlanta.SelectedIndex >= 0)
            {
                panelMain.Enabled = true;
                MessageBox.Show(cmbIdPlanta.Text);
            }
        }
    }
}
