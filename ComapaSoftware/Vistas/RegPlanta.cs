using ComapaSoftware.Controlador;
using ComapaSoftware.Modelo;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComapaSoftware.Vistas
{
    public partial class FormPlanta : Form
    {
        ModeloPlantas m = new ModeloPlantas();
        ControladorPlantas c = new ControladorPlantas();
        public FormPlanta()
        {
            InitializeComponent();
        }
        //CARGA DE ELEMENTOS AL ABRIR FORM
        private void FormPlanta_Load(object sender, EventArgs e)
        {
            cmbColonia.Enabled = false;
            foreach (var item in c.consultarSector())
            {
                cmbSector.Items.Add(item);
            }
        }
       
        //BOTON DE REGISTRO DE INFORMACION
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            GetInfo();
            if (Validate())
            {
                //VALIDAR ANTES DE INGRESAR LA INFO
                if (c.noRepite(m.IdPlanta))
                {
                    if (c.insertarPlanta(m.IdPlanta, m.NumMedidor, m.NumServicio,
               m.TipoPlantas, m.Estatus, m.DescFunciones,m.SubestacionKva, m.Colonia, m.Sector,
               m.Latitud, m.Longitud, m.Elevacion, m.Servicio, m.Domicilio) > 0)
                    {
                        MessageBox.Show("Se han registrado todos los datos");
                        Clean();
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
                string resultId = c.obtenerID(cmbSector.Text);
                cmbColonia.Enabled = true;
                foreach (var item in c.compararDatos(resultId))
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
        public void GetInfo()
        {
            m.IdPlanta = txtPlanta.Text.Trim();
            m.NumMedidor = txtNumMed.Text.Trim();
            m.NumServicio = txtNumServ.Text.Trim();
            m.TipoPlantas = cmbTipoPlanta.Text;
            m.Estatus = cmbEstatus.Text;
            m.DescFunciones = txtDescFunciones.Text;
            m.SubestacionKva = txtKva.Text;
            m.Colonia = cmbColonia.Text;
            m.Sector = cmbSector.Text;
            m.Latitud = txtLatitud.Text;
            m.Longitud = txtLongitud.Text;
            m.Elevacion = txtElevacion.Text;
            m.Servicio = cmbServicio.Text;
            m.Domicilio = txtDomicilio.Text;
        }
        private bool Validate()
        {
            if (m.IdPlanta == "" || m.NumMedidor == "" || m.NumServicio == "" ||
                m.TipoPlantas == "" || m.Estatus == "" || m.DescFunciones == "" ||
                m.SubestacionKva==""||m.Colonia == "" || m.Sector == "" || m.Latitud == "" || m.Longitud == "" ||
                m.Elevacion == "" || m.Servicio == "" || m.Domicilio == "")
            {
                return false;
            }
            return true;
        }
        private void Clean()
        {
            txtPlanta.Clear();
            txtNumMed.Clear();
            txtNumServ.Clear();
            cmbTipoPlanta.Text = "";
            cmbEstatus.Text = "";
            txtDescFunciones.Clear();
            txtKva.Clear();
            cmbColonia.Text = "";
            cmbSector.Text = "";
            txtLatitud.Clear();
            txtLongitud.Clear();
            txtElevacion.Clear();
            txtNumServ.Clear();
            txtDomicilio.Clear();
        }
        private void cmbColonia_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        public async Task ValidarIdPlantas()
        {

        }


        //HTTP REGISTRO
        //public async Task EnviarDatos()
        //{
        //    GetInfo();
        //    if (Validate())
        //    {

        //        using (var client = new HttpClient())
        //        {
        //            var values = new Dictionary<string, string> {
        //            {"IdPlantas", c.IdPlanta },
        //            {"NumMedidor", c.NumMedidor },
        //            {"NumServicio",c.NumServicio },
        //            {"TipoPlantas",c.TipoPlantas },
        //            {"Estatus",c.Estatus },
        //            {"DescFunciones",c.DescFunciones },
        //            {"SubestacionKva",c.SubestacionKva },
        //            {"Colonia",c.Colonia },
        //            {"Sector",c.Sector },
        //            {"Latitud",c.Latitud },
        //            {"Longitud",c.Longitud },
        //            {"Elevacion",c.Elevacion },
        //            {"Servicio",c.Servicio },
        //            {"Domicilio",c.Domicilio }
        //    };
        //            var content = new FormUrlEncodedContent(values);
        //            var response = await client.PostAsync("http://localhost/api/plantas.php", content);
        //            //var responseString = await response.Content.ReadAsStringAsync();
        //            if (response.IsSuccessStatusCode)
        //            {
        //                MessageBox.Show("¡La informacion se ha registrado con exito!");
        //                Clean();
        //            }
        //            else
        //            {
        //                MessageBox.Show("-Ha ocurrido un error, favor de revisar su conexion a internet," +
        //                    "si el problema persiste, consulte con el administrador");
        //            }
        //        }
        //    }
        //    else
        //    {
        //        MessageBox.Show("Llene toda la informacion");
        //    }
        //}


        private void btnRegHttp_Click(object sender, EventArgs e)
        {
            //EnviarDatos();
        }
    }
}
