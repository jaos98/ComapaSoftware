using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;
namespace ComapaSoftware.Vistas
{
    public partial class ControlPanel : Form
    {
        //DECLARACION DE VARIABLES A UTILIZAR EN LA CLASE FormPanel
        MySqlCommand Query = new MySqlCommand();
        MySqlConnection Conn;
        MySqlDataReader consultar;
        //ACCESO PUBLICO A LA CLASE FormPanel
        public ControlPanel()
        {
            InitializeComponent();
        }
        //METODO DE CONEXION A BASE DE DATOS
        public void conectarBase()
        {
            Conn = new MySqlConnection();
            string sql = "server=localhost;user id=root; database=comapainfo;password=;";
            Conn.ConnectionString = sql;
            Conn.Open();
        }
        //DECLARACION DE BOTONES, BOTON QUE MUESTRA LA VISTA AGREGAR PLANTA
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Hide();
            FormPlanta formPlanta = new FormPlanta();
            formPlanta.Show();
        }
        //DECLARACION DE BOTONES, BOTON QUE MUESTRA LA VISTA AGREGAR INFO TECNICA
        private void btnInfoTec_Click(object sender, EventArgs e)
        {
            Hide();
            RegInfoTec regInfoTec = new RegInfoTec();
            regInfoTec.Show();
        }
        //DECLARACION DE BOTONES, BOTON QUE MUESTRA LA VISTA AGREGAR BOMBAS
        private void btnBombas_Click(object sender, EventArgs e)
        {
            Hide();
            RegBomba regBomba = new RegBomba();
            regBomba.Show();
        }
        //DECLARACION DE BOTONES, BOTON QUE ENVIA LA VARIABLE A LA SIGUIENTE VISTA FormResultado PARA SU CONSULTA
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            //consultarDato();
            if (txtConsulta.Text == "")
            {
                MessageBox.Show("Por favor introduzca la informacion correcta");
            }
            else
            {
                string senderInfo = txtConsulta.Text;
                Hide();
                ConsPlanta formResultado = new ConsPlanta(senderInfo);
                formResultado.Show();
            }
        }
        //DECLARACION DE BOTONES, BOTON QUE ENVIA UN RESULTADO DE UN CMBOX A LA SIGUIENTE VISTA FormResultado PARA SU CONSULTA
        private void btnBuscarCat_Click(object sender, EventArgs e)
        {
            if (cmbCategoria.Text == "--Seleccione categoria--")
            {
                MessageBox.Show("Porfavor seleccione categoria para consulta");
            }
            else
            {
                string senderInfo = cmbCategoria.Text;
                Dispose();
                ConsPlanta formResultado = new ConsPlanta(senderInfo);
                formResultado.Show();
            }
        }
        //METODO QUE EJECUTA CODIGO CUANDO CARGA LA VISTA (SIN UTILIZAR)
        private void FormPanel_Load(object sender, EventArgs e)
        {

        }

        private void btnSector_Click(object sender, EventArgs e)
        {
            RegSector rs = new RegSector();
            Dispose();
            rs.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RegCol rc = new RegCol();
            Dispose();
            rc.Show();
        }

        private void ControlPanel_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
