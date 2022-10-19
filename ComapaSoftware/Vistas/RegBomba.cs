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
                foreach (var item in modeloBombas.obtenerIdFicha3(cmbCategoria.Text))
                {
                    cmbIdPlanta.Items.Add(item);
                }

                
                //foreach (var item in modeloBombas.obtenerIdFicha2(cmbCategoria.Text))
                //{
                //    cmbIdPlanta.Items.Add(item);
                //}
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
                Console.WriteLine(cmbIdPlanta.Text);
                panelMain.Enabled = true;
            }
        }
    }
}
