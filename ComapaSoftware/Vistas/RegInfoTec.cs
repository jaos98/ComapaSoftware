using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComapaSoftware.Modelo;

namespace ComapaSoftware.Vistas
{
    public partial class RegInfoTec : Form
    {
        ModeloFichaTecnica model = new ModeloFichaTecnica();
        public RegInfoTec()
        {
            InitializeComponent();
            
        }

        private void RegInfoTec_Load(object sender, EventArgs e)
        {
            cmbId.Enabled = false;
           
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCategoria.SelectedIndex <0)
            {
                MessageBox.Show("Hubo un error, consulte con el administrador");
            }else if (cmbCategoria.SelectedIndex >=0)
            {
                cmbId.Enabled = true;
                cmbId.Items.Clear();
                string catString = cmbCategoria.Text;
                MessageBox.Show(catString);
                foreach (var item in model.obtenerId(catString))
                {
                    cmbId.Refresh();
                    cmbId.Items.Add(item);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            FormPanel formPanel = new FormPanel();
            formPanel.Show();
        }

        private void cmbId_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbId.SelectedIndex<0)
            {
                Console.WriteLine("No hay resultado");
            }
            else
            {
                Console.WriteLine(cmbId.SelectedIndex.ToString());
                panel1.Visible = true;
            }
        }
    }
}
