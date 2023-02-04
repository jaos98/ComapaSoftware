using ComapaSoftware.Controlador;
using ComapaSoftware.Http;
using ComapaSoftware.Modelo;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ComapaSoftware.Vistas
{
    public partial class FormPlanta : Form
    {
        ModelsPlantas mp = new ModelsPlantas();
        Colonia col = new Colonia();
        Sector s = new Sector();
        List<ModelsSector> catcher = new List<ModelsSector>();
        Plantas p = new Plantas();
        public string IdSector;
        public FormPlanta()
        {
            InitializeComponent();
        }
        //CARGA DE ELEMENTOS AL ABRIR FORM
        private void FormPlanta_Load(object sender, EventArgs e)
        {
            cmbColonia.Enabled = false;

            foreach (ModelsSector item in s.getDatosHttpByTipo())
            {
                catcher.Add(item);
                cmbSector.Items.Add(item.NombreSector);

            }
        }
        //BOTON DE REGISTRO
        private void btnRegHttp_Click(object sender, EventArgs e)
        {
            GetInfoHttp();
            if (Validate())
            {
                if (p.DoesNotExists(mp.IdPlantas))
                {
                    if (p.insertarPlantaHttp(mp.IdPlantas, mp.NumMedidor, mp.NumServicio,
                   mp.TipoPlantas, mp.Estatus, mp.DescFunciones, mp.SubestacionKva, mp.Colonia, mp.Sector,
                   mp.Latitud, mp.Longitud, mp.Elevacion, mp.Servicio, mp.Domicilio) > 0)
                    {
                        MessageBox.Show("Registrado Exitosamente");
                        Clean();
                    }
                    else
                    {
                        MessageBox.Show("Algo salio mal");
                    }
                }
                else
                {
                    MessageBox.Show("El Id que esta ingresando ya se encuentra en uso");
                }
            }
            else
            {
                MessageBox.Show("No se han introducido todos los datos");
            }
            
        }
        //CARGA LOS DATOS AL COMBOBOX DESDE LA BASE DE DATOS
        private void cmbSector_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbColonia.Items.Clear();
            int value = cmbSector.SelectedIndex;
            if (cmbSector.SelectedIndex >= 0)
            {
                cmbColonia.Items.Clear();
                cmbColonia.Enabled = true;
                foreach (ModelsSector sector in catcher)
                {
                    if (sector.NombreSector == cmbSector.Text)
                    {
                        IdSector = sector.IdSector;
                        Console.WriteLine(IdSector);
                        break;
                    }
                }
                foreach (ModelsColonia mcl in col.getDatosHttpBySector(IdSector))
                {
                    cmbColonia.Items.Add(mcl.NombreColonia);
                }

            }
            else
            {
                MessageBox.Show("Ha ocurrido un error");
            }
        }
        private void btnVolver_Click(object sender, EventArgs e)
        {
            Dispose();
            ControlPanel formPanel = new ControlPanel();
            formPanel.Show();
        }
       
        private void txtNumServ_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
               (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
        private void txtLatitud_Click(object sender, EventArgs e)
        {
            txtLatitud.Select(0, 0);
        }

        private void txtLongitud_Click(object sender, EventArgs e)
        {
            txtLongitud.Select(0, 0);
        }
        public void GetInfoHttp()
        {

            mp.IdPlantas = txtPlanta.Text.Trim();
            mp.NumMedidor = txtNumMed.Text.Trim();
            mp.NumServicio = txtNumServ.Text.Trim();
            mp.TipoPlantas = cmbTipoPlanta.Text;
            mp.Estatus = cmbEstatus.Text;
            mp.DescFunciones = txtDescFunciones.Text;
            mp.SubestacionKva = txtKva.Text;
            mp.Colonia = cmbColonia.Text;
            mp.Sector = cmbSector.Text;
            mp.Latitud = txtLatitud.Text;
            mp.Longitud = txtLongitud.Text;
            mp.Elevacion = txtElevacion.Text;
            mp.Servicio = cmbServicio.Text;
            mp.Domicilio = txtDomicilio.Text;
        }
        private bool Validate()
        {
            if (mp.IdPlantas == "" || mp.NumMedidor == "" || mp.NumServicio == "" ||
                mp.TipoPlantas == "" || mp.Estatus == "" || mp.DescFunciones == "" ||
                mp.SubestacionKva == "" || mp.Colonia == "" || mp.Sector == "" || mp.Latitud == "" || mp.Longitud == "" ||
                mp.Elevacion == "" || mp.Servicio == "" || mp.Domicilio == "")
            {
                return false;
            }
            return true;
        }
        void Clean()
        {
            txtPlanta.Clear();
            txtNumMed.Clear();
            txtNumServ.Clear();
            cmbTipoPlanta.Text = "";
            cmbEstatus.Text = "";
            txtDescFunciones.Clear();
            txtKva.Clear();
            cmbColonia.Text = "";
            cmbSector.Text = "";
            txtLatitud.Clear();
            txtLongitud.Clear();
            txtElevacion.Clear();
            txtNumServ.Clear();
            txtDomicilio.Clear();
        }
        private void cmbColonia_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
      

        private void FormPlanta_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
