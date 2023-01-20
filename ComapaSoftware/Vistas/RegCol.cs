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
    public partial class RegCol : Form
    {
        ModelsColonia mc = new ModelsColonia();
        Sector s = new Sector();
        Colonia c = new Colonia();
        public string IdSector { get; set; }
        public RegCol()
        {
            InitializeComponent();
        }

        private void RegCol_Load(object sender, EventArgs e)
        {
            GetAll();
        }

        void GetAll()
        {
            foreach (var item in c.LeerIds())
            {
                cmbId.Items.Add(item.IdSector);
            }
        }
        public void GetAllData()
        {
            dgvColonias.DataSource = c.LeerTodo(cmbId.Text);
        }
        public void GetActData(string IdSector)
        {
            dgvColonias.DataSource = c.LeerTodo(IdSector);
        }
        void GetInfo()
        {
            mc.IdSector = cmbId.Text;
            mc.NombreColonia = txtNombre.Text;
        }
        void Clean()
        {
            txtNombre.Text = "";
        }
        private void cmbId_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbId.SelectedIndex>=0)
            {
               c.LeerNombre(cmbId.Text);;
               dgvColonias.DataSource= c.LeerTodo(cmbId.Text);
               lblSector.Text =  c.ms.NombreSector;
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            GetInfo();
            if (c.Registrar(mc.IdSector,mc.NombreColonia))
            {
                MessageBox.Show("¡Registrado!");
                GetAllData();
                Clean();
            }
            else
            {
                MessageBox.Show("Ha ocurrido un error, intentelo mas tarde");
            }

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            bool pressedButton = true;
            if (pressedButton && (MessageBox.Show("¿Desea eliminar esta planta?", "Eliminar registro",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                == System.Windows.Forms.DialogResult.Yes))
            {
                string IdColonia = dgvColonias.CurrentRow.Cells[0].Value.ToString();
                c.Borrar(IdColonia);
                GetAllData();
            }
        }

        private void btnAct_Click(object sender, EventArgs e)
        {
            string IdCol = dgvColonias.CurrentRow.Cells[0].Value.ToString();
            int IdColonia = Convert.ToInt32(IdCol);
            string IdSector = dgvColonias.CurrentRow.Cells[1].Value.ToString();
            string NombreColonia = dgvColonias.CurrentRow.Cells[2].Value.ToString();
            ActCol ac = new ActCol(IdColonia,IdSector,NombreColonia);
            ac.Show();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            ControlPanel cpanel = new ControlPanel();
            Dispose();
            cpanel.Show();
        }

        private void RegCol_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
