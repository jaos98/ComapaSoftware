using ComapaSoftware.Controlador;
using ComapaSoftware.Modelo;
using System;
using System.Windows.Forms;

namespace ComapaSoftware.Vistas
{
    public partial class FormPlanta : Form
    {
        ControladorPlantas c = new ControladorPlantas();
        ModeloPlantas m = new ModeloPlantas();
        public FormPlanta()
        {
            InitializeComponent();
        }
        private void FormPlanta_Load(object sender, EventArgs e)
        {
            cmbColonia.Enabled = false;
            foreach (var item in m.consultarSector())
            {
                cmbSector.Items.Add(item);
            }
        }
       
        //Informacion a llenar con boton
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            getInfo();
            if (validate())
            {
                //VALIDAR ANTES DE INGRESAR LA INFO
                if (m.noRepite(c.IdPlanta))
                {
                    if (m.insertarPlanta(c.IdPlanta, c.NumMedidor, c.NumServicio,
               c.TipoPlantas, c.Estatus, c.DescFunciones, c.Colonia, c.Sector,
               c.Latitud, c.Longitud, c.Elevacion, c.Servicio, c.Domicilio) > 0)
                    {
                        MessageBox.Show("Se han registrado todos los datos");
                        clean();
                    }
                    else
                    {
                        MessageBox.Show("Algo ha salido mal, revise la informacion" +
                            "o bien, contacte al administrador");
                    }
                }
                else
                {
                    MessageBox.Show("El id ingresado ya se utilizo, cambie o elimine el anterior");
                }
            }
            else
            {
                MessageBox.Show("Porfavor Ingrese todos los datos");
            }
        }
        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
            FormPanel formPanel = new FormPanel();
            formPanel.Show();
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
        private void txtNumServ_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
               (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
        private void txtLatitud_Click(object sender, EventArgs e)
        {
            txtLatitud.Select(0, 0);
        }

        private void txtLongitud_Click(object sender, EventArgs e)
        {
            txtLongitud.Select(0, 0);
        }
        public void getInfo()
        {
            c.IdPlanta = txtPlanta.Text.Trim();
            c.NumMedidor = txtNumMed.Text.Trim();
            c.NumServicio = txtNumServ.Text.Trim();
            c.TipoPlantas = cmbTipoPlanta.Text;
            c.Estatus = cmbEstatus.Text;
            c.DescFunciones = txtDescFunciones.Text;
            c.Colonia = cmbColonia.Text;
            c.Sector = cmbSector.Text;
            c.Latitud = txtLatitud.Text;
            c.Longitud = txtLongitud.Text;
            c.Elevacion = txtElevacion.Text;
            c.Servicio = cmbServicio.Text;
            c.Domicilio = txtDomicilio.Text;
        }
        private bool validate()
        {
            if (c.IdPlanta == "" || c.NumMedidor == "" || c.NumServicio == "" ||
                c.TipoPlantas == "" || c.Estatus == "" || c.DescFunciones == "" ||
                c.Colonia == "" || c.Sector == "" || c.Latitud == "" || c.Longitud == "" ||
                c.Elevacion == "" || c.Servicio == "" || c.Domicilio == "")
            {
                return false;
            }
            return true;
        }
        private void clean()
        {
            txtPlanta.Clear();
            txtNumMed.Clear();
            txtNumServ.Clear();
            cmbTipoPlanta.ResetText();
            cmbEstatus.ResetText();
            txtDescFunciones.Clear();
            cmbColonia.ResetText();
            cmbSector.ResetText();
            txtLatitud.Clear();
            txtLongitud.Clear();
            txtElevacion.Clear();
            txtNumServ.Clear();
            txtDomicilio.Clear();
        }
        private void cmbColonia_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
