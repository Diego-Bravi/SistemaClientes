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
            clsActividad act = new clsActividad();


            String nomAct = "";
            nomAct = act.Buscar(Convert.ToInt32(x.idActividad));

            if (x.IdSocio == 0)
            {
                MessageBox.Show("Dato No Encontrado.");
            }
            else
            {
                
                lblDni.Text = x.IdSocio.ToString();
                lblDireccion.Text = x.Direccion.ToString();
                lblActividad.Text = nomAct.ToString();
                lblDeuda.Text = x.Deuda.ToString();
            }
        }
    }
}
