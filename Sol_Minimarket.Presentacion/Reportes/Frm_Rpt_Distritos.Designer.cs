namespace Sol_Minimarket.Presentacion.Reportes
{
    partial class Frm_Rpt_Distritos
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
            this.uSPListadodiBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.uSP_Listado_diTableAdapter = new Sol_Minimarket.Presentacion.Reportes.DataSet_MiniMarketTableAdapters.USP_Listado_diTableAdapter();
            this.txt_p1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet_MiniMarket)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uSPListadodiBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource2.Name = "DataSet1";
            reportDataSource2.Value = this.uSPListadodiBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Sol_Minimarket.Presentacion.Reportes.Rpt_Distritos.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(706, 355);
            this.reportViewer1.TabIndex = 0;
            // 
            // dataSet_MiniMarket
            // 
            this.dataSet_MiniMarket.DataSetName = "DataSet_MiniMarket";
            this.dataSet_MiniMarket.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // uSPListadodiBindingSource
            // 
            this.uSPListadodiBindingSource.DataMember = "USP_Listado_di";
            this.uSPListadodiBindingSource.DataSource = this.dataSet_MiniMarket;
            // 
            // uSP_Listado_diTableAdapter
            // 
            this.uSP_Listado_diTableAdapter.ClearBeforeFill = true;
            // 
            // txt_p1
            // 
            this.txt_p1.Location = new System.Drawing.Point(23, 44);
            this.txt_p1.Name = "txt_p1";
            this.txt_p1.Size = new System.Drawing.Size(100, 20);
            this.txt_p1.TabIndex = 3;
            this.txt_p1.Visible = false;
            // 
            // Frm_Rpt_Distritos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(706, 355);
            this.Controls.Add(this.txt_p1);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Frm_Rpt_Distritos";
            this.Text = "Frm_Rpt_Distritos";
            this.Load += new System.EventHandler(this.Frm_Rpt_Distritos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataSet_MiniMarket)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uSPListadodiBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource uSPListadodiBindingSource;
        private DataSet_MiniMarket dataSet_MiniMarket;
        private DataSet_MiniMarketTableAdapters.USP_Listado_diTableAdapter uSP_Listado_diTableAdapter;
        public System.Windows.Forms.TextBox txt_p1;
    }
}