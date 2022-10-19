using MySql.Data.MySqlClient;
using System;

namespace ComapaSoftware
{
    public class Conexion
    {
        MySqlCommand Query = new MySqlCommand();
        MySqlConnection Conn;
        MySqlDataReader consultar;
        string sql = "server=localhost;user id=root; database=comapainfo;password=;";
        public void test_connection()
        {
            try
            {
                Conn = new MySqlConnection();
                Conn.ConnectionString = sql;
                Conn.Open();
                Console.WriteLine("Conexion realizada");
                Conn.Close();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e);
            }
        }
        public void conectarBase()
        {
            Conn = new MySqlConnection();
            Conn.ConnectionString = sql;
            Conn.Open();
            Console.WriteLine("Conectado con exito!");
        }

        public void consultarDato()
        {
            try
            {
                conectarBase();
                Query.CommandText = "SELECT IdPlantas,NumMedidor,NumServicio FROM plantascomapa";
                Query.Connection = Conn;
                consultar = Query.ExecuteReader();
                while (consultar.Read())
                {
                    string IdPlantas = consultar.GetString(0);
                    string NumMedidor = consultar.GetString(1);
                    string NumServicio = consultar.GetString(2);
                    Console.WriteLine("Resultados: \n" + IdPlantas + "" + NumMedidor + "" + NumServicio + "");

                }
                Conn.Close();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e);
            }

        }

        public void connExperimental()
        {
            try
            {
                MySqlCommand Query = new MySqlCommand();
                MySqlConnection Conn;
                MySqlDataReader consultar;
                string server = "localhost";
                string user_id = "root";
                string database = "comapainfo";
                string password = "";
                string sql = "server=" + server + ";" + "user id=" + user_id + ";" + "database=" + database + ";" + "password=" + password + ";";
                //string sql = "server=localhost;user id=root; database=comapainfo;password=;";
                Conn = new MySqlConnection(sql);
                Conn.Open();
                Console.WriteLine("Conectado con exito");
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e);
            }
        }

        public bool ConsultaExperimental(string usuario, string contraseña)
        {
            try
            {
                conectarBase();
                Query.CommandText = "SELECT CuentaUsuario,ContraseñaUsuario FROM `usuarios` WHERE CuentaUsuario = '" + usuario + "' AND ContraseñaUsuario='" + contraseña + "'";
                Query.Connection = Conn;
                consultar = Query.ExecuteReader();
                return consultar.HasRows;
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e);
                return false;
            }
        }



    }
}
