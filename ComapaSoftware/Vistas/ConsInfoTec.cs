using ComapaSoftware.Controlador;
using ComapaSoftware.Modelo;
using System;
using System.Windows.Forms;
namespace ComapaSoftware.Vistas
{
    public partial class ConsInfoTec : Form
    {
        ControladorFicha c = new ControladorFicha();
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
            dataGridView1.DataSource = c.llevarDatos(globalReceiver);
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
                string result = c.traerDescripcion(dataGridView1.CurrentRow.Cells[1].Value.ToString());

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
                //RECIBE ID ESTACION
                string idEstacion = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                Close();
                ConsBombas consBombas = new ConsBombas(idEstacion);
                consBombas.Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
            ControlPanel controlPanel = new ControlPanel();
            controlPanel.Show();
        }
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                atts.Result = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                c.traerDescripcion(atts.Result);
            }
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            //RECIBE ID ESTACION
            string idEstacion = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            Close();
            ConsBombas consBombas = new ConsBombas(idEstacion);
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

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            bool pressedButton = true;
            if (pressedButton && (MessageBox.Show("¿Desea eliminar esta planta?", "Eliminar registro",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                == System.Windows.Forms.DialogResult.Yes))
            {
                string result = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                c.Delete(result);
                traerDatos();
            }
        }
    }
}
