using ComapaSoftware.Controlador;
using ComapaSoftware.Http;
using ComapaSoftware.Modelo;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComapaSoftware.Vistas
{
    public partial class FormPlanta : Form
    {
        ModeloPlantas m = new ModeloPlantas();
        ControladorPlantas c = new ControladorPlantas();
        ModelsPlantas mp = new ModelsPlantas();
        Colonia col = new Colonia();
        Sector s = new Sector();
        List<ModelsSector> catcher = new List<ModelsSector>();
        //List<ModelsColonia> listcol = new List<ModelsColonia>();
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


            //foreach (var item in c.consultarSector())
            //{
            //    cmbSector.Items.Add(item);
            //}
        }
       
        //BOTON DE REGISTRO DE INFORMACION
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            GetInfo();
            if (Validate())
            {
                //VALIDAR ANTES DE INGRESAR LA INFO
                if (c.noRepite(m.IdPlanta))
                {
                    if (c.insertarPlanta(m.IdPlanta, m.NumMedidor, m.NumServicio,
               m.TipoPlantas, m.Estatus, m.DescFunciones,m.SubestacionKva, m.Colonia, m.Sector,
               m.Latitud, m.Longitud, m.Elevacion, m.Servicio, m.Domicilio) > 0)
                    {
                        MessageBox.Show("Se han registrado todos los datos");
                        Clean();
                    }
                    else
                    {
                        MessageBox.Show("Algo ha salido mal, revise la informacion" +
                            "o bien, contacte al administrador");
                    }
                }
                else
                {
                    MessageBox.Show("El id ingresado ya se utilizo, cambie o elimine el anterior");
                }
            }
            else
            {
                MessageBox.Show("Porfavor Ingrese todos los datos");
            }
        }
        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
            ControlPanel formPanel = new ControlPanel();
            formPanel.Show();
        }
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
                Console.WriteLine("Aqui llego");
                Console.WriteLine(IdSector);
                foreach (ModelsColonia mcl in col.getDatosHttpBySector(IdSector))
                {
                    cmbColonia.Items.Add(mcl.NombreColonia);
                }

            }
            else
            {
                MessageBox.Show("Ha ocurrido un error");
            }

            //int value = cmbSector.SelectedIndex;
            //if (cmbSector.SelectedIndex < 0)
            //{
            //    cmbColonia.Items.Clear();
            //}
            //else if (cmbSector.SelectedIndex >= 0)
            //{
            //    cmbColonia.Items.Clear();
            //    cmbColonia.Enabled = true;
                //string resultId = c.obtenerID(cmbSector.Text);
                //cmbColonia.Enabled = true;
                //foreach (var item in c.compararDatos(resultId))
                //{
                //    cmbColonia.Items.Add(item);
                //}
          //  }
            //int value = cmbSector.SelectedIndex;
            //if (cmbSector.SelectedIndex < 0)
            //{
            //    cmbColonia.Items.Clear();
            //}
            //else if (cmbSector.SelectedIndex >= 0)
            //{
            //    cmbColonia.Items.Clear();
            //    cmbColonia.Enabled = true;
            //    string resultId = c.obtenerID(cmbSector.Text);
            //    cmbColonia.Enabled = true;
            //    foreach (var item in c.compararDatos(resultId))
            //    {
            //        cmbColonia.Items.Add(item);
            //    }
            //}
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
        public void GetInfo()
        {
            m.IdPlanta = txtPlanta.Text.Trim();
            m.NumMedidor = txtNumMed.Text.Trim();
            m.NumServicio = txtNumServ.Text.Trim();
            m.TipoPlantas = cmbTipoPlanta.Text;
            m.Estatus = cmbEstatus.Text;
            m.DescFunciones = txtDescFunciones.Text;
            m.SubestacionKva = txtKva.Text;
            m.Colonia = cmbColonia.Text;
            m.Sector = cmbSector.Text;
            m.Latitud = txtLatitud.Text;
            m.Longitud = txtLongitud.Text;
            m.Elevacion = txtElevacion.Text;
            m.Servicio = cmbServicio.Text;
            m.Domicilio = txtDomicilio.Text;
        }
        private bool Validate()
        {
            if (m.IdPlanta == "" || m.NumMedidor == "" || m.NumServicio == "" ||
                m.TipoPlantas == "" || m.Estatus == "" || m.DescFunciones == "" ||
                m.SubestacionKva==""||m.Colonia == "" || m.Sector == "" || m.Latitud == "" || m.Longitud == "" ||
                m.Elevacion == "" || m.Servicio == "" || m.Domicilio == "")
            {
                return false;
            }
            return true;
        }
        private void Clean()
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


        public async Task ValidarIdPlantas()
        {

        }
        private void btnRegHttp_Click(object sender, EventArgs e)
        {
            GetInfoHttp();
            Plantas p = new Plantas();

            
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
    }
}
