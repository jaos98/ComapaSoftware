using ComapaSoftware.Controlador;
using ComapaSoftware.Http;
using ComapaSoftware.Modelo;
using System;
using System.Windows.Forms;
namespace ComapaSoftware.Vistas
{
    public partial class ConsInfoTec : Form
    {
        ControladorFicha c = new ControladorFicha();
        AttsInfo atts = new AttsInfo();
        ModelsEstaciones me = new ModelsEstaciones();
        Estaciones es = new Estaciones();

        string globalReceiver;
        public ConsInfoTec()
        {

        }
        public ConsInfoTec(string result)
        {
            InitializeComponent();
            globalReceiver = result;  
        }
        //METODO QUE CARGA LOS DATOS EN LA TABLA PRINCIPAL
        public void traerDatos()
        {
            dataGridView1.DataSource = c.llevarDatos(globalReceiver);
        }
        //METODO HTTP
        public void traerDatosHttp()
        {
            dataGridView1.DataSource = es.llevarDatosHttp(globalReceiver);
        }
        //METODO DE CARGA DE ELEMENTOS DEL FORM
        private void ConsInfoTec_Load(object sender, EventArgs e)
        {
            Ocultar();
            traerDatosHttp();
            
             //traerDatos();
        }
        //METODO AL HACER UN CLICK EN LA TABLA
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex>=0)
            {
                dataGridView1.Refresh();
                richTextBox1.Text = es.ObtenerObservaciones(dataGridView1.CurrentRow.Cells[1].Value.ToString());
            }

            //if (e.RowIndex >= 0)
            //{
            //    dataGridView1.Refresh();
            //    //richTextBox1.Text = modelo.traerDescripcion(atts.Result);
            //    string result = c.traerDescripcion(dataGridView1.CurrentRow.Cells[1].Value.ToString());

            //    richTextBox1.Text = result;
            //    //TRAER DESCRIPCIONES
            //    /**
                
            //     **/
            //}
        }
        //METODO AL HACER DOBLE CLICK EN LA TABLA
        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.Refresh();
            if (e.RowIndex >= 0)
            {
                //RECIBE ID ESTACION
                string idEstacion = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                Dispose();
                ConsBombas consBombas = new ConsBombas(idEstacion);
                consBombas.Show();
            }
        }
        void Ocultar()
        {
            dataGridView1.Visible = true;
            btnBack.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label12.Visible = false;
            label13.Visible = false;
            label14.Visible = false;
            label15.Visible = false;
            label16.Visible = false;
            label22.Visible = false;
            lblOb.Visible = false;
            lblPlanta.Visible = false;
            lblEstacion.Visible = false;
            lblNombre.Visible = false;
            lblCap.Visible = false;
            lblOp.Visible = false;
            lblEqinst.Visible = false;
            lblTipo.Visible = false;
            lblGarant.Visible = false;
            lblProm.Visible = false;
            lblInst.Visible = false;
            lblServ.Visible = false;
            richTextBox1.Visible = false;


        }
        void Mostrar()
        {
            dataGridView1.Visible = false;
            btnBack.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            label6.Visible = true;
            label12.Visible = true;
            label13.Visible = true;
            label14.Visible = true;
            label15.Visible = true;
            label16.Visible = true;
            label22.Visible = true;
            lblOb.Visible = true;
            lblPlanta.Visible = true;
            lblEstacion.Visible = true;
            lblNombre.Visible = true;
            lblCap.Visible = true;
            lblOp.Visible = true;
            lblEqinst.Visible = true;
            lblTipo.Visible = true;
            lblGarant.Visible = true;
            lblProm.Visible = true;
            lblInst.Visible = true;
            lblServ.Visible = true;
            richTextBox1.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Dispose();
            ControlPanel controlPanel = new ControlPanel();
            controlPanel.Show();
        }
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            //if (dataGridView1.CurrentRow != null)
            //{
            //    atts.Result = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            //    c.traerDescripcion(atts.Result);
            //}
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            //RECIBE ID ESTACION
            string idEstacion = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            Dispose();
            ConsBombas consBombas = new ConsBombas(idEstacion);
            consBombas.Show();
        }
        class AttsInfo
        {
            private string result;
            private string result2;

            public string Result
            {
                get { return result; }
                set { result = value; }
            }
            public string Result2
            {
                get { return result2; }
                set { result2 = value; }
            }

            public AttsInfo()
            {

            }

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            string result = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            ActInfoTec actInfoTec = new ActInfoTec(result);
            actInfoTec.Show();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            bool pressedButton = true;
            if (pressedButton && (MessageBox.Show("¿Desea eliminar esta planta? Al realizar esta accion eliminara tambien todas las bombas almacenadas en esta estacion", "Eliminar registro",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                == System.Windows.Forms.DialogResult.Yes))
            {
                string result = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                es.Borrar(result);
                traerDatosHttp();
                //c.Delete(result);
                //traerDatos();
            }
        }

        private void ConsInfoTec_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Mostrar();
            string idEstacion = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            if (es.getDatosHttp(idEstacion))
            {
                lblPlanta.Text = es.me.IdPlantas;
                lblEstacion.Text = es.me.IdEstacion;
                lblNombre.Text = es.me.Nombre;
                lblCap.Text = es.me.CapacidadEquipos;
                lblOp.Text = es.me.OperacionMinima;
                lblEqinst.Text = es.me.EquiposInstalados;
                lblTipo.Text = es.me.Tipo;
                lblGarant.Text = es.me.GarantOperacion;
                lblProm.Text = es.me.GastoPromedio;
                lblInst.Text = es.me.GastoInstalado;
                lblServ.Text = es.me.Servicio;
                richTextBox1.Text = es.me.Observaciones;
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Ocultar();
            btnBack.Visible = false;
        }
    }
}
