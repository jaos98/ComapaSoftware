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
    internal class Usuarios
    {

        public string Usuario { get; set; }
        public string Password { get; set; }


        public bool validarSesionHttp(string Usuario,string Password)
        {
            Console.WriteLine(Usuario+"/"+Password);
            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri("https://comapadbb.online");
                client.DefaultRequestHeaders.Add("User-Agent", "Anything");
                client.DefaultRequestHeaders.Add("Function", "login");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //?TipoPlanta=" + tipoPlanta
                var response = client.GetAsync("api/usuarios.php?Usuario="+Usuario+"&Password="+Password+"").Result;
                response.EnsureSuccessStatusCode();
                var result = response.Content.ReadAsStringAsync().Result; 
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else if (!response.IsSuccessStatusCode)
                {
                    return false;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
