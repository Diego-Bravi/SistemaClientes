namespace SistemaClientes
{
    partial class frmListadoActividad
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbActividad = new System.Windows.Forms.ComboBox();
            this.lblMayor = new System.Windows.Forms.Label();
            this.lblMenor = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblPromedio = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.cmdImprimir = new System.Windows.Forms.Button();
            this.cmdReporte = new System.Windows.Forms.Button();
            this.cmdListar = new System.Windows.Forms.Button();
            this.Grilla = new System.Windows.Forms.DataGridView();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prtVentana = new System.Windows.Forms.PrintDialog();
            this.prtDocument = new System.Drawing.Printing.PrintDocument();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grilla)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbActividad);
            this.groupBox1.Controls.Add(this.lblMayor);
            this.groupBox1.Controls.Add(this.lblMenor);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.lblPromedio);
            this.groupBox1.Controls.Add(this.lblTotal);
            this.groupBox1.Controls.Add(this.cmdImprimir);
            this.groupBox1.Controls.Add(this.cmdReporte);
            this.groupBox1.Controls.Add(this.cmdListar);
            this.groupBox1.Controls.Add(this.Grilla);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(534, 451);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Consulta de Datos";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // cmbActividad
            // 
            this.cmbActividad.FormattingEnabled = true;
            this.cmbActividad.Location = new System.Drawing.Point(98, 31);
            this.cmbActividad.Name = "cmbActividad";
            this.cmbActividad.Size = new System.Drawing.Size(184, 21);
            this.cmbActividad.TabIndex = 24;
            // 
            // lblMayor
            // 
            this.lblMayor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblMayor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblMayor.Location = new System.Drawing.Point(178, 336);
            this.lblMayor.Name = "lblMayor";
            this.lblMayor.Size = new System.Drawing.Size(100, 23);
            this.lblMayor.TabIndex = 26;
            // 
            // lblMenor
            // 
            this.lblMenor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblMenor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblMenor.Location = new System.Drawing.Point(178, 302);
            this.lblMenor.Name = "lblMenor";
            this.lblMenor.Size = new System.Drawing.Size(100, 23);
            this.lblMenor.TabIndex = 25;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label4.Location = new System.Drawing.Point(19, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 17);
            this.label4.TabIndex = 22;
            this.label4.Text = "Actividad :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label2.Location = new System.Drawing.Point(20, 339);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(152, 17);
            this.label2.TabIndex = 24;
            this.label2.Text = "Importe Deuda Mayor :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.Location = new System.Drawing.Point(19, 302);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 17);
            this.label1.TabIndex = 23;
            this.label1.Text = "Importe Deuda Menor :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label3.Location = new System.Drawing.Point(297, 312);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 17);
            this.label3.TabIndex = 22;
            this.label3.Text = "Total de Deuda :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label7.Location = new System.Drawing.Point(292, 339);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(142, 17);
            this.label7.TabIndex = 21;
            this.label7.Text = "Promedio de Deuda :";
            // 
            // lblPromedio
            // 
            this.lblPromedio.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblPromedio.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblPromedio.Location = new System.Drawing.Point(440, 339);
            this.lblPromedio.Name = "lblPromedio";
            this.lblPromedio.Size = new System.Drawing.Size(87, 23);
            this.lblPromedio.TabIndex = 20;
            // 
            // lblTotal
            // 
            this.lblTotal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblTotal.Location = new System.Drawing.Point(417, 311);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(100, 23);
            this.lblTotal.TabIndex = 19;
            // 
            // cmdImprimir
            // 
            this.cmdImprimir.Enabled = false;
            this.cmdImprimir.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cmdImprimir.Location = new System.Drawing.Point(37, 404);
            this.cmdImprimir.Name = "cmdImprimir";
            this.cmdImprimir.Size = new System.Drawing.Size(124, 26);
            this.cmdImprimir.TabIndex = 10;
            this.cmdImprimir.Text = "Imprimir Reporte";
            this.cmdImprimir.UseVisualStyleBackColor = true;
            this.cmdImprimir.Click += new System.EventHandler(this.cmdImprimir_Click);
            // 
            // cmdReporte
            // 
            this.cmdReporte.Enabled = false;
            this.cmdReporte.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cmdReporte.Location = new System.Drawing.Point(205, 404);
            this.cmdReporte.Name = "cmdReporte";
            this.cmdReporte.Size = new System.Drawing.Size(124, 26);
            this.cmdReporte.TabIndex = 8;
            this.cmdReporte.Text = "Generar Reporte";
            this.cmdReporte.UseVisualStyleBackColor = true;
            this.cmdReporte.Click += new System.EventHandler(this.cmdReporte_Click);
            // 
            // cmdListar
            // 
            this.cmdListar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cmdListar.Location = new System.Drawing.Point(364, 404);
            this.cmdListar.Name = "cmdListar";
            this.cmdListar.Size = new System.Drawing.Size(135, 26);
            this.cmdListar.TabIndex = 7;
            this.cmdListar.Text = "Listar";
            this.cmdListar.UseVisualStyleBackColor = true;
            this.cmdListar.Click += new System.EventHandler(this.cmdListar_Click);
            // 
            // Grilla
            // 
            this.Grilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grilla.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Codigo,
            this.Column1,
            this.Column4});
            this.Grilla.Location = new System.Drawing.Point(6, 68);
            this.Grilla.Name = "Grilla";
            this.Grilla.Size = new System.Drawing.Size(522, 219);
            this.Grilla.TabIndex = 0;
            // 
            // Codigo
            // 
            this.Codigo.HeaderText = "Codigo";
            this.Codigo.Name = "Codigo";
            this.Codigo.Width = 60;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Nombre y Apellido";
            this.Column1.Name = "Column1";
            this.Column1.Width = 250;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Deuda";
            this.Column4.Name = "Column4";
            this.Column4.Width = 130;
            // 
            // prtVentana
            // 
            this.prtVentana.UseEXDialog = true;
            // 
            // prtDocument
            // 
            this.prtDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.prtDocument_PrintPage);
            // 
            // frmListadoActividad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(556, 471);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmListadoActividad";
            this.Text = "Listado Actividad";
            this.Load += new System.EventHandler(this.frmListadoActividad_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grilla)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblMayor;
        private System.Windows.Forms.Label lblMenor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblPromedio;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button cmdImprimir;
        private System.Windows.Forms.Button cmdReporte;
        private System.Windows.Forms.Button cmdListar;
        private System.Windows.Forms.DataGridView Grilla;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.ComboBox cmbActividad;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PrintDialog prtVentana;
        private System.Drawing.Printing.PrintDocument prtDocument;
    }
}