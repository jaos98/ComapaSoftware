using System;
using System.Collections.Generic;
using System.Data;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;

namespace ComapaSoftware.Http
{
    internal class Sector
    {
        public ModelsSector sector;
        public List<ModelsSector> list = new List<ModelsSector>();
        //OBTIENE TODA LA INFORMACION DE SECTOR
        public List<ModelsSector> getDatosHttpByTipo()
        {

            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri("https://comapadbb.online");
                client.DefaultRequestHeaders.Add("User-Agent", "Anything");
                client.DefaultRequestHeaders.Add("function", "");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //?TipoPlanta=" + tipoPlanta
                var response = client.GetAsync("api/sectores.php?").Result;
                Console.WriteLine(response);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var result = response.Content.ReadAsStringAsync().Result;
                    list = JsonSerializer.Deserialize<List<ModelsSector>>(result);
                    return list;

                }
                else
                {
                    return list;
                }
            }
        }

        //LLENA EL DATAGRIDVIEW DE LA VISTA REG SECTOR
        public DataTable LeerTodo()
        {
            using (var client = new HttpClient())
            {
                DataTable dt = new DataTable("TablaPlantas");
                dt.Columns.Add("Id Sector", typeof(string));
                dt.Columns.Add("Nombre", typeof(string));

                client.BaseAddress = new Uri("https://comapadbb.online");
                client.DefaultRequestHeaders.Add("User-Agent", "Anything");
                client.DefaultRequestHeaders.Add("function", "");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //?TipoPlanta=" + tipoPlanta
                var response = client.GetAsync("api/sectores.php?").Result;
                Console.WriteLine(response);
                var result = response.Content.ReadAsStringAsync().Result; ;
                List<ModelsSector> json = JsonSerializer.Deserialize<List<ModelsSector>>(result);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    foreach (var items in json)
                    {
                        dt.Rows.Add(items.IdSector, items.NombreSector);
                    }
                    return dt;

                }
                else
                {
                    return dt;
                }
            }
        }


        //INSERTAR SECTOR
        public bool Registrar(string IdEstacion, string NombreSector)
        {
            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri("https://comapadbb.online");
                client.DefaultRequestHeaders.Add("Function", "create");
                client.DefaultRequestHeaders.Add("User-Agent", "Anything");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var content = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string,string>("IdSector",IdEstacion),
                    new KeyValuePair<string,string>("NombreSector",NombreSector),

                });
                var response = client.PostAsync("api/sectores.php", content).Result;
                Console.WriteLine(response);
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
        //UPDATE SECTOR
        public bool Actualizar(string IdSector, string NombreSector)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri("https://comapadbb.online");
                httpClient.DefaultRequestHeaders.Add("User-Agent", "Anything");
                httpClient.DefaultRequestHeaders.Add("Function", "update");
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                FormUrlEncodedContent contenido = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("IdSector", IdSector),
                    new KeyValuePair<string, string>("NombreSector", NombreSector),
                });

                HttpResponseMessage respuesta = httpClient.PostAsync("api/sectores.php", contenido).Result;

                Console.WriteLine(respuesta.StatusCode.ToString());
                if (respuesta.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return true;
                }
                return false;
            }
        }
        //ELIMINAR DATOS SEGUN EL ID
        public bool Borrar(string IdSector)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri("https://comapadbb.online");
                httpClient.DefaultRequestHeaders.Add("User-Agent", "Anything");
                httpClient.DefaultRequestHeaders.Add("Function", "delete");
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage respuesta = httpClient.GetAsync("api/sectores.php?IdSector=" + IdSector).Result;
                if (respuesta.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return true;
                }
                return false;
            }
        }

    }
}

