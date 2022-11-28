using ComapaSoftware.Controlador;
using ComapaSoftware.Modelo;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
namespace ComapaSoftware.Vistas
{

    public partial class RegBomba : Form
    {
        string idplanta, pos, marca, modelo, tipo, hp, voltaje, diametro, lps, carga, rpm, estatus, fpm, observaciones;

        ControladorBombas c = new ControladorBombas();
        ModeloBombas modeloBombas = new ModeloBombas();
        string[] catcher = new string[99];
        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            foreach  (var item in modeloBombas.ObtenerIdPlantas(cmbCategoria.Text))
            {
                cmbPlanta.Items.Add(item);
            }
        }
        public RegBomba()
        {
            InitializeComponent();
        }
        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            idplanta = labelId.Text;
            pos = txtPosicion.Text;
            marca = txtMarca.Text;
            modelo = txtModelo.Text;
            tipo = cmbTipo.Text;
            hp = txtHp.Text;
            voltaje = txtVoltaje.Text;
            diametro = txtDiametro.Text;
            lps = txtGastolps.Text;
            carga = txtDinamica.Text;
            rpm = txtRpm.Text;
            estatus = cmbEstatus.Text;
            fpm = txtFpm.Text;
            observaciones = txtObservaciones.Text;

            //switch (validarDatos())
            //{
            //    case 0:
            //        MessageBox.Show("Llene todos los campos");
            //        break;

            //    case 1:
            //        MessageBox.Show("Todos los datos son correctos");
            //        if (modeloBombas.registrarInfoBomba(idplanta,pos,marca,modelo,tipo,hp,voltaje,diametro,lps,carga,rpm,estatus,fpm,observaciones) > 0)
            //        {
            //            MessageBox.Show("Informacion registrada");
            //        }
            //        else
            //        {
            //            MessageBox.Show("Hubo un error");
            //        }
            //        break;
            //}

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {   
            int i=0;
            if (cmbPlanta.SelectedIndex >= 0)
            {
                cmbEstacion.Enabled = true;
                cmbEstacion.Items.Clear();
                foreach (CriterioRegistroBomba cr in modeloBombas.obtenerIdFicha3(cmbPlanta.Text))
                {
                    int u = 0;
                    cmbEstacion.Items.Add(cr.IdPlantas +" - "+ cr.Slug +" - "+ cr.Servicio);
                    var stringCollection = new IdentificadorBombas<string>();
                    stringCollection[i] = cr.Slug;
                    catcher[i] = stringCollection[i];
                    Console.WriteLine(i+stringCollection[i]); 
                    i++;
                }
            }
            else
            {
                Console.WriteLine("Algo ha salido mal");
            }
        }

        private void RegBomba_Load(object sender, EventArgs e)
        {
            cmbEstacion.Enabled = false;
        }

        private void cmbIdPlanta_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbEstacion.SelectedIndex >= 0)
            {
                int num = cmbEstacion.SelectedIndex;
                labelId.Text = catcher[num];
               // var stringCollection = new IdentificadorBombas<string>();
                MessageBox.Show(catcher[num]);
                mainPanel.Enabled = true;
                //MessageBox.Show(cmbIdPlanta.Text);
            }
        }
        private void Validar()
        {

        }
    }
}
