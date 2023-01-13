using ComapaSoftware.Controlador;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ComapaSoftware.Http
{
    internal class Bombas
    {
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

                    dt.Rows.Add(items.IdEstacion, items.Posicion, items.Marca, items.Modelo, items.Tipo,
                        items.Hp, items.Voltaje, items.Diametro, items.Lps, items.Carga, items.Rpm,
                        items.Estatus, items.Fpm, items.Observaciones);

                }
                return dt;
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
    }
}
