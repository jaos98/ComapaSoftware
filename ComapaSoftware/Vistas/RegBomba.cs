using ComapaSoftware.Controlador;
using ComapaSoftware.Http;
using ComapaSoftware.Modelo;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Windows.Forms;
namespace ComapaSoftware.Vistas
{

    public partial class RegBomba : Form
    {
        ModeloBombas m = new ModeloBombas();
        ControladorBombas c = new ControladorBombas();
        Bombas b = new Bombas();
        ModelsBombas mb = new ModelsBombas();
        List<PosBombas>  catcherpos = new List<PosBombas>();
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
            cmbPlanta.Enabled = true;
            cmbEstacion.Items.Clear();
            cmbPlanta.Items.Clear();
            cmbEstacion.Text = "";
            cmbPlanta.Text = "";
            foreach (ModelsPlantas mdp in b.getDatosHttpByTipo(cmbCategoria.Text))
            {
                cmbPlanta.Items.Add(mdp.IdPlantas);
            }
            



            //cmbEstacion.Items.Clear();
            //cmbPlanta.Items.Clear();
            //cmbEstacion.Text = "";
            //cmbPlanta.Text = "";
            //foreach  (var item in c.ObtenerIdPlantas(cmbCategoria.Text))
            //{
            //    cmbPlanta.Items.Add(item);
            //}
            //cmbPlanta.Enabled = true;
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbEstacion.Enabled = true;
            cmbEstacion.Items.Clear();
            cmbEstacion.Text = "";
            foreach (ModelsEstaciones mde in b.getDatosHttpById(cmbPlanta.Text))
            {
                cmbEstacion.Items.Add(mde.IdEstacion);
            }


            //FUNCIONA EN LOCAL
            //foreach (var item in c.ObtenerIdEstacion(cmbPlanta.Text))
            //{
            //    cmbEstacion.Items.Add(item);
            //}
            //cmbEstacion.Enabled = true;
        }
        //COMBO BOX DE ID ESTACION PARA REGISTRO DE BOMBAS
        private void cmbIdPlanta_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (PosBombas pb in b.getDatosHttpByPos(cmbEstacion.Text))
            {
                catcherpos.Add(pb);
            }
            Console.WriteLine(catcherpos);

            foreach (var item in catcherpos)
            {
                Console.WriteLine(item.IdBombas);
                Console.WriteLine(item.IdEstacion);
                Console.WriteLine(item.Posicion);
                Console.WriteLine(item.IsBombas);
            }





            //if (cmbEstacion.SelectedIndex >= 0)
            //{
            //    int num = cmbEstacion.SelectedIndex;
            //    mainPanel.Enabled = true;
            //    //CICLO PARA IDENTIFICAR LA POSICION DE LA BOMBA
            //    for (int i = 1; i <= 10; i++)
            //    {
            //        Console.WriteLine("Iteracion "+i);
            //        if (!c.ConsultarPosicion(cmbEstacion.Text,i))
            //        {
            //            cmbPosicion.Text = i.ToString();
            //            break;
            //        }
            //    }
            //}
            //btnVolver.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnReg_Click(object sender, EventArgs e)
        {
            //DataView();
            //if (Validar())
            //{
            //    if (b.insertarPlantaHttp(m.IdEstacion, m.Posicion, m.Marca, m.Tipo,
            //        m.Modelo, m.Hp, m.Voltaje, m.Diametro, m.Lps, m.Carga, m.Rpm, m.Estatus,
            //        m.Fpm, m.Observaciones)>0)
            //    {
            //        MessageBox.Show("Se ha registrado todo correctamente");
            //        Clean();
            //    }
            //    else
            //    {
            //        MessageBox.Show("Ha sucedido un error");
            //    }

            //}
            DataHttp();
            if (Validar())
            {
                if (b.insertarBombaHttp(mb.IdEstacion, mb.Posicion, mb.Marca, mb.Tipo,
                    mb.Modelo, mb.HP, mb.Voltaje, mb.DiametroDescarga, mb.GastoLPS, mb.CargaDinamica, mb.RPM, mb.Estatus,
                    mb.FPM, mb.Observaciones) > 0)
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
        public void DataHttp()
        {
            mb.IdEstacion = cmbEstacion.Text;
            mb.Posicion = Convert.ToInt32(cmbPosicion.Text);
            mb.Marca = txtMarca.Text;
            mb.Modelo = txtModelo.Text;
            mb.Tipo = cmbTipo.Text;
            mb.HP = txtHp.Text;
            mb.Voltaje = txtVoltaje.Text;
            mb.DiametroDescarga = txtDiametro.Text;
            mb.GastoLPS = txtGastolps.Text;
            mb.CargaDinamica = txtDinamica.Text;
            mb.RPM = txtRpm.Text;
            mb.Estatus = cmbEstatus.Text;
            mb.FPM = txtFpm.Text;
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
