using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sol_Minimarket.Entidades;
using Sol_Minimarket.Negocio;

namespace Sol_Minimarket.Presentacion
{
    public partial class Frm_Proveedores : Form
    {
        public Frm_Proveedores()
        {
            InitializeComponent();
        }

        #region "Mis Variables"
        int Codigo_pr = 0;
        int Codigo_ma = 0;
        int Codigo_um = 0;
        int Codigo_ca = 0;
        int Estadoguarda = 0; //Sin ninguna acción
        #endregion

        #region "Mis Métodos"
        private void Formato_pr()
        {
            Dgv_principal.Columns[0].Width = 90;
            Dgv_principal.Columns[0].HeaderText = "CÓDIGO_PR";
            Dgv_principal.Columns[1].Width = 250;
            Dgv_principal.Columns[1].HeaderText = "PRODUCTO";
            Dgv_principal.Columns[2].Width = 170;
            Dgv_principal.Columns[2].HeaderText = "MARCA";
            Dgv_principal.Columns[3].Width = 90;
            Dgv_principal.Columns[3].HeaderText = "U.MEDIDA";
            Dgv_principal.Columns[4].Width = 170;
            Dgv_principal.Columns[4].HeaderText = "CATEGORÍA";
            Dgv_principal.Columns[5].Width = 105;
            Dgv_principal.Columns[5].HeaderText = "STOCK MIN";
            Dgv_principal.Columns[6].Width = 105;
            Dgv_principal.Columns[6].HeaderText = "STOCK MAX";
            Dgv_principal.Columns[7].Visible = false;
            Dgv_principal.Columns[8].Visible = false;
            Dgv_principal.Columns[9].Visible = false;
        }

        private void Listado_pr(string cTexto)
        {
            try
            {
                Dgv_principal.DataSource = N_Productos.Listado_pr(cTexto);
                this.Formato_pr();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void Estado_Botonesprincipales(bool lEstado) 
        {
            this.Btn_nuevo.Enabled = lEstado;
            this.Btn_actualizar.Enabled = lEstado;
            this.Btn_eliminar.Enabled = lEstado;
            this.Btn_reporte.Enabled = lEstado;
            this.Btn_salir.Enabled = lEstado;
        }

        private void Estado_Botonesprocesos(bool lEstado)
        {
            this.Btn_cancelar.Visible = lEstado;
            this.Btn_guardar.Visible = lEstado;
            this.Btn_retornar.Visible = !lEstado;
        }

        private void Selecciona_item()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Dgv_principal.CurrentRow.Cells["codigo_pr"].Value)))
            {
                MessageBox.Show("No se tiene información para visualizar", "Aviso del sistema",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                this.Codigo_pr = Convert.ToInt32(Dgv_principal.CurrentRow.Cells["codigo_pr"].Value);
                Txt_nrodocumento_pv.Text = Convert.ToString(Dgv_principal.CurrentRow.Cells["descripcion_pr"].Value);
                Codigo_ma = Convert.ToInt32(Dgv_principal.CurrentRow.Cells["codigo_ma"].Value);
                Txt_descripcion_tdpc.Text = Convert.ToString(Dgv_principal.CurrentRow.Cells["descripcion_ma"].Value);
                Codigo_um = Convert.ToInt32(Dgv_principal.CurrentRow.Cells["codigo_um"].Value);
                Txt_descripcion_sx.Text = Convert.ToString(Dgv_principal.CurrentRow.Cells["descripcion_um"].Value);
                Codigo_ca = Convert.ToInt32(Dgv_principal.CurrentRow.Cells["codigo_ca"].Value);
                Txt_descripcion_ru.Text = Convert.ToString(Dgv_principal.CurrentRow.Cells["descripcion_ca"].Value);

                Txt_stock_min.Text = Convert.ToString(Dgv_principal.CurrentRow.Cells["stock_min"].Value);
                Txt_stock_max.Text = Convert.ToString(Dgv_principal.CurrentRow.Cells["stock_max"].Value);
            }
        }

        private void Formato_ma_pr()
        {
            Dgv_marcas.Columns[0].Width = 200;
            Dgv_marcas.Columns[0].HeaderText = "MARCA";
            Dgv_marcas.Columns[1].Visible = false;
        }

        private void Listado_ma_pr(string cTexto)
        {
            try
            {
                Dgv_marcas.DataSource = N_Productos.Listado_ma_pr(cTexto);
                this.Formato_ma_pr();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void Selecciona_item_ma_pr()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Dgv_marcas.CurrentRow.Cells["codigo_ma"].Value)))
            {
                MessageBox.Show("No se tiene información para visualizar", "Aviso del sistema",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                this.Codigo_ma = Convert.ToInt32(Dgv_marcas.CurrentRow.Cells["codigo_ma"].Value);
                Txt_descripcion_tdpc.Text = Convert.ToString(Dgv_marcas.CurrentRow.Cells["descripcion_ma"].Value);
            }
        }

        private void Formato_um_pr()
        {
            Dgv_medidas.Columns[0].Width = 200;
            Dgv_medidas.Columns[0].HeaderText = "MEDIDAS";
            Dgv_medidas.Columns[1].Visible = false;
        }

        private void Listado_um_pr(string cTexto)
        {
            try
            {
                Dgv_medidas.DataSource = N_Productos.Listado_um_pr(cTexto);
                this.Formato_um_pr();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void Selecciona_item_um_pr()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Dgv_medidas.CurrentRow.Cells["codigo_um"].Value)))
            {
                MessageBox.Show("No se tiene información para visualizar", "Aviso del sistema",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                this.Codigo_um = Convert.ToInt32(Dgv_medidas.CurrentRow.Cells["codigo_um"].Value);
                Txt_descripcion_sx.Text = Convert.ToString(Dgv_medidas.CurrentRow.Cells["descripcion_um"].Value);
            }
        }

        private void Formato_ca_pr()
        {
            Dgv_categorias.Columns[0].Width = 200;
            Dgv_categorias.Columns[0].HeaderText = "CATEGORÍAS";
            Dgv_categorias.Columns[1].Visible = false;
        }

        private void Listado_ca_pr(string cTexto)
        {
            try
            {
                Dgv_categorias.DataSource = N_Productos.Listado_ca_pr(cTexto);
                Formato_ca_pr();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void Selecciona_item_ca_pr()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Dgv_categorias.CurrentRow.Cells["codigo_ca"].Value)))
            {
                MessageBox.Show("No se tiene información para visualizar", "Aviso del sistema",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Codigo_ca = Convert.ToInt32(Dgv_categorias.CurrentRow.Cells["codigo_ca"].Value);
                Txt_descripcion_ru.Text = Convert.ToString(Dgv_categorias.CurrentRow.Cells["descripcion_ca"].Value);
            }
        }

        private void Formato_stock_actual()
        {
            Dgv_Stock_actual.Columns[0].Width = 200;
            Dgv_Stock_actual.Columns[0].HeaderText = "ALMACÉN";
            Dgv_Stock_actual.Columns[1].Width = 125;
            Dgv_Stock_actual.Columns[1].HeaderText = "STOCK ACTUAL";
            Dgv_Stock_actual.Columns[2].Width = 125;
            Dgv_Stock_actual.Columns[2].HeaderText = "PU COMPRA";
        }

        private void Listado_stock_actual(int nCodigo_pr)
        {
            try
            {
                Dgv_Stock_actual.DataSource = N_Productos.Ver_Stock_actual_ProductoxAlmacenes(nCodigo_pr);
                Formato_stock_actual();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
        #endregion

        private void Frm_Proveedores_Load(object sender, EventArgs e)
        {
            this.Listado_pr("%");
            this.Listado_ma_pr("%");
            this.Listado_um_pr("%");
            this.Listado_ca_pr("%");
        }

        private void Btn_guardar_Click(object sender, EventArgs e)
        {
            if (Txt_nrodocumento_pv.Text == string.Empty ||
                Txt_descripcion_tdpc.Text == string.Empty ||
                Txt_descripcion_sx.Text == string.Empty ||
                Txt_descripcion_ru.Text == string.Empty)
            {
                MessageBox.Show("Falta ingresar datos requeridos (*)", "Aviso del Sistema",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else //Se procedería a ingresar la información
            {
                E_Productos oPr = new E_Productos();
                string Rpta = "";
                oPr.Codigo_pr = this.Codigo_pr;
                oPr.Descripcion_pr = Txt_nrodocumento_pv.Text;
                oPr.Codigo_ma = Codigo_ma;
                oPr.Codigo_um = Codigo_um;
                oPr.Codigo_ca = Codigo_ca;
                oPr.Stock_min = Convert.ToDecimal(Txt_stock_min.Text);
                oPr.Stock_max = Convert.ToDecimal(Txt_stock_max.Text);
                Rpta = N_Productos.Guardar_pr(Estadoguarda, oPr);
                if (Rpta == "OK")
                {
                    this.Listado_pr("%");
                    MessageBox.Show("Los datos han sido guardados correctamente", "Aviso del Sistema",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Estadoguarda = 0; //Sin ninguna acción
                    this.Estado_Botonesprincipales(true);
                    this.Estado_Botonesprocesos(false);
                    Txt_nrodocumento_pv.Text = "";
                    Txt_stock_min.Text = "0";
                    Txt_stock_max.Text = "0";
                    Txt_nrodocumento_pv.ReadOnly = true;
                    Txt_stock_min.ReadOnly = true;
                    Txt_stock_max.ReadOnly = true;
                    Tbc_principal.SelectedIndex = 0;
                    this.Codigo_pr = 0;
                    Gbx_detalle.Visible = false;
                }
                else
                {
                    MessageBox.Show(Rpta, "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Btn_nuevo_Click(object sender, EventArgs e)
        {
            Estadoguarda = 1; //Nuevo Registro
            Gbx_detalle.Visible = false;
            this.Estado_Botonesprincipales(false);
            this.Estado_Botonesprocesos(true);
            Txt_nrodocumento_pv.Text = "";
            Txt_stock_min.Text = "0";
            Txt_stock_max.Text = "0";
            Txt_nrodocumento_pv.ReadOnly = false;
            Txt_stock_min.ReadOnly = false;
            Txt_stock_max.ReadOnly = false;
            Tbc_principal.SelectedIndex = 1;
            Txt_nrodocumento_pv.Focus();
        }

        private void Btn_actualizar_Click(object sender, EventArgs e)
        {
            Estadoguarda = 2; //Actualizar registro
            Gbx_detalle.Visible = false;
            this.Estado_Botonesprincipales(false);
            this.Estado_Botonesprocesos(true);
            this.Selecciona_item();
            Tbc_principal.SelectedIndex = 1;
            Txt_nrodocumento_pv.ReadOnly = false;
            Txt_nrodocumento_pv.Focus();
        }

        private void Btn_cancelar_Click(object sender, EventArgs e)
        {
            Estadoguarda = 0; //Sin ninguna acción
            Gbx_detalle.Visible = false;
            this.Codigo_pr = 0;
            Txt_nrodocumento_pv.Text = "";
            Txt_stock_min.Text = "0";
            Txt_stock_max.Text = "0";
            Txt_nrodocumento_pv.ReadOnly = true;
            Txt_stock_min.ReadOnly = true;
            Txt_stock_max.ReadOnly = true;
            this.Estado_Botonesprincipales(true);
            this.Estado_Botonesprocesos(false);
            Tbc_principal.SelectedIndex = 0;
        }

        private void Dgv_principal_DoubleClick(object sender, EventArgs e)
        {
            this.Selecciona_item();
            this.Estado_Botonesprocesos(false);
            Tbc_principal.SelectedIndex = 1;
            Listado_stock_actual(Codigo_pr);
            Gbx_detalle.Visible = true;
        }

        private void Btn_retornar_Click(object sender, EventArgs e)
        {
            this.Estado_Botonesprocesos(false);
            Tbc_principal.SelectedIndex = 0;
            this.Codigo_pr = 0;
            Gbx_detalle.Visible = false;

            Btn_retornar.Visible = false;
            Txt_nrodocumento_pv.Text = "";
        }

        private void Btn_eliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Dgv_principal.CurrentRow.Cells["codigo_al"].Value)))
            {
                MessageBox.Show("No se tiene información para visualizar", "Aviso del sistema",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("¿Estás seguro de eliminar el registro seleccionado?", "Aviso del sistema",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(Opcion == DialogResult.Yes)
                {
                    string Rpta = "";
                    this.Codigo_pr = Convert.ToInt32(Dgv_principal.CurrentRow.Cells["codigo_al"].Value);
                    Rpta = N_Productos.Eliminar_pr(this.Codigo_pr);
                    if (Rpta.Equals("OK"))
                    {
                        this.Listado_pr("%");
                        this.Codigo_pr = 0;
                        MessageBox.Show("Registro Eliminado", "Aviso del Sistema",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                }
            }
        }

        private void Btn_buscar_Click(object sender, EventArgs e)
        {
            this.Listado_pr(Txt_buscar.Text.Trim());
        }

        private void Btn_reporte_Click(object sender, EventArgs e)
        {
            //Reportes.Frm_Rpt_Almacenes oRpta4 = new Reportes.Frm_Rpt_Almacenes();
            //oRpta4.txt_p1.Text = Txt_buscar.Text;
            //oRpta4.ShowDialog();
        }

        private void Btn_salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Btn_lupa1_Click(object sender, EventArgs e)
        {
            this.Pnl_Listado_ma.Location = Btn_lupa1.Location;
            this.Pnl_Listado_ma.Visible = true;
        }

        private void Dgv_marcas_DoubleClick(object sender, EventArgs e)
        {
            this.Selecciona_item_ma_pr();
            Pnl_Listado_ma.Visible = false;
        }

        private void Btn_lupa2_Click(object sender, EventArgs e)
        {
            this.Pnl_Listado_um.Location = Btn_lupa1.Location;
            this.Pnl_Listado_um.Visible = true;
        }

        private void Btn_buscar1_Click(object sender, EventArgs e)
        {
            this.Listado_ma_pr(Txt_buscar1.Text);
        }

        private void Btn_buscar2_Click(object sender, EventArgs e)
        {
            this.Listado_um_pr(Txt_buscar2.Text);
        }

        private void Btn_retornar1_Click(object sender, EventArgs e)
        {
            Pnl_Listado_ma.Visible = false;
        }

        private void Btn_retornar2_Click(object sender, EventArgs e)
        {
            Pnl_Listado_um.Visible = false;
        }

        private void Dgv_medidas_DoubleClick(object sender, EventArgs e)
        {
            Selecciona_item_um_pr();
            Pnl_Listado_um.Visible = false;
        }

        private void Btn_lupa3_Click(object sender, EventArgs e)
        {
            Pnl_Listado_ca.Location = Btn_lupa1.Location;
            Pnl_Listado_ca.Visible = true;
        }

        private void Dgv_categorias_DoubleClick(object sender, EventArgs e)
        {
            Selecciona_item_ca_pr();
            Pnl_Listado_ca.Visible = false;
        }

        private void Btn_retornar3_Click(object sender, EventArgs e)
        {
            Pnl_Listado_ca.Visible = false;
        }
    }
}
