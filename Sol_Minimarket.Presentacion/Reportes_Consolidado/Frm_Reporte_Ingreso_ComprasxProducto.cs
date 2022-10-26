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
    public partial class Frm_Reporte_Ingreso_ComprasxProducto : Form
    {
        public Frm_Reporte_Ingreso_ComprasxProducto()
        {
            InitializeComponent();
        }

        private void Btn_salir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Btn_vistaprevia_Click(object sender, EventArgs e)
        {
            Frm_Rpt_Ingreso_ComprasxProductos oRpt_ICP = new Frm_Rpt_Ingreso_ComprasxProductos();
            oRpt_ICP.txt_p1.Text = Convert.ToString(Dp_fecha_ini.Value);
            oRpt_ICP.txt_p2.Text = Convert.ToString(Dp_fecha_fin.Value);
            oRpt_ICP.ShowDialog();
        }
    }
}
