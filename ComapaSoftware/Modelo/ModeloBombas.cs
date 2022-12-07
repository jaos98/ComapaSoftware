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
        public bool ConsultarPosicion(string idEstacion, int i)
        {
            try
            {
                conectarBase();
                Query.CommandText = "SELECT Posicion FROM bombas WHERE IdEstacion= '" + idEstacion + "'AND Posicion = '" + i + "'";
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
            string sql = "SELECT `Posicion`, `Marca`, `Modelo`, " +
                "`Tipo`, `Hp`, `Voltaje`, `Diametro`, `Lps`, `Carga`, `Rpm`, `Estatus`, " +
                "`Fpm`, `Observaciones` FROM bombas WHERE IdEstacion = '" + globalReceiver + "' ORDER BY Posicion";
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
        //ACTUALIZAR INFORMACION BOMBAS (UPDATE)
        public List<ControladorBombas> GetUpdateInfo(string receiver, string receiver2)
        {
            List<ControladorBombas> list = new List<ControladorBombas>();
            try
            {
                conectarBase();
                Query.CommandText = "SELECT `IdEstacion`,`Posicion`, `Marca`, " +
                    "`Modelo`, `Tipo`, `Hp`, `Voltaje`, `Diametro`, " +
                    "`Lps`, `Carga`, `Rpm`, `Estatus`, `Fpm`, " +
                    "`Observaciones` FROM bombas WHERE Posicion= '" + receiver + "'AND IdEstacion='" + receiver2 + "' ";
                Query.Connection = Conn;
                Consultar = Query.ExecuteReader();

                while (Consultar.Read())
                {
                    list.Add(new ControladorBombas(Consultar.GetString(0), Consultar.GetInt32(1)
                        , Consultar.GetString(2), Consultar.GetString(3), Consultar.GetString(4)
                        , Consultar.GetString(5), Consultar.GetString(6), Consultar.GetString(7)
                        , Consultar.GetString(8), Consultar.GetString(9), Consultar.GetString(10)
                        , Consultar.GetString(11), Consultar.GetString(12), Consultar.GetString(13)));
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex);
            }
            return list;
        }
        //Aqui me quede UPDATE
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


    }
}
