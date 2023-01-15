using ComapaSoftware.Controlador;
using ComapaSoftware.Http;
using ComapaSoftware.Modelo;
using System;
using System.Windows.Forms;
namespace ComapaSoftware.Vistas
{
    public partial class ActPlanta : Form
    {
        ControladorPlantas c = new ControladorPlantas();
        ModeloPlantas m = new ModeloPlantas();
        Plantas p = new Plantas();
        ModelsPlantas mp = new ModelsPlantas();
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

            //cmbColonia.Enabled = false;
            //foreach (var item in c.consultarSector())
            //{
            //    cmbSector.Items.Add(item);
            //}
            //foreach (ModeloPlantas list in c.GetUpdateInfo(GlobalReceiver))
            //{
            //    txtId.Text = list.IdPlanta;
            //    txtNm.Text = list.NumMedidor;
            //    txtSer.Text = list.NumServicio;
            //    cmbTipo.Text = list.TipoPlantas;
            //    cmbEstatus.Text = list.Estatus;
            //    txtDesc.Text = list.DescFunciones;
            //    txtKva.Text = list.SubestacionKva;
            //    cmbSector.Text = list.Sector;
            //    cmbColonia.Text = list.Colonia;
            //    cmbSector.Text = list.Sector;
            //    txtLat.Text = list.Latitud;
            //    txtLong.Text = list.Longitud;
            //    txtEle.Text = list.Elevacion;
            //    cmbServicio.Text = list.Servicio;
            //    txtDom.Text = list.Domicilio;
            //}
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            GetInfoHttp();
            if (p.actualizarPlantaHttp(mp.IdPlantas, mp.NumMedidor, mp.NumServicio, mp.TipoPlantas, mp.Estatus,
                 mp.DescFunciones, mp.SubestacionKva, mp.Colonia, mp.Sector, mp.Latitud,
                 mp.Longitud, mp.Elevacion, mp.Servicio, mp.Domicilio))
            {
                MessageBox.Show("Actualizado con exito!");
                Close();
            }
            else
            {
                MessageBox.Show("Ha ocurrido un error, vuelva a intentarlo revise su conexion a internet");
                Close();
            }

            

            //FUNCIONA EN LOCAL
            //GetInfo();
            //if (c.UpdateInfo(m.IdPlanta, m.NumMedidor, m.NumServicio, m.TipoPlantas, m.Estatus,
            //     m.DescFunciones, m.SubestacionKva, m.Colonia, m.Sector, m.Latitud,
            //     m.Longitud, m.Elevacion, m.Servicio, m.Domicilio) > 0)
            //{
            //    MessageBox.Show("Actualizado con exito!");
            //    this.Close();
            //}
            //else
            //{
            //    MessageBox.Show("Algo salio mal, por favor revise la informacion");
            //}

        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void GetInfo()
        {
            m.IdPlanta = txtId.Text;
            m.NumMedidor = txtNm.Text;
            m.NumServicio = txtSer.Text;
            m.TipoPlantas = cmbTipo.Text;
            m.Estatus = cmbEstatus.Text;
            m.DescFunciones = txtDesc.Text;
            m.SubestacionKva = txtKva.Text;
            m.Colonia = cmbColonia.Text;
            m.Sector = cmbSector.Text;
            m.Latitud = txtLat.Text;
            m.Longitud = txtLong.Text;
            m.Elevacion = txtEle.Text;
            m.Servicio = cmbServicio.Text;
            m.Domicilio = txtDom.Text;
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
            if (cmbSector.SelectedIndex < 0)
            {
                cmbColonia.Items.Clear();
            }
            else if (cmbSector.SelectedIndex >= 0)
            {
                cmbColonia.Items.Clear();
                cmbColonia.Enabled = true;
                string resultId = c.obtenerID(cmbSector.Text);
                cmbColonia.Enabled = true;
                foreach (var item in c.compararDatos(resultId))
                {
                    cmbColonia.Items.Add(item);
                }
            }
        }

        //private void btnPrueba_Click(object sender, EventArgs e)
        //{
        //    GetData();
        //    Console.WriteLine(c.IdPlanta);
        //    Console.WriteLine(c.NumMedidor);
        //    Console.WriteLine(c.NumServicio);
        //    Console.WriteLine(c.TipoPlantas);
        //    Console.WriteLine(c.Estatus);
        //    Console.WriteLine(c.DescFunciones);
        //    Console.WriteLine(c.SubestacionKva);
        //    Console.WriteLine(c.Sector);
        //    Console.WriteLine(c.Colonia);
        //    Console.WriteLine(c.Latitud);
        //    Console.WriteLine(c.Longitud);
        //    Console.WriteLine(c.Elevacion);
        //    Console.WriteLine(c.Servicio);
        //    Console.WriteLine(c.Domicilio);
        //}
    }
}
