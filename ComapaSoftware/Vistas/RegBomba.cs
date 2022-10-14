using ComapaSoftware.Modelo;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
namespace ComapaSoftware.Vistas
{

    public partial class RegBomba : Form
    {
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
            //if (cmbCategoria.SelectedIndex <0)
            //{
            //    Console.WriteLine("Algo salio mal");
            //}
            //else
            //{
            //    cmbIdPlanta.Enabled = true;
            //    string cmbresult = cmbCategoria.Text;
            //    foreach (var item in modeloBombas.obtenerId(cmbresult))
            //    {
            //        cmbIdPlanta.Items.Add(item);
            //    }

            //}
        }

        private void RegBomba_Load(object sender, EventArgs e)
        {
            cmbIdPlanta.Enabled = false;
            foreach (var item in modeloBombas.obtenerIdFicha())
            {
                cmbCategoria.Items.Add(item);
            }
        }
    }
}
