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
        string[] catcher = new string[99];
        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            foreach  (var item in modeloBombas.ObtenerIdPlantas(cmbCategoria.Text))
            {
                cmbPlanta.Items.Add(item);
            }
            cmbPlanta.Enabled = true;
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (var item in modeloBombas.ObtenerIdEstacion(cmbPlanta.Text))
            {
                cmbEstacion.Items.Add(item);
            }
            cmbEstacion.Enabled = true;
        }
        private void cmbIdPlanta_SelectedIndexChanged(object sender, EventArgs e)
        { 
            if (cmbEstacion.SelectedIndex >= 0)
            {
                int num = cmbEstacion.SelectedIndex;
                mainPanel.Enabled = true;
                //AQUI SIGO, AQUI ME QUEDE
                int helper = modeloBombas.ValidarPosicion(cmbEstacion.Text);
                Console.WriteLine(helper);
                int catcher = 0;
                for (int i = 1; i <= 10; i++)
                {
                    Console.WriteLine("Iteracion "+i);
                    if (modeloBombas.ConsultarPosicion(cmbEstacion.Text,i))
                    {
                        catcher = i; 
                        Console.WriteLine("Linea 1 " + catcher);
                        cmbPosicion.Text = catcher.ToString();
                    }
                    else
                    {
                        catcher = i;
                            Console.WriteLine("Linea 2 " + catcher);
                        cmbPosicion.Text = catcher.ToString();
                        break;
                    }
                }
                
            }

        }

        //AQUI ME QUEDE
        public RegBomba()
        {
            InitializeComponent();
        }
        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
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



        private void RegBomba_Load(object sender, EventArgs e)
        {
            cmbEstacion.Enabled = false;

        }


        private void Validar()
        {
            c.IdBombas = cmbPlanta.Text;
            c.IdEstacion = cmbEstacion.Text;
            c.Posicion = cmbPosicion.Text;
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

        private void comboBox1_SelectedIndexChanged_2(object sender, EventArgs e)
        {

        }
    }
//    int i = 0;
//            if (cmbPlanta.SelectedIndex >= 0)
//            {
//                cmbEstacion.Enabled = true;
//                cmbEstacion.Items.Clear();
//                foreach (CriterioRegistroBomba cr in modeloBombas.obtenerIdFicha3(cmbPlanta.Text))
//                {
//                    int u = 0;
//    cmbEstacion.Items.Add(cr.IdPlantas +" - "+ cr.Slug +" - "+ cr.Servicio);
//                    var stringCollection = new IdentificadorBombas<string>();
//    stringCollection[i] = cr.Slug;
//                    catcher[i] = stringCollection[i];
//                    Console.WriteLine(i+stringCollection[i]); 
//                    i++;
//                }
//            }
//            else
//{
//    Console.WriteLine("Algo ha salido mal");
//}

}
