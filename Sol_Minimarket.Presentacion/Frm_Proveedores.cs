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
        int Codigo_pv = 0;
        int Codigo_tdpc = 0;
        int Codigo_sx = 0;
        int Codigo_ru = 0;
        int Codigo_di = 0;
        int Estadoguarda = 0; //Sin ninguna acción
        #endregion

        #region "Mis Métodos"
        private void Formato_pv()
        {
            Dgv_principal.Columns[0].Width = 90;
            Dgv_principal.Columns[0].HeaderText = "CÓDIGO_PV";
            Dgv_principal.Columns[1].Width = 95;
            Dgv_principal.Columns[1].HeaderText = "TIPO DOC";
            Dgv_principal.Columns[2].Width = 110;
            Dgv_principal.Columns[2].HeaderText = "NRO DOC";
            Dgv_principal.Columns[3].Width = 270;
            Dgv_principal.Columns[3].HeaderText = "RAZON SOCIAL";
            Dgv_principal.Columns[4].Width = 140;
            Dgv_principal.Columns[4].HeaderText = "NOMBRES";
            Dgv_principal.Columns[5].Width = 140;
            Dgv_principal.Columns[5].HeaderText = "APELLIDOS";
            Dgv_principal.Columns[6].Width = 140;
            Dgv_principal.Columns[6].HeaderText = "RUBRO";
            Dgv_principal.Columns[7].Visible = false;
            Dgv_principal.Columns[8].Visible = false;
            Dgv_principal.Columns[9].Visible = false;
            Dgv_principal.Columns[10].Visible = false;
            Dgv_principal.Columns[11].Visible = false;
            Dgv_principal.Columns[12].Visible = false;
            Dgv_principal.Columns[13].Visible = false;
            Dgv_principal.Columns[14].Visible = false;
            Dgv_principal.Columns[15].Visible = false;
            Dgv_principal.Columns[16].Visible = false;
            Dgv_principal.Columns[17].Visible = false;
            Dgv_principal.Columns[18].Visible = false;
            Dgv_principal.Columns[19].Visible = false;
        }

        private void Listado_pv(string cTexto)
        {
            try
            {
                Dgv_principal.DataSource = N_Proveedores.Listado_pv(cTexto);
                this.Formato_pv();
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
            if (string.IsNullOrEmpty(Convert.ToString(Dgv_principal.CurrentRow.Cells["codigo_pv"].Value)))
            {
                MessageBox.Show("No se tiene información para visualizar", "Aviso del sistema",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string Distrito = "";
                Codigo_pv = Convert.ToInt32(Dgv_principal.CurrentRow.Cells["codigo_pv"].Value);
                Codigo_tdpc = Convert.ToInt32(Dgv_principal.CurrentRow.Cells["codigo_tdpc"].Value);
                Txt_descripcion_tdpc.Text = Convert.ToString(Dgv_principal.CurrentRow.Cells["descripcion_tdpc"].Value);
                Txt_nrodocumento_pv.Text = Convert.ToString(Dgv_principal.CurrentRow.Cells["nrodocumento_pv"].Value);
                Txt_razon_social_pv.Text = Convert.ToString(Dgv_principal.CurrentRow.Cells["razon_social_pv"].Value);
                Txt_nombres.Text = Convert.ToString(Dgv_principal.CurrentRow.Cells["nombres"].Value);
                Txt_apellidos.Text = Convert.ToString(Dgv_principal.CurrentRow.Cells["apellidos"].Value);
                Codigo_ru = Convert.ToInt32(Dgv_principal.CurrentRow.Cells["codigo_ru"].Value);
                Txt_descripcion_ru.Text = Convert.ToString(Dgv_principal.CurrentRow.Cells["descripcion_ru"].Value);
                Txt_email_pv.Text = Convert.ToString(Dgv_principal.CurrentRow.Cells["email_pv"].Value);
                Txt_telefono_pv.Text = Convert.ToString(Dgv_principal.CurrentRow.Cells["telefono_pv"].Value);
                Txt_movil_pv.Text = Convert.ToString(Dgv_principal.CurrentRow.Cells["movil_pv"].Value);
                Codigo_sx = Convert.ToInt32(Dgv_principal.CurrentRow.Cells["codigo_sx"].Value);
                Txt_descripcion_sx.Text = Convert.ToString(Dgv_principal.CurrentRow.Cells["descripcion_sx"].Value);
                Txt_direccion_pv.Text = Convert.ToString(Dgv_principal.CurrentRow.Cells["direccion_pv"].Value);
                Codigo_di = Convert.ToInt32(Dgv_principal.CurrentRow.Cells["codigo_di"].Value);
                Distrito = Convert.ToString(Dgv_principal.CurrentRow.Cells["descripcion_di"].Value).Trim() + "  ||  " +
                            Convert.ToString(Dgv_principal.CurrentRow.Cells["descripcion_po"].Value).Trim() + "  ||  " +
                            Convert.ToString(Dgv_principal.CurrentRow.Cells["descripcion_de"].Value).Trim();
                Txt_distrito.Text = Distrito;
                Txt_observacion_pv.Text = Convert.ToString(Dgv_principal.CurrentRow.Cells["observacion_pv"].Value).Trim();
            }
        }

        private void Formato_tdpc_pv()
        {
            Dgv_tipo_tdpc.Columns[0].Width = 200;
            Dgv_tipo_tdpc.Columns[0].HeaderText = "TIPO DOCUMENTO";
            Dgv_tipo_tdpc.Columns[1].Visible = false;
        }

        private void Listado_tdpc_pv()
        {
            try
            {
                Dgv_tipo_tdpc.DataSource = N_Proveedores.Listado_tdpc_pv();
                Formato_tdpc_pv();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void Selecciona_item_tdpc_pv()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Dgv_tipo_tdpc.CurrentRow.Cells["codigo_tdpc"].Value)))
            {
                MessageBox.Show("No se tiene información para visualizar", "Aviso del sistema",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Codigo_tdpc = Convert.ToInt32(Dgv_tipo_tdpc.CurrentRow.Cells["codigo_tdpc"].Value);
                Txt_descripcion_tdpc.Text = Convert.ToString(Dgv_tipo_tdpc.CurrentRow.Cells["descripcion_tdpc"].Value);
            }
        }

        private void Formato_sx_pv()
        {
            Dgv_sexos.Columns[0].Width = 200;
            Dgv_sexos.Columns[0].HeaderText = "SEXO";
            Dgv_sexos.Columns[1].Visible = false;
        }

        private void Listado_sx_pv()
        {
            try
            {
                Dgv_sexos.DataSource = N_Proveedores.Listado_sx_pv();
                Formato_sx_pv();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void Selecciona_item_sx_pv()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Dgv_sexos.CurrentRow.Cells["codigo_sx"].Value)))
            {
                MessageBox.Show("No se tiene información para visualizar", "Aviso del sistema",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Codigo_sx = Convert.ToInt32(Dgv_sexos.CurrentRow.Cells["codigo_sx"].Value);
                Txt_descripcion_sx.Text = Convert.ToString(Dgv_sexos.CurrentRow.Cells["descripcion_sx"].Value);
            }
        }

        private void Formato_ru_pv()
        {
            Dgv_rubros.Columns[0].Width = 200;
            Dgv_rubros.Columns[0].HeaderText = "RUBRO";
            Dgv_rubros.Columns[1].Visible = false;
        }

        private void Listado_ru_pv(string cTexto)
        {
            try
            {
                Dgv_rubros.DataSource = N_Proveedores.Listado_ru_pv(cTexto);
                Formato_ru_pv();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void Selecciona_item_ru_pv()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Dgv_rubros.CurrentRow.Cells["codigo_ru"].Value)))
            {
                MessageBox.Show("No se tiene información para visualizar", "Aviso del sistema",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Codigo_ru = Convert.ToInt32(Dgv_rubros.CurrentRow.Cells["codigo_ru"].Value);
                Txt_descripcion_ru.Text = Convert.ToString(Dgv_rubros.CurrentRow.Cells["descripcion_ru"].Value);
            }
        }

        private void Formato_di_pv()
        {
            Dgv_distritos.Columns[0].Width = 200;
            Dgv_distritos.Columns[0].HeaderText = "DISTRITO";
            Dgv_distritos.Columns[1].Width = 200;
            Dgv_distritos.Columns[1].HeaderText = "PROVINCIA";
            Dgv_distritos.Columns[2].Width = 200;
            Dgv_distritos.Columns[2].HeaderText = "DEPARTAMENTO";
            Dgv_distritos.Columns[3].Visible = false;
        }

        private void Listado_di_pv(string cTexto)
        {
            try
            {
                Dgv_distritos.DataSource = N_Proveedores.Listado_di_pv(cTexto);
                Formato_di_pv();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void Selecciona_item_di_pv()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Dgv_distritos.CurrentRow.Cells["codigo_di"].Value)))
            {
                MessageBox.Show("No se tiene información para visualizar", "Aviso del sistema",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Codigo_di = Convert.ToInt32(Dgv_distritos.CurrentRow.Cells["codigo_di"].Value);
                Txt_distrito.Text = Convert.ToString(Dgv_distritos.CurrentRow.Cells["descripcion_di"].Value) + "  ||  " +
                                    Convert.ToString(Dgv_distritos.CurrentRow.Cells["descripcion_po"].Value) + "  ||  " +
                                    Convert.ToString(Dgv_distritos.CurrentRow.Cells["descripcion_de"].Value);
            }
        }

        private void Estado_texto(bool lEstado)
        {
            Txt_nrodocumento_pv.ReadOnly = !lEstado;
            Txt_razon_social_pv.ReadOnly = !lEstado;
            Txt_nombres.ReadOnly = !lEstado;
            Txt_apellidos.ReadOnly = !lEstado;
            Txt_email_pv.ReadOnly = !lEstado;
            Txt_telefono_pv.ReadOnly = !lEstado;
            Txt_movil_pv.ReadOnly = !lEstado;
            Txt_direccion_pv.ReadOnly = !lEstado;
            Txt_observacion_pv.ReadOnly = !lEstado;
        }

        private void Limpia_texto()
        {
            Txt_nrodocumento_pv.Text = string.Empty;
            Txt_razon_social_pv.Text = string.Empty;
            Txt_nombres.Text = string.Empty;
            Txt_apellidos.Text = string.Empty;
            Txt_email_pv.Text = string.Empty;
            Txt_telefono_pv.Text = string.Empty;
            Txt_movil_pv.Text = string.Empty;
            Txt_direccion_pv.Text = string.Empty;
            Txt_observacion_pv.Text = string.Empty;
        }
        #endregion

        private void Frm_Proveedores_Load(object sender, EventArgs e)
        {
            Listado_pv("%");
            Listado_tdpc_pv();
            Listado_sx_pv();
            Listado_ru_pv("%");
            Listado_di_pv("%");
        }

        private void Btn_guardar_Click(object sender, EventArgs e)
        {
            if (Txt_descripcion_tdpc.Text == string.Empty ||
                Txt_nrodocumento_pv.Text == string.Empty ||
                Txt_razon_social_pv.Text == string.Empty ||
                Txt_descripcion_sx.Text == string.Empty ||
                Txt_descripcion_ru.Text == string.Empty ||
                Txt_distrito.Text == string.Empty ||
                Txt_direccion_pv.Text == string.Empty)
            {
                MessageBox.Show("Falta ingresar datos requeridos (*)", "Aviso del Sistema",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else //Se procedería a ingresar la información
            {
                string Rpta = "";

                E_Proveedores oPv = new E_Proveedores();
                oPv.Codigo_pv = Codigo_pv;
                oPv.Codigo_tdpc = Codigo_tdpc;
                oPv.Nrodocumento_pv = Txt_nrodocumento_pv.Text.Trim();
                oPv.Razon_social_pv = Txt_razon_social_pv.Text.Trim();
                oPv.Nombres = Txt_nombres.Text.Trim();
                oPv.Apellidos= Txt_apellidos.Text.Trim();
                oPv.Codigo_sx = Codigo_sx;
                oPv.Codigo_ru = Codigo_ru;
                oPv.Email_pv= Txt_email_pv.Text.Trim();
                oPv.Telefono_pv= Txt_telefono_pv.Text.Trim();
                oPv.Movil_pv = Txt_movil_pv.Text.Trim();
                oPv.Direccion_pv = Txt_direccion_pv.Text.Trim();
                oPv.Codigo_di = Codigo_di;
                oPv.Observacion_pv = Txt_observacion_pv.Text.Trim();

                Rpta = N_Proveedores.Guardar_pv(Estadoguarda, oPv);
                if (Rpta.Equals("OK"))
                {
                    Listado_pv("%");
                    MessageBox.Show("Los datos han sido guardados correctamente", "Aviso del Sistema",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Estadoguarda = 0; //Sin ninguna acción
                    Estado_Botonesprincipales(true);
                    Estado_Botonesprocesos(false);
                    Estado_texto(false);
                    Tbc_principal.SelectedIndex = 0;
                    Codigo_pv = 0;
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
            Estado_Botonesprincipales(false);
            Estado_Botonesprocesos(true);
            Limpia_texto();
            Estado_texto(true);
            Tbc_principal.SelectedIndex = 1;
            Txt_nrodocumento_pv.Focus();
        }

        private void Btn_actualizar_Click(object sender, EventArgs e)
        {
            Estadoguarda = 2; //Actualizar registro
            Estado_Botonesprincipales(false);
            Estado_Botonesprocesos(true);
            Estado_texto(true);
            Selecciona_item();
            Tbc_principal.SelectedIndex = 1;
            Txt_nrodocumento_pv.Focus();
        }

        private void Btn_cancelar_Click(object sender, EventArgs e)
        {
            Estadoguarda = 0; //Sin ninguna acción
            Codigo_pv = 0;
            Codigo_tdpc = 0;
            Codigo_sx = 0;
            Codigo_ru = 0;
            Codigo_di = 0;
            Estado_texto(false);
            Limpia_texto();
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
            Txt_nrodocumento_pv.Text = "";
        }

        private void Btn_eliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Dgv_principal.CurrentRow.Cells["codigo_pv"].Value)))
            {
                MessageBox.Show("No se tiene información para visualizar", "Aviso del sistema",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("¿Estás seguro de eliminar el registro seleccionado?", "Aviso del sistema",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (Opcion == DialogResult.Yes)
                {
                    string Rpta = "";
                    Codigo_pv = Convert.ToInt32(Dgv_principal.CurrentRow.Cells["codigo_pv"].Value);
                    Rpta = N_Proveedores.Eliminar_pv(Codigo_pv);
                    if (Rpta.Equals("OK"))
                    {
                        Listado_pv("%");
                        Codigo_pv = 0;
                        MessageBox.Show("Registro Eliminado", "Aviso del Sistema",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                }                
            }
        }

        private void Btn_buscar_Click(object sender, EventArgs e)
        {
            Listado_pv(Txt_buscar.Text.Trim());
        }

        private void Btn_reporte_Click(object sender, EventArgs e)
        {
            Reportes.Frm_Rpt_Proveedores oRpta9 = new Reportes.Frm_Rpt_Proveedores();
            oRpta9.txt_p1.Text = Txt_buscar.Text;
            oRpta9.ShowDialog();
        }

        private void Btn_salir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Btn_lupa1_Click(object sender, EventArgs e)
        {
            Pnl_Listado_tdpc.Location = Btn_lupa1.Location;
            Pnl_Listado_tdpc.Visible = true;
        }
        private void Dgv_tipo_tdpc_DoubleClick(object sender, EventArgs e)
        {
            Selecciona_item_tdpc_pv();
            Pnl_Listado_tdpc.Visible = false;
            Txt_nrodocumento_pv.Focus();
        }

        private void Btn_retornar1_Click(object sender, EventArgs e)
        {
            Pnl_Listado_tdpc.Visible = false;
        }

        private void Btn_lupa2_Click(object sender, EventArgs e)
        {
            Pnl_Listado_sx.Location = Btn_lupa1.Location;
            Pnl_Listado_sx.Visible = true;
        }
        private void Dgv_sexos_DoubleClick(object sender, EventArgs e)
        {
            Selecciona_item_sx_pv();
            Pnl_Listado_sx.Visible = false;
            Btn_lupa3.Focus();
        }

        private void Btn_retornar2_Click(object sender, EventArgs e)
        {
            Pnl_Listado_sx.Visible = false;
        }


        private void Btn_lupa3_Click(object sender, EventArgs e)
        {
            Pnl_Listado_ru.Location = Btn_lupa1.Location;
            Pnl_Listado_ru.Visible = true;
        }

        private void Dgv_rubros_DoubleClick(object sender, EventArgs e)
        {
            Selecciona_item_ru_pv();
            Pnl_Listado_ru.Visible = false;
            Txt_email_pv.Focus();
        }

        private void Btn_retornar3_Click(object sender, EventArgs e)
        {
            Pnl_Listado_ru.Visible = false;
        }

        private void Btn_buscar3_Click(object sender, EventArgs e)
        {
            Listado_ru_pv(Txt_buscar3.Text.Trim());
        }

        private void Btn_lupa4_Click(object sender, EventArgs e)
        {
            Pnl_Listado_di.Location = Btn_lupa1.Location;
            Pnl_Listado_di.Visible = true;
        }

        private void Dgv_distritos_DoubleClick(object sender, EventArgs e)
        {
            Selecciona_item_di_pv();
            Pnl_Listado_di.Visible = false;
            Txt_direccion_pv.Focus();
        }

        private void Btn_retornar4_Click(object sender, EventArgs e)
        {
            Pnl_Listado_di.Visible = false;
        }

        private void Btn_buscar4_Click(object sender, EventArgs e)
        {
            Listado_di_pv(Txt_buscar4.Text.Trim());
        }
    }
}
