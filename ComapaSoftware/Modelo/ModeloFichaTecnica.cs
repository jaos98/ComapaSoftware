using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
namespace ComapaSoftware.Modelo
{
    internal class ModeloFichaTecnica
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

        public List<string> obtenerId(string catString)
        {
            List<string> result = new List<string>();
            try
            {
                conectarBase();
                Query.CommandText = "SELECT IdPlantas FROM plantascomapa WHERE TipoPlantas= '" + catString + "'";
                Query.Connection = Conn;
                consultar = Query.ExecuteReader();
                while (consultar.Read())
                {
                    catString = consultar.GetString(0);
                    Console.WriteLine(catString);
                    result.Add(catString);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);

            }
            return result;
        }


        public int registrarInfo(string idPlantas, string capEquipos, string operacionMinima, string equiposInstalados,
            string tipo, string garantOperacion, string gastoPromedio, string gastoInstalado, string servicio, string observaciones)
        {

            int numRegistros = 0;
            string sqlEjecutar = "INSERT INTO `informaciontecnica`(`IdPlantas`, `CapacidadEquipos`, `OperacionMinima`, `EquiposInstalados`, `Tipo`, " +
                    "`GarantOperacion`, `GastoPromedio`, `GastoInstalado`, `Servicio`, `Observaciones`) " +
                    "VALUES (@idPlantas,@capacidadEquipos,@operacionMinima,@equiposInstalados,@tipo,@garantOperacion,@gastoPromedio,@gastoInstalado,@servicio,@observaciones);";
            try
            {

                Conn.Close();
                Query.Connection = Conn;
                Query.CommandText = sqlEjecutar;
                Query.Parameters.Add("@idPlantas", MySqlDbType.String).Value = idPlantas;
                Query.Parameters.Add("@capacidadEquipos", MySqlDbType.String).Value = capEquipos;
                Query.Parameters.Add("@operacionMinima", MySqlDbType.String).Value = operacionMinima;
                Query.Parameters.Add("@equiposInstalados", MySqlDbType.String).Value = equiposInstalados;
                Query.Parameters.Add("@tipo", MySqlDbType.String).Value = tipo;
                Query.Parameters.Add("@garantOperacion", MySqlDbType.String).Value = garantOperacion;
                Query.Parameters.Add("@gastoPromedio", MySqlDbType.String).Value = gastoPromedio;
                Query.Parameters.Add("@gastoInstalado", MySqlDbType.String).Value = gastoInstalado;
                Query.Parameters.Add("@servicio", MySqlDbType.String).Value = servicio;
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
            string sql = "SELECT `IdInfoTecnica`, `IdPlantas`, `slug`, `CapacidadEquipos`, `OperacionMinima`, " +
                "`EquiposInstalados`, `Tipo`, `GarantOperacion`, `GastoPromedio`, `GastoInstalado`, " +
                "`Servicio`" +
                " FROM informaciontecnica WHERE IdPlantas = '" + globalReceiver + "' ";
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
        public string traerDescripcion(string idFicha)
        {
            conectarBase();
            try
            {
                Query.CommandText = "SELECT Observaciones FROM informaciontecnica WHERE idInfoTecnica= '" + idFicha + "'";
                Query.Connection = Conn;
                consultar = Query.ExecuteReader();
                while (consultar.Read())
                {
                    idFicha = consultar.GetString(0);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Conn.Close();
                throw;
            }
            return idFicha;
        }
    }
}
