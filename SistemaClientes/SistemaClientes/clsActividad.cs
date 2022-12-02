using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;


namespace SistemaClientes
{
    internal class clsActividad
    {
        private OleDbConnection conexion = new OleDbConnection();
        private OleDbCommand comando = new OleDbCommand();
        private OleDbDataAdapter adaptador = new OleDbDataAdapter();

        private string CadenaConexion = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source = BD_Clientes.mdb";
        private string Tabla = "Actividad";

        public void Listar(ComboBox Combo)
        {
            try
            {
                conexion.ConnectionString = CadenaConexion;
                conexion.Open();

                comando.Connection = conexion;
                comando.CommandType = CommandType.TableDirect;
                comando.CommandText = Tabla;

                adaptador = new OleDbDataAdapter(comando);
                DataSet DS = new DataSet();
                adaptador.Fill(DS, Tabla);

                Combo.DataSource = DS.Tables[Tabla];
                Combo.DisplayMember = "Nombre";
                Combo.ValueMember = "idActividad";


                conexion.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        public String Buscar(Int32 idActividad)
        {
            try
            {
                conexion.ConnectionString = CadenaConexion;
                conexion.Open();

                comando.Connection = conexion;
                comando.CommandType = CommandType.TableDirect;
                comando.CommandText = Tabla;

                OleDbDataReader DR = comando.ExecuteReader();
                String Resultado = "";

                if (DR.HasRows)
                {
                    while (DR.Read())
                    {
                        if (DR.GetInt32(0) == idActividad)
                        {
                            Resultado = DR.GetString(1);
                        }
                    }

                }
                conexion.Close();
                return Resultado;
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }
    }
}
