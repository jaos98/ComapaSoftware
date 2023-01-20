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
    public partial class ActCol : Form
    {
        Colonia c = new Colonia();
        ModelsColonia mc = new ModelsColonia();
        public int IdColonia { get; set; }
        public string IdSector { get; set; }
        public string NombreColonia { get; set; }
        public ActCol(int idColonia,string idSector,string nombreColonia)
        {
            IdColonia = idColonia;
            IdSector = idSector;
            NombreColonia = nombreColonia;
            InitializeComponent();
        }

        private void ActCol_Load(object sender, EventArgs e)
        {
            GetAllInfo();
            cmbId.Text = IdSector;
            txtCol.Text = NombreColonia;
        }
        void GetAllInfo()
        {
            foreach (var item in c.LeerIds())
            {
                cmbId.Items.Add(item.IdSector);
            }
        }
        void GetInfo()
        {
            mc.IdColonia = IdColonia;
            mc.IdSector = IdSector;
            mc.NombreColonia = NombreColonia;

        }

        private void btnAct_Click(object sender, EventArgs e)
        {
            GetInfo();
            if (c.Actualizar(mc.IdColonia, cmbId.Text, txtCol.Text))
            {
                MessageBox.Show("¡Actualizado!");

                Dispose();
                
            }
            else
            {
                MessageBox.Show("Ha ocurrido un error, intentelo mas tarde");
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Dispose();
        }

    }
}
