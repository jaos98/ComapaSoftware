using ComapaSoftware.Controlador;
using ComapaSoftware.Modelo;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
namespace ComapaSoftware.Vistas
{

    public partial class RegBomba : Form
    {
        ControladorBombas c = new ControladorBombas();
        ModeloBombas modeloBombas = new ModeloBombas();

        public RegBomba(string receiver)
        {
            InitializeComponent();
            cmbCategoria.Enabled = false;
            cmbEstacion.Enabled = false;
            cmbEstacion.Enabled = false;
            btnVolver.Hide();
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine("Iteracion " + i);
                if (!modeloBombas.ConsultarPosicion(receiver, i))
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
            foreach  (var item in modeloBombas.ObtenerIdPlantas(cmbCategoria.Text))
            {
                cmbPlanta.Items.Add(item);
            }
            cmbPlanta.Enabled = true;
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbEstacion.Items.Clear();
            cmbEstacion.Text = "";
            foreach (var item in modeloBombas.ObtenerIdEstacion(cmbPlanta.Text))
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
                    if (!modeloBombas.ConsultarPosicion(cmbEstacion.Text,i))
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

        private void button1_Click(object sender, EventArgs e)
        {
            DataView();
            if (Validar())
            {
                if (modeloBombas.registrarInfoBomba(c.IdEstacion, c.Posicion, c.Marca, c.Tipo,
                    c.Modelo, c.Hp, c.Voltaje, c.Diametro, c.Lps, c.Carga, c.Rpm, c.Estatus,
                    c.Fpm, c.Observaciones)>0)
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
            c.IdBombas = cmbPlanta.Text;
            c.IdEstacion = cmbEstacion.Text;
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
            c.Estatus = cmbEstatus.Text;
            c.Fpm = txtFpm.Text;
            c.Observaciones = txtObservaciones.Text;
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
            if (c.Marca == ""||c.Modelo ==""|| c.Tipo ==""||c.Hp ==""|| c.Voltaje ==""||
                c.Diametro ==""||c.Lps ==""||c.Carga ==""||c.Rpm==""||c.Estatus==""||
                c.Fpm ==""||c.Observaciones=="")
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
            FormPanel control = new FormPanel();
            this.Close();
            control.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            FormPanel control = new FormPanel();
            this.Close();
            control.Show();
        }
    }
}
