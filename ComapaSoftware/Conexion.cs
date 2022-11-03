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
        public void conectarBase()
        {
            Conn = new MySqlConnection();
            Conn.ConnectionString = sql;
            Conn.Open();
            Console.WriteLine("Conectado con exito!");
        }
        public bool validarUsuario(string usuario, string contraseña)
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
