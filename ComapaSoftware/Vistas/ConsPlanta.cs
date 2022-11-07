using ComapaSoftware.Controlador;
using ComapaSoftware.Modelo;
using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace ComapaSoftware.Vistas
{
    public partial class FormResultado : Form
    {
        ModeloPlantas m = new ModeloPlantas();
        string globalReceiver;
        string getIndex;
        public FormResultado(string senderInfo)
        {
            globalReceiver = senderInfo;
            InitializeComponent();
            FormPlanta formPlanta = new FormPlanta();
            formPlanta.FormBorderStyle = FormBorderStyle.FixedDialog;
            formPlanta.StartPosition = FormStartPosition.CenterScreen;
        }

        public void traerDatos()
        {

            dataGridView1.DataSource = m.llevarDatos(globalReceiver);
        }
        public void traerTodo()
        {

            dataGridView1.DataSource = m.dataSender();
        }
        public void consultaTecnica()
        {

            dataGridView1.DataSource = m.dataSender();
        }
        public void consultaAdicional()
        {
            string globalEntry = txtAdicional.Text;

            dataGridView1.DataSource = m.consultaAdicional(globalEntry);
            dataGridView1.Refresh();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //Aqui me quede
            string result = dataGridView1.Rows[ new RowsP().Arg.RowIndex].Cells[0].Value.ToString();
            MessageBox.Show(result);
            //Close();
            //ConsInfoTec consInfoTec = new ConsInfoTec(result);
            //consInfoTec.Show();
        }

        private void FormResultado_Load(object sender, EventArgs e)
        {
            traerDatos();
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            traerTodo();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            consultaAdicional();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
            FormPanel formPanel = new FormPanel();
            formPanel.Show();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {

            }

        }
        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string result = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                Close();
                ConsInfoTec consInfoTec = new ConsInfoTec(result);
                consInfoTec.Show();
            }


        }
        class RowsP
        {
            DataGridViewCellEventArgs arg;


            public DataGridViewCellEventArgs Arg
            {
                get { return arg; }
                set { arg = value; }
            }
            public RowsP(DataGridViewCellEventArgs Arg)
            {
                this.Arg = Arg;
            }

            public RowsP()
            {

            }


        }
    }
}
