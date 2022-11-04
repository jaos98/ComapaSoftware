using ComapaSoftware.Modelo;
using System;
using System.Windows.Forms;
using ComapaSoftware.Controlador;

namespace ComapaSoftware.Vistas
{
    public partial class RegInfoTec : Form
    {
        ModeloFichaTecnica model = new ModeloFichaTecnica();
        ControladorInfo c = new ControladorInfo();
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
            DataView();
            if (Validate())
            {
                MessageBox.Show("Todos los datos son correctos");
                if (model.registrarInfo(c.IdPlantas, c.CapEquipos, c.OperacionMinima,
                    c.EquiposInstalados, c.Tipo, c.GarantOperacion, c.GastoPromedio,
                    c.GastoInstalado, c.Servicio, c.Observaciones) > 0)
                {
                    MessageBox.Show("Informacion registrada");
                    Clean();
                }
                else
                {
                    MessageBox.Show("Hubo un error");
                }
            }
            else
            {
                MessageBox.Show("Llene todos los campos");
            }
        }
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCategoria.SelectedIndex < 0)
            {
                MessageBox.Show("Hubo un error, consulte con el administrador");
            }
            else if (cmbCategoria.SelectedIndex >= 0)
            {
                cmbId.Enabled = true;
                cmbId.Items.Clear();
                string catString = cmbCategoria.Text;
                MessageBox.Show(catString);
                foreach (var item in model.obtenerId(catString))
                {
                    cmbId.Refresh();
                    cmbId.Items.Add(item);
                }
            }
        }
        private void cmbId_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbId.SelectedIndex < 0)
            {
                Console.WriteLine("No hay resultado");
            }
            else
            {
                Console.WriteLine(cmbId.SelectedIndex.ToString());
                panel1.Visible = true;
                btnVolver2.Visible = false;
            }
        }
        new bool Validate()
        {
            if (c.IdPlantas == ""|| c.CapEquipos =="" ||c.OperacionMinima==""||
                c.EquiposInstalados==""||c.Tipo==""||c.GarantOperacion==""||
                c.GastoPromedio==""||c.GastoInstalado==""||c.Servicio==""||
                c.Observaciones=="")
            {
                return false;
            }
            return true;
        }
        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
            FormPanel formPanel = new FormPanel();
            formPanel.Show();
        }
        private void btnVolver2_Click(object sender, EventArgs e)
        {
            this.Close();
            FormPanel formPanel = new FormPanel();
            formPanel.Show();
        }

        private void Clean()
        {
            cmbId.Text = "";
            txtCap.Clear();
            txtOpmin.Clear();
            txtEquinst.Clear();
            cmbTipo.Text="";
            txtGarant.Clear();
            txtProm.Clear();
            txtInst.Clear();
            cmbServicio.Text="";
            txtObservacion.Clear();

        }
        private void DataView()
        {
            c.IdPlantas = cmbId.Text;
            c.CapEquipos = txtCap.Text;
            c.OperacionMinima = txtOpmin.Text;
            c.EquiposInstalados = txtEquinst.Text;
            c.Tipo = cmbTipo.Text;
            c.GarantOperacion = txtGarant.Text;
            c.GastoPromedio = txtProm.Text;
            c.GastoInstalado = txtInst.Text;
            c.Servicio = cmbServicio.Text;
            c.Observaciones = txtObservacion.Text;
        }
    }
}
