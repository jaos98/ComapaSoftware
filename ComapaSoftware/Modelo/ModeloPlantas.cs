using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComapaSoftware.Controlador;
using MySql.Data.MySqlClient;

namespace ComapaSoftware.Modelo
{
    internal class ModeloPlantas
    {
        Conexion conn = new Conexion();
        ControladorInfo controlador = new ControladorInfo();
        MySqlCommand Query = new MySqlCommand();
        MySqlConnection Conn;
        MySqlDataReader consultar;
        public void conectarBase()
        {
            Conn = new MySqlConnection();
            string sql = "server=localhost;user id=root; database=comapainfo;password=;";
            Conn.ConnectionString = sql;
            Conn.Open();
        }
        public void insertarPlanta(string idPlanta, string numMedidor)
        {
            
        }
        public List<string> consultarSector()
        {
            List<string> lista = new List<string>();
            try
            {
                conectarBase();
                Query.CommandText = "SELECT NombreSector FROM sector";
                Query.Connection = Conn;
                consultar = Query.ExecuteReader();
                while (consultar.Read())
                {
                    
                    string result = consultar.GetString(0);

                   
                    lista.Add(result);
                }
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e);
            }
            return lista;
        }
        public ComboBox.ObjectCollection consultarSector2(ComboBox cmbSector)
        {
            ComboBox.ObjectCollection Items = new ComboBox.ObjectCollection(cmbSector);
            try
            {
                conectarBase();
                Query.CommandText = "SELECT NombreSector FROM sector";
                Query.Connection = Conn;
                consultar = Query.ExecuteReader();
                while (consultar.Read())
                {

                    string result = consultar.GetString(0);
                    Items.Add(result);
                }
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e);
            }
            return Items;
        }
    }
}
