using ComapaSoftware.Controlador;
using ComapaSoftware.Modelo;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
namespace ComapaSoftware.Vistas
{

    public partial class RegBomba : Form
    {
        ModeloBombas m = new ModeloBombas();
        ControladorBombas c = new ControladorBombas();
        private string idEstacion;
        public string IdEstacion
        {
            get { return idEstacion; }
            set { idEstacion = value; }
        }

        public RegBomba(string idEstacion)
        {
            IdEstacion = idEstacion;
            InitializeComponent();
            cmbCategoria.Enabled = false;
            cmbEstacion.Enabled = false;
            cmbEstacion.Enabled = false;
            btnReg.Visible = false;
            btnReg2.Visible = true;
            btnVolver.Hide();
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine("Iteracion " + i);
                if (!c.ConsultarPosicion(IdEstacion, i))
                {
                    cmbPosicion.Text = i.ToString();
                    break;
                }
            }
            mainPanel.Enabled = true;
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
            cmbEstacion.Items.Clear();
            cmbPlanta.Items.Clear();
            cmbEstacion.Text = "";
            cmbPlanta.Text = "";
            foreach  (var item in c.ObtenerIdPlantas(cmbCategoria.Text))
            {
                cmbPlanta.Items.Add(item);
            }
            cmbPlanta.Enabled = true;
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbEstacion.Items.Clear();
            cmbEstacion.Text = "";
            foreach (var item in c.ObtenerIdEstacion(cmbPlanta.Text))
            {
                cmbEstacion.Items.Add(item);
            }
            cmbEstacion.Enabled = true;
        }
        //COMBO BOX DE ID ESTACION PARA REGISTRO DE BOMBAS
        private void cmbIdPlanta_SelectedIndexChanged(object sender, EventArgs e)
        { 
            if (cmbEstacion.SelectedIndex >= 0)
            {
                int num = cmbEstacion.SelectedIndex;
                mainPanel.Enabled = true;
                //CICLO PARA IDENTIFICAR LA POSICION DE LA BOMBA
                for (int i = 1; i <= 10; i++)
                {
                    Console.WriteLine("Iteracion "+i);
                    if (!c.ConsultarPosicion(cmbEstacion.Text,i))
                    {
                        cmbPosicion.Text = i.ToString();
                        break;
                    }
                }
            }
            btnVolver.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnReg_Click(object sender, EventArgs e)
        {
            DataView();
            if (Validar())
            {
                if (c.registrarInfoBomba(m.IdEstacion, m.Posicion, m.Marca, m.Tipo,
                    m.Modelo, m.Hp, m.Voltaje, m.Diametro, m.Lps, m.Carga, m.Rpm, m.Estatus,
                    m.Fpm, m.Observaciones)>0)
                {
                    MessageBox.Show("Se ha registrado todo correctamente");
                    Clean();
                }
                else
                {
                    MessageBox.Show("Ha sucedido un error");
                }
                
            }
        }
        private void DataView()
        {
            m.IdBombas = cmbPlanta.Text;
            m.IdEstacion = cmbEstacion.Text;
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
            m.Estatus = cmbEstatus.Text;
            m.Fpm = txtFpm.Text;
            m.Observaciones = txtObservaciones.Text;
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
            if (m.Marca == ""||m.Modelo ==""|| m.Tipo ==""||m.Hp ==""|| m.Voltaje ==""||
                m.Diametro ==""||m.Lps ==""||m.Carga ==""||m.Rpm==""||m.Estatus==""||
                m.Fpm ==""||m.Observaciones=="")
            {
                MessageBox.Show("Porfavor ingrese todos los datos");
                return false;
            }
            return true;
        }

        private void comboBox1_SelectedIndexChanged_2(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ControlPanel control = new ControlPanel();
            Close();
            control.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            ControlPanel control = new ControlPanel();
            Close();
            control.Show();
        }

        private void btnReg2_Click(object sender, EventArgs e)
        {

            DataView();
            Console.WriteLine("Este es el id: "+IdEstacion);
            Console.WriteLine(m.Posicion);
            if (c.registrarInfoBomba2(IdEstacion, m.Posicion, m.Marca, m.Tipo,
                m.Modelo, m.Hp, m.Voltaje, m.Diametro, m.Lps, m.Carga, m.Rpm, m.Estatus,
                m.Fpm, m.Observaciones) > 0)
            {
                MessageBox.Show("Se ha registrado todo correctamente");
                Clean();
            }
        }
    }
}
