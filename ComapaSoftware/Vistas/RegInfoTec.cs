using ComapaSoftware.Controlador;
using ComapaSoftware.Http;
using ComapaSoftware.Modelo;
using System;
using System.Windows.Forms;

namespace ComapaSoftware.Vistas
{
    public partial class RegInfoTec : Form
    {
        Estaciones es = new Estaciones();
        ModelsEstaciones ms = new ModelsEstaciones();
        public RegInfoTec()
        {
            InitializeComponent();
        }
        private void RegInfoTec_Load(object sender, EventArgs e)
        {
            cmbId.Enabled = false;
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (Validate())
            {
                GetInfoHttp();
                if (es.insertarInfoHttp(ms.IdPlantas, ms.IdEstacion, ms.Nombre, ms.CapacidadEquipos,
                    ms.OperacionMinima, ms.EquiposInstalados, ms.Tipo, ms.GarantOperacion, ms.GastoPromedio,
                    ms.GastoInstalado, ms.Servicio, ms.Observaciones))
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
                MessageBox.Show("Porfavor rellene todos los campos");
            }
        }
        private void cmbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cmbCategoria.SelectedIndex >= 0)
            {
                cmbId.Enabled = true;
                cmbId.Items.Clear();
                string catString = cmbCategoria.Text;
                foreach (ModelsPlantas item in es.getDatosHttpByTipo(catString))
                {
                    cmbId.Items.Add(item.IdPlantas);
                }
            }
        }
        private void cmbId_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbId.SelectedIndex >= 0)
            {
                Console.WriteLine(cmbId.SelectedIndex.ToString());
                panel1.Visible = true;
                btnVolver2.Visible = false;
                string saver = cmbId.Text;
                labelIdFicha.Text = "FT" + saver;
            }
            else
            {
                Console.WriteLine("No hay resultado");
                Console.WriteLine(cmbId.SelectedIndex.ToString());
            }
        }
        new bool Validate()
        {
            if (ms.IdPlantas == "" || ms.IdEstacion == "" || ms.Nombre == "" || ms.CapacidadEquipos == "" || ms.OperacionMinima == "" ||
                ms.EquiposInstalados == "" || ms.Tipo == "" || ms.GarantOperacion == "" ||
                ms.GastoPromedio == "" || ms.GastoInstalado == "" || ms.Servicio == "" ||
                ms.Observaciones == "")
            {
                return false;
            }
            return true;
        }
        private void btnVolver_Click(object sender, EventArgs e)
        {
            Dispose();
            ControlPanel formPanel = new ControlPanel();
            formPanel.Show();
        }
        private void btnVolver2_Click(object sender, EventArgs e)
        {
            Dispose();
            ControlPanel formPanel = new ControlPanel();
            formPanel.Show();
        }
        private void Clean()
        {
            cmbId.Text = "";
            txtNombre.Text = "";
            txtCap.Clear();
            txtOpmin.Clear();
            txtEquinst.Clear();
            cmbTipo.Text = "";
            txtGarant.Clear();
            txtProm.Clear();
            txtInst.Clear();
            cmbServicio.Text = "";
            txtObservacion.Clear();

        } 
        private void GetInfoHttp()
        {
            ms.IdPlantas = cmbId.Text;
            ms.IdEstacion = labelIdFicha.Text;
            ms.Nombre = txtNombre.Text;
            ms.CapacidadEquipos = txtCap.Text;
            ms.OperacionMinima = txtOpmin.Text;
            ms.EquiposInstalados = txtEquinst.Text;
            ms.Tipo = cmbTipo.Text;
            ms.GarantOperacion = txtGarant.Text;
            ms.GastoPromedio = txtProm.Text;
            ms.GastoInstalado = txtInst.Text;
            ms.Servicio = cmbServicio.Text;
            ms.Observaciones = txtObservacion.Text;
        }
        private void RegInfoTec_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
