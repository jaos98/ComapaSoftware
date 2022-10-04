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
                Query.CommandText = "SELECT IdSector,NombreSector FROM sector";
                Query.Connection = Conn;
                consultar = Query.ExecuteReader();
                while (consultar.Read())
                {
                    string result = consultar.GetString(1);
                    Console.WriteLine(result);
                    lista.Add(result);
                }
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e);
            }
            return lista;
        }

        public string obtenerID(string idObtenido)
        {
            try
            {
                conectarBase();
                Query.CommandText = "SELECT IdSector FROM sector WHERE NombreSector = '"+idObtenido+"'";
                Query.Connection = Conn;
                consultar = Query.ExecuteReader();
                while (consultar.Read())
                {
                    idObtenido = consultar.GetString(0);
                    Console.WriteLine(idObtenido);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return idObtenido;
        }

        public List<string> compararDatos(string resultId)
        {
            List<string> helper = new List<string>();
            conectarBase();
            Query.CommandText = "SELECT sector.IdSector, colonia.NombreColonia FROM sector " +
                "INNER JOIN colonia ON sector.IdSector = colonia.IdSector WHERE sector.IdSector = '"+resultId+"'";
            Query.Connection = Conn;
            consultar = Query.ExecuteReader();
            while (consultar.Read())
            {
                string res = consultar.GetString(1);
                helper.Add(res);
            }
            return helper;
        }


        public void insertarPlanta(string idPlantas,string numMedidor, string numServicio,string tipoPlanta, string estatus, string descFunciones, string colonia, string sector, string latitud, string longitud, string elevacion, string servicio, string domicilio)
        {
            //Registro de plantas
            try
            {
                conectarBase();
                Query.CommandText = "INSERT INTO `plantascomapa`(`IdPlantas`, `NumMedidor`, `NumServicio`, `TipoPlantas`, `Estatus`, " +
                    "`DescFunciones`, `Colonia`, `Sector`, `Latitud`, `Longitud`, `Elevacion`, `Servicio`, `Domicilio`) " +
                    "VALUES ('"+idPlantas+"','"+numMedidor+"','"+numServicio+ "','" + tipoPlanta + "','" + estatus + "','" + descFunciones + "','" + colonia + "','" + sector + "','" + latitud + "','" + longitud + "','" + elevacion + "','" + servicio + "','" + domicilio +"');";               
                Query.Connection = Conn;
                Query.ExecuteNonQuery();
               
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            Console.WriteLine("La info se registro, creo");
        }


        //public ComboBox.ObjectCollection consultarSector2(ComboBox cmbSector)
        //{
        //    ComboBox.ObjectCollection Items = new ComboBox.ObjectCollection(cmbSector);
        //    try
        //    {
        //        conectarBase();
        //        Query.CommandText = "SELECT NombreSector FROM sector";
        //        Query.Connection = Conn;
        //        consultar = Query.ExecuteReader();
        //        while (consultar.Read())
        //        {

        //            string result = consultar.GetString(0);
        //            Items.Add(result);
        //        }
        //    }
        //    catch (MySqlException e)
        //    {
        //        Console.WriteLine(e);
        //    }
        //    return Items;
        //}
    }
}
