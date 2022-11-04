using ComapaSoftware.Controlador;
using ComapaSoftware.Modelo;
using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace ComapaSoftware.Vistas
{
    public partial class FormResultado : Form
    {
        string globalReceiver;
        MySqlCommand Query = new MySqlCommand();
        MySqlConnection Conn;
        MySqlDataReader consultar;
        public FormResultado(string senderInfo)
        {
            globalReceiver = senderInfo;
            InitializeComponent();
            FormPlanta formPlanta = new FormPlanta();
            formPlanta.FormBorderStyle = FormBorderStyle.FixedDialog;
            formPlanta.StartPosition = FormStartPosition.CenterScreen;
        }
        public void conectarBase()
        {
            Conn = new MySqlConnection();
            string sql = "server=localhost;user id=root; database=comapainfo;password=;";
            Conn.ConnectionString = sql;
            Conn.Open();
        }

        public void traerDatos()
        {
            ModeloPlantas modeloPlantas = new ModeloPlantas();
            dataGridView1.DataSource = modeloPlantas.llevarDatos(globalReceiver);
        }
        public void traerTodo()
        {
            ModeloPlantas modeloPlantas = new ModeloPlantas();
            dataGridView1.DataSource = modeloPlantas.dataSender();
        }
        public void consultaTecnica()
        {
            ModeloPlantas modeloPlantas = new ModeloPlantas();
            dataGridView1.DataSource = modeloPlantas.dataSender();
        }
        public void consultaAdicional()
        {
            string globalEntry = txtAdicional.Text;
            ModeloPlantas modeloPlantas = new ModeloPlantas();
            dataGridView1.DataSource = modeloPlantas.consultaAdicional(globalEntry);
            dataGridView1.Refresh();
        }






        private void button1_Click(object sender, EventArgs e)
        {

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
                this.Close();
                ConsInfoTec consInfoTec = new ConsInfoTec(result);
                consInfoTec.Show();
            }


        }
    }
}
