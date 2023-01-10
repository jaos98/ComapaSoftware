using ComapaSoftware.Http;
using ComapaSoftware.Vistas;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace ComapaSoftware
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }
        public bool validacionDatos()
        {
            if (txtUsuario.Text == "" || txtContraseña.Text == "")
            {
                MessageBox.Show("Llene todos los campos");
                return false;
            }
            return true;
        }
        private void btnIniciar_Click(object sender, EventArgs e)
        {
            if (validacionDatos())
            {
                if (new Conexion().LogIn(txtUsuario.Text, txtContraseña.Text))
                {
                    MessageBox.Show("Bienvenido");
                    Close();
                    FormPanel formPanel = new FormPanel();
                    formPanel.Show();
                }
                else
                {
                    MessageBox.Show("Error en el usuario o contraseña");
                }
            }
        }
        private void FormLogin_Load(object sender, EventArgs e)
        {
            FormLogin formLogin = new FormLogin();
            formLogin.FormBorderStyle = FormBorderStyle.FixedDialog;
            formLogin.StartPosition = FormStartPosition.CenterScreen;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ComprobarInicio();
        }

        public async Task ComprobarInicio()
        {
            using (var client = new HttpClient())
            {
                var values = new Dictionary<string, string> {
                    {"CuentaUsuario", txtUsuario.Text },
                    {"ContraseñaUsuario",txtContraseña.Text }
            };
                var content = new FormUrlEncodedContent(values);
                var response = await client.PostAsync("http://localhost/api/validation.php", content);
                var responseString = await response.Content.ReadAsStringAsync();

                Console.WriteLine(responseString);
                //if (response.IsSuccessStatusCode)
                //{
                //    MessageBox.Show("¡Existe!");
                //}
                //else
                //{
                //    MessageBox.Show("-Ha ocurrido un error, favor de revisar su conexion a internet," +
                //        "si el problema persiste, consulte con el administrador");
                //}
            }
            //string url = "http://localhost/api/validation.php";
            //var client = new HttpClient();
            //PostUser post = new PostUser()
            //{
            //    CuentaUsuario = "comapa",
            //    ContraseñaUsuario = "prueba"

            //};

            //var data = JsonSerializer.Serialize<PostUser>(post);
            //HttpContent content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
            //var httpResponse = await client.PostAsync(url, content);
            //var result = await httpResponse.Content.ReadAsStringAsync();
            //Console.WriteLine(result);
            //if (httpResponse.IsSuccessStatusCode)
            //{
            //    var result = await httpResponse.Content.ReadAsStringAsync();
            //    Console.WriteLine(result);
            //    var postResult = JsonSerializer.Deserialize<PostUser>(result);
            //    Console.WriteLine(postResult);

            //}
            //else
            //{
            //    Console.WriteLine("Algo ha salido mal");
            //}
        }
    }
}
