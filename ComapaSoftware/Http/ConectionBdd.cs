using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ComapaSoftware.Http
{
    internal class ConectionBdd
    {
public async Task ObtenerRespuestaAsync()
        {
            using (var client = new HttpClient())
            {
                var result = await client.GetAsync("https://www.netmentor.es");
                Console.WriteLine(result.StatusCode);
            }
        }

    }
}
