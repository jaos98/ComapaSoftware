using ComapaSoftware.Controlador;
using ComapaSoftware.Http;
using ComapaSoftware.Modelo;
using System;
using System.Windows.Forms;

namespace ComapaSoftware.Vistas
{
    public partial class ActInfoTec : Form
    {
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
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            GetInfoHttp();
            if (es.Actualizar(me.IdEstacion, me.Nombre, me.CapacidadEquipos, me.OperacionMinima,
               me.EquiposInstalados, me.Tipo, me.GarantOperacion, me.GastoPromedio, me.GastoInstalado,
               me.Servicio, me.Observaciones))
            {

                MessageBox.Show("La informacion se ha registrado con exito");
                Dispose();
            }
            else
            {
                MessageBox.Show("Ha ocurrido un error, reinicie la aplicacion");
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Dispose();
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
