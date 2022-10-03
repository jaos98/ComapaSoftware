using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComapaSoftware.Controlador;
using ComapaSoftware.Modelo;

namespace ComapaSoftware.Vistas
{
    public partial class FormPlanta : Form
    {

        Conexion conn = new Conexion();
        ControladorInfo controlador = new ControladorInfo();
        ModeloPlantas modelo = new ModeloPlantas();
        public FormPlanta()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            FormPanel formPanel = new FormPanel();
            formPanel.Show();
        }
        //Informacion a llenar con boton
        private void button1_Click(object sender, EventArgs e)
        {
            controlador.IdPlanta = txtPlanta.Text.Trim();
            controlador.NumMedidor = txtNumMed.Text.Trim();
            string txtNumServicio = txtNumServ.Text.Trim();
            int num = Int32.Parse(txtNumServicio);
            controlador.NumServicio = num;
            controlador.TipoPlantas = cmbTipoPlanta.Text;
            controlador.Estatus = cmbEstatus.Text;
            controlador.DescFunciones = txtDescFunciones.Text;


            MessageBox.Show(controlador.IdPlanta + "\n" +
            "\n" + controlador.NumServicio.ToString() +
            "\n" + controlador.NumMedidor +
            "\n" + controlador.TipoPlantas);

        }

        private void FormPlanta_Load(object sender, EventArgs e)
        {
            //cmbSector.Items.Add(modelo.consultarSector2(cmbSector));
            
            foreach (var item in modelo.consultarSector())
            {
                cmbSector.Items.Add(item);
            }
        }

        private void cmbSector_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
        
    }
}
