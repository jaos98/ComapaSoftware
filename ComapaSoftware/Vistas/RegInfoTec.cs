using ComapaSoftware.Modelo;
using System;
using System.Windows.Forms;
using ComapaSoftware.Controlador;
using System.Text.RegularExpressions;

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
                if (model.registrarInfo(c.IdPlantas,c.IdEstacion,c.Nombre, c.CapEquipos, c.OperacionMinima,
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
        private void cmbCategoria_SelectedIndexChanged(object sender, EventArgs e)
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
            if (c.IdPlantas == ""||c.IdEstacion =="" || c.Nombre ==""|| c.CapEquipos =="" ||c.OperacionMinima==""||
                c.EquiposInstalados==""||c.Tipo==""||c.GarantOperacion==""||
                c.GastoPromedio==""||c.GastoInstalado==""||c.Servicio==""||
                c.Observaciones=="")
            {
                return false;
            }
            return true;
        }
        //private bool Validate2()
        //{
            
        //}
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
            txtNombre.Text = "";
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
            c.IdEstacion = labelIdFicha.Text;
            c.Nombre = txtNombre.Text;
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
        private void onAction()
        {
            
        }

        private void txtIdFicha_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
