using System;
using System.Collections.Generic;
using System.Data;
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

        //REGISTRO DE PLANTAS SIN PARAMETROS
        public void insertarPlanta(string idPlantas,string numMedidor, string numServicio,string tipoPlanta, string estatus, string descFunciones, string colonia, string sector, string latitud, string longitud, string elevacion, string servicio, string domicilio)
        {
         
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


       


        //INSERT CON PARAMETROS (PRUEBA)
        public int insertarEquipo(string idPlantas, string numMedidor, string numServicio, string tipoPlanta, string estatus, string descFunciones, string colonia, string sector, string latitud, string longitud, string elevacion, string servicio, string domicilio)
        {
            int numRegistros = 0;
            string sqlEjecutar = "INSERT INTO `plantascomapa`(`IdPlantas`, `NumMedidor`, `NumServicio`, `TipoPlantas`, `Estatus`, " +
                    "`DescFunciones`, `Colonia`, `Sector`, `Latitud`, `Longitud`, `Elevacion`, `Servicio`, `Domicilio`) " +
                    "VALUES (@idPlantas,@numMedidor,@numServicio,@tipoPlanta,@estatus,@descFunciones,@colonia,@sector,@latitud,@longitud,@elevacion,@servicio,@domicilio);";
            try
            {
                
                Conn.Close();
                Query.Connection = Conn;
                Query.CommandText = sqlEjecutar;
                Query.Parameters.Add("@idPlantas", MySqlDbType.String).Value = idPlantas;
                Query.Parameters.Add("@numMedidor", MySqlDbType.String).Value = numMedidor;
                Query.Parameters.Add("@numServicio", MySqlDbType.String).Value = numServicio;
                Query.Parameters.Add("@tipoPlanta", MySqlDbType.String).Value = tipoPlanta;
                Query.Parameters.Add("@estatus", MySqlDbType.String).Value = estatus;
                Query.Parameters.Add("@descFunciones", MySqlDbType.String).Value = descFunciones;
                Query.Parameters.Add("@colonia", MySqlDbType.String).Value = colonia;
                Query.Parameters.Add("@sector", MySqlDbType.String).Value = sector;
                Query.Parameters.Add("@latitud", MySqlDbType.String).Value = latitud;
                Query.Parameters.Add("@longitud", MySqlDbType.String).Value = longitud;
                Query.Parameters.Add("@elevacion", MySqlDbType.String).Value = elevacion;
                Query.Parameters.Add("@servicio", MySqlDbType.String).Value = servicio;
                Query.Parameters.Add("@domicilio", MySqlDbType.String).Value = domicilio;
                Conn.Open();
                numRegistros = Query.ExecuteNonQuery();
                return numRegistros;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error al añadir dispositivo");
                Console.WriteLine(ex);
                return numRegistros; //0 si ha habido algún error
            }
            finally
            {
                Conn.Close();
            }
        }
        public DataTable llevarDatos(string globalReceiver)
        {
            string sql = "SELECT IdPlantas,NumMedidor,NumServicio,TipoPlantas,Estatus,Domicilio,Servicio " +
                "FROM plantascomapa WHERE IdPlantas = '" + globalReceiver + "' OR TipoPlantas = '" + globalReceiver + "' ";
            conectarBase();
            try
            {
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter(sql, Conn);
                DataTable dt = new DataTable();
                dataAdapter.Fill(dt);
                Conn.Close();
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Conn.Close();
                throw;
            }
        }
        public DataTable dataSender()
        {
            string sql = "SELECT * " +
                "FROM plantascomapa";
            conectarBase();
            try
            {
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter(sql, Conn);
                DataTable dt = new DataTable();
                dataAdapter.Fill(dt);
                return dt;
            }
            catch (Exception)
            {

                throw;
            }

        }
        public DataTable consultaAdicional(string globalEntry)
        {
            string sql = "SELECT IdPlantas,NumMedidor,NumServicio,TipoPlantas,Estatus,Domicilio,Servicio " +
                "FROM plantascomapa WHERE (IdPlantas = '"+globalEntry+"') OR (TipoPlantas ='"+globalEntry+"') ";
            conectarBase();
            try
            {
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter(sql, Conn);
                DataTable dt = new DataTable();
                dataAdapter.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }

        }

    }
}
