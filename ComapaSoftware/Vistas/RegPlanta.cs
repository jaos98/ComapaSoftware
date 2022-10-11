using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComapaSoftware.Controlador;
using ComapaSoftware.Modelo;

namespace ComapaSoftware.Vistas
{
    public partial class FormPlanta : Form
    {

        Conexion conn = new Conexion();
        ControladorInfo controlador = new ControladorInfo();
        ModeloPlantas modelo = new ModeloPlantas();
        public FormPlanta()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            FormPanel formPanel = new FormPanel();
            formPanel.Show();
        }
        //Informacion a llenar con boton
        private void button1_Click(object sender, EventArgs e)
        {
            getInfo();
            string idPlanta, numMedidor,numServicio, tipoPlantas, estatus, descFunciones, colonia, sector, latitud
                , longitud, elevacion, servicio, domicilio;
            idPlanta = controlador.IdPlanta;
            numMedidor = controlador.NumMedidor;
            numServicio = controlador.NumServicio;
            tipoPlantas = controlador.TipoPlantas;
            estatus = controlador.Estatus;
            descFunciones = controlador.DescFunciones;
            colonia = controlador.Colonia;
            sector = controlador.Sector;
            latitud = controlador.Latitud;
            elevacion = controlador.Elevacion;
            longitud = controlador.Longitud;
            servicio = controlador.Servicio;
            domicilio = controlador.Domicilio;

            MessageBox.Show(idPlanta+numMedidor+ numServicio+ tipoPlantas+ estatus+ descFunciones+ colonia+
                sector+ latitud+
                longitud+ elevacion+ servicio+ domicilio);

            if (modelo.insertarEquipo(idPlanta, numMedidor, numServicio, tipoPlantas, estatus, descFunciones, colonia, sector, latitud
                , longitud, elevacion, servicio, domicilio)>0)
            {
                MessageBox.Show("La informacion se ha registrado!");
            }
            else
            {
                MessageBox.Show("Algo ha salido mal");
            }
           // modelo.insertarEquipo(idPlanta, numMedidor, numServicio, tipoPlantas, estatus, descFunciones, colonia, sector, latitud
            //    ,longitud,elevacion,servicio,domicilio);
              //modelo.insertarPlanta(idPlanta,numMedidor,numServicio,tipoPlantas,estatus,descFunciones,colonia,sector,latitud
              //  ,longitud,elevacion,servicio,domicilio);


        }

        private void FormPlanta_Load(object sender, EventArgs e)
        {
            //cmbSector.Items.Add(modelo.consultarSector2(cmbSector));
                        
           cmbColonia.Enabled = false;
            foreach (var item in modelo.consultarSector())
            {
                cmbSector.Items.Add(item);

            }
            
        }

        private void cmbSector_SelectedIndexChanged(object sender, EventArgs e)
        {
            int value = cmbSector.SelectedIndex;
            if (cmbSector.SelectedIndex < 0)
            {
                cmbColonia.Items.Clear();
            }
            else if (cmbSector.SelectedIndex >= 0)
            {
                cmbColonia.Items.Clear();
                cmbColonia.Enabled = true;
                string resultId = modelo.obtenerID(cmbSector.Text);
                cmbColonia.Enabled = true;
                foreach (var item in modelo.compararDatos(resultId))
                {
                    cmbColonia.Items.Add(item);
                }
            }
        }

        private void cmbColonia_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        public void getInfo()
        {
            controlador.IdPlanta = txtPlanta.Text.Trim();
            controlador.NumMedidor = txtNumMed.Text.Trim();
            controlador.NumServicio = txtNumServ.Text.Trim();
            controlador.TipoPlantas = cmbTipoPlanta.Text;
            controlador.Estatus = cmbEstatus.Text;
            controlador.DescFunciones = txtDescFunciones.Text;
            controlador.Colonia = cmbColonia.Text;
            controlador.Sector = cmbSector.Text;
            controlador.Latitud = txtLatitud.Text;
            controlador.Longitud = txtLongitud.Text;
            controlador.Elevacion = txtElevacion.Text;
            controlador.Servicio = cmbServicio.Text;
            controlador.Domicilio = txtDomicilio.Text;
        }
    }
 
}
