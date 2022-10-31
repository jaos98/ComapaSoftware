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
        ControladorBombas controlador = new ControladorBombas();
        ModeloBombas modeloBombas = new ModeloBombas();
        string[] catcher = new string[99];
        public RegBomba()
        {
            InitializeComponent();
        }
        private int validarDatos()
        {
            int result;
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


            if (pos == "" || marca == "" || modelo == "" || tipo == "" || hp == "" ||
                voltaje == "" || diametro == "" || lps == "" || carga == "" || rpm == "" ||
                estatus == "" || fpm == "" || observaciones =="")
            {
                MessageBox.Show("Porfavor ingrese todos los datos");
                result = 0;

            }
            else
            {
                result = 1;
            }
            return result;
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

            switch (validarDatos())
            {
                case 0:
                    MessageBox.Show("Llene todos los campos");
                    break;

                case 1:
                    MessageBox.Show("Todos los datos son correctos");
                    if (modeloBombas.registrarInfoBomba(idplanta,pos,marca,modelo,tipo,hp,voltaje,diametro,lps,carga,rpm,estatus,fpm,observaciones) > 0)
                    {
                        MessageBox.Show("Informacion registrada");
                    }
                    else
                    {
                        MessageBox.Show("Hubo un error");
                    }
                    break;
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {   
            int i=0;
            if (cmbCategoria.SelectedIndex >= 0)
            {
                cmbIdPlanta.Enabled = true;
                cmbIdPlanta.Items.Clear();
                foreach (CriterioRegistroBomba cr in modeloBombas.obtenerIdFicha3(cmbCategoria.Text))
                {
                    int u = 0;
                    cmbIdPlanta.Items.Add(cr.IdPlantas +" - "+ cr.Slug +" - "+ cr.Servicio);
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
            cmbIdPlanta.Enabled = false;
        }

        private void cmbIdPlanta_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbIdPlanta.SelectedIndex >= 0)
            {
                int num = cmbIdPlanta.SelectedIndex;
                labelId.Text = catcher[num];
               // var stringCollection = new IdentificadorBombas<string>();
                MessageBox.Show(catcher[num]);
                mainPanel.Enabled = true;
                //MessageBox.Show(cmbIdPlanta.Text);
            }
        }
    }
}
