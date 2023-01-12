using ComapaSoftware.Controlador;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;

namespace ComapaSoftware.Modelo
{
    internal class ControladorBombas : Conexion
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
        public int registrarInfoBomba2(string idEstacion, int posicion, string marca, string tipo,
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
        public List<ModeloBombas> GetUpdateInfo(string pos,string estacion)
        {
            List<ModeloBombas> list = new List<ModeloBombas>();
            try
            {
                conectarBase();
                Query.CommandText = "SELECT `IdBombas`,`IdEstacion`,`Posicion`, `Marca`, " +
                    "`Modelo`, `Tipo`, `Hp`, `Voltaje`, `Diametro`, " +
                    "`Lps`, `Carga`, `Rpm`, `Estatus`, `Fpm`, " +
                    "`Observaciones` FROM bombas WHERE Posicion= '" + pos + "'AND IdEstacion = '"+estacion+"'";
                Query.Connection = Conn;
                Consultar = Query.ExecuteReader();

                while (Consultar.Read())
                {
                    list.Add(new ModeloBombas(Consultar.GetString(0), Consultar.GetString(1)
                        , Consultar.GetInt32(2), Consultar.GetString(3), Consultar.GetString(4)
                        , Consultar.GetString(5), Consultar.GetString(6), Consultar.GetString(7)
                        , Consultar.GetString(8), Consultar.GetString(9), Consultar.GetString(10)
                        , Consultar.GetString(11), Consultar.GetString(12), Consultar.GetString(13)
                        , Consultar.GetString(14)));
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex);
            }
            return list;
        }
        //ACTUALIZAR INFORMACION UPDATE
        public int UpdateInfo(string idEstacion,int posicion, string marca,
           string modelo, string tipo, string hp, string voltaje,
           string diametro, string lps, string carga, string rpm,
           string estatus,string fpm,string observaciones)
        {
            int numRegistros = 0;
            string sqlEjecutar = "UPDATE `bombas` SET `Posicion`=@posicion,`Marca`=@marca," +
                "`Modelo`=@modelo," +
                "`Tipo`=@tipo,`Hp`=@hp,`Voltaje`=@voltaje," +
                "`Diametro`=@diametro,`Lps`=@lps,`Carga`=@carga," +
                "`Rpm`=@rpm,`Estatus`=@estatus,`Fpm`=@fpm," +
                "`Observaciones`=@observaciones WHERE Posicion ='"+posicion+"'AND IdEstacion = '"+idEstacion+"'";

            try
            {
                Console.WriteLine("Entro al metodo: "+posicion+idEstacion);
                Conn.Close();
                Query.Connection = Conn;
                Query.CommandText = sqlEjecutar;
                Query.Parameters.Add("@posicion", MySqlDbType.String).Value = posicion;
                Query.Parameters.Add("@marca", MySqlDbType.String).Value = marca;
                Query.Parameters.Add("@modelo", MySqlDbType.String).Value = modelo;
                Query.Parameters.Add("@tipo", MySqlDbType.String).Value = tipo;
                Query.Parameters.Add("@hp", MySqlDbType.String).Value = hp;
                Query.Parameters.Add("@voltaje", MySqlDbType.String).Value = voltaje;
                Query.Parameters.Add("@diametro", MySqlDbType.String).Value = diametro;
                Query.Parameters.Add("@lps", MySqlDbType.String).Value = lps;
                Query.Parameters.Add("@carga", MySqlDbType.String).Value = carga;
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
                Console.WriteLine(ex);
                return numRegistros;
                throw;
            }
            finally
            {
                Conn.Close();
            }
        }
        //ELIMINAR REGISTROS
        public bool Delete(string estacion, string posicion)
        {
            conectarBase();
            try
            {
                Query.CommandText = "DELETE FROM `bombas` WHERE IdEstacion = '" + estacion + "' AND Posicion= '" + posicion + "' ";
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


        //HTTPREQUEST

        //CONSULTA DE DATOS
        public DataTable llevarDatosHttp(string idPlantas)
        {
            DataTable dt = new DataTable("Tabla Estaciones");
            dt.Columns.Add("Id Estacion", typeof(string));
            dt.Columns.Add("Posicion", typeof(string));
            dt.Columns.Add("Marca", typeof(string));
            dt.Columns.Add("Modelo", typeof(string));
            dt.Columns.Add("Tipo", typeof(string));
            dt.Columns.Add("Hp", typeof(string));
            dt.Columns.Add("Voltaje", typeof(string));
            dt.Columns.Add("Diametro", typeof(string));
            dt.Columns.Add("Lps", typeof(string));
            dt.Columns.Add("Carga", typeof(string));
            dt.Columns.Add("Rpm", typeof(string));
            dt.Columns.Add("Estatus", typeof(string));
            dt.Columns.Add("Fpm", typeof(string));
            dt.Columns.Add("Observaciones", typeof(string));
            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri("http://localhost");
                client.DefaultRequestHeaders.Add("User-Agent", "Anything");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //?TipoPlanta=" + tipoPlanta
                var response = client.GetAsync("/api/getPlantas.php").Result;
                response.EnsureSuccessStatusCode();
                var result = response.Content.ReadAsStringAsync().Result; ;
                List<ModeloBombas> json = JsonSerializer.Deserialize<List<ModeloBombas>>(result);

                foreach (var items in json)
                {

                    dt.Rows.Add(items.IdEstacion,items.Posicion,items.Marca,items.Modelo,items.Tipo,
                        items.Hp,items.Voltaje,items.Diametro,items.Lps,items.Carga,items.Rpm,
                        items.Estatus,items.Fpm,items.Observaciones);

                }
                return dt;
            }
        }

        //REGISTRO HTTPREQUEST
        public int insertarPlantaHttp(string IdEstacion, int Posicion, string Marca, string Tipo,
          string Modelo, string Hp, string Voltaje, string DiametroDescarga, string GastoLps,
          string CargaDinamica, string Rpm, string Estatus, string Fpm, string Observaciones)
        {
            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri("http://localhost");
                client.DefaultRequestHeaders.Add("User-Agent", "Anything");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var content = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string,string>("IdPlantas",IdEstacion),
                    new KeyValuePair<string,string>("NumMedidor",Posicion.ToString()),
                    new KeyValuePair<string,string>("NumServicio",Marca),
                    new KeyValuePair<string,string>("TipoPlantas",Tipo),
                    new KeyValuePair<string,string>("Estatus",Modelo),
                    new KeyValuePair<string,string>("DescFunciones",Hp),
                    new KeyValuePair<string,string>("SubestacionKva",Voltaje),
                    new KeyValuePair<string,string>("Colonia",DiametroDescarga),
                    new KeyValuePair<string,string>("Sector",GastoLps),
                    new KeyValuePair<string,string>("Latitud",CargaDinamica),
                    new KeyValuePair<string,string>("Longitud",Rpm),
                    new KeyValuePair<string,string>("Elevacion",Estatus),
                    new KeyValuePair<string,string>("Servicio",Fpm),
                    new KeyValuePair<string,string>("Domicilio",Observaciones)

                });
                var response = client.PostAsync("/api/getPlantas.php", content).Result;
                if (response.StatusCode == System.Net.HttpStatusCode.Created)
                {
                    Console.WriteLine(response.Content.ReadAsStringAsync().Result);
                    return 1;
                }
                else
                {
                    Console.WriteLine(response.Content.ReadAsStringAsync().Result);
                    return 0;
                }

            }
        }
    }
}
