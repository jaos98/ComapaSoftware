using ComapaSoftware.Http;
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
    public partial class ActSector : Form
    {
        Sector s = new Sector();
        private string idSector, nombreSector;

        public string IdSector { get { return idSector; } set { idSector = value; } }
        public string NombreSector { get { return nombreSector; } set { nombreSector = value; } }

        public ActSector(string idSector,string nombreSector)
        {
            IdSector = idSector;
            NombreSector = nombreSector;
            InitializeComponent();
            GetInfo();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (s.Actualizar(txtId.Text, txtNombre.Text))
            {
                    MessageBox.Show("Actualizado con exito");
                    RegSector rs = new RegSector();
                    rs.GetAll();
                    Close();
            }
            else
            {
                MessageBox.Show("Ha ocurrido un error, intentelo mas tarde");
            }
           
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ActSector_Load(object sender, EventArgs e)
        {
           
        }
        void GetInfo()
        {
            txtId.Text = IdSector;
            txtNombre.Text = NombreSector;
        }
    }
}
