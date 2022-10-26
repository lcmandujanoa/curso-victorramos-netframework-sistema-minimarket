namespace Sol_Minimarket.Presentacion.Reportes
{
    partial class Frm_Rpt_Salida_Productos
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dataSet_MiniMarket = new Sol_Minimarket.Presentacion.Reportes.DataSet_MiniMarket();
            this.uSPListadospBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.uSP_Listado_spTableAdapter = new Sol_Minimarket.Presentacion.Reportes.DataSet_MiniMarketTableAdapters.USP_Listado_spTableAdapter();
            this.txt_p1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet_MiniMarket)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uSPListadospBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource2.Name = "DataSet1";
            reportDataSource2.Value = this.uSPListadospBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Sol_Minimarket.Presentacion.Reportes.Rpt_Salida_Productos.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1097, 450);
            this.reportViewer1.TabIndex = 0;
            // 
            // dataSet_MiniMarket
            // 
            this.dataSet_MiniMarket.DataSetName = "DataSet_MiniMarket";
            this.dataSet_MiniMarket.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // uSPListadospBindingSource
            // 
            this.uSPListadospBindingSource.DataMember = "USP_Listado_sp";
            this.uSPListadospBindingSource.DataSource = this.dataSet_MiniMarket;
            // 
            // uSP_Listado_spTableAdapter
            // 
            this.uSP_Listado_spTableAdapter.ClearBeforeFill = true;
            // 
            // txt_p1
            // 
            this.txt_p1.Location = new System.Drawing.Point(22, 43);
            this.txt_p1.Name = "txt_p1";
            this.txt_p1.Size = new System.Drawing.Size(100, 20);
            this.txt_p1.TabIndex = 4;
            this.txt_p1.Visible = false;
            // 
            // Frm_Rpt_Salida_Productos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1097, 450);
            this.Controls.Add(this.txt_p1);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Frm_Rpt_Salida_Productos";
            this.Text = "Frm_Rpt_Salida_Productos";
            this.Load += new System.EventHandler(this.Frm_Rpt_Salida_Productos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataSet_MiniMarket)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uSPListadospBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource uSPListadospBindingSource;
        private DataSet_MiniMarket dataSet_MiniMarket;
        private DataSet_MiniMarketTableAdapters.USP_Listado_spTableAdapter uSP_Listado_spTableAdapter;
        public System.Windows.Forms.TextBox txt_p1;
    }
}