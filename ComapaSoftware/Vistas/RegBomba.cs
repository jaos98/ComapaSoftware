using ComapaSoftware.Http;
using System;
using System.Windows.Forms;
namespace ComapaSoftware.Vistas
{

    public partial class RegBomba : Form
    {
        Bombas b = new Bombas();
        ModelsBombas mb = new ModelsBombas();
        private string idEstacion;
        public string IdEstacion
        {
            get { return idEstacion; }
            set { idEstacion = value; }
        }
        public RegBomba()
        {
            InitializeComponent();
        }

        private void RegBomba_Load(object sender, EventArgs e)
        {
            cmbEstacion.Enabled = false;
        }
        //PRIMER COMBOBOX DE ID PLANTAS
        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            cmbPlanta.Enabled = true;
            cmbPosicion.Items.Clear();
            cmbEstacion.Items.Clear();
            cmbPlanta.Items.Clear();
            cmbEstacion.Text = "";
            cmbPlanta.Text = "";
            foreach (ModelsPlantas mdp in b.getDatosHttpByTipo(cmbCategoria.Text))
            {
                cmbPlanta.Items.Add(mdp.IdPlantas);
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbEstacion.Enabled = true;
            cmbPosicion.Items.Clear();
            cmbEstacion.Items.Clear();
            cmbEstacion.Text = "";
            foreach (ModelsEstaciones mde in b.getDatosHttpById(cmbPlanta.Text))
            {
                cmbEstacion.Items.Add(mde.IdEstacion);
            }
        }
        //COMBO BOX DE ID ESTACION PARA REGISTRO DE BOMBAS
        private void cmbIdPlanta_SelectedIndexChanged(object sender, EventArgs e)
        {
            ValidatePos();
        }
        void ValidatePos()
        {
            if (cmbEstacion.SelectedIndex >= 0)
            {
                cmbPosicion.Items.Clear();

                for (int i = 1; i <= 10; i++)
                {
                    if (b.VerificarPosicion(cmbEstacion.Text, i))
                    {

                    }
                    else
                    {
                        cmbPosicion.Items.Add(i);
                    }

                }
                mainPanel.Enabled = true;
                btnVolver.Hide();


            }
        }


        private void btnReg_Click(object sender, EventArgs e)
        {
            DataHttp();
            if (Validar())
            {
                if (b.insertarBombaHttp(mb.IdEstacion, mb.Posicion, mb.Marca, mb.Tipo,
                    mb.Modelo, mb.Hp, mb.Voltaje, mb.Diametro, mb.Lps, mb.Carga, mb.Rpm, mb.Estatus,
                    mb.Fpm, mb.Observaciones) > 0)
                {
                    MessageBox.Show("Se ha registrado todo correctamente");
                    Clean();
                    Dispose();
                    ControlPanel cpanel = new ControlPanel();
                    cpanel.Show();

                }
                else
                {
                    MessageBox.Show("Ha sucedido un error");
                }

            }
        }
        public void DataHttp()
        {
            mb.IdEstacion = cmbEstacion.Text;
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
            mb.Estatus = cmbEstatus.Text;
            mb.Fpm = txtFpm.Text;
            mb.Observaciones = txtObservaciones.Text;
        }
        private void Clean()
        {
            cmbPlanta.Text = "";
            cmbEstacion.Text = "";
            cmbPosicion.Text = "";
            txtMarca.Text = "";
            txtModelo.Text = "";
            cmbTipo.Text = "";
            txtHp.Text = "";
            txtVoltaje.Text = "";
            txtDiametro.Text = "";
            txtGastolps.Text = "";
            txtDinamica.Text = "";
            txtRpm.Text = "";
            cmbEstatus.Text = "";
            txtFpm.Text = "";
            txtObservaciones.Text = "";
        }
        private bool Validar()
        {
            if (mb.Marca == "" || mb.Modelo == "" || mb.Tipo == "" || mb.Hp == "" || mb.Voltaje == "" ||
                mb.Diametro == "" || mb.Lps == "" || mb.Carga == "" || mb.Rpm == "" || mb.Estatus == "" ||
                mb.Fpm == "" || mb.Observaciones == "")
            {
                MessageBox.Show("Porfavor ingrese todos los datos");
                return false;
            }
            return true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ControlPanel control = new ControlPanel();
            Dispose();
            control.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            ControlPanel control = new ControlPanel();
            Dispose();
            control.Show();
        }

        private void RegBomba_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
