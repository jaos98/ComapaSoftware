using System;
using System.Collections.Generic;
using System.Data;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;

namespace ComapaSoftware.Http
{
    internal class Bombas
    {
        List<ModelsPlantas> plantas = new List<ModelsPlantas>();
        List<ModelsEstaciones> estaciones = new List<ModelsEstaciones>();
        List<PosBombas> posbombas = new List<PosBombas>();

        //HTTPREQUEST

        //CONSULTA DE DATOS
        public DataTable getDatosBomba(string IdEstacion)
        {
            DataTable dt = new DataTable("Tabla Estaciones");
            dt.Columns.Add("Id Bombas", typeof(string));
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
                client.BaseAddress = new Uri("https://comapadbb.online");
                client.DefaultRequestHeaders.Add("Function", "readall");
                client.DefaultRequestHeaders.Add("User-Agent", "Anything");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //?TipoPlanta=" + tipoPlanta
                var response = client.GetAsync("api/bombas.php?IdEstacion=" + IdEstacion).Result;
                var result = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine(result + "es este el result");
                List<ModelsBombas> json = JsonSerializer.Deserialize<List<ModelsBombas>>(result);
                Console.WriteLine(json);
                foreach (var items in json)
                {
                    dt.Rows.Add(items.IdBombas.ToString(), items.IdEstacion, items.Posicion.ToString(), items.Marca, items.Modelo, items.Tipo,
                        items.Hp, items.Voltaje, items.Diametro, items.Lps, items.Carga, items.Rpm, items.Estatus,
                        items.Fpm, items.Observaciones);
                }
                return dt;
            }
        }
        //CONSULTA UN SOLO REGISTRO PARA ACTUALIZAR O MOSTRAR
        public ModelsBombas Leer(string IdBombas)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri("https://comapadbb.online");
                httpClient.DefaultRequestHeaders.Add("Function", "read");
                httpClient.DefaultRequestHeaders.Add("User-Agent", "Anything");
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage respuesta = httpClient.GetAsync("api/bombas.php?IdBombas=" + IdBombas).Result;

                Console.WriteLine(respuesta.StatusCode.ToString());
                if (respuesta.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var stringRespuesta = respuesta.Content.ReadAsStringAsync().Result;
                    return JsonSerializer.Deserialize<ModelsBombas>(stringRespuesta);
                }
                else
                {
                    throw new Exception();
                }
            }
        }


        //REGISTRO HTTPREQUEST FUNCIONA!
        public int insertarBombaHttp(string IdEstacion, int Posicion, string Marca, string Tipo,
          string Modelo, string HP, string Voltaje, string DiametroDescarga, string GastoLPS,
          string CargaDinamica, string RPM, string Estatus, string FPM, string Observaciones)
        {
            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri("https://comapadbb.online");
                client.DefaultRequestHeaders.Add("Function", "create");
                client.DefaultRequestHeaders.Add("User-Agent", "Anything");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var content = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string,string>("IdEstacion",IdEstacion),
                    new KeyValuePair<string,string>("Posicion",Posicion.ToString()),
                    new KeyValuePair<string,string>("Marca",Marca),
                    new KeyValuePair<string,string>("Tipo",Tipo),
                    new KeyValuePair<string,string>("Modelo",Modelo),
                    new KeyValuePair<string,string>("HP",HP),
                    new KeyValuePair<string,string>("Voltaje",Voltaje),
                    new KeyValuePair<string,string>("DiametroDescarga",DiametroDescarga),
                    new KeyValuePair<string,string>("GastoLPS",GastoLPS),
                    new KeyValuePair<string,string>("CargaDinamica",CargaDinamica),
                    new KeyValuePair<string,string>("RPM",RPM),
                    new KeyValuePair<string,string>("Estatus",Estatus),
                    new KeyValuePair<string,string>("FPM",FPM),
                    new KeyValuePair<string,string>("Observaciones",Observaciones)

                });
                var response = client.PostAsync("api/bombas.php", content).Result;
                Console.WriteLine(response);
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
                    plantas = JsonSerializer.Deserialize<List<ModelsPlantas>>(result);
                    return plantas;

                }
                else
                {
                    return plantas;
                }
            }
        }

        // OBTIENE LA ESTACION PARA REGISTRO
        public List<ModelsEstaciones> getDatosHttpById(string IdPlantas)
        {

            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri("https://comapadbb.online");
                client.DefaultRequestHeaders.Add("User-Agent", "Anything");
                client.DefaultRequestHeaders.Add("function", "getest");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //?TipoPlanta=" + tipoPlanta
                var response = client.GetAsync("api/estaciones.php?IdPlantas=" + IdPlantas).Result;
                Console.WriteLine(response);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var result = response.Content.ReadAsStringAsync().Result;
                    estaciones = JsonSerializer.Deserialize<List<ModelsEstaciones>>(result);

                    return estaciones;

                }
                else
                {
                    return estaciones;
                }
            }
        }




        //VERIFICA LAS POSICIONES DE BOMBAS DISPONIBLES
        public bool VerificarPosicion(string IdEstacion, int Posicion)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri("https://comapadbb.online");
                httpClient.DefaultRequestHeaders.Add("User-Agent", "Anything");
                httpClient.DefaultRequestHeaders.Add("Function", "getpos");
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage respuesta = httpClient.GetAsync("api/bombas.php?IdEstacion=" + IdEstacion + "&Posicion=" + Posicion).Result;

                Console.WriteLine(respuesta.StatusCode.ToString());
                Console.WriteLine(respuesta.Content.ReadAsStringAsync().Result);
                if (respuesta.StatusCode == System.Net.HttpStatusCode.Accepted)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
        }
        //ACTUALIZAR INFORMACION DE BOMBAS
        public bool Actualizar(int idBombas, int posicion, string marca, string tipo, string modelo, string hp, string voltaje, string diametro, string lps, string carga, string rpm, string estatus, string fpm, string observaciones)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri("https://comapadbb.online");
                httpClient.DefaultRequestHeaders.Add("User-Agent", "Anything");
                httpClient.DefaultRequestHeaders.Add("Function", "update");
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                FormUrlEncodedContent contenido = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("IdBombas", idBombas.ToString()),
                    new KeyValuePair<string, string>("Posicion", posicion.ToString()),
                    new KeyValuePair<string, string>("Marca", marca),
                    new KeyValuePair<string, string>("Tipo", tipo),
                    new KeyValuePair<string, string>("Modelo", modelo),
                    new KeyValuePair<string, string>("Hp", hp),
                    new KeyValuePair<string, string>("Voltaje", voltaje),
                    new KeyValuePair<string, string>("Diametro", diametro),
                    new KeyValuePair<string, string>("Lps", lps),
                    new KeyValuePair<string, string>("Carga", carga),
                    new KeyValuePair<string, string>("Rpm", rpm),
                    new KeyValuePair<string, string>("Estatus", estatus),
                    new KeyValuePair<string, string>("FPM", fpm),
                    new KeyValuePair<string, string>("Observaciones", observaciones)
                });

                HttpResponseMessage respuesta = httpClient.PostAsync("api/bombas.php", contenido).Result;

                Console.WriteLine(respuesta.StatusCode.ToString());
                if (respuesta.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return true;
                }
                return false;
            }
        }

        //ELIMINAR BOMBA
        public bool Borrar(string IdBombas)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri("https://comapadbb.online");
                httpClient.DefaultRequestHeaders.Add("User-Agent", "Anything");
                httpClient.DefaultRequestHeaders.Add("Function", "delete");
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage respuesta = httpClient.GetAsync("api/bombas.php?IdBombas=" + IdBombas).Result;

                Console.WriteLine(respuesta.StatusCode.ToString());
                if (respuesta.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return true;
                }
                return false;
            }
        }
    }
}
