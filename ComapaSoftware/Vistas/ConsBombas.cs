using ComapaSoftware.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComapaSoftware.Vistas
{
    public partial class ConsBombas : Form
    {
        ModeloBombas model = new ModeloBombas();
        string globalReceiver;
        public ConsBombas(string result)
        {
            InitializeComponent();
            globalReceiver = result;
        }
        public void traerDatos()
        {
            dgvBombas.DataSource = model.llevarDatos(globalReceiver);
        }
        private void dgvBombas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void ConsBombas_Load(object sender, EventArgs e)
        {
            MessageBox.Show(globalReceiver);
            traerDatos();
        }
    }
}
