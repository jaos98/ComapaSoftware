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
    
    public partial class RegSector : Form
    {
        Sector s = new Sector();
        ModelsSector ms = new ModelsSector();
        public RegSector()
        {
            InitializeComponent();
        }

        private void RegSector_Load(object sender, EventArgs e)
        {
            GetAll();
        }


        public void GetAll()
        {
            dgvSector.DataSource = s.LeerTodo();
        }

        void GetInfo()
        {
            ms.IdSector = txtId.Text;
            ms.NombreSector = txtNombre.Text;
        }
        void Clean()
        {
            txtId.Text = "";
            txtNombre.Text = "";
        }

        private void btnRegistro_Click(object sender, EventArgs e)
        {
            GetInfo();
            if (s.Registrar(ms.IdSector, ms.NombreSector))
            {
                MessageBox.Show("Se ha registrado");
                GetAll();
                Clean();
            }
            else
            {
            MessageBox.Show("Ha ocurrido un error, intentelo mas tarde");
            }

        }

        private void dgvSector_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string result = dgvSector.CurrentRow.Cells[0].Value.ToString();
                ms.IdSector = result;
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            bool pressedButton = true;
            if (pressedButton && (MessageBox.Show("¿Desea eliminar esta planta?", "Eliminar registro",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                == System.Windows.Forms.DialogResult.Yes))
            {
                string result = dgvSector.CurrentRow.Cells[0].Value.ToString();
                s.Borrar(result);
                GetAll();
            }
           
        }

        private void btnAct_Click(object sender, EventArgs e)
        {
            string result = dgvSector.CurrentRow.Cells[0].Value.ToString();
            string result2 = dgvSector.CurrentRow.Cells[1].Value.ToString();
            Console.WriteLine(result);
            Console.WriteLine(result2);
            ActSector asec = new ActSector(result,result2);
            asec.Show();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            ControlPanel cpanel = new ControlPanel();
            Close();
            cpanel.Show();
        }
    }
}
