using ComapaSoftware.Controlador;
using ComapaSoftware.Modelo;
using System;
using System.Windows.Forms;

namespace ComapaSoftware.Vistas
{

    public partial class Actbomba : Form
    {
        ModeloBombas m = new ModeloBombas();
        ControladorBombas c = new ControladorBombas();
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
        public Actbomba(string receiver, string receiver2)
        {
            GlobalPos = receiver;
            GlobalReceiver = receiver2;

            Console.WriteLine("Hasta aqui vamos bien " + GlobalPos + GlobalReceiver);
            InitializeComponent();

        }
        public Actbomba()
        {
            InitializeComponent();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            GetInfo();
            Console.WriteLine("Esta info esta bien, creo: " + GlobalReceiver + m.Posicion);
            if (c.UpdateInfo(GlobalReceiver, m.Posicion, m.Marca, m.Modelo,
            m.Tipo, m.Hp, m.Voltaje, m.Diametro, m.Lps, m.Carga, m.Rpm, m.Estatus,
            m.Fpm, m.Observaciones) > 0)
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
            foreach (ModeloBombas list in c.GetUpdateInfo(GlobalPos, GlobalReceiver))
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
            m.Posicion = Convert.ToInt32(cmbPosicion.Text);
            m.Marca = txtMarca.Text;
            m.Modelo = txtModelo.Text;
            m.Tipo = cmbTipo.Text;
            m.Hp = txtHp.Text;
            m.Voltaje = txtVoltaje.Text;
            m.Diametro = txtDiametro.Text;
            m.Lps = txtGastolps.Text;
            m.Carga = txtDinamica.Text;
            m.Rpm = txtRpm.Text;
            m.Fpm = txtFpm.Text;
            m.Estatus = cmbEstatus.Text;
            m.Observaciones = txtObservaciones.Text;

        }
    }
}
