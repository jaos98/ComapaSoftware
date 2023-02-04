using ComapaSoftware.Controlador;
using ComapaSoftware.Http;
using ComapaSoftware.Modelo;
using System;
using System.Windows.Forms;

namespace ComapaSoftware.Vistas
{

    public partial class Actbomba : Form
    {
        Bombas b = new Bombas();
        ModelsBombas mb = new ModelsBombas();
        private string idBomba;
        private string idEstacion;
        public string IdEstacion
        {
            get { return idEstacion; }
            set { idEstacion = value; }
        }
        public string IdBomba
        {
            get { return idBomba; }
            set { idBomba = value; }
        }
        public Actbomba(string idBomba, string idEstacion)
        {
            IdBomba = idBomba;
            IdEstacion = idEstacion;
            InitializeComponent();

        }
        public Actbomba()
        {
            InitializeComponent();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            GetInfoHttp();
            if (b.Actualizar(mb.IdBombas, mb.Posicion, mb.Marca, mb.Tipo, mb.Modelo, mb.Hp, mb.Voltaje,
                mb.Diametro, mb.Lps, mb.Carga, mb.Rpm, mb.Estatus, mb.Fpm, mb.Observaciones))
            {
                MessageBox.Show("Se ham actualizado los datos");
                Close();
            }
            else
            {
                MessageBox.Show("Ha ocurrido un erro, intentelo mas tarde o contacte al administrador");
                Close();
            }
        }

        private void Actbomba_Load(object sender, EventArgs e)
        {
            validatePos();
            mb = b.Leer(IdBomba);

            cmbPosicion.Text = mb.Posicion.ToString();
            txtMarca.Text = mb.Marca;
            txtModelo.Text = mb.Modelo;
            cmbTipo.Text = mb.Tipo;
            txtHp.Text = mb.Hp;
            txtVoltaje.Text = mb.Voltaje;
            txtDiametro.Text = mb.Diametro;
            txtGastolps.Text = mb.Lps;
            txtDinamica.Text = mb.Carga;
            txtRpm.Text = mb.Rpm;
            txtFpm.Text = mb.Fpm;
            cmbEstatus.Text = mb.Estatus;
            txtObservaciones.Text = mb.Observaciones;
        }
        void validatePos()
        {
            cmbPosicion.Items.Clear();
            for (int i = 1; i <= 10; i++)
            {
                if (b.VerificarPosicion(IdEstacion, i))
                {

                }
                else
                {
                    cmbPosicion.Items.Add(i);
                }
            }
        }
        void GetInfoHttp()
        {
            mb.IdBombas = Convert.ToInt32(IdBomba);
            mb.Posicion = Convert.ToInt32(cmbPosicion.Text);
            mb.Marca = txtMarca.Text;
            mb.Modelo = txtModelo.Text;
            mb.Tipo = cmbTipo.Text;
            mb.Hp = txtHp.Text;
            mb.Voltaje = txtVoltaje.Text;
            mb.Diametro = txtDiametro.Text;
            mb.Lps = txtGastolps.Text;
            mb.Carga = txtDinamica.Text;
            mb.Rpm = txtRpm.Text;
            mb.Fpm = txtFpm.Text;
            mb.Estatus = cmbEstatus.Text;
            mb.Observaciones = txtObservaciones.Text;

        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
