namespace Sol_Minimarket.Presentacion.Reportes_Consolidado
{
    partial class Frm_Rpt_Ingreso_ComprasxProductos
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dataSet_Reportes_Consolidado = new Sol_Minimarket.Presentacion.Reportes_Consolidado.DataSet_Reportes_Consolidado();
            this.uSPReporteIngresosComprasxProductosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.uSP_Reporte_Ingresos_ComprasxProductosTableAdapter = new Sol_Minimarket.Presentacion.Reportes_Consolidado.DataSet_Reportes_ConsolidadoTableAdapters.USP_Reporte_Ingresos_ComprasxProductosTableAdapter();
            this.txt_p1 = new System.Windows.Forms.TextBox();
            this.txt_p2 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet_Reportes_Consolidado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uSPReporteIngresosComprasxProductosBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.uSPReporteIngresosComprasxProductosBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Sol_Minimarket.Presentacion.Reportes_Consolidado.Rpt_Ingreso_ComprasxProductos.rd" +
    "lc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 450);
            this.reportViewer1.TabIndex = 0;
            // 
            // dataSet_Reportes_Consolidado
            // 
            this.dataSet_Reportes_Consolidado.DataSetName = "DataSet_Reportes_Consolidado";
            this.dataSet_Reportes_Consolidado.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // uSPReporteIngresosComprasxProductosBindingSource
            // 
            this.uSPReporteIngresosComprasxProductosBindingSource.DataMember = "USP_Reporte_Ingresos_ComprasxProductos";
            this.uSPReporteIngresosComprasxProductosBindingSource.DataSource = this.dataSet_Reportes_Consolidado;
            // 
            // uSP_Reporte_Ingresos_ComprasxProductosTableAdapter
            // 
            this.uSP_Reporte_Ingresos_ComprasxProductosTableAdapter.ClearBeforeFill = true;
            // 
            // txt_p1
            // 
            this.txt_p1.Location = new System.Drawing.Point(28, 53);
            this.txt_p1.Name = "txt_p1";
            this.txt_p1.Size = new System.Drawing.Size(100, 20);
            this.txt_p1.TabIndex = 2;
            this.txt_p1.Visible = false;
            // 
            // txt_p2
            // 
            this.txt_p2.Location = new System.Drawing.Point(28, 79);
            this.txt_p2.Name = "txt_p2";
            this.txt_p2.Size = new System.Drawing.Size(100, 20);
            this.txt_p2.TabIndex = 3;
            this.txt_p2.Visible = false;
            // 
            // Frm_Rpt_Ingreso_ComprasxProductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txt_p2);
            this.Controls.Add(this.txt_p1);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Frm_Rpt_Ingreso_ComprasxProductos";
            this.Text = "Frm_Rpt_Ingreso_ComprasxProductos";
            this.Load += new System.EventHandler(this.Frm_Rpt_Ingreso_ComprasxProductos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataSet_Reportes_Consolidado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uSPReporteIngresosComprasxProductosBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource uSPReporteIngresosComprasxProductosBindingSource;
        private DataSet_Reportes_Consolidado dataSet_Reportes_Consolidado;
        private DataSet_Reportes_ConsolidadoTableAdapters.USP_Reporte_Ingresos_ComprasxProductosTableAdapter uSP_Reporte_Ingresos_ComprasxProductosTableAdapter;
        public System.Windows.Forms.TextBox txt_p1;
        public System.Windows.Forms.TextBox txt_p2;
    }
}