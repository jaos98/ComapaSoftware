using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComapaSoftware.Modelo;
using ComapaSoftware.Controlador;
namespace ComapaSoftware.Vistas
{
    public partial class ActPlanta : Form
    {
        ModeloPlantas m = new ModeloPlantas();
        ControladorPlantas c = new ControladorPlantas();
        private string globalReceiver;
        public string GlobalReceiver{
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
            cmbColonia.Enabled = false;
            foreach (var item in m.consultarSector())
            {
                cmbSector.Items.Add(item);
            }
            foreach  (ControladorPlantas list in m.GetUpdateInfo(GlobalReceiver))
            {
                txtId.Text = list.IdPlanta;
                txtNm.Text = list.NumMedidor;
                txtSer.Text = list.NumServicio;
                cmbTipo.Text = list.TipoPlantas;
                cmbEstatus.Text = list.Estatus;
                txtDesc.Text = list.DescFunciones;
                txtKva.Text = list.SubestacionKva;
                cmbSector.Text = list.Sector;
                cmbColonia.Text = list.Colonia;
                cmbSector.Text = list.Sector;
                txtLat.Text = list.Latitud;
                txtLong.Text = list.Longitud;
                txtEle.Text = list.Elevacion;
                cmbServicio.Text = list.Servicio;
                txtDom.Text = list.Domicilio;
            }
            }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            GetData();
            if (m.UpdateInfo(c.IdPlanta, c.NumMedidor, c.NumServicio, c.TipoPlantas, c.Estatus,
                 c.DescFunciones, c.SubestacionKva, c.Colonia, c.Sector, c.Latitud,
                 c.Longitud, c.Elevacion, c.Servicio, c.Domicilio)>0)
            {
                MessageBox.Show("Actualizado con exito!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Algo salio mal, por favor revise la informacion");
            }
            
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void GetData()
        {
            c.IdPlanta = txtId.Text;
            c.NumMedidor = txtNm.Text;
            c.NumServicio = txtSer.Text;
            c.TipoPlantas = cmbTipo.Text;
            c.Estatus = cmbEstatus.Text;
            c.DescFunciones = txtDesc.Text;
            c.SubestacionKva = txtKva.Text;
            c.Colonia = cmbColonia.Text;
            c.Sector = cmbSector.Text;
            c.Latitud = txtLat.Text;
            c.Longitud = txtLong.Text;
            c.Elevacion = txtEle.Text;
            c.Servicio = cmbServicio.Text;
            c.Domicilio = txtDom.Text;
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
                string resultId = m.obtenerID(cmbSector.Text);
                cmbColonia.Enabled = true;
                foreach (var item in m.compararDatos(resultId))
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
