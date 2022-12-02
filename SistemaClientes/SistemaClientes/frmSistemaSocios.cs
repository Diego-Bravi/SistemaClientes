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
    public partial class frmSistemaSocios : Form
    {
        public frmSistemaSocios()
        {
            InitializeComponent();
        }

        private void sToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void agregarNuevosSociosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAgregarSocio NuevoSocio = new frmAgregarSocio();

            NuevoSocio.Show();
        }

        private void buscarSocioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBusquedaCliente Busqueda = new frmBusquedaCliente();

            Busqueda.Show();
        }

        private void consultaDeUnSocioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmConsultaSocio Consulta = new frmConsultaSocio();
            Consulta.Show();
        }

        private void listadoDeTodosLosSociosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListadoSocios ListadoSocios = new frmListadoSocios();

            ListadoSocios.Show();
        }

        private void listadoDeSociosDeudoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListadoDeudores ListadoDeudores = new frmListadoDeudores();

            ListadoDeudores.Show();

        }

        private void listadoDeSociosDeUnaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListadoActividad ListadoActividad = new frmListadoActividad();

            ListadoActividad.Show();
        }

        private void listadoDeSociosDeUnBarrioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListadoBarrio ListadoBarrio = new frmListadoBarrio();

            ListadoBarrio.Show();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void acercaDelDesarrolladorDelSistemaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAcercade acercade = new frmAcercade();

            acercade.Show();
        }
    }
}
