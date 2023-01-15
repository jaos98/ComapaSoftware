using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ComapaSoftware.Http
{
    internal class Colonia
    {
        public List<ModelsColonia> col = new List<ModelsColonia>();
        public List<ModelsColonia> getDatosHttpBySector(string IdSector)
        {

            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri("https://comapadbb.online");
                client.DefaultRequestHeaders.Add("User-Agent", "Anything");
                client.DefaultRequestHeaders.Add("function", "getname");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //?TipoPlanta=" + tipoPlanta
                var response = client.GetAsync("api/colonias.php?IdSector="+IdSector).Result;
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
    }
}
