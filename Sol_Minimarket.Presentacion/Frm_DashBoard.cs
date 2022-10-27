using Sol_Minimarket.Presentacion.Reportes_Consolidado;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sol_Minimarket.Presentacion
{
    public partial class Frm_DashBoard : Form
    {
        public Frm_DashBoard()
        {
            InitializeComponent();
        }

        #region "Mis Variables"

        private Form activeForm = null;

        #endregion

        #region "Mis Métodos"

        private void openChildForm(Form childForm)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }

            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            Pnl_cuerpo.Controls.Add(childForm);
            childForm.BringToFront();
            childForm.Show();
        }

        #endregion

        private void Frm_DashBoard_Load(object sender, EventArgs e)
        {
            Pnl_procesos.Visible = false;
            Pnl_reportes.Visible = false;
            Pnl_datos_maestros.Visible = false;
            Pnl_sistemas.Visible = false;
        }

        private void Btn_procesos_Click(object sender, EventArgs e)
        {
            Pnl_procesos.Visible = !Pnl_procesos.Visible;
            Pnl_reportes.Visible = false;
            Pnl_datos_maestros.Visible = false;
            Pnl_sistemas.Visible = false;
        }

        private void btn_reportes_Click(object sender, EventArgs e)
        {
            Pnl_procesos.Visible = false;
            Pnl_reportes.Visible = !Pnl_reportes.Visible;
            Pnl_datos_maestros.Visible = false;
            Pnl_sistemas.Visible = false;
        }

        private void Btn_datos_maestros_Click(object sender, EventArgs e)
        {
            Pnl_procesos.Visible = false;
            Pnl_reportes.Visible = false;
            Pnl_datos_maestros.Visible = !Pnl_datos_maestros.Visible;
            Pnl_sistemas.Visible = false;
        }

        private void Btn_sistemas_Click(object sender, EventArgs e)
        {
            Pnl_procesos.Visible = false;
            Pnl_reportes.Visible = false;
            Pnl_datos_maestros.Visible = false;
            Pnl_sistemas.Visible = !Pnl_sistemas.Visible;
        }

        private void Btn_entrada_productos_Click(object sender, EventArgs e)
        {
            openChildForm(new Frm_Entrada_Productos());
        }

        private void Btn_salida_productos_Click(object sender, EventArgs e)
        {
            openChildForm(new Frm_Salida_Productos());
        }

        private void btn_reporte1_Click(object sender, EventArgs e)
        {
            openChildForm(new Frm_Reporte_Ingreso_ComprasxProducto());
        }

        private void Btn_reporte2_Click(object sender, EventArgs e)
        {
            openChildForm(new Frm_Reporte_Ingreso_AcumuladoxProducto());
        }

        private void Btn_reporte3_Click(object sender, EventArgs e)
        {
            openChildForm(new Frm_Reporte_Salida_VentasxProducto());
        }

        private void Btn_reporte4_Click(object sender, EventArgs e)
        {
            openChildForm(new Frm_Reporte_Salida_AcumuladaxProducto());
        }

        private void Btn_productos_Click(object sender, EventArgs e)
        {
            openChildForm(new Frm_Productos());
        }

        private void Btn_marcas_Click(object sender, EventArgs e)
        {
            openChildForm(new Frm_Marcas());
        }

        private void Btn_unidades_medidas_Click(object sender, EventArgs e)
        {
            openChildForm(new Frm_Unidades_Medida());
        }

        private void Btn_categorias_Click(object sender, EventArgs e)
        {
            openChildForm(new Frm_Categorias());
        }

        private void Btn_almacenes_Click(object sender, EventArgs e)
        {
            openChildForm(new Frm_Almacenes());
        }

        private void Btn_clientes_Click(object sender, EventArgs e)
        {
            openChildForm(new Frm_Clientes());
        }

        private void Btn_proveedores_Click(object sender, EventArgs e)
        {
            openChildForm(new Frm_Proveedores());
        }

        private void Btn_rubros_Click(object sender, EventArgs e)
        {
            openChildForm(new Frm_Rubros());
        }

        private void Btn_distritos_Click(object sender, EventArgs e)
        {
            openChildForm(new Frm_Distritos());
        }

        private void Btn_provincias_Click(object sender, EventArgs e)
        {
            openChildForm(new Frm_Provincias());
        }

        private void Btn_departamentos_Click(object sender, EventArgs e)
        {
            openChildForm(new Frm_Departamentos());

        }

        private void Btn_usuarios_sistemas_Click(object sender, EventArgs e)
        {
            openChildForm(new Frm_Usuarios());
        }

        private void Btn_cerrar_sesion_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
