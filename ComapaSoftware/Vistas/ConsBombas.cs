using ComapaSoftware.Controlador;
using ComapaSoftware.Http;
using ComapaSoftware.Modelo;
using System;
using System.Windows.Forms;

namespace ComapaSoftware.Vistas
{
    public partial class ConsBombas : Form
    {
        ModeloBombas m = new ModeloBombas();
        ControladorBombas c = new ControladorBombas();
        Bombas b = new Bombas();
        ModelsBombas mb;

        private string estacion;
        public string IdEstacion
        {
            get { return estacion; }
            set { estacion = value; }
        }
        public ConsBombas(string idEstacion)
        {
            InitializeComponent();
            IdEstacion = idEstacion;
            HideElements();
        }
        private void ConsBombas_Load(object sender, EventArgs e)
        {
            MessageBox.Show(IdEstacion);
            traerDatosHttp();

            //traerDatos();
            HideElements();
        }
        public void traerDatos()
        {

            dgvBombas.DataSource = c.llevarDatos(IdEstacion);
        }
        public void traerDatosHttp()
        {
            dgvBombas.DataSource = b.getDatosBomba(IdEstacion);
        }
        private void dgvBombas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            //RECIBE ID ESTACION
            RegBomba regBomba = new RegBomba(IdEstacion);
            Dispose();
            regBomba.Show();
        }
        void HideElements()
        {
            label1.Hide();
            lblEstacion.Hide();
            label3.Hide();
            lblPosicion.Hide();
            label5.Hide();
            lblMarca.Hide();
            label7.Hide();
            lblModelo.Hide();
            label9.Hide();
            lblTipo.Hide();
            label11.Hide();
            lblHp.Hide();
            label13.Hide();
            lblVoltaje.Hide();
            label15.Hide();
            lblDiametro.Hide();
            label17.Hide();
            lblLps.Hide();
            label19.Hide();
            lblCarga.Hide();
            label21.Hide();
            lblRpm.Hide();
            label23.Hide();
            lblEstatus.Hide();
            label25.Hide();
            lblFpm.Hide();
            label27.Hide();
            btnRegresar.Hide();
            richTextBox1.Hide();
            lblIdbomba.Hide();
        }
        void ShowElements()
        {
            dgvBombas.Hide();
            label1.Show();
            lblEstacion.Show();
            label3.Show();
            lblPosicion.Show();
            label5.Show();
            lblMarca.Show();
            label7.Show();
            lblModelo.Show();
            label9.Show();
            lblTipo.Show();
            label11.Show();
            lblHp.Show();
            label13.Show();
            lblVoltaje.Show();
            label15.Show();
            lblDiametro.Show();
            label17.Show();
            lblLps.Show();
            label19.Show();
            lblCarga.Show();
            label21.Show();
            lblRpm.Show();
            label23.Show();
            lblEstatus.Show();
            label25.Show();
            lblFpm.Show();
            label27.Show();
            btnRegresar.Show();
            richTextBox1.Show();
            lblIdbomba.Show();
        }

        private void btnInfo_Click(object sender, EventArgs e)
        {
            string IdBombas = dgvBombas.CurrentRow.Cells[0].Value.ToString();
            mb = b.Leer(IdBombas);
            lblIdbomba.Text = mb.IdBombas.ToString();
            lblEstacion.Text = mb.IdEstacion;
            lblPosicion.Text = mb.Posicion.ToString();
            lblMarca.Text = mb.Marca;
            lblModelo.Text = mb.Modelo;
            lblTipo.Text = mb.Tipo;
            lblHp.Text = mb.Hp;
            lblVoltaje.Text = mb.Voltaje;
            lblDiametro.Text = mb.Diametro;
            lblLps.Text = mb.Lps;
            lblCarga.Text = mb.Carga;
            lblRpm.Text = mb.Rpm;
            lblFpm.Text = mb.Fpm;
            lblEstatus.Text = mb.Estatus;
            richTextBox1.Text = mb.Observaciones;
            ShowElements();







            //string idBombas = dgvBombas.CurrentRow.Cells[0].Value.ToString();
            //foreach (ModeloBombas list in c.GetUpdateInfo(idBombas))
            //{
            //    lblIdbomba.Text = list.IdBombas;
            //    lblEstacion.Text = list.IdEstacion;
            //    lblPosicion.Text = list.Posicion.ToString();
            //    lblMarca.Text = list.Marca;
            //    lblModelo.Text = list.Modelo;
            //    lblTipo.Text = list.Tipo;
            //    lblHp.Text = list.Hp;
            //    lblVoltaje.Text = list.Voltaje;
            //    lblDiametro.Text = list.Diametro;
            //    lblLps.Text = list.Lps;
            //    lblCarga.Text = list.Carga;
            //    lblRpm.Text = list.Rpm;
            //    lblFpm.Text = list.Fpm;
            //    lblEstatus.Text = list.Estatus;
            //    richTextBox1.Text = list.Observaciones;
            //}
            //ShowElements();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            HideElements();
            dgvBombas.Show();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            string idBombas = dgvBombas.CurrentRow.Cells[0].Value.ToString();
            string idEstacion = dgvBombas.CurrentRow.Cells[1].Value.ToString();
            Actbomba act = new Actbomba(idBombas,idEstacion);
            Console.WriteLine("Aqui llego " + idBombas);
            act.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool pressedButton = true;
            if (pressedButton && (MessageBox.Show("¿Desea eliminar esta planta?", "Eliminar registro",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                == System.Windows.Forms.DialogResult.Yes))
            {
                string idBombas = dgvBombas.CurrentRow.Cells[0].Value.ToString();
                b.Borrar(idBombas);
                traerDatosHttp();
                //c.Delete(idBombas);
                //traerDatos();
            }
        }



        private void ConsBombas_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnVolverIni_Click(object sender, EventArgs e)
        {
            Dispose();
            ControlPanel control = new ControlPanel();
            control.Show();
        }
    }
}
