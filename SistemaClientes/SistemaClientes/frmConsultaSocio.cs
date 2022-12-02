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
    public partial class frmConsultaSocio : Form
    {
        public frmConsultaSocio()
        {
            InitializeComponent();
        }

        private void frmConsultaSocio_Load(object sender, EventArgs e)
        {
            clsSocio Soc = new clsSocio();

            Soc.Listar(cmbSocio);
        }

        private void cmdBuscar_Click(object sender, EventArgs e)
        {
            Int32 idSocio = Convert.ToInt32(cmbSocio.SelectedValue);
            clsSocio x = new clsSocio();

            x.ConsultaSocio(idSocio);
            if (x.IdSocio == 0)
            {
                MessageBox.Show("Dato No Encontrado.");
            }
            else
            {
                lblNombre.Text = x.Nombre;
                lblDireccion.Text = x.Direccion.ToString();
                lblActividad.Text = x.idActividad.ToString();
                lblDeuda.Text = x.Deuda.ToString();
            }
        }
    }
}
