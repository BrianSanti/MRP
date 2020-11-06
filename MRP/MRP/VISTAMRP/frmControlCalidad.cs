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
using CONTROLADORMRP;
using MODELOMRP;

namespace VISTAMRP
{
    public partial class frmControlCalidad : Form
    {
        clsConexion cn = new clsConexion();
        clsValidaciones va = new clsValidaciones();
        
        public frmControlCalidad()
        {
            InitializeComponent();
            Actualizar();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void frmControlCalidad_Load(object sender, EventArgs e)
        {
            
        }

        private void cmbOrden_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void eventOrden(object sender, KeyPressEventArgs e)
        {
            va.Combobox(e);
           
        }

        private void eventInventario(object sender, KeyPressEventArgs e)
        {
            va.Combobox(e);
        }

        private void cmEmpleado_SelectedIndexChanged(object sender, EventArgs e)
        {
         
        }

        private void cmbResultado_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void eventEmpleado(object sender, KeyPressEventArgs e)
        {
            va.Combobox(e);
        }

        private void eventResultado(object sender, KeyPressEventArgs e)
        {
            va.Combobox(e);
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            Ingresar();
        }

        private void Ingresar()
        {
            try
            {
                String Ingre = "INSERT INTO control_calidad (pk_id_control_calidad, fk_id_orden_produccion_control_calidad,fk_id_inventario_control_calidad, fk_id_responsable_control_calidad,resultado_control_calidad, estado_control_calidad) values (" + txtCodigo.Text + ",  1  ,  1 ,  1  ,  1 , " + txtEstado.Text + "  )";
                OdbcCommand consulta = new OdbcCommand(Ingre, cn.conexion());
                consulta.ExecuteNonQuery();
                MessageBox.Show("Ingreso exitoso");
                Actualizar();
            }
            catch
            {
                MessageBox.Show("No se ha podido ingresar");
                Console.WriteLine("Error");

            }
        }
        private void Actualizar()
        {
            string cadena = "Select *FROM control_calidad ";
            OdbcDataAdapter datos = new OdbcDataAdapter(cadena, cn.conexion());
            DataTable dt = new DataTable();
            datos.Fill(dt);

            dataGridView1.DataSource = dt;
        }
        private void Eliminar()
        {
            try
            {
                string eliminar = "DELETE FROM control_calidad WHERE pk_id_control_calidad = " + txtEliminar.Text;
                OdbcDataAdapter datos = new OdbcDataAdapter(eliminar, cn.conexion());
                DataTable dt = new DataTable();
                datos.Fill(dt);
                dataGridView1.DataSource = dt;
                MessageBox.Show("Eliminado exitosamente");
                Actualizar();

            }
            catch
            {

                MessageBox.Show("No se ha podido eliminar");
                Console.WriteLine("Error");

            }
        }
        private void modificar()
        {
            try
            {
                string actualizar = "UPDATE control_calidad SET fk_id_orden_produccion_control_calidad = '" + this.cmbOrden.Text + "',  fk_id_inventario_control_calidad =   '" + this.cmbInventario.Text + "' , fk_id_inventario_control_calidad =   '" + this.cmbInventario.Text + "' ,  fk_id_responsable_control_calidad =   '" + this.cmbEmple.Text + "' , resultado_control_calidad =   '" + this.cmbResultado.Text + "' , estado_control_calidad =   '" + this.txtEstado.Text + "'      WHERE pk_id_control_calidad = " + txtModificar.Text;
                OdbcDataAdapter datos = new OdbcDataAdapter(actualizar, cn.conexion());
                DataTable dt = new DataTable();
                datos.Fill(dt);
                dataGridView1.DataSource = dt;
                MessageBox.Show("Modificado existosamente");
                Actualizar();

            }
            catch
            {

                MessageBox.Show("No se ha podido modificar");
                Console.WriteLine("Error");

            }


        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Eliminar();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            modificar();
        }
    }
}
