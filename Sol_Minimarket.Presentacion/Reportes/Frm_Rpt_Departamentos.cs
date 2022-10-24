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
    public partial class Frm_Rpt_Departamentos : Form
    {
        public Frm_Rpt_Departamentos()
        {
            InitializeComponent();
        }

        private void Frm_Rpt_Departamentos_Load(object sender, EventArgs e)
        {
            this.uSP_Listado_deTableAdapter.Fill(this.dataSet_MiniMarket.USP_Listado_de, cTexto: txt_p1.Text);

            this.reportViewer1.RefreshReport();
        }
    }
}
