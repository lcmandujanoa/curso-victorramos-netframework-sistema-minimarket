using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sol_Minimarket.Presentacion.Reportes
{
    public partial class Frm_Rpt_Entrada_Productos : Form
    {
        public Frm_Rpt_Entrada_Productos()
        {
            InitializeComponent();
        }

        private void Frm_Rpt_Entrada_Productos_Load(object sender, EventArgs e)
        {
            uSP_Listado_epTableAdapter.Fill(dataSet_MiniMarket.USP_Listado_ep, cTexto: txt_p1.Text);

            this.reportViewer1.RefreshReport();
        }
    }
}
