using ComapaSoftware.Http;
using ComapaSoftware.Vistas;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace ComapaSoftware
{
    public partial class FormLogin : Form
    {
        Usuarios u = new Usuarios();

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
                    ControlPanel formPanel = new ControlPanel();
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

        //HTTP
        public async Task ComprobarInicio()
        {


            if (u.validarSesionHttp(u.Usuario = txtUsuario.Text,
            u.Password = txtContraseña.Text))
            {
                MessageBox.Show("¡Bienvenido!");
                Close();
                ControlPanel formPanel = new ControlPanel();
                formPanel.Show();
            }
            else
            {
                MessageBox.Show("Usuario/Contraseña incorrectos. Si el problema persiste, revise su conexion a internet");
            }
        }
    }
}
