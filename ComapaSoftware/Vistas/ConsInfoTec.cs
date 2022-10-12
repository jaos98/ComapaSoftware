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
using ComapaSoftware.Controlador;
namespace ComapaSoftware.Vistas
{
    public partial class ConsInfoTec : Form
    {
        ControladorPlantas controler = new ControladorPlantas();
        ModeloFichaTecnica modelo = new ModeloFichaTecnica();
        string globalReceiver;
        public ConsInfoTec(string result)
        {
            InitializeComponent();
            globalReceiver = result;
        }

        public void traerDatos()
        {
            dataGridView1.DataSource = modelo.llevarDatos(globalReceiver);
        }
        private void ConsInfoTec_Load(object sender, EventArgs e)
        {
            MessageBox.Show(globalReceiver);
            traerDatos();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                richTextBox1.Text = modelo.traerDescripcion(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            }
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= -0)
            {
                richTextBox1.Text = modelo.traerDescripcion(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            FormPanel controlPanel = new FormPanel();
            controlPanel.Show();
        }


    }
}
