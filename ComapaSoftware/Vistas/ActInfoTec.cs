using ComapaSoftware.Controlador;
using ComapaSoftware.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComapaSoftware.Vistas
{
    public partial class ActInfoTec : Form
    {
        ModeloFichaTecnica m = new ModeloFichaTecnica();
        ControladorInfo c = new ControladorInfo();

        private string globalReceiver;
        public string GlobalReceiver
        {
            get { return globalReceiver; }
            set { globalReceiver = value; }
        }
        public ActInfoTec(string receiver)
        {
            GlobalReceiver = receiver;
            InitializeComponent();
        }
        public ActInfoTec()
        {
            InitializeComponent();
        }

        private void ActInfoTec_Load(object sender, EventArgs e)
        {
            foreach (ControladorInfo list in m.GetUpdateInfo(GlobalReceiver))
            {
                lblPlanta.Text = list.IdPlantas;
                lblEstacion.Text = list.IdEstacion;
                txtNombre.Text = list.Nombre;
                txtCapEq.Text = list.CapEquipos;
                txtOp.Text = list.OperacionMinima;
                txtEquInst.Text = list.EquiposInstalados;
                cmbTipo.Text = list.Tipo;
                txtGarant.Text = list.GarantOperacion;
                txtProm.Text = list.GastoPromedio;
                txtInst.Text = list.GastoInstalado;
                cmbServ.Text = list.Servicio;
                txtObs.Text = list.Observaciones;
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            GetData();
            if (m.UpdateInfo(c.IdEstacion,c.Nombre,c.CapEquipos,c.OperacionMinima,
                c.EquiposInstalados,c.Tipo,c.GarantOperacion,c.GastoPromedio,c.GastoInstalado,
                c.Servicio,c.Observaciones)>0)
            {
                MessageBox.Show("La informacion se ha registrado con exito");
                Close();
            }
            else
            {
                MessageBox.Show("Ha ocurrido un error, reinicie la aplicacion");
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Close();
        }
        void GetData()
        {
            c.IdPlantas = lblPlanta.Text;
            c.IdEstacion = lblEstacion.Text;
            c.Nombre = txtNombre.Text;
            c.CapEquipos = txtCapEq.Text;
            c.OperacionMinima = txtOp.Text;
            c.EquiposInstalados = txtEquInst.Text;
            c.Tipo = cmbTipo.Text;
            c.GarantOperacion = txtGarant.Text;
            c.GastoPromedio = txtProm.Text;
            c.GastoInstalado = txtInst.Text;
            c.Servicio = cmbServ.Text;
            c.Observaciones = txtObs.Text;
        }
    }
}
