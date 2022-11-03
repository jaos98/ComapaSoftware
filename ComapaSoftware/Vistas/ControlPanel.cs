using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;
namespace ComapaSoftware.Vistas
{
    public partial class FormPanel : Form
    {
        MySqlCommand Query = new MySqlCommand();
        MySqlConnection Conn;
        MySqlDataReader consultar;
        public FormPanel()
        {
            InitializeComponent();
        }
        public void conectarBase()
        {
            Conn = new MySqlConnection();
            string sql = "server=localhost;user id=root; database=comapainfo;password=;";
            Conn.ConnectionString = sql;
            Conn.Open();
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Hide();
            FormPlanta formPlanta = new FormPlanta();
            formPlanta.Show();
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            //consultarDato();
            if (txtConsulta.Text == "")
            {
                MessageBox.Show("Por favor introduzca la informacion correcta");
            }
            else
            {
                string senderInfo = txtConsulta.Text;
                Hide();
                FormResultado formResultado = new FormResultado(senderInfo);
                formResultado.Show();
            }
        }
        private void btnBuscarCat_Click(object sender, EventArgs e)
        {
            if (cmbCategoria.Text == "--Seleccione categoria--")
            {
                MessageBox.Show("Porfavor seleccione categoria para consulta");
            }
            else
            {
                string senderInfo = cmbCategoria.Text;
                Hide();
                FormResultado formResultado = new FormResultado(senderInfo);
                formResultado.Show();
            }
        }

        private void btnInfoTec_Click(object sender, EventArgs e)
        {
            Hide();
            RegInfoTec regInfoTec = new RegInfoTec();
            regInfoTec.Show();
        }

        private void btnBombas_Click(object sender, EventArgs e)
        {
            Hide();
            RegBomba regBomba = new RegBomba();
            regBomba.Show();
        }

        private void FormPanel_Load(object sender, EventArgs e)
        {

        }
        public void consultarDato()
        {
            try
            {
                conectarBase();
                Console.WriteLine("Conectado con exito!");
                Query.CommandText = "SELECT IdPlantas,NumMedidor,NumServicio FROM plantascomapa";
                Query.Connection = Conn;
                consultar = Query.ExecuteReader();
                while (consultar.Read())
                {
                    string IdPlantas = consultar.GetString(0);
                    string NumMedidor = consultar.GetString(1);
                    string NumServicio = consultar.GetString(2);
                    MessageBox.Show("Resultados: \n" + IdPlantas + "\n" + NumMedidor + "\n" + NumServicio + "\n");
                }
                Conn.Close();
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}
