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
    public partial class Frm_Entrada_Productos : Form
    {
        public Frm_Entrada_Productos()
        {
            InitializeComponent();
        }

        #region "Mis Variables"
        int Codigo_ep = 0;
        int Codigo_tde = 0;
        int Codigo_pv = 0;
        int Codigo_al = 0;
        int Estadoguarda = 0;
        DataTable TablaDetalle = new DataTable();
        #endregion

        #region "Mis Métodos"
        private void Formato_ep()
        {
            Dgv_principal.Columns[0].Width = 85;
            Dgv_principal.Columns[0].HeaderText = "CÓDIGO_EP";
            Dgv_principal.Columns[1].Width = 95;
            Dgv_principal.Columns[1].HeaderText = "TIPO DOC";
            Dgv_principal.Columns[2].Width = 110;
            Dgv_principal.Columns[2].HeaderText = "NRO DOC";
            Dgv_principal.Columns[3].Width = 120;
            Dgv_principal.Columns[3].HeaderText = "FECHA DOC";
            Dgv_principal.Columns[4].Width = 260;
            Dgv_principal.Columns[4].HeaderText = "PROVEEDOR";
            Dgv_principal.Columns[5].Width = 170;
            Dgv_principal.Columns[5].HeaderText = "ALMACÉN";
            Dgv_principal.Columns[6].Width = 135;
            Dgv_principal.Columns[6].HeaderText = "TOTAL IMPORTE";
            Dgv_principal.Columns[7].Visible = false;
            Dgv_principal.Columns[8].Visible = false;
            Dgv_principal.Columns[9].Visible = false;
            Dgv_principal.Columns[10].Visible = false;
            Dgv_principal.Columns[11].Visible = false;
            Dgv_principal.Columns[12].Visible = false;
        }

        private void Listado_ep(string cTexto)
        {
            try
            {
                Dgv_principal.DataSource = N_Entrada_Productos.Listado_ep(cTexto);
                Formato_ep();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void Estado_Botonesprincipales(bool lEstado) 
        {
            Btn_nuevo.Enabled = lEstado;
            Btn_eliminar.Enabled = lEstado;
            Btn_reporte.Enabled = lEstado;
            Btn_salir.Enabled = lEstado;
        }

        private void Estado_Botonesprocesos(bool lEstado)
        {
            Btn_cancelar.Visible = lEstado;
            Btn_guardar.Visible = lEstado;
            Btn_retornar.Visible = !lEstado;

            Btn_agregar.Visible = lEstado;
            Btn_quitar.Visible = lEstado;

            Btn_lupa1.Visible = lEstado;
            Btn_lupa2.Visible = lEstado;
            Btn_lupa3.Visible = lEstado;
        }

        private void Selecciona_item()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Dgv_principal.CurrentRow.Cells["codigo_ep"].Value)))
            {
                MessageBox.Show("No se tiene información para visualizar", "Aviso del sistema",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Codigo_ep = Convert.ToInt32(Dgv_principal.CurrentRow.Cells["codigo_ep"].Value);
                Codigo_tde = Convert.ToInt32(Dgv_principal.CurrentRow.Cells["codigo_tde"].Value);
                Codigo_pv = Convert.ToInt32(Dgv_principal.CurrentRow.Cells["codigo_pv"].Value);
                Codigo_al = Convert.ToInt32(Dgv_principal.CurrentRow.Cells["codigo_al"].Value);
                Txt_descripcion_tde.Text = Dgv_principal.CurrentRow.Cells["descripcion_tde"].Value.ToString();
                Txt_nrodocumento_ep.Text = Dgv_principal.CurrentRow.Cells["nrodocumento_ep"].Value.ToString();
                Dtp_fecha_ep.Value = Convert.ToDateTime(Dgv_principal.CurrentRow.Cells["fecha_ep"].Value);
                Txt_razon_social_pv.Text = Dgv_principal.CurrentRow.Cells["razon_social_pv"].Value.ToString();
                Txt_descripcion_al.Text = Dgv_principal.CurrentRow.Cells["descripcion_al"].Value.ToString();
                Txt_observacion_ep.Text = Dgv_principal.CurrentRow.Cells["observacion_ep"].Value.ToString();
                Txt_subtotal.Text = Dgv_principal.CurrentRow.Cells["subtotal"].Value.ToString();
                Txt_igv.Text = Dgv_principal.CurrentRow.Cells["igv"].Value.ToString();
                Txt_total_importe.Text = Dgv_principal.CurrentRow.Cells["total_importe"].Value.ToString();

                Dgv_Detalle.DataSource = N_Entrada_Productos.Listado_detalle_ep(Codigo_ep);

                Formato_detalle();
            }
        }

        private void Crear_TablaDetalle()
        {
            TablaDetalle = new DataTable("TablaDetalle");
            TablaDetalle.Columns.Add("Descripcion_pr", Type.GetType("System.String"));
            TablaDetalle.Columns.Add("Descripcion_ma", Type.GetType("System.String"));
            TablaDetalle.Columns.Add("Descripcion_um", Type.GetType("System.String"));
            TablaDetalle.Columns.Add("Cantidad", Type.GetType("System.Decimal"));
            TablaDetalle.Columns.Add("Pu_compra", Type.GetType("System.Decimal"));
            TablaDetalle.Columns.Add("Total", Type.GetType("System.Decimal"));
            TablaDetalle.Columns.Add("Codigo_pr", Type.GetType("System.Int32"));

            TablaDetalle.AcceptChanges();

            Dgv_Detalle.DataSource = TablaDetalle;

            Formato_detalle();
        }

        private void Agregar_item(string cDescripcion_pr,
                                    string cDescripcion_ma,
                                    string cDescripcion_um,
                                    decimal nCantidad,
                                    decimal nPu_compra,
                                    decimal nTotal,
                                    int nCodigo_pr)
        {
            DataRow xFila = TablaDetalle.NewRow();
            xFila["Descripcion_pr"] = cDescripcion_pr;
            xFila["Descripcion_ma"] = cDescripcion_ma;
            xFila["Descripcion_um"] = cDescripcion_um;
            xFila["Cantidad"] = nCantidad;
            xFila["Pu_compra"] = nPu_compra;
            xFila["Total"] = nTotal;
            xFila["Codigo_pr"] = nCodigo_pr;
            TablaDetalle.Rows.Add(xFila);
            TablaDetalle.AcceptChanges();
        }

        private void Formato_detalle()
        {
            Dgv_Detalle.Columns[0].Width = 250;
            Dgv_Detalle.Columns[0].HeaderText = "PRODUCTO";
            Dgv_Detalle.Columns[1].Width = 150;
            Dgv_Detalle.Columns[1].HeaderText = "MARCA";
            Dgv_Detalle.Columns[2].Width = 80;
            Dgv_Detalle.Columns[2].HeaderText = "U.MEDIDA";
            Dgv_Detalle.Columns[3].Width = 90;
            Dgv_Detalle.Columns[3].HeaderText = "CANTIDAD";
            Dgv_Detalle.Columns[4].Width = 120;
            Dgv_Detalle.Columns[4].HeaderText = "PU COMPRA";
            Dgv_Detalle.Columns[5].Width = 90;
            Dgv_Detalle.Columns[5].HeaderText = "TOTAL";
            Dgv_Detalle.Columns[6].Visible = false;

            Dgv_Detalle.Columns[0].ReadOnly = true;
            Dgv_Detalle.Columns[1].ReadOnly = true;
            Dgv_Detalle.Columns[2].ReadOnly = true;
            Dgv_Detalle.Columns[3].ReadOnly = true;
            Dgv_Detalle.Columns[4].ReadOnly = true;
            Dgv_Detalle.Columns[5].ReadOnly = true;
        }

        private void Formato_tde_ep()
        {
            Dgv_tipo_tde.Columns[0].Width = 200;
            Dgv_tipo_tde.Columns[0].HeaderText = "TIPO DOCUMENTO";
            Dgv_tipo_tde.Columns[1].Visible = false;
        }

        private void Listado_tde_ep()
        {
            try
            {
                Dgv_tipo_tde.DataSource = N_Entrada_Productos.Listado_tde_ep();
                Formato_tde_ep();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void Selecciona_item_tde_ep()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Dgv_tipo_tde.CurrentRow.Cells["codigo_tde"].Value)))
            {
                MessageBox.Show("No se tiene información para visualizar", "Aviso del sistema",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Codigo_tde = Convert.ToInt32(Dgv_tipo_tde.CurrentRow.Cells["codigo_tde"].Value);
                Txt_descripcion_tde.Text = Convert.ToString(Dgv_tipo_tde.CurrentRow.Cells["descripcion_tde"].Value);
            }
        }

        private void Formato_al_ep()
        {
            Dgv_almacenes.Columns[0].Width = 200;
            Dgv_almacenes.Columns[0].HeaderText = "ALMACÉN";
            Dgv_almacenes.Columns[1].Visible = false;
        }

        private void Listado_al_ep()
        {
            try
            {
                Dgv_almacenes.DataSource = N_Entrada_Productos.Listado_al_ep();
                Formato_al_ep();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void Selecciona_item_al_ep()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Dgv_almacenes.CurrentRow.Cells["codigo_al"].Value)))
            {
                MessageBox.Show("No se tiene información para visualizar", "Aviso del sistema",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Codigo_al = Convert.ToInt32(Dgv_almacenes.CurrentRow.Cells["codigo_al"].Value);
                Txt_descripcion_al.Text = Convert.ToString(Dgv_almacenes.CurrentRow.Cells["descripcion_al"].Value);
            }
        }

        private void Formato_pv_ep()
        {
            Dgv_proveedores.Columns[0].Width = 200;
            Dgv_proveedores.Columns[0].HeaderText = "PROVEEDOR";
            Dgv_proveedores.Columns[1].Width = 200;
            Dgv_proveedores.Columns[1].HeaderText = "TIPO DOC";
            Dgv_proveedores.Columns[2].Width = 200;
            Dgv_proveedores.Columns[2].HeaderText = "NRO DOC";
            Dgv_proveedores.Columns[3].Visible = false;
        }

        private void Listado_pv_ep(string cTexto)
        {
            try
            {
                Dgv_proveedores.DataSource = N_Entrada_Productos.Listado_pv_ep(cTexto);
                Formato_pv_ep();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void Selecciona_item_pv_ep()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Dgv_proveedores.CurrentRow.Cells["codigo_pv"].Value)))
            {
                MessageBox.Show("No se tiene información para visualizar", "Aviso del sistema",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Codigo_pv = Convert.ToInt32(Dgv_proveedores.CurrentRow.Cells["codigo_pv"].Value);
                Txt_razon_social_pv.Text = Convert.ToString(Dgv_proveedores.CurrentRow.Cells["razon_social_pv"].Value);
            }
        }

        private void Formato_pr_ep()
        {
            Dgv_productos.Columns[0].Width = 200;
            Dgv_productos.Columns[0].HeaderText = "PRODUCTO";
            Dgv_productos.Columns[1].Width = 160;
            Dgv_productos.Columns[1].HeaderText = "MARCA";
            Dgv_productos.Columns[2].Width = 90;
            Dgv_productos.Columns[2].HeaderText = "U.MEDIDA";
            Dgv_productos.Columns[3].Width = 160;
            Dgv_productos.Columns[3].HeaderText = "CATEGORÍA";
            Dgv_productos.Columns[4].Visible = false;
        }

        private void Listado_pr_ep(string cTexto)
        {
            try
            {
                Dgv_productos.DataSource = N_Entrada_Productos.Listado_pr_ep(cTexto);
                Formato_pr_ep();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void Selecciona_item_pr_ep()
        {

            if (string.IsNullOrEmpty(Convert.ToString(Dgv_productos.CurrentRow.Cells["codigo_pr"].Value)))
            {
                MessageBox.Show("No se tiene información para visualizar", "Aviso del sistema",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string xDescripcion_pr;
                string xDescripcion_ma;
                string xDescripcion_um;
                decimal xCantidad;
                decimal xPu_compra;
                decimal xTotal;
                int xCodigo_pr;

                bool Agregar = true;

                xCodigo_pr = Convert.ToInt32(Dgv_productos.CurrentRow.Cells["codigo_pr"].Value);

                foreach (DataRow FilaTemp in TablaDetalle.Rows)
                {
                    if (Convert.ToInt32(FilaTemp["codigo_pr"]) == xCodigo_pr)
                    {
                        Agregar = false;
                        MessageBox.Show("El producto ya se encuentra agregado", "Aviso del Sistema");
                    }
                }

                if (Agregar)
                {
                    xDescripcion_pr = Convert.ToString(Dgv_productos.CurrentRow.Cells["descripcion_pr"].Value);
                    xDescripcion_ma = Convert.ToString(Dgv_productos.CurrentRow.Cells["descripcion_ma"].Value);
                    xDescripcion_um = Convert.ToString(Dgv_productos.CurrentRow.Cells["descripcion_um"].Value);
                    xCantidad = 0.00M;
                    xPu_compra = 0.00M;
                    xTotal = 0.00M;

                    Agregar_item(xDescripcion_pr, xDescripcion_ma, xDescripcion_um, xCantidad, xPu_compra, xTotal, xCodigo_pr);
                }
            }
        }

        private void Estado_texto(bool lEstado)
        {
            Txt_nrodocumento_ep.ReadOnly = !lEstado;
            Txt_observacion_ep.ReadOnly = !lEstado;
            Dtp_fecha_ep.Enabled = lEstado;
        }

        private void Limpia_texto()
        {
            Txt_nrodocumento_ep.Clear();
            Txt_observacion_ep.Clear();
            Txt_subtotal.Clear();
            Txt_igv.Clear();
            Txt_total_importe.Clear();
            
            Crear_TablaDetalle();
        }

        private void Calcular_Totales()
        {
            decimal nSubtotal = 0;
            decimal nTotal_importe = 0;
            decimal nIgv = 0;
            if (Dgv_Detalle.Rows.Count == 0)
            {
                nSubtotal = 0;
                nIgv = 0;
                nTotal_importe = 0;
            }
            else
            {
                TablaDetalle.AcceptChanges();
                foreach (DataRow Filatemp in TablaDetalle.Rows)
                {
                    nTotal_importe = nTotal_importe + Convert.ToDecimal(Filatemp["total"]);
                }                
                nSubtotal = nTotal_importe / (1 + Convert.ToDecimal("0.18"));
                nIgv = nTotal_importe - nSubtotal;
                Txt_subtotal.Text = decimal.Round(nSubtotal, 2).ToString("#0.00");
                Txt_igv.Text = decimal.Round(nIgv, 2).ToString("#0.00");
                Txt_total_importe.Text = decimal.Round(nTotal_importe, 2).ToString("#0.00");
            }
        }
        #endregion

        private void Frm_Entrada_Productos_Load(object sender, EventArgs e)
        {
            Listado_ep("%");
            Listado_tde_ep();
            Listado_pv_ep("%");
            Listado_al_ep();
            //Listado_pr_ep("%"); // No mostrar información de golpe?
        }

        private void Btn_guardar_Click(object sender, EventArgs e)
        {
            if (Txt_descripcion_tde.Text == string.Empty ||
                Txt_nrodocumento_ep.Text == string.Empty ||
                Txt_razon_social_pv.Text == string.Empty ||
                Txt_descripcion_al.Text == string.Empty ||
                Dgv_Detalle.Rows.Count == 0)
            {
                MessageBox.Show("Falta ingresar datos requeridos (*)", "Aviso del Sistema",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else //Se procedería a ingresar la información
            {
                string Rpta = "";

                E_Entrada_Productos oEp = new E_Entrada_Productos();
              
                oEp.Codigo_ep = Codigo_ep;
                oEp.Codigo_tde = Codigo_tde;
                oEp.Nrodocumento_ep = Txt_nrodocumento_ep.Text.Trim();
                oEp.Codigo_pv = Codigo_pv;
                oEp.Fecha_ep = Dtp_fecha_ep.Value;
                oEp.Codigo_al = Codigo_al;
                oEp.Observacion_ep = Txt_observacion_ep.Text.Trim();
                oEp.Subtotal = Convert.ToDecimal(Txt_subtotal.Text.Trim());
                oEp.Igv = Convert.ToDecimal(Txt_igv.Text.Trim());
                oEp.Total_importe = Convert.ToDecimal(Txt_total_importe.Text.Trim());

                TablaDetalle.AcceptChanges();

                Rpta = N_Entrada_Productos.Guardar_ep(oEp, TablaDetalle);
                if (Rpta.Equals("OK"))
                {
                    Listado_ep("%");
                    MessageBox.Show("Los datos han sido guardados correctamente", "Aviso del Sistema",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Estado_Botonesprincipales(true);
                    Estado_Botonesprocesos(false);
                    Estado_texto(false);
                    Dgv_Detalle.Columns[3].ReadOnly = true;
                    Dgv_Detalle.Columns[4].ReadOnly = true;
                    Tbc_principal.SelectedIndex = 0;
                    Codigo_ep = 0;
                    Estadoguarda = 0;
                }
                else
                {
                    MessageBox.Show(Rpta, "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Btn_nuevo_Click(object sender, EventArgs e)
        {
            Estadoguarda = 1;
            Estado_Botonesprincipales(false);
            Estado_Botonesprocesos(true);
            Limpia_texto();

            Dgv_Detalle.Columns[3].ReadOnly = false;
            Dgv_Detalle.Columns[4].ReadOnly = false;

            Estado_texto(true);
            Tbc_principal.SelectedIndex = 1;
            Txt_nrodocumento_ep.Focus();
        }

        private void Btn_cancelar_Click(object sender, EventArgs e)
        {
            Estadoguarda = 0;
            Codigo_ep = 0;
            Codigo_tde = 0;
            Codigo_pv = 0;
            Codigo_al = 0;
            Estado_texto(false);
            Limpia_texto();

            Dgv_Detalle.Columns[3].ReadOnly = true;
            Dgv_Detalle.Columns[4].ReadOnly = true;

            Estado_Botonesprincipales(true);
            Estado_Botonesprocesos(false);
            Tbc_principal.SelectedIndex = 0;
        }

        private void Dgv_principal_DoubleClick(object sender, EventArgs e)
        {
            Selecciona_item();
            Estado_Botonesprocesos(false);
            Tbc_principal.SelectedIndex = 1;
        }

        private void Btn_retornar_Click(object sender, EventArgs e)
        {
            Estado_Botonesprocesos(false);
            Tbc_principal.SelectedIndex = 0;

            Btn_retornar.Visible = false;
            Txt_nrodocumento_ep.Text = "";
        }

        private void Btn_eliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Dgv_principal.CurrentRow.Cells["codigo_ep"].Value)))
            {
                MessageBox.Show("No se tiene información para visualizar", "Aviso del sistema",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("¿Estás seguro de anular el registro seleccionado?", "Aviso del sistema",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (Opcion == DialogResult.Yes)
                {
                    string Rpta = "";
                    Codigo_ep = Convert.ToInt32(Dgv_principal.CurrentRow.Cells["codigo_ep"].Value);
                    Rpta = N_Entrada_Productos.Eliminar_ep(Codigo_ep);
                    if (Rpta.Equals("OK"))
                    {
                        Listado_ep("%");
                        Codigo_ep = 0;
                        MessageBox.Show("Registro Anulado", "Aviso del Sistema",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                }                
            }
        }

        private void Btn_buscar_Click(object sender, EventArgs e)
        {
            Listado_ep(Txt_buscar.Text.Trim());
        }

        private void Btn_reporte_Click(object sender, EventArgs e)
        {
            Reportes.Frm_Rpt_Entrada_Productos oRpt11 = new Reportes.Frm_Rpt_Entrada_Productos();
            oRpt11.txt_p1.Text = Txt_buscar.Text;
            oRpt11.ShowDialog();
        }

        private void Btn_salir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Btn_lupa1_Click(object sender, EventArgs e)
        {
            Pnl_Listado_tde.Location = Btn_lupa1.Location;
            Pnl_Listado_tde.Visible = true;
        }
        private void Dgv_tipo_tde_DoubleClick(object sender, EventArgs e)
        {
            Selecciona_item_tde_ep();
            Pnl_Listado_tde.Visible = false;
            Txt_nrodocumento_ep.Focus();
        }

        private void Btn_retornar1_Click(object sender, EventArgs e)
        {
            Pnl_Listado_tde.Visible = false;
        }

        private void Btn_lupa2_Click(object sender, EventArgs e)
        {
            Pnl_Listado_pv.Location = Btn_lupa1.Location;
            Pnl_Listado_pv.Visible = true;
        }

        private void Btn_lupa3_Click(object sender, EventArgs e)
        {
            Pnl_Listado_al.Location = new Point(618, 63);
            Pnl_Listado_al.Visible = true;
        }

        private void Dgv_almacenes_DoubleClick(object sender, EventArgs e)
        {
            Selecciona_item_al_ep();
            Pnl_Listado_al.Visible = false;
            Txt_observacion_ep.Focus();
        }

        private void Btn_retornar3_Click(object sender, EventArgs e)
        {
            Pnl_Listado_al.Visible = false;
        }     

        private void Btn_lupa4_Click(object sender, EventArgs e)
        {
            Pnl_Listado_pv.Location = Btn_lupa1.Location;
            Pnl_Listado_pv.Visible = true;
        }

        private void Dgv_proveedores_DoubleClick(object sender, EventArgs e)
        {
            Selecciona_item_pv_ep();
            Pnl_Listado_pv.Visible = false;
            Btn_lupa3.Focus();
        }

        private void Btn_retornar2_Click(object sender, EventArgs e)
        {
            Pnl_Listado_pv.Visible = false;
        }

        private void Btn_buscar2_Click(object sender, EventArgs e)
        {
            Listado_pv_ep(Txt_buscar2.Text.Trim());
        }

        private void Btn_agregar_Click(object sender, EventArgs e)
        {
            Pnl_Listado_pv.Location = Btn_lupa1.Location;
            Pnl_Listado_pr.Visible = true;
            Txt_buscar4.Focus();
        }

        private void Btn_retornar4_Click(object sender, EventArgs e)
        {
            Pnl_Listado_pr.Visible = false;
        }

        private void Btn_buscar4_Click(object sender, EventArgs e)
        {
            Listado_pr_ep(Txt_buscar4.Text.Trim());
        }

        private void Dgv_productos_DoubleClick(object sender, EventArgs e)
        {
            Selecciona_item_pr_ep();
            Pnl_Listado_pr.Visible = false;
            Btn_agregar.Focus();
        }

        private void Dgv_Detalle_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (Estadoguarda == 1)
            {
                DataRow yFila = TablaDetalle.Rows[e.RowIndex];
                decimal yCantidad = Convert.ToDecimal(yFila["Cantidad"]);
                decimal yPu_compra = Convert.ToDecimal(yFila["Pu_compra"]);
                yFila["Total"] = decimal.Round(yCantidad * yPu_compra, 2).ToString("#0.00");

                Calcular_Totales();
            }
        }

        private void Btn_quitar_Click(object sender, EventArgs e)
        {
            if (Dgv_Detalle.Rows.Count > 0)
            {
                Dgv_Detalle.Rows.Remove(Dgv_Detalle.CurrentRow);
                Dgv_Detalle.Refresh();
                TablaDetalle.AcceptChanges();
                Calcular_Totales();
            }
        }
    }
}
