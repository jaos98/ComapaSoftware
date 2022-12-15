using ComapaSoftware.Controlador;
using ComapaSoftware.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComapaSoftware.Vistas
{
    
    public partial class Actbomba : Form
    {
        ControladorBombas c = new ControladorBombas();
        ModeloBombas m = new ModeloBombas();
        private string globalReceiver;
        private string globalPos;
        public string GlobalPos
        {
            get { return globalPos; }
            set { globalPos = value; }
        }
        public string GlobalReceiver
        {
            get { return globalReceiver; }
            set { globalReceiver = value; }
        }
        public Actbomba(string receiver,string receiver2)
        {
            GlobalPos = receiver;
            GlobalReceiver = receiver2;

            Console.WriteLine("Hasta aqui vamos bien "+GlobalPos+GlobalReceiver);
            InitializeComponent();
            
        }
        public Actbomba()
        {
            InitializeComponent();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            GetInfo();
            Console.WriteLine("Esta info esta bien, creo: "+GlobalReceiver + c.Posicion);
                if (m.UpdateInfo(GlobalReceiver, c.Posicion, c.Marca, c.Modelo,
                c.Tipo, c.Hp, c.Voltaje, c.Diametro, c.Lps, c.Carga, c.Rpm, c.Estatus,
                c.Fpm, c.Observaciones) > 0)
                {
                MessageBox.Show("Actualizado correctamente");
                Close();
                }
            else
            {
                MessageBox.Show("Ha ocurrido un error");
            }
            
        
            
            

        }

        private void Actbomba_Load(object sender, EventArgs e)
        {
            foreach (ControladorBombas list in m.GetUpdateInfo(GlobalPos,GlobalReceiver))
            {

                //lblEstacion.Text = list.IdEstacion;
                cmbPosicion.Text = list.Posicion.ToString();
                txtMarca.Text = list.Marca;
                txtModelo.Text = list.Modelo;
                cmbTipo.Text = list.Tipo;
                txtHp.Text = list.Hp;
                txtVoltaje.Text = list.Voltaje;
                txtDiametro.Text = list.Diametro;
                txtGastolps.Text = list.Lps;
                txtDinamica.Text = list.Carga;
                txtRpm.Text = list.Rpm;
                txtFpm.Text = list.Fpm;
                cmbEstatus.Text = list.Estatus;
                txtObservaciones.Text = list.Observaciones;
            }
        }
        void GetInfo()
        {
            c.Posicion = Convert.ToInt32(cmbPosicion.Text);
            c.Marca = txtMarca.Text;
            c.Modelo = txtModelo.Text;
            c.Tipo = cmbTipo.Text;
            c.Hp = txtHp.Text;
            c.Voltaje = txtVoltaje.Text;
            c.Diametro = txtDiametro.Text;
            c.Lps = txtGastolps.Text;
            c.Carga = txtDinamica.Text;
            c.Rpm = txtRpm.Text;
            c.Fpm = txtFpm.Text;
            c.Estatus = cmbEstatus.Text;
            c.Observaciones = txtObservaciones.Text;

        }
    }
}
