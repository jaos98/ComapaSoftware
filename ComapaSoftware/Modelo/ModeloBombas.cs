using ComapaSoftware.Controlador;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace ComapaSoftware.Modelo
{
    internal class ModeloBombas : Conexion
    {
        //CONSULTA DE ID PLANTAS PARA EL PRIMER COMBOBOX
        public List<string> ObtenerIdPlantas(string receiver) 
        {
        List<string> list = new List<string>();
            
            try
            {
                conectarBase();
                Query.CommandText = "SELECT IdPlantas FROM plantascomapa WHERE TipoPlantas= '" + receiver + "' ORDER BY IdPlantas DESC";
                Query.Connection = Conn;
                Consultar = Query.ExecuteReader();
                while (Consultar.Read())
                {
                    string helper;
                    helper = Consultar.GetString(0);
                    Console.WriteLine(helper);
                    list.Add(helper);
                }
                return list;
            }
            catch (Exception)
            {

                throw;
            }
        }
        //SEGUNDA CONSULTA DEL COMBOBOX (IDESTACION)
        public List<string> ObtenerIdEstacion(string receiver)
        {
            List<string> list = new List<string>();

            try
            {
                conectarBase();
                Query.CommandText = "SELECT IdEstacion FROM estaciones WHERE IdPlantas= '" + receiver + "'";
                Query.Connection = Conn;
                Consultar = Query.ExecuteReader();
                while (Consultar.Read())
                {
                    string helper;
                    helper = Consultar.GetString(0);
                    Console.WriteLine(helper);
                    list.Add(helper);
                }
                return list;
            }
            catch (Exception)
            {

                throw;
            }
        }
        //REGISTRO DE BOMBA
        public int registrarInfoBomba(string idEstacion, int posicion, string marca, string tipo,
          string modelo, string hp, string voltaje, string diametroDescarga, string gastoLps,
          string cargaDinamica, string rpm, string estatus, string fpm, string observaciones)
        {

            int numRegistros = 0;
            string sqlEjecutar = "INSERT INTO `bombas`(`IdEstacion`, `Posicion`, `Marca`, `Tipo`, `Modelo`, " +
                    "`Hp`, `Voltaje`, `Diametro`, `Lps`, `Carga`, `Rpm`, `Estatus`, `Fpm`, `Observaciones`) " +
                    "VALUES (@idEstacion,@posicion,@marca,@tipo,@modelo,@hp,@voltaje,@diametro,@lps,@cargaDinamica,@rpm,@estatus,@fpm,@observaciones);";
            try
            {
                Conn.Close();
                Query.Connection = Conn;
                Query.CommandText = sqlEjecutar;
                Query.Parameters.Add("@idEstacion", MySqlDbType.String).Value = idEstacion;
                Query.Parameters.Add("@posicion", MySqlDbType.Int16).Value = posicion;
                Query.Parameters.Add("@marca", MySqlDbType.String).Value = marca;
                Query.Parameters.Add("@tipo", MySqlDbType.String).Value = tipo;
                Query.Parameters.Add("@modelo", MySqlDbType.String).Value = modelo;
                Query.Parameters.Add("@hp", MySqlDbType.String).Value = hp;
                Query.Parameters.Add("@voltaje", MySqlDbType.String).Value = voltaje;
                Query.Parameters.Add("@diametro", MySqlDbType.String).Value = diametroDescarga;
                Query.Parameters.Add("@lps", MySqlDbType.String).Value = gastoLps;
                Query.Parameters.Add("@cargaDinamica", MySqlDbType.String).Value = cargaDinamica;
                Query.Parameters.Add("@rpm", MySqlDbType.String).Value = rpm;
                Query.Parameters.Add("@estatus", MySqlDbType.String).Value = estatus;
                Query.Parameters.Add("@fpm", MySqlDbType.String).Value = fpm;
                Query.Parameters.Add("@observaciones", MySqlDbType.String).Value = observaciones;
                Conn.Open();
                numRegistros = Query.ExecuteNonQuery();
                return numRegistros;//1 si se ha registrado
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

        //METODO DE VALIDACION, CUANTOS REGISTROS EXISTEN DENTRO DE UNA COLUMNA
        //public int ValidarPosicion(string idEstacion)
        //{
        //    int value = 0;
        //    try
        //    {
        //        string answer;
        //        conectarBase();
        //        Query.CommandText = "SELECT count(*) FROM bombas WHERE IdEstacion= '" + idEstacion + "'";
        //        Query.Connection = Conn;
        //        value = Convert.ToInt32(Query.ExecuteScalar());
        //        return value;

        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //    return value;
        //}

        //TOMA UN VALOR Y LO CONSULTA A LA BDD, RETORNA FALSO O VERDADERO SI EXISTE EN CADA CONSULTA
        public bool ConsultarPosicion(string idEstacion,int i)
        {
            try
            {
                conectarBase();
                Query.CommandText = "SELECT Posicion FROM bombas WHERE IdEstacion= '" + idEstacion + "'AND Posicion = '"+i+"'";
                Query.Connection = Conn;
                Consultar = Query.ExecuteReader();
                if (Consultar.HasRows)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return false;
        }
        




























        public DataTable llevarDatos(string globalReceiver)
        {
            string sql = "SELECT * FROM bombas WHERE IdPlantas = '"+globalReceiver+"'";
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
                Console.WriteLine(ex.Message);
                Conn.Close();
                Console.WriteLine(ex);
                throw;
            }
        }


    }
}
