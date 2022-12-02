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
    public partial class frmListadoBarrio : Form
    {
        public frmListadoBarrio()
        {
            InitializeComponent();
        }

        private void cmdListar_Click(object sender, EventArgs e)
        {
            clsSocio soc = new clsSocio();

            soc.ListarSociosBarrio(Grilla,Convert.ToInt32(cmbBarrio.SelectedValue));
            lblTotal.Text = soc.TotalDeuda.ToString("0.00");
            lblCantidad.Text = soc.Cantidad.ToString();
            cmdReporte.Enabled = true;
            cmdImprimir.Enabled = true;
        }

        private void frmListadoBarrio_Load(object sender, EventArgs e)
        {
            clsBarrio barr = new clsBarrio();

            barr.Listar(cmbBarrio);
        }

        private void cmdImprimir_Click(object sender, EventArgs e)
        {
            prtVentana.ShowDialog();
            prtDocument.PrinterSettings = prtVentana.PrinterSettings;
            prtDocument.Print();
            MessageBox.Show("Reporte Impreso");
        }

        private void cmdReporte_Click(object sender, EventArgs e)
        {
            SaveFileDialog objArchivo = new SaveFileDialog();
            objArchivo.Title = "Seleccione Carpeta y Escriba Nombre de Archivo";
            objArchivo.RestoreDirectory = true;
            objArchivo.Filter = "Arcihvos de texto separado por coma (*.csv)|*.csv|Archivos de texto (*.txt)|*.txt";
            objArchivo.ShowDialog();


            clsSocio x = new clsSocio();
            x.ReporteSociosBarrio(objArchivo.FileName,Convert.ToInt32(cmbBarrio.SelectedValue));
            MessageBox.Show("Reporte Generado Exitosamente");
        }

        private void prtDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            clsSocio soc = new clsSocio();

            soc.ImprimirSociosBarrio(e, Convert.ToInt32(cmbBarrio.SelectedValue));
        }
    }
}
