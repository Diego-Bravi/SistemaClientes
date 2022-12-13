using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaClientes
{
    public partial class frmAgregarSocio : Form
    {
        public frmAgregarSocio()
        {
            InitializeComponent();
        }

        private void frmAgregarSocio_Load(object sender, EventArgs e)
        {
            clsActividad Act = new clsActividad();

            clsBarrio Barr = new clsBarrio();

            Barr.Listar(cmbBarrio);
            Act.Listar(cmbActividad);
        }

        private void cmdCargar_Click(object sender, EventArgs e)
        {
            clsSocio soc = new clsSocio();

            soc.IdSocio = Convert.ToInt32(txtDni.Text);
            soc.Nombre = txtNombre.Text;
            soc.Direccion = txtDireccion.Text;
            soc.idBarrio = Convert.ToInt32(cmbBarrio.SelectedValue);
            soc.idActividad = Convert.ToInt32(cmbActividad.SelectedValue);
            soc.Deuda = Convert.ToDecimal(txtDeuda.Text);
            soc.Agregar();
            MessageBox.Show("Datos Agregados");

            txtDni.Text = "";
            txtNombre.Text = "";
            txtDireccion.Text = "";
            cmbBarrio.SelectedIndex = 0;
            cmbActividad.SelectedIndex = 0;
            txtDeuda.Text =  "";
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

    
    }
}
