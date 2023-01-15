using ComapaSoftware.Controlador;
using ComapaSoftware.Http;
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
        ModelsEstaciones me = new ModelsEstaciones();
        Estaciones es = new Estaciones();

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
            if (es.getDatosHttp(GlobalReceiver))
            {
                lblPlanta.Text = es.me.IdPlantas;
                lblEstacion.Text = es.me.IdEstacion;
                txtNombre.Text = es.me.Nombre;
                txtCapEq.Text = es.me.CapacidadEquipos;
                txtOp.Text = es.me.OperacionMinima;
                txtEquInst.Text = es.me.EquiposInstalados;
                cmbTipo.Text = es.me.Tipo;
                txtGarant.Text = es.me.GarantOperacion;
                txtProm.Text = es.me.GastoPromedio;
                txtInst.Text = es.me.GastoInstalado;
                cmbServ.Text = es.me.Servicio;
                txtObs.Text = es.me.Observaciones;
            }
            

            ////FUNCIONA EN LOCAL
            //foreach (ModeloInfo list in c.GetUpdateInfo(GlobalReceiver))
            //{
            //    lblPlanta.Text = list.IdPlantas;
            //    lblEstacion.Text = list.IdEstacion;
            //    txtNombre.Text = list.Nombre;
            //    txtCapEq.Text = list.CapEquipos;
            //    txtOp.Text = list.OperacionMinima;
            //    txtEquInst.Text = list.EquiposInstalados;
            //    cmbTipo.Text = list.Tipo;
            //    txtGarant.Text = list.GarantOperacion;
            //    txtProm.Text = list.GastoPromedio;
            //    txtInst.Text = list.GastoInstalado;
            //    cmbServ.Text = list.Servicio;
            //    txtObs.Text = list.Observaciones;
            //}
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            GetInfo();
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
        void GetInfo()
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
        public void GetInfoHttp()
        {
            me.IdPlantas = lblPlanta.Text;
            me.IdEstacion = lblEstacion.Text;
            me.Nombre = txtNombre.Text;
            me.CapacidadEquipos = txtCapEq.Text;
            me.OperacionMinima = txtOp.Text;
            me.EquiposInstalados = txtEquInst.Text;
            me.Tipo = cmbTipo.Text;
            me.GarantOperacion = txtGarant.Text;
            me.GastoPromedio = txtProm.Text;
            me.GastoInstalado = txtInst.Text;
            me.Servicio = cmbServ.Text;
            me.Observaciones = txtObs.Text;
        }
    }
}
