using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;
using System.Drawing.Printing;
using System.Drawing;



namespace SistemaClientes
{
    internal class clsSocio
    {

        private OleDbConnection conexion = new OleDbConnection();
        private OleDbCommand comando = new OleDbCommand();
        private OleDbDataAdapter adaptador = new OleDbDataAdapter();

        private string CadenaConexion = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source = BD_Clientes.mdb";
        private string Tabla = "Socio";

        private Decimal TotDeuda;
        private Decimal Numero;
        private Decimal NumMayor;
        private Decimal NumMenor;
        public Int32 Cant;
 

        public Int32 idSoc;
        public string Nom;
        public string Direc;
        public Int32 idBarr;
        public Int32 idAct;
        public Decimal Deu;


        public Int32 IdSocio
        {
            get { return idSoc; }
            set { idSoc = value; }
        }
        public String Nombre
        {
            get { return Nom; }
            set { Nom = value; }
        }
        public String Direccion
        {
            get { return Direc; }
            set { Direc = value; }
        }

        public Int32 idBarrio
        {
            get { return idBarr; }
            set { idBarr = value; }
        }
        public Int32 idActividad
        {
            get { return idAct; }
            set { idAct = value; }
        }
        public Decimal Deuda
        {
            get { return Deu; }
            set { Deu = value; }
        }

        public Decimal TotalDeuda
        {
            get { return TotDeuda; }

        }

        public Decimal NumeroMayor
        {
            get { return NumMayor; }

        }

        public Decimal NumeroMenor
        {
            get { return NumMenor; }

        }

        public Int32 Cantidad
        {
            get { return Cant; }
        }

        public Decimal PromedioDeuda
        {
            get { return TotalDeuda / Cantidad; }
        }


        public void Modificar(Int32 IdSocio)
        {
            try
            {
                String sql = "";
                sql = "UPDATE SOCIO SET DEUDA = " + Deu.ToString() + " WHERE IDSOCIO = " + IdSocio.ToString();
                conexion.ConnectionString = CadenaConexion;
                conexion.Open();

                comando.Connection = conexion;
                comando.CommandType = CommandType.Text;
                comando.CommandText = sql;
                comando.ExecuteNonQuery();




                conexion.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }


        public void Eliminar(Int32 IdSocio)
        {
            try
            {
                String sql = "DELETE * FROM SOCIO WHERE IDSOCIO = " + IdSocio.ToString();
                conexion.ConnectionString = CadenaConexion;
                conexion.Open();

                comando.Connection = conexion;
                comando.CommandType = CommandType.Text;
                comando.CommandText = sql;
                comando.ExecuteNonQuery();




                conexion.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }


        public void Agregar()
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

                DataTable tabla = DS.Tables[Tabla];
                DataRow fila = tabla.NewRow();

                fila["idSocio"] = idSoc;
                fila["Nombre"] = Nom;
                fila["Direccion"] = Direc;
                fila["idBarrio"] = idBarr;
                fila["idActividad"] = idAct;
                fila["Deuda"] = Deu;

                tabla.Rows.Add(fila);
                OleDbCommandBuilder ConciliaCambios = new OleDbCommandBuilder(adaptador);
                adaptador.Update(DS, Tabla);
                conexion.Close();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        public void Buscar(Int32 IdSocio)
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
               


                if (DS.Tables[Tabla].Rows.Count > 0)
                {
                    foreach (DataRow x in DS.Tables[Tabla].Rows)
                    {
                        if (Convert.ToInt32(x["idSocio"]) == IdSocio)
                        {
                            idSoc = Convert.ToInt32(x["idSocio"]);
                            Nom = x["Nombre"].ToString();
                            Direc = x["Direccion"].ToString();
                            Deu = Convert.ToDecimal(x["Deuda"]);

                        }

                    }
                }

                conexion.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        public void ConsultaSocio(Int32 IdSocio)
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
               
                


                if (DS.Tables[Tabla].Rows.Count > 0)
                {
                    foreach (DataRow x in DS.Tables[Tabla].Rows)
                    {
                       
                        if (Convert.ToInt32(x["idSocio"]) == IdSocio)
                        {
                          
                            idSoc = Convert.ToInt32(x["idSocio"]);
                            Nom = x["Nombre"].ToString();
                            Direc = x["Direccion"].ToString();
                            idAct = Convert.ToInt32(x["idActividad"]);
                            Deu = Convert.ToDecimal(x["Deuda"]);

                        }

                    }
                }

                conexion.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

       

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
                Combo.ValueMember = "idSocio";


                conexion.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        public void ListarSocios(DataGridView Grilla)
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
                TotDeuda = 0;
                Cant = 0;
                Numero = 0;
                NumMayor = 0;
                NumMenor = 0;





                Grilla.Rows.Clear();



                if (DS.Tables[Tabla].Rows.Count > 0)
                {
                    foreach (DataRow x in DS.Tables[Tabla].Rows)
                    {
                       
                        

                            Grilla.Rows.Add(x["idSocio"], x["Nombre"], x["Direccion"], x["Deuda"]);
                            TotDeuda = TotDeuda + Convert.ToDecimal(x["Deuda"]);
                            Numero = Convert.ToDecimal(x["Deuda"]);
                            Cant = Cant + 1;


                            if (Numero > NumMayor)
                            {
                                NumMayor = Numero;
                            }
                            if (Numero < NumMenor)
                            {
                                NumMenor = Numero;
                            }

                    }
                }
                conexion.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        public void Imprimir(PrintPageEventArgs Reporte)
        {
            try
            {
                Font LetraTexto = new Font("Arial", 8);
                Font Titulo1 = new Font("Arial", 20);
                Font Titulo2 = new Font("Arial", 12);
                Int32 Linea = 200;
                clsActividad act = new clsActividad();
                clsBarrio barr = new clsBarrio();
                String nomAct = "";
                String nomBarr = "";
                TotDeuda = 0;
                Cant = 0;
                Numero = 0;
                NumMayor = 0;
                NumMenor = 0;


                Reporte.Graphics.DrawString("Listado de Socios", Titulo1, Brushes.Red, 300, 80);
                Reporte.Graphics.DrawString("DNI", Titulo2, Brushes.Blue, 100, 170);
                Reporte.Graphics.DrawString("Nombre Socio", Titulo2, Brushes.Blue, 180, 170);
                Reporte.Graphics.DrawString("Direccion", Titulo2, Brushes.Blue, 300, 170);
                Reporte.Graphics.DrawString("Barrio", Titulo2, Brushes.Blue, 450, 170);
                Reporte.Graphics.DrawString("Actividad", Titulo2, Brushes.Blue, 550, 170);
                Reporte.Graphics.DrawString("Deuda", Titulo2, Brushes.Blue, 650, 170);
                conexion.ConnectionString = CadenaConexion;
                conexion.Open();

                comando.Connection = conexion;
                comando.CommandType = CommandType.TableDirect;
                comando.CommandText = Tabla;

                adaptador = new OleDbDataAdapter(comando);
                DataSet DS = new DataSet();
                adaptador.Fill(DS, Tabla);


                if (DS.Tables[Tabla].Rows.Count > 0)
                {
                    foreach (DataRow fila in DS.Tables[Tabla].Rows)
                    {
                        nomAct = act.Buscar(Convert.ToInt32(fila["idActividad"]));
                        nomBarr = barr.Buscar(Convert.ToInt32(fila["idBarrio"]));

                        TotDeuda = TotDeuda + Convert.ToDecimal(fila["Deuda"]);
                        Numero = Convert.ToDecimal(fila["Deuda"]);
                        Cant = Cant + 1;


                        if (Numero > NumMayor)
                        {
                            NumMayor = Numero;
                        }
                        if (Numero < NumMenor)
                        {
                            NumMenor = Numero;
                        }

                        Reporte.Graphics.DrawString(fila["idSocio"].ToString(), LetraTexto, Brushes.Black, 100, Linea);
                        Reporte.Graphics.DrawString(fila["Nombre"].ToString(), LetraTexto, Brushes.Black, 180, Linea);
                        Reporte.Graphics.DrawString(fila["Direccion"].ToString(), LetraTexto, Brushes.Black, 300, Linea);
                        Reporte.Graphics.DrawString(nomAct, LetraTexto, Brushes.Black, 450, Linea);
                        Reporte.Graphics.DrawString(nomBarr.ToString(), LetraTexto, Brushes.Black, 550, Linea);
                        Reporte.Graphics.DrawString(fila["Direccion"].ToString(), LetraTexto, Brushes.Black, 650, Linea);
                        


                        Linea = Linea + 15;

                        

                    }
                }

                Reporte.Graphics.DrawString("Total Deuda : " + TotDeuda.ToString("0.00"), LetraTexto, Brushes.Blue, 100, 120);
                Reporte.Graphics.DrawString("Promedio Deuda : " + PromedioDeuda.ToString("0.00"), LetraTexto, Brushes.Blue, 100, 140);
                Reporte.Graphics.DrawString("Deuda Menor : " + NumeroMenor, LetraTexto, Brushes.Blue, 250, 120);
                Reporte.Graphics.DrawString("Deuda Mayor : " + NumeroMayor, LetraTexto, Brushes.Blue, 250, 140);


                conexion.Close();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        public void ReporteSocios( String NombreArchivo)
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
                    clsActividad act = new clsActividad();
                    clsBarrio barr = new clsBarrio();

                    String nomAct = "";
                    String nomBarr = "";
                    TotDeuda = 0;
                    Cant = 0;
                    Numero = 0;
                    NumMayor = 0;
                    NumMenor = 0;

                StreamWriter AD = new StreamWriter(NombreArchivo, false, Encoding.UTF8);
                    AD.WriteLine("Listado de Socios\n");
                    AD.WriteLine("DNI;Nombre;Direccion;Barrio;Actividad;Deuda\n");



                    if (DS.Tables[Tabla].Rows.Count > 0)
                    {
                        foreach (DataRow x in DS.Tables[Tabla].Rows)
                        {
                            
                                nomAct = act.Buscar(Convert.ToInt32(x["idActividad"]));
                                nomBarr = barr.Buscar(Convert.ToInt32(x["idBarrio"]));

                                AD.Write(x["idSocio"].ToString());
                                AD.Write(";");
                                AD.Write(x["Nombre"]);
                                AD.Write(";");
                                AD.Write(x["Direccion"]);
                                AD.Write(";");
                                AD.Write(nomBarr);
                                AD.Write(";");
                                AD.Write(nomAct);
                                AD.Write(";");
                                AD.WriteLine(x["Deuda"]);



                                  TotDeuda = TotDeuda + Convert.ToDecimal(x["Deuda"]);
                                  Numero = Convert.ToDecimal(x["Deuda"]);
                                  Cant = Cant + 1;


                                  if (Numero > NumMayor)
                                  {
                                     NumMayor = Numero;
                                  }
                                  if (Numero < NumMenor)
                                  {
                                       NumMenor = Numero;
                                  }


                        }
                    }

                AD.Write("\nDeuda Mayor:;");
                AD.WriteLine(NumeroMayor);
                AD.Write("Deuda Menor:;");
                AD.WriteLine(NumeroMenor);
                AD.Write("Total de la Deuda:;");
                AD.WriteLine(TotDeuda);
                AD.Write("Promedio Deuda:;");
                AD.WriteLine(PromedioDeuda);



                conexion.Close();
                    AD.Close();
            }
                
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }


        public void ListarSociosDeudores(DataGridView Grilla)
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

                TotDeuda = 0;
                Cant = 0;
                Numero = 0;
                NumMayor = 0;
                NumMenor = 0;


                Grilla.Rows.Clear();



                if (DS.Tables[Tabla].Rows.Count > 0)
                {
                    foreach (DataRow x in DS.Tables[Tabla].Rows)
                    {

                        if (Convert.ToInt32(x["Deuda"]) > 0 ) 
                        { 

                        Grilla.Rows.Add(x["idSocio"], x["Nombre"], x["Deuda"]);

                            TotDeuda = TotDeuda + Convert.ToDecimal(x["Deuda"]);
                            Numero = Convert.ToDecimal(x["Deuda"]);
                            Cant = Cant + 1;


                            if (Numero > NumMayor)
                            {
                                NumMayor = Numero;
                            }
                            if (Numero < NumMenor)
                            {
                                NumMenor = Numero;
                            }
                        }

                    }
                }
                conexion.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        public void ImprimirDeudores(PrintPageEventArgs Reporte)
        {
            try
            {
                Font LetraTexto = new Font("Arial", 8);
                Font Titulo1 = new Font("Arial", 20);
                Font Titulo2 = new Font("Arial", 12);
                Int32 Linea = 200;

                TotDeuda = 0;
                Cant = 0;
                Numero = 0;
                NumMayor = 0;
                NumMenor = 0;




                Reporte.Graphics.DrawString("Listado de Socios Deudores", Titulo1, Brushes.Red, 120, 80);
                Reporte.Graphics.DrawString("DNI", Titulo2, Brushes.Blue, 100, 170);
                Reporte.Graphics.DrawString("Nombre Socio", Titulo2, Brushes.Blue, 180, 170);
                Reporte.Graphics.DrawString("Deuda", Titulo2, Brushes.Blue, 320, 170);
                conexion.ConnectionString = CadenaConexion;
                conexion.Open();

                comando.Connection = conexion;
                comando.CommandType = CommandType.TableDirect;
                comando.CommandText = Tabla;

                adaptador = new OleDbDataAdapter(comando);
                DataSet DS = new DataSet();
                adaptador.Fill(DS, Tabla);


                if (DS.Tables[Tabla].Rows.Count > 0)
                {
                    foreach (DataRow fila in DS.Tables[Tabla].Rows)
                    {

                        if (Convert.ToInt32(fila["Deuda"]) > 0)
                        {

                            Reporte.Graphics.DrawString(fila["idSocio"].ToString(), LetraTexto, Brushes.Black, 110, Linea);
                            Reporte.Graphics.DrawString(fila["Nombre"].ToString(), LetraTexto, Brushes.Black, 190, Linea);
                            Reporte.Graphics.DrawString(fila["Deuda"].ToString(), LetraTexto, Brushes.Black, 330, Linea);

                            Linea = Linea + 15;

                            TotDeuda = TotDeuda + Convert.ToDecimal(fila["Deuda"]);
                            Numero = Convert.ToDecimal(fila["Deuda"]);
                            Cant = Cant + 1;


                            if (Numero > NumMayor)
                            {
                                NumMayor = Numero;
                            }
                            if (Numero < NumMenor)
                            {
                                NumMenor = Numero;
                            }
                        }

                    }
                }

                Reporte.Graphics.DrawString("Total Deuda : " + TotDeuda.ToString("0.00"), LetraTexto, Brushes.Blue, 100, 120);
                Reporte.Graphics.DrawString("Promedio Deuda : " + PromedioDeuda.ToString("0.00"), LetraTexto, Brushes.Blue, 100, 140);
                Reporte.Graphics.DrawString("Deuda Menor : " + NumeroMenor, LetraTexto, Brushes.Blue, 250, 120);
                Reporte.Graphics.DrawString("Deuda Mayor : " + NumeroMayor, LetraTexto, Brushes.Blue, 250, 140);



                conexion.Close();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        public void ReporteSociosDeudores(String NombreArchivo)
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

                TotDeuda = 0;
                Cant = 0;
                Numero = 0;
                NumMayor = 0;
                NumMenor = 0;



                StreamWriter AD = new StreamWriter(NombreArchivo, false, Encoding.UTF8);
                AD.WriteLine("Listado de Socios Deudores\n");
                AD.WriteLine("DNI;Nombre;Deuda\n");



                if (DS.Tables[Tabla].Rows.Count > 0)
                {
                    foreach (DataRow x in DS.Tables[Tabla].Rows)
                    {
                        if (Convert.ToInt32(x["Deuda"]) > 0)
                        {
                            AD.Write(x["idSocio"].ToString());
                            AD.Write(";");
                            AD.Write(x["Nombre"]);
                            AD.Write(";");
                            AD.WriteLine(x["Deuda"]);

                            TotDeuda = TotDeuda + Convert.ToDecimal(x["Deuda"]);
                            Numero = Convert.ToDecimal(x["Deuda"]);
                            Cant = Cant + 1;


                            if (Numero > NumMayor)
                            {
                                NumMayor = Numero;
                            }
                            if (Numero < NumMenor)
                            {
                                NumMenor = Numero;
                            }
                        }
                         


                    }
                }

                AD.Write("\nDeuda Mayor:;");
                AD.WriteLine(NumeroMayor);
                AD.Write("Deuda Menor:;");
                AD.WriteLine(NumeroMenor);
                AD.Write("Total de la Deuda:;");
                AD.WriteLine(TotDeuda);
                AD.Write("Promedio Deuda:;");
                AD.WriteLine(PromedioDeuda);


                conexion.Close();
                AD.Close();
            }

            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }


        public void ListarSociosActividad(DataGridView Grilla, Int32 idActividad)
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


                TotDeuda = 0;
                Cant = 0;
                Numero = 0;
                NumMayor = 0;
                NumMenor = 0;


                Grilla.Rows.Clear();



                if (DS.Tables[Tabla].Rows.Count > 0)
                {
                    foreach (DataRow x in DS.Tables[Tabla].Rows)
                    {

                        if (Convert.ToInt32(x["idActividad"]) == idActividad)
                        {

                            Grilla.Rows.Add(x["idSocio"], x["Nombre"], x["Deuda"]);

                            TotDeuda = TotDeuda + Convert.ToDecimal(x["Deuda"]);
                            Numero = Convert.ToDecimal(x["Deuda"]);
                            Cant = Cant + 1;


                            if (Numero > NumMayor)
                            {
                                NumMayor = Numero;
                            }
                            if (Numero < NumMenor)
                            {
                                NumMenor = Numero;
                            }
                        }

                    }
                }
                conexion.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        public void ImprimirSociosActividad(PrintPageEventArgs Reporte, Int32 idActividad)
        {
            try
            {
                Font LetraTexto = new Font("Arial", 8);
                Font Titulo1 = new Font("Arial", 20);
                Font Titulo2 = new Font("Arial",15);
                Font Titulo3 = new Font("Arial", 12);
                Int32 Linea = 230;
                clsActividad act = new clsActividad();
                String nomAct = "";

                TotDeuda = 0;
                Cant = 0;
                Numero = 0;
                NumMayor = 0;
                NumMenor = 0;


                conexion.ConnectionString = CadenaConexion;
                conexion.Open();

                comando.Connection = conexion;
                comando.CommandType = CommandType.TableDirect;
                comando.CommandText = Tabla;

                adaptador = new OleDbDataAdapter(comando);
                DataSet DS = new DataSet();
                adaptador.Fill(DS, Tabla);


                if (DS.Tables[Tabla].Rows.Count > 0)
                {
                    foreach (DataRow fila in DS.Tables[Tabla].Rows)
                    {
                        if (Convert.ToInt32(fila["idActividad"]) == idActividad)
                        {
                            nomAct = act.Buscar(Convert.ToInt32(fila["idActividad"]));

                            Reporte.Graphics.DrawString("Listado de Socios por Actividad", Titulo1, Brushes.Red, 120, 30);
                            Reporte.Graphics.DrawString("Actividad : " + nomAct, Titulo2, Brushes.Red, 100, 80);
                            Reporte.Graphics.DrawString("DNI", Titulo3, Brushes.Blue, 100, 190);
                            Reporte.Graphics.DrawString("Nombre Socio", Titulo3, Brushes.Blue, 180, 190);
                            Reporte.Graphics.DrawString("Deuda", Titulo3, Brushes.Blue, 320, 190);
                            Reporte.Graphics.DrawString(fila["idSocio"].ToString(), LetraTexto, Brushes.Black, 100, Linea);
                            Reporte.Graphics.DrawString(fila["Nombre"].ToString(), LetraTexto, Brushes.Black, 180, Linea);
                            Reporte.Graphics.DrawString(fila["Deuda"].ToString(), LetraTexto, Brushes.Black, 320, Linea);

                             Linea = Linea + 15;

                            TotDeuda = TotDeuda + Convert.ToDecimal(fila["Deuda"]);
                            Numero = Convert.ToDecimal(fila["Deuda"]);
                            Cant = Cant + 1;


                            if (Numero > NumMayor)
                            {
                                NumMayor = Numero;
                            }
                            if (Numero < NumMenor)
                            {
                                NumMenor = Numero;
                            }
                        }

                    }
                }

                Reporte.Graphics.DrawString("Total Deuda : " + TotDeuda.ToString("0.00"), LetraTexto, Brushes.Blue, 100, 120);
                Reporte.Graphics.DrawString("Promedio Deuda : " + PromedioDeuda.ToString("0.00"), LetraTexto, Brushes.Blue, 100, 140);
                Reporte.Graphics.DrawString("Deuda Menor : " + NumeroMenor, LetraTexto, Brushes.Blue, 250, 120);
                Reporte.Graphics.DrawString("Deuda Mayor : " + NumeroMayor, LetraTexto, Brushes.Blue, 250, 140);

                conexion.Close();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        public void ReporteSociosActividad(String NombreArchivo, Int32 idActividad)
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

                TotDeuda = 0;
                Cant = 0;
                Numero = 0;
                NumMayor = 0;
                NumMenor = 0;





                StreamWriter AD = new StreamWriter(NombreArchivo, false, Encoding.UTF8);
                AD.WriteLine("Listado de Socios por Actividad\n");
                AD.WriteLine("Actividad :\n");
                AD.WriteLine("DNI;Nombre;Deuda\n");



                if (DS.Tables[Tabla].Rows.Count > 0)
                {
                    foreach (DataRow x in DS.Tables[Tabla].Rows)
                    {
                        if (Convert.ToInt32(x["idActividad"]) == idActividad)
                        {
                            AD.Write(x["idSocio"].ToString());
                            AD.Write(";");
                            AD.Write(x["Nombre"]);
                            AD.Write(";");
                            AD.WriteLine(x["Deuda"]);

                            TotDeuda = TotDeuda + Convert.ToDecimal(x["Deuda"]);
                            Numero = Convert.ToDecimal(x["Deuda"]);
                            Cant = Cant + 1;


                            if (Numero > NumMayor)
                            {
                                NumMayor = Numero;
                            }
                            if (Numero < NumMenor)
                            {
                                NumMenor = Numero;
                            }
                        }



                    }
                }

                AD.Write("\nDeuda Mayor:;");
                AD.WriteLine(NumeroMayor);
                AD.Write("Deuda Menor:;");
                AD.WriteLine(NumeroMenor);
                AD.Write("Total de la Deuda:;");
                AD.WriteLine(TotDeuda);
                AD.Write("Promedio Deuda:;");
                AD.WriteLine(PromedioDeuda);


                conexion.Close();
                AD.Close();
            }

            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        public void ListarSociosBarrio(DataGridView Grilla, Int32 idBarrio)
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


                TotDeuda = 0;
                Cant = 0;
                Numero = 0;
                NumMayor = 0;
                NumMenor = 0;



                Grilla.Rows.Clear();



                if (DS.Tables[Tabla].Rows.Count > 0)
                {
                    foreach (DataRow x in DS.Tables[Tabla].Rows)
                    {

                        if (Convert.ToInt32(x["idBarrio"]) == idBarrio)
                        {

                            Grilla.Rows.Add(x["idSocio"], x["Nombre"], x["Deuda"]);

                            TotDeuda = TotDeuda + Convert.ToDecimal(x["Deuda"]);
                            Numero = Convert.ToDecimal(x["Deuda"]);
                            Cant = Cant + 1;


                            if (Numero > NumMayor)
                            {
                                NumMayor = Numero;
                            }
                            if (Numero < NumMenor)
                            {
                                NumMenor = Numero;
                            }
                        }

                    }
                }
                conexion.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        public void ImprimirSociosBarrio(PrintPageEventArgs Reporte, Int32 idBarrio)
        {
            try
            {
                Font LetraTexto = new Font("Arial", 8);
                Font Titulo1 = new Font("Arial", 20);
                Font Titulo2 = new Font("Arial", 15);
                Font Titulo3 = new Font("Arial", 12);
                Int32 Linea = 200;
                clsBarrio barr = new clsBarrio();

                String nomBarr = "";

                TotDeuda = 0;
                Cant = 0;
                Numero = 0;
                NumMayor = 0;
                NumMenor = 0;


                conexion.ConnectionString = CadenaConexion;
                conexion.Open();

                comando.Connection = conexion;
                comando.CommandType = CommandType.TableDirect;
                comando.CommandText = Tabla;

                adaptador = new OleDbDataAdapter(comando);
                DataSet DS = new DataSet();
                adaptador.Fill(DS, Tabla);


                if (DS.Tables[Tabla].Rows.Count > 0)
                {
                    foreach (DataRow fila in DS.Tables[Tabla].Rows)
                    {
                        if (Convert.ToInt32(fila["idBarrio"]) == idBarrio)
                        {
                            nomBarr = barr.Buscar(Convert.ToInt32(fila["idBarrio"]));

                            Reporte.Graphics.DrawString("Listado de Socios por Barrio", Titulo1, Brushes.Red, 120, 30);
                            Reporte.Graphics.DrawString("Barrio : "+ nomBarr, Titulo2, Brushes.Red, 100, 80);
                            Reporte.Graphics.DrawString("DNI", Titulo3, Brushes.Blue, 100, 160);
                            Reporte.Graphics.DrawString("Nombre Socio", Titulo3, Brushes.Blue, 180, 160);
                            Reporte.Graphics.DrawString("Deuda", Titulo3, Brushes.Blue, 320, 160);
                            Reporte.Graphics.DrawString(fila["idSocio"].ToString(), LetraTexto, Brushes.Black, 100, Linea);
                            Reporte.Graphics.DrawString(fila["Nombre"].ToString(), LetraTexto, Brushes.Black, 180, Linea);
                            Reporte.Graphics.DrawString(fila["Deuda"].ToString(), LetraTexto, Brushes.Black, 320, Linea);

                            Linea = Linea + 15;

                            TotDeuda = TotDeuda + Convert.ToDecimal(fila["Deuda"]);
                            Numero = Convert.ToDecimal(fila["Deuda"]);
                            Cant = Cant + 1;


                            if (Numero > NumMayor)
                            {
                                NumMayor = Numero;
                            }
                            if (Numero < NumMenor)
                            {
                                NumMenor = Numero;
                            }
                        }

                    }
                }

                Reporte.Graphics.DrawString("Total Deuda : " + TotDeuda.ToString("0.00"), LetraTexto, Brushes.Blue, 100, 120);
                Reporte.Graphics.DrawString("Cantidad de Socios : " + Cantidad, LetraTexto, Brushes.Blue, 250, 120);
               

                conexion.Close();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        public void ReporteSociosBarrio(String NombreArchivo, Int32 idBarrio)
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

                TotDeuda = 0;
                Cant = 0;
                Numero = 0;
                NumMayor = 0;
                NumMenor = 0;





                StreamWriter AD = new StreamWriter(NombreArchivo, false, Encoding.UTF8);
                AD.WriteLine("Listado de Socios por Actividad\n");
                AD.WriteLine("Actividad :\n");
                AD.WriteLine("DNI;Nombre;Deuda\n");



                if (DS.Tables[Tabla].Rows.Count > 0)
                {
                    foreach (DataRow x in DS.Tables[Tabla].Rows)
                    {
                        if (Convert.ToInt32(x["idBarrio"]) == idBarrio)
                        {
                            AD.Write(x["idSocio"].ToString());
                            AD.Write(";");
                            AD.Write(x["Nombre"]);
                            AD.Write(";");
                            AD.WriteLine(x["Deuda"]);

                            TotDeuda = TotDeuda + Convert.ToDecimal(x["Deuda"]);
                            Numero = Convert.ToDecimal(x["Deuda"]);
                            Cant = Cant + 1;


                            if (Numero > NumMayor)
                            {
                                NumMayor = Numero;
                            }
                            if (Numero < NumMenor)
                            {
                                NumMenor = Numero;
                            }
                        }



                    }
                }

               
                AD.Write("Total de la Deuda:;");
                AD.WriteLine(TotDeuda);
                AD.Write("Cantidad de Socios:;");
                AD.WriteLine(Cantidad);



                conexion.Close();
                AD.Close();
            }

            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }
    }
}
