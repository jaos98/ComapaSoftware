using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComapaSoftware.Controlador;

namespace ComapaSoftware.Vistas
{
    public partial class FormResultado : Form
    {
        string globalReceiver;
        MySqlCommand Query = new MySqlCommand();
        MySqlConnection Conn;
        MySqlDataReader consultar;
        ControladorPlantas controladorPlantas = new ControladorPlantas();
        public FormResultado(string senderInfo)
        {
            controladorPlantas.ReceiverInfo = senderInfo;
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
            string sql = "SELECT IdPlantas,NumMedidor,NumServicio,TipoPlantas,Estatus FROM plantascomapa";
            conectarBase();
            try
            {
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter(sql, Conn);
                DataTable dt = new DataTable();
                dataAdapter.Fill(dt);
                dataGridView1.DataSource = dt;
                Conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Conn.Close();
                throw;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            traerDatos();
        }

        private void FormResultado_Load(object sender, EventArgs e)
        {
            
        }
    }
}
