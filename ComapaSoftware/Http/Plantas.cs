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
    internal class Plantas
    {

        //HTTP REQUEST CONSULTA DATATABLE
        public DataTable llevarDatosHttp(string tipoPlanta)
        {
            DataTable dt = new DataTable("TablaPlantas");
            dt.Columns.Add("Id Planta", typeof(string));
            dt.Columns.Add("Numero Medidor", typeof(string));
            dt.Columns.Add("Numero Servicio", typeof(string));
            dt.Columns.Add("Tipo Planta", typeof(string));
            dt.Columns.Add("Estatus", typeof(string));
            dt.Columns.Add("Desc Funciones", typeof(string));
            dt.Columns.Add("Kva", typeof(string));
            dt.Columns.Add("Colonia", typeof(string));
            dt.Columns.Add("Sector", typeof(string));
            dt.Columns.Add("Latitud", typeof(string));
            dt.Columns.Add("Longitud", typeof(string));
            dt.Columns.Add("Elevacion", typeof(string));
            dt.Columns.Add("Servicio", typeof(string));
            dt.Columns.Add("Domicilio", typeof(string));
            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri("http://localhost");
                client.DefaultRequestHeaders.Add("User-Agent", "Anything");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //?TipoPlanta=" + tipoPlanta
                var response = client.GetAsync("/api/getPlantas.php").Result;
                response.EnsureSuccessStatusCode();
                var result = response.Content.ReadAsStringAsync().Result; ;
                List<ModeloPlantas> json = JsonSerializer.Deserialize<List<ModeloPlantas>>(result);

                foreach (var items in json)
                {
                    dt.Rows.Add(items.IdPlanta, items.NumMedidor, items.NumServicio, items.TipoPlantas,
                        items.Estatus, items.DescFunciones, items.SubestacionKva, items.Colonia, items.Sector,
                        items.Latitud, items.Longitud, items.Elevacion, items.Servicio, items.Domicilio);
                }
                return dt;
            }
        }

        // TRAER INFO (SELECT) HTTP REQUEST
        public List<ModeloPlantas> getDatosHttp(string tipoPlanta)
        {
            List<ModeloPlantas> list = new List<ModeloPlantas>();
            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri("http://localhost");
                client.DefaultRequestHeaders.Add("User-Agent", "Anything");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //?TipoPlanta=" + tipoPlanta
                var response = client.GetAsync("/api/getPlantas.php?TipoPlanta=" + tipoPlanta).Result;
                response.EnsureSuccessStatusCode();
                var result = response.Content.ReadAsStringAsync().Result; ;
                List<ModeloPlantas> json = JsonSerializer.Deserialize<List<ModeloPlantas>>(result);

                return json;
            }
        }
        //HTTP REGISTRO
        public int insertarPlantaHttp(string IdPlantas, string NumMedidor, string NumServicio,
            string TipoPlanta, string Estatus, string DescFunciones, string Subestacionkva,
            string Colonia, string Sector, string Latitud, string Longitud,
            string Elevacion, string Servicio, string Domicilio)
        {
            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri("http://localhost");
                client.DefaultRequestHeaders.Add("User-Agent", "Anything");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var content = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string,string>("IdPlantas",IdPlantas),
                    new KeyValuePair<string,string>("NumMedidor",NumMedidor),
                    new KeyValuePair<string,string>("NumServicio",NumServicio),
                    new KeyValuePair<string,string>("TipoPlantas",TipoPlanta),
                    new KeyValuePair<string,string>("Estatus",Estatus),
                    new KeyValuePair<string,string>("DescFunciones",DescFunciones),
                    new KeyValuePair<string,string>("SubestacionKva",Subestacionkva),
                    new KeyValuePair<string,string>("Colonia",Colonia),
                    new KeyValuePair<string,string>("Sector",Sector),
                    new KeyValuePair<string,string>("Latitud",Latitud),
                    new KeyValuePair<string,string>("Longitud",Longitud),
                    new KeyValuePair<string,string>("Elevacion",Elevacion),
                    new KeyValuePair<string,string>("Servicio",Servicio),
                    new KeyValuePair<string,string>("Domicilio",Domicilio)

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
        //ACTUALIZAR HTTPREQUEST
        public int actualizarPlantaHttp(string IdPlantas, string NumMedidor, string NumServicio,
            string TipoPlanta, string Estatus, string DescFunciones, string Subestacionkva,
            string Colonia, string Sector, string Latitud, string Longitud,
            string Elevacion, string Servicio, string Domicilio)
        {
            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri("http://localhost");
                client.DefaultRequestHeaders.Add("User-Agent", "Anything");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var content = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string,string>("IdPlantas",IdPlantas),
                    new KeyValuePair<string,string>("NumMedidor",NumMedidor),
                    new KeyValuePair<string,string>("NumServicio",NumServicio),
                    new KeyValuePair<string,string>("TipoPlantas",TipoPlanta),
                    new KeyValuePair<string,string>("Estatus",Estatus),
                    new KeyValuePair<string,string>("DescFunciones",DescFunciones),
                    new KeyValuePair<string,string>("SubestacionKva",Subestacionkva),
                    new KeyValuePair<string,string>("Colonia",Colonia),
                    new KeyValuePair<string,string>("Sector",Sector),
                    new KeyValuePair<string,string>("Latitud",Latitud),
                    new KeyValuePair<string,string>("Longitud",Longitud),
                    new KeyValuePair<string,string>("Elevacion",Elevacion),
                    new KeyValuePair<string,string>("Servicio",Servicio),
                    new KeyValuePair<string,string>("Domicilio",Domicilio)

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
