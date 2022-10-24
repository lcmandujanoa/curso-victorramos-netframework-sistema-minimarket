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
    public partial class Frm_Rpt_Provincias : Form
    {
        public Frm_Rpt_Provincias()
        {
            InitializeComponent();
        }

        private void Frm_Rpt_Provincias_Load(object sender, EventArgs e)
        {
            this.uSP_Listado_poTableAdapter.Fill(this.dataSet_MiniMarket.USP_Listado_po, cTexto: txt_p1.Text);

            this.reportViewer1.RefreshReport();
        }
    }
}
