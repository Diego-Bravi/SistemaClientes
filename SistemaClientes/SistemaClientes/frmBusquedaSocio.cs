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
    public partial class frmBusquedaCliente : Form
    {
        public frmBusquedaCliente()
        {
            InitializeComponent();
        }

        private void cmdBuscar_Click(object sender, EventArgs e)
        {
            Int32 idSocio = Convert.ToInt32(txtCodigo.Text);
            clsSocio x = new clsSocio();

            x.Buscar(idSocio);
            if (x.IdSocio == 0)
            {
                MessageBox.Show("Dato No Encontrado.");
            }
            else
            {
                lblNombre.Text = x.Nombre;
                lblDireccion.Text = x.Direccion.ToString();
                txtDeuda.Text = x.Deuda.ToString();
                cmdModificar.Enabled = true;
                cmdEliminar.Enabled = true;

                
            }
        }

        private void cmdModificar_Click(object sender, EventArgs e)
        {
            cmdEliminar.Enabled = false;
            cmdModificar.Enabled = false;
            cmdGuardar.Enabled = true;
            txtDeuda.ReadOnly = false;
  

        }

        private void cmdEliminar_Click(object sender, EventArgs e)
        {
            clsSocio x = new clsSocio();

            x.Eliminar(Convert.ToInt32(txtCodigo.Text));
            MessageBox.Show("Dato Eliminado");
            Limpiar();
        }

        private void Limpiar()
        {
            
            lblNombre.Text = "";
            lblDireccion.Text = "";
            txtDeuda.Text = "";
            txtDeuda.ReadOnly = true;
            cmdEliminar.Enabled = false;
            cmdModificar.Enabled = false;
            cmdGuardar.Enabled = false;
        }

        private void cmdGuardar_Click(object sender, EventArgs e)
        {
            clsSocio soc = new clsSocio();
            soc.Modificar(Convert.ToInt32(txtCodigo.Text));
            soc.Deuda = Convert.ToDecimal(txtDeuda.Text);
            MessageBox.Show("Dato Grabado Correctamente");
            Limpiar();
        }
    }
}
