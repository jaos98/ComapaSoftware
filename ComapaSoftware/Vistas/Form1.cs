using ComapaSoftware.Vistas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            
            String usuario = txtUsuario.Text;
            String contraseña = txtContraseña.Text;
            if (usuario == "" || contraseña == "")
            {
                MessageBox.Show("Porfavor introduzca datos validos");
                return false;
            }
            return true;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (validacionDatos())
            {
                String usuario = txtUsuario.Text;
                String contraseña = txtContraseña.Text;
                if (con.ConsultaExperimental(usuario,contraseña))
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


    }
    
}
