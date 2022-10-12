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


            //string result = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                //MessageBox.Show("Diste un solo click");
               // labelDesc.Text = modelo.traerDescripcion(result);
            
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Index.ToString() == "-1")
            {
                string result = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                MessageBox.Show(result);
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
