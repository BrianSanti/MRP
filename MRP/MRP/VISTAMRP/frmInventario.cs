using MODELOMRP;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Odbc;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VISTAMRP
{
    public partial class frmInventario : Form
    {
        clsConexion cn = new clsConexion();
        public frmInventario()
        {
            InitializeComponent();
            Actualizar();
        }

        private void frmInventario_Load(object sender, EventArgs e)
        {

        }

        private void dgv1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Actualizar()
        {
            string cadena = "Select *FROM orden_produccion ";
            OdbcDataAdapter datos = new OdbcDataAdapter(cadena, cn.conexion());

            DataTable dt = new DataTable();
            datos.Fill(dt);
            dgv1.DataSource = dt;
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Actualizar();
        }
    }
}
