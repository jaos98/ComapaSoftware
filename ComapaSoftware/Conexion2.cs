using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComapaSoftware
{
    internal class Conexion2
    {
        MySqlCommand query;
        MySqlConnection conn;
        MySqlDataReader consultar;
        private string sql = "server=localhost;user id=root; database=comapainfo;password=;";

        public MySqlCommand Query
        {
            get { return query; }
            set { query = value; }
        }
        public MySqlConnection Conn
        {
            get { return conn;}
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

        //public Conexion2(MySqlCommand query,MySqlConnection conn,MySqlDataReader consultar)
        //{
        //    this.query = query;
        //    this.conn = conn;
        //    this.consultar = consultar;
        //}
        public Conexion2()
        {
            conectarBase();
        }
        public void conectarBase()
        {
            Conn.ConnectionString = sql;
            Conn.Open();
        }

    }
}
