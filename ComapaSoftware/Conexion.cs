using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComapaSoftware
{
    internal class Conexion
    {
        //DECLARACION DE VARIABLES A UTILIZAR PARA CONEXION
        MySqlCommand query = new MySqlCommand();
        MySqlConnection conn;
        MySqlDataReader consultar;
        private string sql = "server=localhost;user id=root; database=comapainfo;password=;";
        
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
        public string Sql
        {
            set { sql = value; }
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
            catch (Exception ex)
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
