using ComapaSoftware.Controlador;
using ComapaSoftware.Modelo;
using System;
using System.Windows.Forms;
namespace ComapaSoftware.Vistas
{
    public partial class ConsInfoTec : Form
    {
        ModeloFichaTecnica modelo = new ModeloFichaTecnica();
        AttsInfo atts = new AttsInfo();
        string globalReceiver;
        public ConsInfoTec()
        {

        }
        public ConsInfoTec(string result)
        {
            InitializeComponent();
            globalReceiver = result;  
        }
        //METODO QUE CARGA LOS DATOS EN LA TABLA PRINCIPAL
        public void traerDatos()
        {
            dataGridView1.DataSource = modelo.llevarDatos(globalReceiver);
        }
        //METODO DE CARGA DE ELEMENTOS DEL FORM
        private void ConsInfoTec_Load(object sender, EventArgs e)
        {
            MessageBox.Show(globalReceiver);
            traerDatos();
        }
        //METODO AL HACER UN CLICK EN LA TABLA
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dataGridView1.Refresh();
                //richTextBox1.Text = modelo.traerDescripcion(atts.Result);
                string result = modelo.traerDescripcion(dataGridView1.CurrentRow.Cells[1].Value.ToString());

                richTextBox1.Text = result;
                //TRAER DESCRIPCIONES
                /**
                
                 **/
            }
        }
        //METODO AL HACER DOBLE CLICK EN LA TABLA
        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.Refresh();
            if (e.RowIndex >= 0)
            {
                string result = dataGridView1.CurrentRow.Cells[1].Value.ToString();
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
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                atts.Result = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                modelo.traerDescripcion(atts.Result);
            }
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            string result = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            Close();
            ConsBombas consBombas = new ConsBombas(result);
            consBombas.Show();
        }
        class AttsInfo
        {
            private string result;
            private string result2;

            public string Result
            {
                get { return result; }
                set { result = value; }
            }
            public string Result2
            {
                get { return result2; }
                set { result2 = value; }
            }

            public AttsInfo()
            {

            }

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            string result = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            ActInfoTec actInfoTec = new ActInfoTec(result);
            actInfoTec.Show();
        }
    }
}
