using ComapaSoftware.Controlador;
using ComapaSoftware.Http;
using ComapaSoftware.Modelo;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComapaSoftware.Vistas
{
    public partial class ConsPlanta : Form
    {
        //INSTANCIAS Y VARIABLES GLOBALES
        ControladorPlantas c = new ControladorPlantas();
        Plantas p = new Plantas();
        Atts att = new Atts();
        string globalReceiver;
        public string GlobalReceiver
        {
            get { return globalReceiver; }
            set { globalReceiver = value; }
        }
        //LA CLASE PRINCIPAL RECIBE UN PARAMETRO DE SU VISTA ANTERIOR FormPanel EN LA VARIABLE senderInfo
        public ConsPlanta(string senderInfo)
        {
            //LA VARIABLE RECIBIDA senderInfo SE ALMACENA EN UNA VARIABLE GLOBAL globalReceiver PARA SU POSTERIOR USO
            globalReceiver = senderInfo;
            InitializeComponent();
            FormPlanta formPlanta = new FormPlanta();
            formPlanta.FormBorderStyle = FormBorderStyle.FixedDialog;
            formPlanta.StartPosition = FormStartPosition.CenterScreen;
        }
        //ACCESO A LA CLASE FormResultado
        public ConsPlanta()
        {

        }
        //DECLARACION DE BOTONES, ESTE BOTON ENVIA LA INFORMACION A LA VISTA ConsInfoTec MEDIANTE EL ID RECOGIDO POR LA CLASE ATT
        private void btnTecnica_Click(object sender, EventArgs e)
        {
            Close();
            ConsInfoTec consInfoTec = new ConsInfoTec(att.Result);
            consInfoTec.Show();
        }
        //DECLARACION DE BOTONES, ESTE BOTON TRAE TODA LA INFORMACION DE LA BASE DE DATOS EN EL datagridview1
        private void btnMostrar_Click(object sender, EventArgs e)
        {
            traerTodo();
        }
        //DECLARACION DE BOTONES, ESTE BOTON REALIZA NUEVAMENTE LA BUSQUEDA EN FUNCION A UN TEXTBOX
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            consultaAdicional();
        }
        //DECLARACION DE BOTONES, ESTE BOTON TE PERMITE VOLVER AL PANEL DE CONTROL
        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
            FormPanel formPanel = new FormPanel();
            formPanel.Show();
        }
        //DECLARACION DE BOTONES, ESTE BOTON TE PERMITE MOSTRAR EN PANTALLA LA INFORMACION GENERAL
        private void btnAdicional_Click(object sender, EventArgs e)
        {
            foreach (ModeloPlantas list in c.GetUpdateInfo(att.Result))
            {
                labelId.Text = list.IdPlanta;
                labelNm.Text = list.NumMedidor;
                labelNs.Text = list.NumServicio;
                labelTp.Text = list.TipoPlantas;
                labelEst.Text = list.Estatus;
                labelDesc.Text = list.DescFunciones;
                labelKva.Text = list.SubestacionKva;
                labelSec.Text = list.Sector;
                labelCol.Text = list.Colonia;
                labelSec.Text = list.Sector;
                labelLa.Text = list.Latitud;
                labelLon.Text = list.Longitud;
                labelEle.Text = list.Elevacion;
                labelSer.Text = list.Servicio;
                labelDom.Text = list.Domicilio;
                ShowElements();
            }
        }
        //DECLARACION DE BOTONES, CUANDO SE MUESTRA LA INFORMACION GENERAL,
        //ESTE BOTON SE ENCARGA DE ESCONDER LA INFORMACION GENERAL Y MOSTRAR EL RESUMEN EN EL datagridview1
        private void btnBack_Click(object sender, EventArgs e)
        {
            HideElements();
        }
        //EL METODO PERMITE TRAER UN RESUMEN DE DATOS DESDE LA BASE EN UN DATASOURCE PARA INGRESARLO EN UN datagridview1
        public void traerDatos()
        {
            //PRUEBA HTTP
            //dataGridView1.DataSource = p.llevarDatosHttp(globalReceiver);


            //si funciona, devolver a la normalidad
            dataGridView1.DataSource = c.llevarDatos(globalReceiver);
        }
        //EL METODO PERMITE TRAER TODA LA INFORMACION E INSERTARLA AL datagridview1 (POSIBLE ELIMINACION)
        public void traerTodo()
        {
            dataGridView1.DataSource = c.dataSender();
        }
        //EL METODO PERMITE REALIZAR UNA CONSULTA CON 1 DATO QUE COINCIDA CON 2 CRITERIOS IdPlantas || TipoPlantas
        public void consultaAdicional()
        {
            string globalEntry = txtAdicional.Text;
            dataGridView1.DataSource = c.consultaAdicional(globalEntry);
            dataGridView1.Refresh();
        }

        //EL METODO PERMITE EJECUTAR LA OBTENCION DE DATOS Y OCULTAR ELEMENTOS DE CONSULTA GENERAL
        private void FormResultado_Load(object sender, EventArgs e)
        {
            traerDatos();
            HideElements();
        }

        //DECLARACION DE EVENTOS, AL HACER CLICK, EL METODO OBTENDRA EL VALOR DE LA FILA EN LA POSICION 0 (IdPlanta)
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.Refresh();
            if (e.RowIndex >= 0)
            {
                string result = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                att.Result = result;
            }
        }
        //DECLARACION DE EVENTO, AL HACER DOBLE CLICK, CERRARA LA VENTANA ACTUAL Y ENVIARA A ConsInfoTec
        //CON LA VARIABLE RESULT QUE PROVIENE DE EL VALOR DE LA FILA SELECCIONADA CON LA POSICION 0 (idPlanta)
        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.Refresh();
            if (e.RowIndex >= 0)
            {
                string result = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                att.Result = result;
                Close();
                ConsInfoTec consInfoTec = new ConsInfoTec(result);
                consInfoTec.Show();
            }
        }
        //METODO SIN USAR (POSIBLE ELIMINACION)
        private void dataGridView1_RowLeave(object sender, DataGridViewCellEventArgs e)
        {

        }
        //DECLARACION DE EVENTO, AL DAR CLICK EN OTRA CELDA, SE OBTENDRA EL VALOR DE LA FILA EN LA POSICION 0 (idPlantas)
        //Y LO ALMACENARA DENTRO DE LA CLASE ATT
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                string result = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                att.Result = result;
            }
        }
        //METODO QUE OCULTA LOS ELEMENTOS DE MUESTRA DE INFORMACION GENERAL
        public void HideElements()
        {
            titleId.Hide();
            titleNm.Hide();
            titleNs.Hide();
            titleTp.Hide();
            titleEs.Hide();
            titleDesc.Hide();
            titleKva.Hide();
            titleSec.Hide();
            titleCol.Hide();
            titleSec.Hide();
            titleLat.Hide();
            titleLong.Hide();
            titleEle.Hide();
            titleServ.Hide();
            titleDom.Hide();
            labelId.Hide();
            labelNm.Hide();
            labelNs.Hide();
            labelTp.Hide();
            labelEst.Hide();
            labelDesc.Hide();
            labelKva.Hide();
            labelSec.Hide();
            labelCol.Hide();
            labelSec.Hide();
            labelLa.Hide();
            labelLon.Hide();
            labelEle.Hide();
            labelSer.Hide();
            labelDom.Hide();
            btnBack.Hide();
            dataGridView1.Show();
        }
        //METODO QUE MUESTRA LOS ELEMENTOS DE MUESTRA DE INFORMACION GENERAL
        public void ShowElements()
        {
            titleId.Show();
            titleNm.Show();
            titleNs.Show();
            titleTp.Show();
            titleEs.Show();
            titleDesc.Show();
            titleKva.Show();
            titleSec.Show();
            titleCol.Show();
            titleSec.Show();
            titleLat.Show();
            titleLong.Show();
            titleEle.Show();
            titleServ.Show();
            titleDom.Show();
            labelId.Show();
            labelNm.Show();
            labelNs.Show();
            labelTp.Show();
            labelEst.Show();
            labelDesc.Show();
            labelKva.Show();
            labelSec.Show();
            labelCol.Show();
            labelSec.Show();
            labelLa.Show();
            labelLon.Show();
            labelEle.Show();
            labelSer.Show();
            labelDom.Show();
            btnBack.Show();
            dataGridView1.Hide();
        }
        //CLASE QUE RECOGE LA INFORMACION DE LA POSICION 0 (idPlantas) PROVENIENTE DE LOS EVENTOS DEL datagridview1
        class Atts
        {
            //DECLARACION DE VARIABLES RESERVADAS (ATRIBUTOS)
            private string result;
            public string Result { get { return result; } set { result = value; } }
            //CONSTRUCTOR PUBLICO CON PARAMETROS
            public Atts(string result)
            {
                this.result = Result;
            }
            //CONSTRUCTOR DE ACCESO PUBLICO A LOS ATRIBUTOS
            public Atts()
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            att.Result = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            ActPlanta actPlanta = new ActPlanta(att.Result);
            actPlanta.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool pressedButton = true;
            if (pressedButton && (MessageBox.Show("¿Desea eliminar esta planta?", "Eliminar registro",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                == System.Windows.Forms.DialogResult.Yes))
            {
                string result = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                c.Delete(result);
                traerDatos();
            }


        }


        //HTTP CONSULTA
        public async Task ComprobarInicio()
        {
            using (var client = new HttpClient())
            {
                var values = new Dictionary<string, string> {
                    {"TipoPlantas", globalReceiver }

            };
                var content = new FormUrlEncodedContent(values);
                var response = await client.PostAsync("http://localhost/api/validation.php", content);
                var responseString = await response.Content.ReadAsStringAsync();
                Console.WriteLine(responseString);
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("¡Bienvenido!");

                }
                else
                {


                }
            }


        }
    }
}
