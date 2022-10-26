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
    public partial class Frm_Reporte_Salida_AcumuladaxProducto : Form
    {
        public Frm_Reporte_Salida_AcumuladaxProducto()
        {
            InitializeComponent();
        }

        private void Btn_salir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Btn_vistaprevia_Click(object sender, EventArgs e)
        {
            Frm_Rpt_Salida_AcumuladaxProducto oRpt_SAP = new Frm_Rpt_Salida_AcumuladaxProducto();
            oRpt_SAP.txt_p1.Text = Convert.ToString(Dp_fecha_ini.Value);
            oRpt_SAP.txt_p2.Text = Convert.ToString(Dp_fecha_fin.Value);
            oRpt_SAP.ShowDialog();
        }
    }
}
