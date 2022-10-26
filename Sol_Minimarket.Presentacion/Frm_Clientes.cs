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
    public partial class Frm_Clientes : Form
    {
        public Frm_Clientes()
        {
            InitializeComponent();
        }

        #region "Mis Variables"
        int Codigo_cl = 0;
        int Codigo_tdpc = 0;
        int Codigo_sx = 0;
        int Codigo_ru = 0;
        int Codigo_di = 0;
        int Estadoguarda = 0; //Sin ninguna acción
        #endregion

        #region "Mis Métodos"
        private void Formato_cl()
        {
            Dgv_principal.Columns[0].Width = 90;
            Dgv_principal.Columns[0].HeaderText = "CÓDIGO_CL";
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

        private void Listado_cl(string cTexto)
        {
            try
            {
                Dgv_principal.DataSource = N_Clientes.Listado_cl(cTexto);
                this.Formato_cl();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void Estado_Botonesprincipales(bool lEstado) 
        {
            Btn_nuevo.Enabled = lEstado;
            Btn_actualizar.Enabled = lEstado;
            Btn_eliminar.Enabled = lEstado;
            Btn_reporte.Enabled = lEstado;
            Btn_salir.Enabled = lEstado;
        }

        private void Estado_Botonesprocesos(bool lEstado)
        {
            Btn_cancelar.Visible = lEstado;
            Btn_guardar.Visible = lEstado;
            Btn_retornar.Visible = !lEstado;
        }

        private void Selecciona_item()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Dgv_principal.CurrentRow.Cells["codigo_cl"].Value)))
            {
                MessageBox.Show("No se tiene información para visualizar", "Aviso del sistema",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string Distrito = "";
                Codigo_cl = Convert.ToInt32(Dgv_principal.CurrentRow.Cells["codigo_cl"].Value);
                Codigo_tdpc = Convert.ToInt32(Dgv_principal.CurrentRow.Cells["codigo_tdpc"].Value);
                Txt_descripcion_tdpc.Text = Convert.ToString(Dgv_principal.CurrentRow.Cells["descripcion_tdpc"].Value);
                Txt_nrodocumento_cl.Text = Convert.ToString(Dgv_principal.CurrentRow.Cells["nrodocumento_cl"].Value);
                Txt_razon_social_cl.Text = Convert.ToString(Dgv_principal.CurrentRow.Cells["razon_social_cl"].Value);
                Txt_nombres.Text = Convert.ToString(Dgv_principal.CurrentRow.Cells["nombres"].Value);
                Txt_apellidos.Text = Convert.ToString(Dgv_principal.CurrentRow.Cells["apellidos"].Value);
                Codigo_ru = Convert.ToInt32(Dgv_principal.CurrentRow.Cells["codigo_ru"].Value);
                Txt_descripcion_ru.Text = Convert.ToString(Dgv_principal.CurrentRow.Cells["descripcion_ru"].Value);
                Txt_email_cl.Text = Convert.ToString(Dgv_principal.CurrentRow.Cells["email_cl"].Value);
                Txt_telefono_cl.Text = Convert.ToString(Dgv_principal.CurrentRow.Cells["telefono_cl"].Value);
                Txt_movil_cl.Text = Convert.ToString(Dgv_principal.CurrentRow.Cells["movil_cl"].Value);
                Codigo_sx = Convert.ToInt32(Dgv_principal.CurrentRow.Cells["codigo_sx"].Value);
                Txt_descripcion_sx.Text = Convert.ToString(Dgv_principal.CurrentRow.Cells["descripcion_sx"].Value);
                Txt_direccion_cl.Text = Convert.ToString(Dgv_principal.CurrentRow.Cells["direccion_cl"].Value);
                Codigo_di = Convert.ToInt32(Dgv_principal.CurrentRow.Cells["codigo_di"].Value);
                Distrito = Convert.ToString(Dgv_principal.CurrentRow.Cells["descripcion_di"].Value).Trim() + "  ||  " +
                            Convert.ToString(Dgv_principal.CurrentRow.Cells["descripcion_po"].Value).Trim() + "  ||  " +
                            Convert.ToString(Dgv_principal.CurrentRow.Cells["descripcion_de"].Value).Trim();
                Txt_distrito.Text = Distrito;
                Txt_observacion_cl.Text = Convert.ToString(Dgv_principal.CurrentRow.Cells["observacion_cl"].Value).Trim();
            }
        }

        private void Formato_tdpc_cl()
        {
            Dgv_tipo_tdpc.Columns[0].Width = 200;
            Dgv_tipo_tdpc.Columns[0].HeaderText = "TIPO DOCUMENTO";
            Dgv_tipo_tdpc.Columns[1].Visible = false;
        }

        private void Listado_tdpc_cl()
        {
            try
            {
                Dgv_tipo_tdpc.DataSource = N_Clientes.Listado_tdpc_cl();
                Formato_tdpc_cl();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void Selecciona_item_tdpc_cl()
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

        private void Formato_sx_cl()
        {
            Dgv_sexos.Columns[0].Width = 200;
            Dgv_sexos.Columns[0].HeaderText = "SEXO";
            Dgv_sexos.Columns[1].Visible = false;
        }

        private void Listado_sx_cl()
        {
            try
            {
                Dgv_sexos.DataSource = N_Clientes.Listado_sx_cl();
                Formato_sx_cl();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void Selecciona_item_sx_cl()
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

        private void Formato_ru_cl()
        {
            Dgv_rubros.Columns[0].Width = 200;
            Dgv_rubros.Columns[0].HeaderText = "RUBRO";
            Dgv_rubros.Columns[1].Visible = false;
        }

        private void Listado_ru_cl(string cTexto)
        {
            try
            {
                Dgv_rubros.DataSource = N_Clientes.Listado_ru_cl(cTexto);
                Formato_ru_cl();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void Selecciona_item_ru_cl()
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

        private void Formato_di_cl()
        {
            Dgv_distritos.Columns[0].Width = 200;
            Dgv_distritos.Columns[0].HeaderText = "DISTRITO";
            Dgv_distritos.Columns[1].Width = 200;
            Dgv_distritos.Columns[1].HeaderText = "PROVINCIA";
            Dgv_distritos.Columns[2].Width = 200;
            Dgv_distritos.Columns[2].HeaderText = "DEPARTAMENTO";
            Dgv_distritos.Columns[3].Visible = false;
        }

        private void Listado_di_cl(string cTexto)
        {
            try
            {
                Dgv_distritos.DataSource = N_Clientes.Listado_di_cl(cTexto);
                Formato_di_cl();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void Selecciona_item_di_cl()
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
            Txt_nrodocumento_cl.ReadOnly = !lEstado;
            Txt_razon_social_cl.ReadOnly = !lEstado;
            Txt_nombres.ReadOnly = !lEstado;
            Txt_apellidos.ReadOnly = !lEstado;
            Txt_email_cl.ReadOnly = !lEstado;
            Txt_telefono_cl.ReadOnly = !lEstado;
            Txt_movil_cl.ReadOnly = !lEstado;
            Txt_direccion_cl.ReadOnly = !lEstado;
            Txt_observacion_cl.ReadOnly = !lEstado;
        }

        private void Limpia_texto()
        {
            Txt_nrodocumento_cl.Text = string.Empty;
            Txt_razon_social_cl.Text = string.Empty;
            Txt_nombres.Text = string.Empty;
            Txt_apellidos.Text = string.Empty;
            Txt_email_cl.Text = string.Empty;
            Txt_telefono_cl.Text = string.Empty;
            Txt_movil_cl.Text = string.Empty;
            Txt_direccion_cl.Text = string.Empty;
            Txt_observacion_cl.Text = string.Empty;
        }
        #endregion

        private void Frm_Clientes_Load(object sender, EventArgs e)
        {
            Listado_cl("%");
            Listado_tdpc_cl();
            Listado_sx_cl();
            Listado_ru_cl("%");
            Listado_di_cl("%");
        }

        private void Btn_guardar_Click(object sender, EventArgs e)
        {
            if (Txt_descripcion_tdpc.Text == string.Empty ||
                Txt_nrodocumento_cl.Text == string.Empty ||
                Txt_razon_social_cl.Text == string.Empty ||
                Txt_descripcion_sx.Text == string.Empty ||
                Txt_descripcion_ru.Text == string.Empty ||
                Txt_distrito.Text == string.Empty ||
                Txt_direccion_cl.Text == string.Empty)
            {
                MessageBox.Show("Falta ingresar datos requeridos (*)", "Aviso del Sistema",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else //Se procedería a ingresar la información
            {
                string Rpta = "";

                E_Clientes oCl = new E_Clientes();
                oCl.Codigo_cl = Codigo_cl;
                oCl.Codigo_tdpc = Codigo_tdpc;
                oCl.Nrodocumento_cl = Txt_nrodocumento_cl.Text.Trim();
                oCl.Razon_social_cl = Txt_razon_social_cl.Text.Trim();
                oCl.Nombres = Txt_nombres.Text.Trim();
                oCl.Apellidos= Txt_apellidos.Text.Trim();
                oCl.Codigo_sx = Codigo_sx;
                oCl.Codigo_ru = Codigo_ru;
                oCl.Email_cl= Txt_email_cl.Text.Trim();
                oCl.Telefono_cl= Txt_telefono_cl.Text.Trim();
                oCl.Movil_cl = Txt_movil_cl.Text.Trim();
                oCl.Direccion_cl = Txt_direccion_cl.Text.Trim();
                oCl.Codigo_di = Codigo_di;
                oCl.Observacion_cl = Txt_observacion_cl.Text.Trim();

                Rpta = N_Clientes.Guardar_cl(Estadoguarda, oCl);
                if (Rpta.Equals("OK"))
                {
                    Listado_cl("%");
                    MessageBox.Show("Los datos han sido guardados correctamente", "Aviso del Sistema",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Estadoguarda = 0; //Sin ninguna acción
                    Estado_Botonesprincipales(true);
                    Estado_Botonesprocesos(false);
                    Estado_texto(false);
                    Tbc_principal.SelectedIndex = 0;
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
            Txt_nrodocumento_cl.Focus();
        }

        private void Btn_actualizar_Click(object sender, EventArgs e)
        {
            Estadoguarda = 2; //Actualizar registro
            Estado_Botonesprincipales(false);
            Estado_Botonesprocesos(true);
            Estado_texto(true);
            Selecciona_item();
            Tbc_principal.SelectedIndex = 1;
            Txt_nrodocumento_cl.Focus();
        }

        private void Btn_cancelar_Click(object sender, EventArgs e)
        {
            Estadoguarda = 0; //Sin ninguna acción
            Codigo_cl = 0;
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
            Txt_nrodocumento_cl.Text = "";
        }

        private void Btn_eliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Dgv_principal.CurrentRow.Cells["codigo_cl"].Value)))
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
                    Codigo_cl = Convert.ToInt32(Dgv_principal.CurrentRow.Cells["codigo_cl"].Value);
                    Rpta = N_Clientes.Eliminar_cl(Codigo_cl);
                    if (Rpta.Equals("OK"))
                    {
                        Listado_cl("%");
                        Codigo_cl = 0;
                        MessageBox.Show("Registro Eliminado", "Aviso del Sistema",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                }                
            }
        }

        private void Btn_buscar_Click(object sender, EventArgs e)
        {
            Listado_cl(Txt_buscar.Text.Trim());
        }

        private void Btn_reporte_Click(object sender, EventArgs e)
        {
            Reportes.Frm_Rpt_Clientes oRpta12 = new Reportes.Frm_Rpt_Clientes();
            oRpta12.txt_p1.Text = Txt_buscar.Text;
            oRpta12.ShowDialog();
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
            Selecciona_item_tdpc_cl();
            Pnl_Listado_tdpc.Visible = false;
            Txt_nrodocumento_cl.Focus();
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
            Selecciona_item_sx_cl();
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
            Selecciona_item_ru_cl();
            Pnl_Listado_ru.Visible = false;
            Txt_email_cl.Focus();
        }

        private void Btn_retornar3_Click(object sender, EventArgs e)
        {
            Pnl_Listado_ru.Visible = false;
        }

        private void Btn_buscar3_Click(object sender, EventArgs e)
        {
            Listado_ru_cl(Txt_buscar3.Text.Trim());
        }

        private void Btn_lupa4_Click(object sender, EventArgs e)
        {
            Pnl_Listado_di.Location = Btn_lupa1.Location;
            Pnl_Listado_di.Visible = true;
        }

        private void Dgv_distritos_DoubleClick(object sender, EventArgs e)
        {
            Selecciona_item_di_cl();
            Pnl_Listado_di.Visible = false;
            Txt_direccion_cl.Focus();
        }

        private void Btn_retornar4_Click(object sender, EventArgs e)
        {
            Pnl_Listado_di.Visible = false;
        }

        private void Btn_buscar4_Click(object sender, EventArgs e)
        {
            Listado_di_cl(Txt_buscar4.Text.Trim());
        }
    }
}
