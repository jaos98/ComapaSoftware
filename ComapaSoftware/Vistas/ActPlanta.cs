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
            foreach  (ControladorPlantas list in m.UpdateInfo(GlobalReceiver))
            {
                txtId.Text = list.IdPlanta;
                txtNm.Text = list.NumMedidor;
                txtSer.Text = list.NumServicio;
                txtTp.Text = list.TipoPlantas;
                txtEst.Text = list.Estatus;
                txtDesc.Text = list.DescFunciones;
                txtKva.Text = list.SubestacionKva;
                txtSec.Text = list.Sector;
                txtCol.Text = list.Colonia;
                txtSec.Text = list.Sector;
                txtLat.Text = list.Latitud;
                txtLong.Text = list.Longitud;
                txtEle.Text = list.Elevacion;
                txtServicio.Text = list.Servicio;
                txtDom.Text = list.Domicilio;
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {

        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
