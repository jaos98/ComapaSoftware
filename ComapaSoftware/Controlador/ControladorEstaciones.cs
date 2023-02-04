using ComapaSoftware.Controlador;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace ComapaSoftware.Modelo
{
    internal class ControladorFicha : Conexion
    {
        public List<string> obtenerId(string catString)
        {
            List<string> result = new List<string>();
            try
            {
                conectarBase();
                Query.CommandText = "SELECT IdPlantas FROM plantascomapa WHERE TipoPlantas= '" + catString + "' ORDER BY IdPlantas ASC";
                Query.Connection = Conn;
                Consultar = Query.ExecuteReader();
                while (Consultar.Read())
                {
                    catString = Consultar.GetString(0);
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


        public int registrarInfo(string idPlantas, string idEstacion, string nombre, string capEquipos, string operacionMinima, string equiposInstalados,
            string tipo, string garantOperacion, string gastoPromedio, string gastoInstalado, string servicio, string observaciones)
        {

            int numRegistros = 0;
            string sqlEjecutar = "INSERT INTO `estaciones`(`IdPlantas`,`IdEstacion`,`Nombre`, `CapacidadEquipos`, `OperacionMinima`, `EquiposInstalados`, `Tipo`, " +
                    "`GarantOperacion`, `GastoPromedio`, `GastoInstalado`, `Servicio`, `Observaciones`) " +
                    "VALUES (@idPlantas,@idEstacion,@nombre,@capacidadEquipos,@operacionMinima,@equiposInstalados,@tipo,@garantOperacion,@gastoPromedio,@gastoInstalado,@servicio,@observaciones);";
            try
            {
                Conn.Close();
                Query.Connection = Conn;
                Query.CommandText = sqlEjecutar;
                Query.Parameters.Add("@idPlantas", MySqlDbType.String).Value = idPlantas;
                Query.Parameters.Add("@idEstacion", MySqlDbType.String).Value = idEstacion;
                Query.Parameters.Add("@nombre", MySqlDbType.String).Value = nombre;
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

            }
        }
        public DataTable llevarDatos(string globalReceiver)
        {
            string sql = "SELECT `IdPlantas`, `IdEstacion`, `Nombre`, `CapacidadEquipos`," +
                " `OperacionMinima`, `EquiposInstalados`, `Tipo`, `GarantOperacion`, `GastoPromedio`," +
                " `GastoInstalado`, `Servicio`, `Observaciones` FROM `estaciones` WHERE IdPlantas='" + globalReceiver + "'";
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
        //AQUI ME QUEDE 01/12/2022 
        public string traerDescripcion(string idFicha)
        {
            conectarBase();
            try
            {
                Query.CommandText = "SELECT Observaciones FROM estaciones WHERE IdEstacion= '" + idFicha + "'";
                Query.Connection = Conn;
                Consultar = Query.ExecuteReader();

                while (Consultar.Read())
                {
                    idFicha = Consultar.GetString(0);
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
        //ACTUALIZAR INFORMACION (UPDATE)
        public List<ModeloInfo> GetUpdateInfo(string receiver)
        {
            List<ModeloInfo> list = new List<ModeloInfo>();
            try
            {
                conectarBase();
                Query.CommandText = "SELECT * FROM estaciones WHERE IdEstacion= '" + receiver + "' ";
                Query.Connection = Conn;
                Consultar = Query.ExecuteReader();
                while (Consultar.Read())
                {
                    list.Add(new ModeloInfo(Consultar.GetString(0), Consultar.GetString(1)
                        , Consultar.GetString(2), Consultar.GetString(3), Consultar.GetString(4)
                        , Consultar.GetString(5), Consultar.GetString(6), Consultar.GetString(7)
                        , Consultar.GetString(8), Consultar.GetString(9), Consultar.GetString(10)
                        , Consultar.GetString(11)));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return list;
        }
        //UPDATE
        public int UpdateInfo(string idEstacion, string nombre,
           string capEquipos, string opMinima, string eqInstalados, string tipo,
           string garantOp, string gastoProm, string gastoInst, string servicio,
           string observaciones)
        {
            int numRegistros = 0;
            string sqlEjecutar = "UPDATE `estaciones` SET `Nombre`=@nombre," +
                   "`CapacidadEquipos`=@capEquipos,`OperacionMinima`=@opMinima,`EquiposInstalados`=@eqInstalados," +
                   "`Tipo`=@tipo,`GarantOperacion`=@garantOp,`GastoPromedio`=@gastoProm," +
                   "`GastoInstalado`=@gastoInst,`Servicio`=@servicio,`Observaciones`=@observaciones " +
                   "WHERE IdEstacion = '" + idEstacion + "'";

            try
            {
                Conn.Close();
                Query.Connection = Conn;
                Query.CommandText = sqlEjecutar;
                Query.Parameters.Add("@nombre", MySqlDbType.String).Value = nombre;
                Query.Parameters.Add("@capEquipos", MySqlDbType.String).Value = capEquipos;
                Query.Parameters.Add("@opMinima", MySqlDbType.String).Value = opMinima;
                Query.Parameters.Add("@eqInstalados", MySqlDbType.String).Value = eqInstalados;
                Query.Parameters.Add("@tipo", MySqlDbType.String).Value = tipo;
                Query.Parameters.Add("@garantOp", MySqlDbType.String).Value = garantOp;
                Query.Parameters.Add("@gastoProm", MySqlDbType.String).Value = gastoProm;
                Query.Parameters.Add("@gastoInst", MySqlDbType.String).Value = gastoInst;
                Query.Parameters.Add("@servicio", MySqlDbType.String).Value = servicio;
                Query.Parameters.Add("@observaciones", MySqlDbType.String).Value = observaciones;
                Conn.Open();
                numRegistros = Query.ExecuteNonQuery();
                return numRegistros;//1 si se ha registrado
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex);
                return numRegistros;
                throw;
            }
            finally
            {
                Conn.Close();
            }
        }
        //ELIMINAR INFORMACION
        public bool Delete(string receiver)
        {
            conectarBase();
            try
            {
                Query.CommandText = "DELETE FROM `estaciones` WHERE IdEstacion = '" + receiver + "' ";
                Query.Connection = Conn;
                if (Query.ExecuteNonQuery() > 0)
                {
                    return true;
                }

            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            return false;
        }
    }
}
