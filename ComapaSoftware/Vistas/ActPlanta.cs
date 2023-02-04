using ComapaSoftware.Controlador;
using ComapaSoftware.Http;
using ComapaSoftware.Modelo;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
namespace ComapaSoftware.Vistas
{
    public partial class ActPlanta : Form
    {
       /// ControladorPlantas c = new ControladorPlantas();
        ModeloPlantas m = new ModeloPlantas();
        Plantas p = new Plantas();
        Sector s = new Sector();
        Colonia col = new Colonia();
        ModelsPlantas mp = new ModelsPlantas();
        List<ModelsSector> catcher = new List<ModelsSector>();
        public string IdSector;
        private string globalReceiver;
        public string GlobalReceiver
        {
            get { return globalReceiver; }
            set { globalReceiver = value; }
        }
        public ActPlanta(string globalReceiver)
        {
            this.globalReceiver = globalReceiver;
            InitializeComponent();
            foreach (ModelsSector item in s.getDatosHttpByTipo())
            {
                catcher.Add(item);
                cmbSector.Items.Add(item.NombreSector);

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (p.getDatosHttp(globalReceiver))
            {
                txtId.Text = p.mp.IdPlantas;
                txtNm.Text = p.mp.NumMedidor;
                txtSer.Text = p.mp.NumServicio;
                cmbTipo.Text = p.mp.TipoPlantas;
                cmbEstatus.Text = p.mp.Estatus;
                txtDesc.Text = p.mp.DescFunciones;
                txtKva.Text = p.mp.SubestacionKva;
                cmbSector.Text = p.mp.Sector;
                cmbColonia.Text = p.mp.Colonia;
                cmbSector.Text = p.mp.Sector;
                txtLat.Text = p.mp.Latitud;
                txtLong.Text = p.mp.Longitud;
                txtEle.Text = p.mp.Elevacion;
                cmbServicio.Text = p.mp.Servicio;
                txtDom.Text = p.mp.Domicilio;
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            GetInfoHttp();
            if (p.actualizarPlantaHttp(mp.IdPlantas, mp.NumMedidor, mp.NumServicio, mp.TipoPlantas, mp.Estatus,
                 mp.DescFunciones, mp.SubestacionKva, mp.Colonia, mp.Sector, mp.Latitud,
                 mp.Longitud, mp.Elevacion, mp.Servicio, mp.Domicilio))
            {
                MessageBox.Show("Actualizado con exito!");
                Dispose();
            }
            else
            {
                MessageBox.Show("Ha ocurrido un error, vuelva a intentarlo revise su conexion a internet");
                Dispose();
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Dispose();
        }
        private void GetInfoHttp()
        {
            mp.ID = globalReceiver;
            mp.IdPlantas = txtId.Text;
            mp.NumMedidor = txtNm.Text;
            mp.NumServicio = txtSer.Text;
            mp.TipoPlantas = cmbTipo.Text;
            mp.Estatus = cmbEstatus.Text;
            mp.DescFunciones = txtDesc.Text;
            mp.SubestacionKva = txtKva.Text;
            mp.Colonia = cmbColonia.Text;
            mp.Sector = cmbSector.Text;
            mp.Latitud = txtLat.Text;
            mp.Longitud = txtLong.Text;
            mp.Elevacion = txtEle.Text;
            mp.Servicio = cmbServicio.Text;
            mp.Domicilio = txtDom.Text;
        }
        private void cmbSector_SelectedIndexChanged(object sender, EventArgs e)
        {
            int value = cmbSector.SelectedIndex;
            if (cmbSector.SelectedIndex >= 0)
            {
                cmbColonia.Items.Clear();
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
        }
    }

}
