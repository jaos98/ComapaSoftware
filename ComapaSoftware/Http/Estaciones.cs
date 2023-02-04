using System;
using System.Collections.Generic;
using System.Data;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;

namespace ComapaSoftware.Http
{
    internal class Estaciones
    {
        public ModelsEstaciones me;
        List<ModelsPlantas> estaciones = new List<ModelsPlantas>();
        //HTTP REQUEST METHODS

        //HTTP REGISTRO
        public bool insertarInfoHttp(string IdPlantas, string IdEstacion, string Nombre,
            string CapacidadEquipos, string OperacionMinima, string EquiposInstalados, string Tipo,
            string GarantOperacion, string GastoPromedio, string GastoInstalado, string Servicio,
            string Observaciones)
        {
            Console.WriteLine(IdPlantas);
            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri("https://comapadbb.online");
                client.DefaultRequestHeaders.Add("Function", "create");
                client.DefaultRequestHeaders.Add("User-Agent", "Anything");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var content = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string,string>("IdPlantas",IdPlantas),
                    new KeyValuePair<string,string>("IdEstacion",IdEstacion),
                    new KeyValuePair<string,string>("Nombre",Nombre),
                    new KeyValuePair<string,string>("CapacidadEquipos",CapacidadEquipos),
                    new KeyValuePair<string,string>("OperacionMinima",OperacionMinima),
                    new KeyValuePair<string,string>("EquiposInstalados",EquiposInstalados),
                    new KeyValuePair<string,string>("Tipo",Tipo),
                    new KeyValuePair<string,string>("GarantOperacion",GarantOperacion),
                    new KeyValuePair<string,string>("GastoPromedio",GastoPromedio),
                    new KeyValuePair<string,string>("GastoInstalado",GastoInstalado),
                    new KeyValuePair<string,string>("Servicio",Servicio),
                    new KeyValuePair<string,string>("Observaciones",Observaciones),
                });
                var response = client.PostAsync("api/estaciones.php", content).Result;
                //Console.WriteLine(response);
                if (response.StatusCode == System.Net.HttpStatusCode.Created)
                {
                    Console.WriteLine(response.Content.ReadAsStringAsync().Result);
                    return true;
                }
                else
                {
                    Console.WriteLine(response.Content.ReadAsStringAsync().Result);
                    return false;
                }

            }
        }
        //CONSULTAR INF0RMACION
        public DataTable llevarDatosHttp(string IdPlantas)
        {
            DataTable dt = new DataTable("Tabla Estaciones");
            dt.Columns.Add("Id Planta", typeof(string));
            dt.Columns.Add("Id Estacion", typeof(string));
            dt.Columns.Add("Nombre", typeof(string));
            dt.Columns.Add("Capacidad de equipos", typeof(string));
            dt.Columns.Add("Operacion Minima", typeof(string));
            dt.Columns.Add("Equipos Instalados", typeof(string));
            dt.Columns.Add("Tipo", typeof(string));
            dt.Columns.Add("Garantizar Operacion", typeof(string));
            dt.Columns.Add("Gasto Promedio", typeof(string));
            dt.Columns.Add("Gasto Instalado", typeof(string));
            dt.Columns.Add("Servicio", typeof(string));
            dt.Columns.Add("Observaciones", typeof(string));
            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri("https://comapadbb.online");
                client.DefaultRequestHeaders.Add("USER-AGENT", "Anything");
                client.DefaultRequestHeaders.Add("function", "IdPlantas");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //?TipoPlanta=" + tipoPlanta
                var response = client.GetAsync("api/estaciones.php?IdPlantas=" + IdPlantas).Result;
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    Console.WriteLine(response);
                    var result = response.Content.ReadAsStringAsync().Result; ;
                    List<ModelsEstaciones> json = JsonSerializer.Deserialize<List<ModelsEstaciones>>(result);

                    foreach (var items in json)
                    {
                        dt.Rows.Add(items.IdPlantas, items.IdEstacion, items.Nombre, items.CapacidadEquipos, items.OperacionMinima,
                            items.EquiposInstalados, items.Tipo, items.GarantOperacion, items.GastoPromedio, items.GastoInstalado,
                            items.Servicio, items.Observaciones);
                    }
                    return dt;
                }
                return dt;
            }
        }
        // TRAER UN SOLO DATO PARA ACTUALIZAR (SELECT) HTTP REQUEST
        public bool getDatosHttp(string IdEstacion)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://comapadbb.online");
                client.DefaultRequestHeaders.Add("Function", "read");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //?TipoPlanta=" + tipoPlanta
                var response = client.GetAsync("api/estaciones.php?IdEstacion=" + IdEstacion).Result;
                Console.WriteLine(response);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var result = response.Content.ReadAsStringAsync().Result;
                    me = JsonSerializer.Deserialize<ModelsEstaciones>(result);

                    return true;
                }
                return false;
            }
        }
        //



        // TRAE EL ID DE LAS PLANTAS PARA REGISTRO
        public List<ModelsPlantas> getDatosHttpByTipo(string TipoPlantas)
        {

            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri("https://comapadbb.online");
                client.DefaultRequestHeaders.Add("User-Agent", "Anything");
                client.DefaultRequestHeaders.Add("function", "getidp");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //?TipoPlanta=" + tipoPlanta
                var response = client.GetAsync("api/estaciones.php?TipoPlantas=" + TipoPlantas).Result;
                Console.WriteLine(response);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var result = response.Content.ReadAsStringAsync().Result;
                    estaciones = JsonSerializer.Deserialize<List<ModelsPlantas>>(result);
                    return estaciones;

                }
                else
                {
                    return estaciones;
                }
            }
        }

        //ELIMINAR ESTACION
        public bool Borrar(string IdEstacion)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri("https://comapadbb.online");
                httpClient.DefaultRequestHeaders.Add("User-Agent", "Anything");
                httpClient.DefaultRequestHeaders.Add("Function", "delete");
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage respuesta = httpClient.GetAsync("api/estaciones.php?IdEstacion=" + IdEstacion).Result;

                Console.WriteLine(respuesta.StatusCode.ToString());
                if (respuesta.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return true;
                }
                return false;
            }
        }


        //ACTUALIZAR ESTACION HTTP
        public bool Actualizar(string idEstacion, string nombre, string capacidadEquipos, string operacionMinima, string equiposInstalados, string tipo, string garantOperacion, string gastoPromedio, string gastoInstalado, string servicio, string observaciones)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri("https://comapadbb.online");
                httpClient.DefaultRequestHeaders.Add("User-Agent", "Anything");
                httpClient.DefaultRequestHeaders.Add("Function", "update");
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                FormUrlEncodedContent contenido = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("IdEstacion", idEstacion),
                    new KeyValuePair<string, string>("Nombre", nombre),
                    new KeyValuePair<string, string>("CapacidadEquipos", capacidadEquipos),
                    new KeyValuePair<string, string>("OperacionMinima", operacionMinima),
                    new KeyValuePair<string, string>("EquiposInstalados", equiposInstalados),
                    new KeyValuePair<string, string>("Tipo", tipo),
                    new KeyValuePair<string, string>("GarantOperacion", garantOperacion),
                    new KeyValuePair<string, string>("GastoPromedio", gastoPromedio),
                    new KeyValuePair<string, string>("GastoInstalado", gastoInstalado),
                    new KeyValuePair<string, string>("Servicio", servicio),
                    new KeyValuePair<string, string>("Observaciones", observaciones)
                });

                HttpResponseMessage respuesta = httpClient.PostAsync("api/estaciones.php?", contenido).Result;

                Console.WriteLine(respuesta.StatusCode.ToString());
                if (respuesta.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return true;
                }
                return false;
            }
        }

        public string ObtenerObservaciones(string IdEstacion)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri("https://comapadbb.online");
                httpClient.DefaultRequestHeaders.Add("User-Agent", "Anything");
                httpClient.DefaultRequestHeaders.Add("Function", "getdesc");
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage respuesta = httpClient.GetAsync("api/estaciones.php?IdEstacion=" + IdEstacion).Result;

                Console.WriteLine(respuesta.StatusCode.ToString());
                if (respuesta.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var stringRespuesta = respuesta.Content.ReadAsStringAsync().Result;
                    ModelsEstaciones estaciones = JsonSerializer.Deserialize<ModelsEstaciones>(stringRespuesta);
                    return estaciones.Observaciones;
                }
                else
                {
                    throw new Exception();
                }
            }
        }

    }
}
