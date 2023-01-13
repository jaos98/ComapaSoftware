using MySql.Data.MySqlClient;
using System;

namespace ComapaSoftware
{
    internal class Conexion
    {
        //DECLARACION DE VARIABLES A UTILIZAR PARA CONEXION
        MySqlCommand query = new MySqlCommand();
        MySqlConnection conn;
        MySqlDataReader consultar;
        private string sql = "Server=localhost; Port=3306; Database=comapainfo2; Uid=root; Pwd=;";

        //VARIABLES PUBLICAS DE LA CLASE
        public MySqlCommand Query
        {
            get { return query; }
            set { query = value; }
        }
        public MySqlConnection Conn
        {
            get { return conn; }
            set { conn = value; }
        }
        public MySqlDataReader Consultar
        {
            get { return consultar; }
            set { consultar = value; }
        }
        //ACCESO A LA CLASE Y SUS METODOS
        public Conexion()
        {
            conectarBase();
        }
        //METODO DE CONEXION A LA BASE DE DATOS
        public void conectarBase()
        {
            try
            {
                Conn = new MySqlConnection();
                if (Conn != null)
                {
                    Conn.ConnectionString = sql;
                    Conn.Open();
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex);
            }
        }
        //METODO DE COMPROBACION DE INICIO DE SESION DE USUARIO
        public bool LogIn(string usuario, string contraseña)
        {
            try
            {
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
