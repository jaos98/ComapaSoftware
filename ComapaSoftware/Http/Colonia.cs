using System;
using System.Collections.Generic;
using System.Data;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;

namespace ComapaSoftware.Http
{
    internal class Colonia
    {
        public ModelsSector ms;
        public List<ModelsColonia> col = new List<ModelsColonia>();
        public List<ModelsSector> sector = new List<ModelsSector>();
        public List<ModelsColonia> getDatosHttpBySector(string IdSector)
        {

            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri("https://comapadbb.online");
                client.DefaultRequestHeaders.Add("User-Agent", "Anything");
                client.DefaultRequestHeaders.Add("function", "getname");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //?TipoPlanta=" + tipoPlanta
                var response = client.GetAsync("api/colonias.php?IdSector=" + IdSector).Result;
                Console.WriteLine(response);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var result = response.Content.ReadAsStringAsync().Result;
                    col = JsonSerializer.Deserialize<List<ModelsColonia>>(result);
                    return col;

                }
                else
                {
                    return col;
                }
            }
        }
        //LEER TODAS LAS COLONIAS
        public DataTable LeerTodo(string IdSector)
        {
            using (var client = new HttpClient())
            {
                DataTable dt = new DataTable("TablaPlantas");
                dt.Columns.Add("Id Colonia", typeof(string));
                dt.Columns.Add("Id Sector", typeof(string));
                dt.Columns.Add("Nombre de colonia", typeof(string));

                client.BaseAddress = new Uri("https://comapadbb.online");
                client.DefaultRequestHeaders.Add("User-Agent", "Anything");
                client.DefaultRequestHeaders.Add("function", "getallcol");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync("api/colonias.php?IdSector=" + IdSector).Result;
                Console.WriteLine(response);
                var result = response.Content.ReadAsStringAsync().Result; ;

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    List<ModelsColonia> json = JsonSerializer.Deserialize<List<ModelsColonia>>(result);
                    foreach (var items in json)
                    {
                        dt.Rows.Add(items.IdColonia, items.IdSector, items.NombreColonia);
                    }
                    return dt;

                }
                else
                {
                    return dt;
                }
            }
        }
        //TRAER LOS ID DE SECTORES
        public List<ModelsSector> LeerIds()
        {

            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri("https://comapadbb.online");
                client.DefaultRequestHeaders.Add("User-Agent", "Anything");
                client.DefaultRequestHeaders.Add("function", "readall");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //?TipoPlanta=" + tipoPlanta
                var response = client.GetAsync("api/sectores.php").Result;
                Console.WriteLine(response);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var result = response.Content.ReadAsStringAsync().Result;
                    sector = JsonSerializer.Deserialize<List<ModelsSector>>(result);
                    return sector;

                }
                else
                {
                    return sector;
                }
            }
        }
        //LEER 1 SOLO DATO 
        public ModelsSector LeerNombre(string IdSector)
        {

            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri("https://comapadbb.online");
                client.DefaultRequestHeaders.Add("User-Agent", "Anything");
                client.DefaultRequestHeaders.Add("function", "read");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //?TipoPlanta=" + tipoPlanta
                var response = client.GetAsync("api/sectores.php?IdSector=" + IdSector).Result;
                Console.WriteLine(response);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var result = response.Content.ReadAsStringAsync().Result;
                    ms = JsonSerializer.Deserialize<ModelsSector>(result);
                    return ms;

                }
                else
                {
                    return ms;
                }
            }
        }
        //REGISTRAR COLONIA
        public bool Registrar(string IdSector, string NombreColonia)
        {
            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri("https://comapadbb.online");
                client.DefaultRequestHeaders.Add("Function", "create");
                client.DefaultRequestHeaders.Add("User-Agent", "Anything");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var content = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string,string>("IdSector",IdSector),
                    new KeyValuePair<string,string>("NombreColonia",NombreColonia),

                });
                var response = client.PostAsync("api/colonias.php", content).Result;
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

        //UPDATE COLONIA
        public bool Actualizar(int IdColonia, string IdSector, string NombreColonia)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri("https://comapadbb.online");
                httpClient.DefaultRequestHeaders.Add("User-Agent", "Anything");
                httpClient.DefaultRequestHeaders.Add("Function", "update");
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                FormUrlEncodedContent contenido = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("IdColonia", IdColonia.ToString()),
                    new KeyValuePair<string, string>("IdSector", IdSector),
                    new KeyValuePair<string, string>("NombreColonia", NombreColonia),
                });

                HttpResponseMessage respuesta = httpClient.PostAsync("api/colonias.php", contenido).Result;
                Console.WriteLine(respuesta);
                Console.WriteLine(respuesta.StatusCode.ToString());
                if (respuesta.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return true;
                }
                return false;
            }
        }
        //BORRAR DATOS
        public bool Borrar(string IdColonia)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri("https://comapadbb.online");
                httpClient.DefaultRequestHeaders.Add("User-Agent", "Anything");
                httpClient.DefaultRequestHeaders.Add("Function", "delete");
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage respuesta = httpClient.GetAsync("api/colonias.php?IdColonia=" + IdColonia).Result;
                if (respuesta.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return true;
                }
                return false;
            }
        }

    }
}
