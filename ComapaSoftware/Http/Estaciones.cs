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
    internal class Estaciones
    {
        //HTTP REQUEST METHODS


        //CONSULTAR INF0RMACION
        public DataTable llevarDatosHttp(string idPlantas)
        {
            DataTable dt = new DataTable("Tabla Estaciones");
            dt.Columns.Add("Id Planta", typeof(string));
            dt.Columns.Add("Id Estacion", typeof(string));
            dt.Columns.Add("Nombre", typeof(string));
            dt.Columns.Add("Capacidad de equipos", typeof(string));
            dt.Columns.Add("Operacion Minima", typeof(string));
            dt.Columns.Add("Equipos Instalados", typeof(string));
            dt.Columns.Add("Tipo", typeof(string));
            dt.Columns.Add("Garantizar Operacion", typeof(string));
            dt.Columns.Add("Gasto Promedio", typeof(string));
            dt.Columns.Add("Gasto Instalado", typeof(string));
            dt.Columns.Add("Servicio", typeof(string));
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
                List<ModeloInfo> json = JsonSerializer.Deserialize<List<ModeloInfo>>(result);

                foreach (var items in json)
                {

                    dt.Rows.Add(items.IdEstacion, items.IdEstacion, items.Nombre, items.CapEquipos, items.OperacionMinima,
                        items.EquiposInstalados, items.Tipo, items.GarantOperacion, items.GastoPromedio, items.GastoInstalado,
                        items.Servicio, items.Observaciones);

                }
                return dt;
            }
        }
        //REGISTRO HTTP REQUEST
        public int insertarInfoHttp(string IdPlantas, string IdEstacion, string Nombre, string CapEquipos, string OperacionMinima, string EquiposInstalados,
            string Tipo, string GarantOperacion, string GastoPromedio, string GastoInstalado, string Servicio, string Observaciones)
        {
            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri("http://localhost");
                client.DefaultRequestHeaders.Add("User-Agent", "Anything");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var content = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string,string>("IdPlantas",IdPlantas),
                    new KeyValuePair<string,string>("NumMedidor",IdEstacion),
                    new KeyValuePair<string,string>("NumServicio",Nombre),
                    new KeyValuePair<string,string>("TipoPlantas",CapEquipos),
                    new KeyValuePair<string,string>("Estatus",OperacionMinima),
                    new KeyValuePair<string,string>("DescFunciones",EquiposInstalados),
                    new KeyValuePair<string,string>("SubestacionKva",Tipo),
                    new KeyValuePair<string,string>("Colonia",GarantOperacion),
                    new KeyValuePair<string,string>("Sector",GastoPromedio),
                    new KeyValuePair<string,string>("Latitud",GastoInstalado),
                    new KeyValuePair<string,string>("Longitud",Servicio),
                    new KeyValuePair<string,string>("Elevacion",Observaciones)

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
