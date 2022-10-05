using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

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
        
        

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormPlanta formPlanta = new FormPlanta();
            formPlanta.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //consultarDato();
            this.Hide();
            FormResultado formResultado = new FormResultado();
            formResultado.Show();
        }

        public void consultarDato()
        {
            try
            {
                
                Conn = new MySqlConnection();
                string sql = "server=localhost;user id=root; database=comapainfo;password=;";
                Conn.ConnectionString = sql;
                Conn.Open();
                Console.WriteLine("Conectado con exito!");
                Query.CommandText = "SELECT IdPlantas,NumMedidor,NumServicio FROM plantascomapa";
                Query.Connection = Conn;
                consultar = Query.ExecuteReader();
                while (consultar.Read())
                {
                    string IdPlantas = consultar.GetString(0);
                    string NumMedidor = consultar.GetString(1);
                    string NumServicio = consultar.GetString(2);
                    // Console.WriteLine("Resultados: \n" + IdPlantas + "" + NumMedidor + "" + NumServicio + "");
                    MessageBox.Show("Resultados: \n" + IdPlantas + "\n" + NumMedidor + "\n" + NumServicio + "\n");
                }
                Conn.Close();
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.Message);
            }
        }




        //public void traerDatos()
        //{
        //    string sql = "SELECT IdPlantas,NumMedidor,NumServicio FROM plantascomapa";
        //    conectarBase();
        //    try
        //    {
        //        MySqlDataAdapter dataAdapter = new MySqlDataAdapter(sql,Conn);
        //        DataTable dt = new DataTable();
        //        dataAdapter.Fill(dt);


        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}
    }
}
