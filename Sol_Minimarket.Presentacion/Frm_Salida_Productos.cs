using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Sol_Minimarket.Entidades;
using Sol_Minimarket.Negocio;

namespace Sol_Minimarket.Presentacion
{
    public partial class Frm_Salida_Productos : Form
    {
        public Frm_Salida_Productos()
        {
            InitializeComponent();
        }

        #region "Mis Variables"
        int Codigo_sp = 0;
        int Codigo_tde = 0;
        int Codigo_cl = 0;
        int Estadoguarda = 0;
        DataTable TablaDetalle = new DataTable();
        #endregion

        #region "Mis Métodos"
        private void Formato_sp()
        {
            Dgv_principal.Columns[0].Width = 85;
            Dgv_principal.Columns[0].HeaderText = "CÓDIGO_SP";
            Dgv_principal.Columns[1].Width = 95;
            Dgv_principal.Columns[1].HeaderText = "TIPO DOC";
            Dgv_principal.Columns[2].Width = 110;
            Dgv_principal.Columns[2].HeaderText = "NRO DOC";
            Dgv_principal.Columns[3].Width = 120;
            Dgv_principal.Columns[3].HeaderText = "FECHA DOC";
            Dgv_principal.Columns[4].Width = 260;
            Dgv_principal.Columns[4].HeaderText = "DOC CLIENTE";
            Dgv_principal.Columns[5].Width = 170;
            Dgv_principal.Columns[5].HeaderText = "CLIENTE";
            Dgv_principal.Columns[6].Width = 135;
            Dgv_principal.Columns[6].HeaderText = "TOTAL IMPORTE";
            Dgv_principal.Columns[7].Visible = false;
            Dgv_principal.Columns[8].Visible = false;
            Dgv_principal.Columns[9].Visible = false;
            Dgv_principal.Columns[10].Visible = false;
            Dgv_principal.Columns[11].Visible = false;            
        }

        private void Listado_sp(string cTexto)
        {
            try
            {
                Dgv_principal.DataSource = N_Salida_Productos.Listado_sp(cTexto);
                Formato_sp();
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

            Btn_agregar.Visible = lEstado;
            Btn_quitar.Visible = lEstado;

            Btn_lupa1.Visible = lEstado;
            Btn_lupa2.Visible = lEstado;
        }

        private void Selecciona_item()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Dgv_principal.CurrentRow.Cells["codigo_sp"].Value)))
            {
                MessageBox.Show("No se tiene información para visualizar", "Aviso del sistema",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Codigo_sp = Convert.ToInt32(Dgv_principal.CurrentRow.Cells["codigo_sp"].Value);
                Codigo_tde = Convert.ToInt32(Dgv_principal.CurrentRow.Cells["codigo_tde"].Value);
                Codigo_cl = Convert.ToInt32(Dgv_principal.CurrentRow.Cells["codigo_cl"].Value);
                Txt_descripcion_tde.Text = Dgv_principal.CurrentRow.Cells["descripcion_tde"].Value.ToString();
                Txt_nrodocumento_sp.Text = Dgv_principal.CurrentRow.Cells["nrodocumento_sp"].Value.ToString();
                Dtp_fecha_sp.Value = Convert.ToDateTime(Dgv_principal.CurrentRow.Cells["fecha_sp"].Value);
                Txt_nrodocumento_cl.Text = Dgv_principal.CurrentRow.Cells["nrodocumento_cl"].Value.ToString();                
                Txt_razon_social_cl.Text = Dgv_principal.CurrentRow.Cells["razon_social_cl"].Value.ToString();                
                Txt_observacion_sp.Text = Dgv_principal.CurrentRow.Cells["observacion_sp"].Value.ToString();
                Txt_subtotal.Text = Dgv_principal.CurrentRow.Cells["subtotal"].Value.ToString();
                Txt_igv.Text = Dgv_principal.CurrentRow.Cells["igv"].Value.ToString();
                Txt_total_importe.Text = Dgv_principal.CurrentRow.Cells["total_importe"].Value.ToString();

                Dgv_Detalle.DataSource = N_Salida_Productos.Listado_detalle_sp(Codigo_sp);

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
            TablaDetalle.Columns.Add("Pu_venta", Type.GetType("System.Decimal"));
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
                                    decimal nPu_venta,
                                    decimal nTotal,
                                    int nCodigo_pr)
        {
            DataRow xFila = TablaDetalle.NewRow();
            xFila["Descripcion_pr"] = cDescripcion_pr;
            xFila["Descripcion_ma"] = cDescripcion_ma;
            xFila["Descripcion_um"] = cDescripcion_um;
            xFila["Cantidad"] = nCantidad;
            xFila["Pu_venta"] = nPu_venta;
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
            Dgv_Detalle.Columns[4].HeaderText = "PU VENTA";
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

        private void Formato_tde_sp()
        {
            Dgv_tipo_tde.Columns[0].Width = 200;
            Dgv_tipo_tde.Columns[0].HeaderText = "TIPO DOCUMENTO";
            Dgv_tipo_tde.Columns[1].Visible = false;
        }

        private void Listado_tde_sp()
        {
            try
            {
                Dgv_tipo_tde.DataSource = N_Salida_Productos.Listado_tde_sp();
                Formato_tde_sp();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void Selecciona_item_tde_sp()
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

        private void Formato_cl_sp()
        {
            Dgv_clientes.Columns[0].Width = 200;
            Dgv_clientes.Columns[0].HeaderText = "CLIENTE";
            Dgv_clientes.Columns[1].Width = 200;
            Dgv_clientes.Columns[1].HeaderText = "TIPO DOC";
            Dgv_clientes.Columns[2].Width = 200;
            Dgv_clientes.Columns[2].HeaderText = "NRO DOC";
            Dgv_clientes.Columns[3].Visible = false;
        }

        private void Listado_cl_sp(string cTexto)
        {
            try
            {
                Dgv_clientes.DataSource = N_Salida_Productos.Listado_cl_sp(cTexto);
                Formato_cl_sp();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void Selecciona_item_cl_sp()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Dgv_clientes.CurrentRow.Cells["codigo_cl"].Value)))
            {
                MessageBox.Show("No se tiene información para visualizar", "Aviso del sistema",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Codigo_cl = Convert.ToInt32(Dgv_clientes.CurrentRow.Cells["codigo_cl"].Value);
                Txt_nrodocumento_cl.Text = Convert.ToString(Dgv_clientes.CurrentRow.Cells["nrodocumento_cl"].Value);
                Txt_razon_social_cl.Text = Convert.ToString(Dgv_clientes.CurrentRow.Cells["razon_social_cl"].Value);
                if (Codigo_cl == 1) //Si es el cliente genérico
                {
                    Txt_nrodocumento_cl.ReadOnly = false;
                    Txt_razon_social_cl.ReadOnly = false;
                    Txt_nrodocumento_cl.Focus();
                }
                else //Para los demás clientes
                {
                    Txt_nrodocumento_cl.ReadOnly = true;
                    Txt_razon_social_cl.ReadOnly = true;
                    Txt_observacion_sp.Focus();
                }
            }
        }

        private void Formato_pr_sp()
        {
            Dgv_productos.Columns[0].Width = 200;
            Dgv_productos.Columns[0].HeaderText = "PRODUCTO";
            Dgv_productos.Columns[1].Width = 160;
            Dgv_productos.Columns[1].HeaderText = "MARCA";
            Dgv_productos.Columns[2].Width = 90;
            Dgv_productos.Columns[2].HeaderText = "U.MEDIDA";
            Dgv_productos.Columns[3].Width = 160;
            Dgv_productos.Columns[3].HeaderText = "CATEGORÍA";
            Dgv_productos.Columns[4].Width = 130;
            Dgv_productos.Columns[4].HeaderText = "STOCK ACTUAL";
            Dgv_productos.Columns[5].Width = 100;
            Dgv_productos.Columns[5].HeaderText = "PU VENTA";
            Dgv_productos.Columns[6].Visible = false;
        }

        private void Listado_pr_sp(string cTexto)
        {
            try
            {
                Dgv_productos.DataSource = N_Salida_Productos.Listado_pr_sp(cTexto);
                Formato_pr_sp();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void Selecciona_item_pr_sp()
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
                decimal xPu_venta;
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
                    xCantidad = Convert.ToDecimal(Dgv_productos.CurrentRow.Cells["stock_actual"].Value);
                    xPu_venta = Convert.ToDecimal(Dgv_productos.CurrentRow.Cells["pu_venta"].Value);
                    xTotal = decimal.Round(xCantidad * xPu_venta, 2);

                    Agregar_item(xDescripcion_pr, xDescripcion_ma, xDescripcion_um, xCantidad, xPu_venta, xTotal, xCodigo_pr);
                    Calcular_Totales();
                }
            }
        }

        private void Estado_texto(bool lEstado)
        {
            Txt_nrodocumento_sp.ReadOnly = !lEstado;
            Txt_observacion_sp.ReadOnly = !lEstado;
            Dtp_fecha_sp.Enabled = lEstado;
        }

        private void Limpia_texto()
        {
            Txt_nrodocumento_sp.Clear();
            Txt_observacion_sp.Clear();
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

        private void Frm_Salida_Productos_Load(object sender, EventArgs e)
        {
            Listado_sp("%");
            Listado_tde_sp();
            Listado_cl_sp("%");
        }

        private void Btn_guardar_Click(object sender, EventArgs e)
        {
            if (Txt_descripcion_tde.Text == string.Empty ||
                Txt_nrodocumento_sp.Text == string.Empty ||
                Txt_nrodocumento_cl.Text == string.Empty ||
                Dgv_Detalle.Rows.Count == 0)
            {
                MessageBox.Show("Falta ingresar datos requeridos (*)", "Aviso del Sistema",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else //Se procedería a ingresar la información
            {
                string Rpta = "";

                E_Salida_Productos oSp = new E_Salida_Productos();
              
                oSp.Codigo_sp = Codigo_sp;
                oSp.Codigo_tde = Codigo_tde;
                oSp.Nrodocumento_sp = Txt_nrodocumento_sp.Text.Trim();
                oSp.Codigo_cl = Codigo_cl;
                oSp.Nrodocumento_cl = Txt_nrodocumento_cl.Text.Trim();
                oSp.Razon_social_cl = Txt_razon_social_cl.Text.Trim();
                oSp.Fecha_sp = Dtp_fecha_sp.Value;
                oSp.Observacion_sp = Txt_observacion_sp.Text.Trim();
                oSp.Subtotal = Convert.ToDecimal(Txt_subtotal.Text.Trim());
                oSp.Igv = Convert.ToDecimal(Txt_igv.Text.Trim());
                oSp.Total_importe = Convert.ToDecimal(Txt_total_importe.Text.Trim());

                TablaDetalle.AcceptChanges();

                Rpta = N_Salida_Productos.Guardar_sp(oSp, TablaDetalle);
                if (Rpta != string.Empty)
                {
                    Codigo_sp = Convert.ToInt32(Rpta);
                    Listado_sp("%");
                    MessageBox.Show("Los datos han sido guardados correctamente # " + Codigo_sp, "Aviso del Sistema", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //Generando el ticket de la venta
                    Reportes.Frm_Rpt_Imprimir_Venta_Generada oRpt14 = new Reportes.Frm_Rpt_Imprimir_Venta_Generada();
                    oRpt14.txt_p1.Text = Rpta;
                    oRpt14.ShowDialog();
                    //fin del proceso del ticket para imprimir

                    Estado_Botonesprincipales(true);
                    Estado_Botonesprocesos(false);
                    Estado_texto(false);
                    Dgv_Detalle.Columns[3].ReadOnly = true;
                    Tbc_principal.SelectedIndex = 0;
                    Codigo_sp = 0;
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

            Estado_texto(true);
            Tbc_principal.SelectedIndex = 0;
            Txt_nrodocumento_sp.Focus();
        }

        private void Btn_cancelar_Click(object sender, EventArgs e)
        {
            Estadoguarda = 0;
            Codigo_sp = 0;
            Codigo_tde = 0;
            Codigo_cl = 0;
            Estado_texto(false);
            Limpia_texto();

            Dgv_Detalle.Columns[3].ReadOnly = true;

            Estado_Botonesprincipales(true);
            Estado_Botonesprocesos(false);
            Tbc_principal.SelectedIndex = 0;
        }

        private void Dgv_principal_DoubleClick(object sender, EventArgs e)
        {
            Selecciona_item();
            Estado_Botonesprocesos(false);
            Tbc_principal.SelectedIndex = 0;
        }

        private void Btn_eliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Dgv_principal.CurrentRow.Cells["codigo_sp"].Value)))
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
                    Codigo_sp = Convert.ToInt32(Dgv_principal.CurrentRow.Cells["codigo_sp"].Value);
                    Rpta = N_Salida_Productos.Eliminar_sp(Codigo_sp);
                    if (Rpta.Equals("OK"))
                    {
                        Listado_sp("%");
                        Limpia_texto();
                        Codigo_sp = 0;
                        MessageBox.Show("Registro Anulado", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        Tbc_principal.SelectedIndex = 1;
                    }

                }                
            }
        }

        private void Btn_buscar_Click(object sender, EventArgs e)
        {
            Listado_sp(Txt_buscar.Text.Trim());
        }

        private void Btn_reporte_Click(object sender, EventArgs e)
        {
            Reportes.Frm_Rpt_Salida_Productos oRpt13 = new Reportes.Frm_Rpt_Salida_Productos();
            oRpt13.txt_p1.Text = Txt_buscar.Text;
            oRpt13.ShowDialog();
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
            Selecciona_item_tde_sp();
            Pnl_Listado_tde.Visible = false;
            Txt_nrodocumento_sp.Focus();
        }

        private void Btn_retornar1_Click(object sender, EventArgs e)
        {
            Pnl_Listado_tde.Visible = false;
        }

        private void Btn_lupa2_Click(object sender, EventArgs e)
        {
            Pnl_Listado_cl.Location = Btn_lupa1.Location;
            Pnl_Listado_cl.Visible = true;
        }

        private void Btn_lupa4_Click(object sender, EventArgs e)
        {
            Pnl_Listado_cl.Location = Btn_lupa1.Location;
            Pnl_Listado_cl.Visible = true;
        }

        private void Dgv_clientes_DoubleClick(object sender, EventArgs e)
        {
            Selecciona_item_cl_sp();
            Pnl_Listado_cl.Visible = false;
        }

        private void Btn_retornar2_Click(object sender, EventArgs e)
        {
            Pnl_Listado_cl.Visible = false;
        }

        private void Btn_buscar2_Click(object sender, EventArgs e)
        {
            Listado_cl_sp(Txt_buscar2.Text.Trim());
        }

        private void Btn_agregar_Click(object sender, EventArgs e)
        {
            Pnl_Listado_cl.Location = Btn_lupa1.Location;
            Pnl_Listado_pr.Visible = true;
            Txt_buscar4.Focus();
        }

        private void Btn_retornar4_Click(object sender, EventArgs e)
        {
            Pnl_Listado_pr.Visible = false;
        }

        private void Btn_buscar4_Click(object sender, EventArgs e)
        {
            Listado_pr_sp(Txt_buscar4.Text.Trim());
        }

        private void Dgv_productos_DoubleClick(object sender, EventArgs e)
        {
            Selecciona_item_pr_sp();
            Pnl_Listado_pr.Visible = false;
            Btn_agregar.Focus();
        }

        private void Dgv_Detalle_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (Estadoguarda == 1)
            {
                DataRow yFila = TablaDetalle.Rows[e.RowIndex];
                decimal yCantidad = Convert.ToDecimal(yFila["Cantidad"]);
                decimal yPu_venta = Convert.ToDecimal(yFila["Pu_venta"]);
                yFila["Total"] = decimal.Round(yCantidad * yPu_venta, 2).ToString("#0.00");

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
