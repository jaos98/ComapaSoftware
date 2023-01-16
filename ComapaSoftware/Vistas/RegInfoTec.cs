using ComapaSoftware.Modelo;
using System;
using System.Windows.Forms;
using ComapaSoftware.Controlador;
using System.Text.RegularExpressions;
using ComapaSoftware.Http;

namespace ComapaSoftware.Vistas
{
    public partial class RegInfoTec : Form
    {
        ControladorFicha c = new ControladorFicha();
        ModeloInfo m = new ModeloInfo();
        ModelsPlantas mp = new ModelsPlantas();
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
            


        //DataView();
        //if (Validate())
        //{
        //    MessageBox.Show("Todos los datos son correctos");
        //    if (c.registrarInfo(m.IdPlantas, m.IdEstacion, m.Nombre, m.CapEquipos, m.OperacionMinima,
        //        m.EquiposInstalados, m.Tipo, m.GarantOperacion, m.GastoPromedio,
        //        m.GastoInstalado, m.Servicio, m.Observaciones) > 0)
        //    {
        //        MessageBox.Show("Informacion registrada");
        //        Clean();
        //    }
        //    else
        //    {
        //        MessageBox.Show("Hubo un error");
        //    }
        //}
        //else
        //{
        //    MessageBox.Show("Llene todos los campos");
        //}
    }
        private void cmbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cmbCategoria.SelectedIndex >= 0)
            {
                cmbId.Enabled = true;
                cmbId.Items.Clear();
                string catString = cmbCategoria.Text;
                MessageBox.Show(catString);
                foreach (ModelsPlantas item in es.getDatosHttpByTipo(catString))
                {
                    cmbId.Items.Add(item.IdPlantas);
                }
            }



            //if (cmbCategoria.SelectedIndex < 0)
            //{
            //    MessageBox.Show("Hubo un error, consulte con el administrador");
            //}
            //else if (cmbCategoria.SelectedIndex >= 0)
            //{
            //    cmbId.Enabled = true;
            //    cmbId.Items.Clear();
            //    string catString = cmbCategoria.Text;
            //    MessageBox.Show(catString);
            //    foreach (var item in c.obtenerId(catString))
            //    {
            //        cmbId.Refresh();
            //        cmbId.Items.Add(item);
            //    }
            //}
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
            if (m.IdPlantas == ""||m.IdEstacion =="" || m.Nombre ==""|| m.CapEquipos =="" ||m.OperacionMinima==""||
                m.EquiposInstalados==""||m.Tipo==""||m.GarantOperacion==""||
                m.GastoPromedio==""||m.GastoInstalado==""||m.Servicio==""||
                m.Observaciones=="")
            {
                return false;
            }
            return true;
        }
        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
            ControlPanel formPanel = new ControlPanel();
            formPanel.Show();
        }
        private void btnVolver2_Click(object sender, EventArgs e)
        {
            this.Close();
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
        private void GetInfo()
        {
            m.IdPlantas = cmbId.Text;
            m.IdEstacion = labelIdFicha.Text;
            m.Nombre = txtNombre.Text;
            m.CapEquipos = txtCap.Text;
            m.OperacionMinima = txtOpmin.Text;
            m.EquiposInstalados = txtEquinst.Text;
            m.Tipo = cmbTipo.Text;
            m.GarantOperacion = txtGarant.Text;
            m.GastoPromedio = txtProm.Text;
            m.GastoInstalado = txtInst.Text;
            m.Servicio = cmbServicio.Text;
            m.Observaciones = txtObservacion.Text;
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
        private void txtIdFicha_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
