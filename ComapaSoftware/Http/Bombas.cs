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
