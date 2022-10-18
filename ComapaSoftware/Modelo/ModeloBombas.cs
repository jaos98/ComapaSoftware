using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace ComapaSoftware.Modelo
{
    internal class ModeloBombas
    {
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

        public List<string> obtenerId(string idReceipt)
        {
            List<string> result = new List<string>();
            try
            {
                conectarBase();
                Query.CommandText = "SELECT IdPlantas,Servicio FROM informaciontecnica WHERE Servicio= '" + idReceipt + "'";
                Query.Connection = Conn;
                consultar = Query.ExecuteReader();
                while (consultar.Read())
                {

                    idReceipt = consultar.GetString(0);
                    idReceipt = consultar.GetString(1);
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
                Query.CommandText = "SELECT slug FROM informaciontecnica WHERE Servicio= '"+receiver+"' ";
                Query.Connection = Conn;
                consultar = Query.ExecuteReader();
                while (consultar.Read())
                {
                    values = consultar.GetString(0);
                    
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
        //public string[] obtenerIdFicha2()
        //{
        //    string[] values = new string[2] ;
        //    try
        //    {
        //        conectarBase();
        //        Query.CommandText = "SELECT IdPlantas,Servicio FROM informaciontecnica ";
        //        Query.Connection = Conn;
        //        consultar = Query.ExecuteReader();
        //        while (consultar.Read())
        //        {
        //            values[0] = consultar.GetString(0);
        //            values[1] = consultar.GetString(1);
        //           // Console.WriteLine(values[0]+", "+values[1]);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex);
        //    }
        //    return values;
        //}
    }
}
