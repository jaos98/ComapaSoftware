using ComapaSoftware.Controlador;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace ComapaSoftware.Modelo
{
    internal class ModeloBombas : Conexion
    {

        public List<string> ObtenerIdPlantas(string receiver) 
        {
        List<string> list = new List<string>();
            
            try
            {
                conectarBase();
                Query.CommandText = "SELECT IdPlantas FROM plantascomapa WHERE TipoPlantas= '" + receiver + "'";
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






        public List<string> obtenerId(string idReceipt)
        {
            List<string> result = new List<string>();
            try
            {
                conectarBase();
                Query.CommandText = "SELECT IdEstacion,Servicio FROM estaciones WHERE Servicio= '" + idReceipt + "'";
                Query.Connection = Conn;
                Consultar = Query.ExecuteReader();
                while (Consultar.Read())
                {
                    idReceipt = Consultar.GetString(0);
                    idReceipt = Consultar.GetString(1);
                    Console.WriteLine(idReceipt);
                    result.Add(idReceipt);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);

            }
            return result;
        }
        //MODIFICAR
        public List<string> obtenerIdFicha(string receiver)
        {
            List<string> helper = new List<string>();
            string values;
            try
            {
                conectarBase();
                Query.CommandText = "SELECT slug FROM estaciones WHERE Servicio= '" + receiver + "' ";
                Query.Connection = Conn;
               Consultar = Query.ExecuteReader();
                while (Consultar.Read())
                {
                    values = Consultar.GetString(0);

                    helper.Add(values);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            return helper;
        }
        public List<string> obtenerIdFicha2(string receiver)
        {

            List<string> list = new List<string>(3);

            try
            {
                conectarBase();
                Query.CommandText = "SELECT IdPlantas,slug,Servicio FROM estaciones WHERE Servicio= '" + receiver + "' ";
                Query.Connection = Conn;
                Consultar = Query.ExecuteReader();
                while (Consultar.Read())
                {
                    list.Add(Consultar.GetString(0) + ", " + Consultar.GetString(1) + ", " + Consultar.GetString(2));

                }
                return list;
            }
            catch (MySqlException ex)
            {
                return null;
                Console.WriteLine(ex);
                throw;
            }

        }
        public List<CriterioRegistroBomba> obtenerIdFicha3(string receiver)
        {
            List<CriterioRegistroBomba> list = new List<CriterioRegistroBomba>();
            try
            {
                conectarBase();
                Query.CommandText = "SELECT IdPlantas,slug,Servicio FROM estaciones WHERE Servicio= '" + receiver + "' ";
                Query.Connection = Conn;
                Consultar = Query.ExecuteReader();
                while (Consultar.Read())
                {
                    list.Add(new CriterioRegistroBomba(Consultar.GetString(0), Consultar.GetString(1)
                        ,Consultar.GetString(2)));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return list;
        }


        public int registrarInfoBomba(string idPlantas, string posicion, string marca, string tipo,
           string modelo, string hp, string voltaje, string diametroDescarga, string gastoLps,
           string cargaDinamica,string rpm, string estatus, string fpm, string observaciones)
        {

            int numRegistros = 0;
            string sqlEjecutar = "INSERT INTO `bombas`(`IdPlantas`, `Posicion`, `Marca`, `Tipo`, `Modelo`, " +
                    "`Hp`, `Voltaje`, `DiametroDescarga`, `GastoLps`, `CargaDinamica`, `Rpm`, `Estatus`, `Fpm`, `Observaciones`) " +
                    "VALUES (@idPlantas,@posicion,@marca,@tipo,@modelo,@hp,@voltaje,@diametroDescarga,@gastoLps,@cargaDinamica,@rpm,@estatus,@fpm,@observaciones);";
            try
            {
                Conn.Close();
                Query.Connection = Conn;
                Query.CommandText = sqlEjecutar;
                Query.Parameters.Add("@idPLantas", MySqlDbType.String).Value = idPlantas;
                Query.Parameters.Add("@posicion", MySqlDbType.String).Value = posicion;
                Query.Parameters.Add("@marca", MySqlDbType.String).Value = marca;
                Query.Parameters.Add("@tipo", MySqlDbType.String).Value = tipo;
                Query.Parameters.Add("@modelo", MySqlDbType.String).Value = modelo;
                Query.Parameters.Add("@hp", MySqlDbType.String).Value = hp;
                Query.Parameters.Add("@voltaje", MySqlDbType.String).Value = voltaje;
                Query.Parameters.Add("@diametroDescarga", MySqlDbType.String).Value = diametroDescarga;
                Query.Parameters.Add("@gastoLps", MySqlDbType.String).Value = gastoLps;
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
