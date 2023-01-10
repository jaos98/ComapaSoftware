using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComapaSoftware.Controlador;

namespace ComapaSoftware.Vistas
{
    public partial class PruebaHttp : Form
    {
        
        public PruebaHttp()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ObtenerRespuestaAsync();
        }
        public async Task ObtenerRespuestaAsync()
        {
            using (var client = new HttpClient())
            {
                var result = await client.GetAsync("http://localhost/api/databaseconn.php");
                Console.WriteLine(result.StatusCode);
            }
        }
        public async Task EnviarDatos()
        {
            using (var client = new HttpClient())
            {
                var values = new Dictionary<string, string> {
                    { "IdPlantas", "hello" }, 
                    { "", "world" },
                    {"","" }

            };
                var content = new FormUrlEncodedContent(values);
                var response = await client.PostAsync("http://www.example.com/recepticle.aspx", content);
                var responseString = await response.Content.ReadAsStringAsync();
                Console.WriteLine(responseString);
            }
       
        }


    }
}
