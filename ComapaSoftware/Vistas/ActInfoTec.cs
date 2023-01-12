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
        ControladorFicha c = new ControladorFicha();
        ModeloInfo m = new ModeloInfo();

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
            foreach (ModeloInfo list in c.GetUpdateInfo(GlobalReceiver))
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
            if (c.UpdateInfo(m.IdEstacion,m.Nombre,m.CapEquipos,m.OperacionMinima,
                m.EquiposInstalados,m.Tipo,m.GarantOperacion,m.GastoPromedio,m.GastoInstalado,
                m.Servicio,m.Observaciones)>0)
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
            m.IdPlantas = lblPlanta.Text;
            m.IdEstacion = lblEstacion.Text;
            m.Nombre = txtNombre.Text;
            m.CapEquipos = txtCapEq.Text;
            m.OperacionMinima = txtOp.Text;
            m.EquiposInstalados = txtEquInst.Text;
            m.Tipo = cmbTipo.Text;
            m.GarantOperacion = txtGarant.Text;
            m.GastoPromedio = txtProm.Text;
            m.GastoInstalado = txtInst.Text;
            m.Servicio = cmbServ.Text;
            m.Observaciones = txtObs.Text;
        }
    }
}
