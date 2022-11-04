using ComapaSoftware.Controlador;
using ComapaSoftware.Modelo;
using System;
using System.Windows.Forms;
namespace ComapaSoftware.Vistas
{
    public partial class ConsInfoTec : Form
    {
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
            if (e.RowIndex >= 0)
            {
                string result = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                this.Close();
                ConsBombas consBombas = new ConsBombas(result);
                consBombas.Show();
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
