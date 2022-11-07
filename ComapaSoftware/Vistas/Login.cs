using ComapaSoftware.Vistas;
using System;
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
            //var bounds = Screen.FromControl(this).Bounds;
            //this.Width = bounds.Width - 100;
            // this.Height = bounds.Height - 100;
            FormLogin formLogin = new FormLogin();
            formLogin.FormBorderStyle = FormBorderStyle.FixedDialog;
            formLogin.StartPosition = FormStartPosition.CenterScreen;
        }
    }
}
