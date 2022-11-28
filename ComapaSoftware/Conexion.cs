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
        public string Sql
        {
            set { sql = value; }
        }

        //private string servidor;
        //private string bd;
        //private string usuario;
        //private string password;
        //private string datos = null;
        //public string Servidor { get { return servidor; } set { servidor = "https//mysql-96199-0.cloudclusters.net"; } }
        //public string Bd { get { return bd; } set { bd = "comapainfo"; } }
        //public string Usuario { get { return usuario; } set { usuario = "admin"; } }
        //public string Password { get { return password; } set { password = "mayx5w6K"; } }
        //public string Datos { get { return datos; } set { datos = null; } }
        







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
        //public void pruebaHost()
        //{
        //    string conectarBase = "Database=" + Bd + "; Data Source=" + Servidor + "; User Id=" + Usuario + "; Password=" + Password + "";
        //    MySqlConnection conexionBD = new MySqlConnection(conectarBase);
        //    MySqlDataReader reader = null;
        //    try
        //    {
        //        string consulta = "SHOW DATABASES";
        //        MySqlCommand comando = new MySqlCommand(consulta);
        //        comando.Connection = conexionBD;
        //        conexionBD.Open();
        //        reader = comando.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            datos += reader.GetString(0) + "\n";
        //        }
        //        Console.WriteLine(datos);
        //    }
        //    catch (MySqlException ex)
        //    {
        //        Console.WriteLine(ex);
        //        throw;
        //    }
        //    finally
        //    {
        //        conexionBD.Close();
        //    }
        //}

    }
}
