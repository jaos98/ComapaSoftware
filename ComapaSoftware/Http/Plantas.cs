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
        public ModelsPlantas mp;
        //HTTP REQUEST CONSULTA DATATABLE
        public DataTable llevarDatosHttp(string entry)
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
                client.BaseAddress = new Uri("http://comabadbb.online");
                client.DefaultRequestHeaders.Add("USER-AGENT", "Anything");
                client.DefaultRequestHeaders.Add("function", "Entry");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //?TipoPlanta=" + tipoPlanta
                var response = client.GetAsync("api/plantas.php?Entry=" + entry).Result;
                Console.WriteLine(response);
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

        // TRAER UN SOLO DATO PARA ACTUALIZAR (SELECT) HTTP REQUEST
        public bool getDatosHttp(string IdPlantas)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://comapadbb.online");
                client.DefaultRequestHeaders.Add("Function", "read");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //?TipoPlanta=" + tipoPlanta
                var response = client.GetAsync("api/plantas.php?IdPlantas=" + IdPlantas).Result;

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var result = response.Content.ReadAsStringAsync().Result;
                    mp = JsonSerializer.Deserialize<ModelsPlantas>(result);

                    return true;
                }
                return false;
            }
        }

        //OBTIENE UN VALOR SEGUN EL IDPLANTA O TIPO PLANTA
        public DataTable getDatosHttpByTipo(string TipoPlanta)
        {
            DataTable dt = new DataTable("TablaPlantas");
            dt.Columns.Add("Id Planta", typeof(string));
            dt.Columns.Add("Numero Medidor", typeof(string));
            dt.Columns.Add("Numero Servicio", typeof(string));
            dt.Columns.Add("Tipo Planta", typeof(string));
            dt.Columns.Add("Estatus", typeof(string));
            dt.Columns.Add("Desc Funciones", typeof(string));
            dt.Columns.Add("Kva", typeof(string));
            //dt.Columns.Add("Colonia", typeof(string));
            //dt.Columns.Add("Sector", typeof(string));
            //dt.Columns.Add("Latitud", typeof(string));
            //dt.Columns.Add("Longitud", typeof(string));
            //dt.Columns.Add("Elevacion", typeof(string));
            //dt.Columns.Add("Servicio", typeof(string));
            //dt.Columns.Add("Domicilio", typeof(string));
            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri("https://comapadbb.online");
                client.DefaultRequestHeaders.Add("User-Agent", "Anything");
                client.DefaultRequestHeaders.Add("function", "readall");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //?TipoPlanta=" + tipoPlanta
                var response = client.GetAsync("api/plantas.php?Entry=" + TipoPlanta).Result;
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var result = response.Content.ReadAsStringAsync().Result;
                    List<ModelsPlantas> json = JsonSerializer.Deserialize<List<ModelsPlantas>>(result);

                    foreach (var items in json)
                    {
                        dt.Rows.Add(items.IdPlantas, items.NumMedidor, items.NumServicio, items.TipoPlantas,
                            items.Estatus, items.DescFunciones, items.SubestacionKva);
                    }
                    return dt;
                }
                else
                {
                    return dt;
                }
            }
        }
        //HTTP REGISTRO
        public int insertarPlantaHttp(string IdPlantas, string NumMedidor, string NumServicio,
            string TipoPlantas, string Estatus, string DescFunciones, string SubestacionKva,
            string Colonia, string Sector, string Latitud, string Longitud,
            string Elevacion, string Servicio, string Domicilio)
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
                    new KeyValuePair<string,string>("NumMedidor",NumMedidor),
                    new KeyValuePair<string,string>("NumServicio",NumServicio),
                    new KeyValuePair<string,string>("TipoPlantas",TipoPlantas),
                    new KeyValuePair<string,string>("Estatus",Estatus),
                    new KeyValuePair<string,string>("DescFunciones",DescFunciones),
                    new KeyValuePair<string,string>("SubestacionKva",SubestacionKva),
                    new KeyValuePair<string,string>("Colonia",Colonia),
                    new KeyValuePair<string,string>("Sector",Sector),
                    new KeyValuePair<string,string>("Latitud",Latitud),
                    new KeyValuePair<string,string>("Longitud",Longitud),
                    new KeyValuePair<string,string>("Elevacion",Elevacion),
                    new KeyValuePair<string,string>("Servicio",Servicio),
                    new KeyValuePair<string,string>("Domicilio",Domicilio),

                });
                var response = client.PostAsync("api/plantas.php", content).Result;
                //Console.WriteLine(response);
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
        public bool actualizarPlantaHttp(string IdPlantas, string NumMedidor, string NumServicio,
            string TipoPlanta, string Estatus, string DescFunciones, string Subestacionkva,
            string Colonia, string Sector, string Latitud, string Longitud,
            string Elevacion, string Servicio, string Domicilio)
        {
            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri("https://comapadbb.online");
                client.DefaultRequestHeaders.Add("User-Agent", "Anything");
                client.DefaultRequestHeaders.Add("Function", "update");
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
                var response = client.PostAsync("api/plantas.php?IdPlantas="+IdPlantas, content).Result;
                Console.WriteLine(response);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
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

        //DELETE 
        public bool BorrarPlanta(string IdPlantas)
        {
            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri("https://comapadbb.online");
                client.DefaultRequestHeaders.Add("User-Agent", "Anything");
                client.DefaultRequestHeaders.Add("function", "delete");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //?TipoPlanta=" + tipoPlanta
                var response = client.GetAsync("api/plantas.php?IdPlantas=" + IdPlantas).Result;
                Console.WriteLine(response);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    
                    return true;

                }
                return false;
            }
        }

        //EXISTE
        public bool DoesNotExists(string IdPlantas)
        {
            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri("https://comapadbb.online");
                client.DefaultRequestHeaders.Add("User-Agent", "Anything");
                client.DefaultRequestHeaders.Add("function", "validate");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //?TipoPlanta=" + tipoPlanta
                var response = client.GetAsync("api/plantas.php?IdPlantas=" +IdPlantas).Result;
                Console.WriteLine(response);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {

                    return false;

                }
                return true;
            }
        }
    }
}
