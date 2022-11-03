using ComapaSoftware.Vistas;
using System;
using System.Windows.Forms;
namespace ComapaSoftware
{
    public partial class FormLogin : Form
    {
        Conexion con = new Conexion();
        public FormLogin()
        {
            InitializeComponent();
        }
        public bool validacionDatos()
        {
            string usuario = txtUsuario.Text;
            string contraseña = txtContraseña.Text;
            if (usuario == "" || contraseña == "")
            {
                MessageBox.Show("Porfavor introduzca datos validos");
                return false;
            }
            return true;
        }
        private void btnIniciar_Click(object sender, EventArgs e)
        {
            if (validacionDatos())
            {
                string usuario = txtUsuario.Text;
                string contraseña = txtContraseña.Text;
                if (con.validarUsuario(usuario, contraseña))
                {
                    MessageBox.Show("Bienvenido");
                    this.Close();
                    FormPanel formPanel = new FormPanel();
                    formPanel.Show();
                }
                else
                {
                    MessageBox.Show("Datos incorrectos");
                }
            }
        }
        private void FormLogin_Load(object sender, EventArgs e)
        {
            //var bounds = Screen.FromControl(this).Bounds;
            //this.Width = bounds.Width - 100;
            // this.Height = bounds.Height - 100;
            FormLogin formLogin = new FormLogin();
            formLogin.FormBorderStyle = FormBorderStyle.FixedDialog;
            formLogin.StartPosition = FormStartPosition.CenterScreen;
        }
    }
}
