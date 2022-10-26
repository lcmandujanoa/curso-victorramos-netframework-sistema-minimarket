using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sol_Minimarket.Presentacion.Reportes_Consolidado
{
    public partial class Frm_Rpt_Ingreso_ComprasxProductos : Form
    {
        public Frm_Rpt_Ingreso_ComprasxProductos()
        {
            InitializeComponent();
        }

        private void Frm_Rpt_Ingreso_ComprasxProductos_Load(object sender, EventArgs e)
        {
            uSP_Reporte_Ingresos_ComprasxProductosTableAdapter
                .Fill(dataSet_Reportes_Consolidado.USP_Reporte_Ingresos_ComprasxProductos, 
                        Fecha_ini: Convert.ToDateTime(txt_p1.Text), 
                        Fecha_fin: Convert.ToDateTime(txt_p2.Text));

            this.reportViewer1.RefreshReport();
        }
    }
}
