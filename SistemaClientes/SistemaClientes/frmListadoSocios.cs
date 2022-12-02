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
    public partial class frmListadoSocios : Form
    {
        public frmListadoSocios()
        {
            InitializeComponent();
        }


        private void prtDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            clsSocio soc = new clsSocio();

            soc.Imprimir(e);
        }

        private void cmdListar_Click(object sender, EventArgs e)
        {
            clsSocio Soc = new clsSocio();

            Soc.ListarSocios(Grilla);
            lblTotal.Text = Soc.TotalDeuda.ToString("0.00");
            lblMayor.Text = Soc.NumeroMayor.ToString("0.00");
            lblMenor.Text = Soc.NumeroMenor.ToString("0.00");
            lblPromedio.Text = Soc.PromedioDeuda.ToString("0.00");

            cmdReporte.Enabled = true;
            cmdImprimir.Enabled = true;
        }

        private void cmdReporte_Click(object sender, EventArgs e)
        {
          

                SaveFileDialog objArchivo = new SaveFileDialog();
                objArchivo.Title = "Seleccione Carpeta y Escriba Nombre de Archivo";
                objArchivo.RestoreDirectory = true;
                objArchivo.Filter = "Arcihvos de texto separado por coma (*.csv)|*.csv|Archivos de texto (*.txt)|*.txt";
                objArchivo.ShowDialog();


                clsSocio x = new clsSocio();
                x.ReporteSocios(objArchivo.FileName);
                MessageBox.Show("Reporte Generado Exitosamente");
            
        }

        private void cmdImprimir_Click_1(object sender, EventArgs e)
        {
            prtVentana.ShowDialog();
            prtDocument.PrinterSettings = prtVentana.PrinterSettings;
            prtDocument.Print();
            MessageBox.Show("Reporte Impreso");

        }
    }
}
