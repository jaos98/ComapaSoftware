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
    internal class Sector
    {
        public ModelsSector sector;
        public  List<ModelsSector> list = new List<ModelsSector>();
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
    }
}

