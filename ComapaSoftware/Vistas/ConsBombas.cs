using ComapaSoftware.Controlador;
using ComapaSoftware.Modelo;
using System;
using System.Windows.Forms;

namespace ComapaSoftware.Vistas
{
    public partial class ConsBombas : Form
    {
        ModeloBombas m = new ModeloBombas();
        ControladorBombas c = new ControladorBombas();

        private string globalReceiver;
        public string GlobalReceiver
        {
            get { return globalReceiver; }
            set { globalReceiver = value; }
        }
        public ConsBombas(string result)
        {
            InitializeComponent();
            GlobalReceiver = result;
            HideElements();
        }
        private void ConsBombas_Load(object sender, EventArgs e)
        {
            MessageBox.Show(globalReceiver);
            traerDatos();
            HideElements();
        }
        public void traerDatos()
        {
            dgvBombas.DataSource = c.llevarDatos(globalReceiver);
        }
        private void dgvBombas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            //RECIBE ID ESTACION
            RegBomba regBomba = new RegBomba(globalReceiver);
            this.Hide();
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
        }

        private void btnInfo_Click(object sender, EventArgs e)
        {
            string posicion = dgvBombas.CurrentRow.Cells[0].Value.ToString();

            Console.WriteLine(posicion);
            foreach (ModeloBombas list in c.GetUpdateInfo(posicion, GlobalReceiver))
            {
                lblIdbomba.Text = list.IdBombas;
                lblEstacion.Text = list.IdEstacion;
                lblPosicion.Text = list.Posicion.ToString();
                lblMarca.Text = list.Marca;
                lblModelo.Text = list.Modelo;
                lblTipo.Text = list.Tipo;
                lblHp.Text = list.Hp;
                lblVoltaje.Text = list.Voltaje;
                lblDiametro.Text = list.Diametro;
                lblLps.Text = list.Lps;
                lblCarga.Text = list.Carga;
                lblRpm.Text = list.Rpm;
                lblFpm.Text = list.Fpm;
                lblEstatus.Text = list.Estatus;
                richTextBox1.Text = list.Observaciones;
            }
            ShowElements();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            HideElements();
            dgvBombas.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string posicion = dgvBombas.CurrentRow.Cells[0].Value.ToString();
            Actbomba act = new Actbomba(posicion, GlobalReceiver);
            Console.WriteLine("Aqui llego " + posicion + "-" + GlobalReceiver);
            act.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool pressedButton = true;
            if (pressedButton && (MessageBox.Show("¿Desea eliminar esta planta?", "Eliminar registro",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                == System.Windows.Forms.DialogResult.Yes))
            {
                string posicion = dgvBombas.CurrentRow.Cells[0].Value.ToString();
                c.Delete(GlobalReceiver, posicion);
                traerDatos();
            }
        }
    }
}
