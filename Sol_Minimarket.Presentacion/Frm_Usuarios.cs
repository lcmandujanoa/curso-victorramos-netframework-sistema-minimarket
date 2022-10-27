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
    public partial class Frm_Usuarios : Form
    {
        public Frm_Usuarios()
        {
            InitializeComponent();
        }

        #region "Mis Variables"
        int Codigo_us = 0;
        int Estadoguarda = 0; //Sin ninguna acción
        #endregion

        #region "Mis Métodos"
        private void Formato_us()
        {
            Dgv_principal.Columns[0].Width = 100;
            Dgv_principal.Columns[0].HeaderText = "CÓDIGO_US";
            Dgv_principal.Columns[1].Width = 100;
            Dgv_principal.Columns[1].HeaderText = "LOGIN";
            Dgv_principal.Columns[2].Width = 250;
            Dgv_principal.Columns[2].HeaderText = "NOMBRES";
            Dgv_principal.Columns[3].Width = 200;
            Dgv_principal.Columns[3].HeaderText = "CARGO";
            Dgv_principal.Columns[3].Visible = false;
        }

        private void Listado_us(string cTexto)
        {
            try
            {
                Dgv_principal.DataSource = N_Usuarios.Listado_us(cTexto);
                this.Formato_us();
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
            if (string.IsNullOrEmpty(Convert.ToString(Dgv_principal.CurrentRow.Cells["codigo_us"].Value)))
            {
                MessageBox.Show("No se tiene información para visualizar", "Aviso del sistema",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Codigo_us = Convert.ToInt32(Dgv_principal.CurrentRow.Cells["codigo_us"].Value);
                Txt_login_us.Text = Convert.ToString(Dgv_principal.CurrentRow.Cells["login_us"].Value);
                Txt_password_us.Text = string.Empty;
                Txt_nombres_us.Text = Convert.ToString(Dgv_principal.CurrentRow.Cells["nombres_us"].Value);
                Txt_cargo_us.Text = Convert.ToString(Dgv_principal.CurrentRow.Cells["cargo_us"].Value);
                Chk_es_admin.Checked = Convert.ToBoolean(Dgv_principal.CurrentRow.Cells["es_admin"].Value);
            }
        }
        #endregion

        private void Frm_Usuarios_Load(object sender, EventArgs e)
        {
            Listado_us("%");
        }

        private void Btn_guardar_Click(object sender, EventArgs e)
        {
            if (Txt_password_us.Text == string.Empty && Estadoguarda == 1)
            {
                MessageBox.Show("Falta ingresar datos requeridos (*)", "Aviso del Sistema",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (Txt_login_us.Text == string.Empty || Txt_nombres_us.Text == string.Empty)
                {
                    MessageBox.Show("Falta ingresar datos requeridos (*)", "Aviso del Sistema",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else //Se procedería a ingresar la información
                {
                    E_Usuarios oUs = new E_Usuarios();
                    string Rpta = "";
                    oUs.Codigo_us = Codigo_us;
                    oUs.Login_us = Txt_login_us.Text.Trim();
                    oUs.Password_us = Txt_password_us.Text.Trim();
                    oUs.Nombres_us = Txt_nombres_us.Text.Trim();
                    oUs.Cargo_us = Txt_cargo_us.Text.Trim();
                    oUs.Es_admin = Chk_es_admin.Checked;

                    Rpta = N_Usuarios.Guardar_us(Estadoguarda, oUs);
                    if (Rpta == "OK")
                    {
                        Listado_us("%");
                        MessageBox.Show("Los datos han sido guardados correctamente", "Aviso del Sistema",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Estadoguarda = 0; //Sin ninguna acción
                        Estado_Botonesprincipales(true);
                        Estado_Botonesprocesos(false);

                        Txt_login_us.Text = "";
                        Txt_password_us.Text = "";
                        Txt_nombres_us.Text = "";
                        Txt_cargo_us.Text = "";
                        Chk_es_admin.Checked = false;

                        Txt_login_us.ReadOnly = true;
                        Txt_password_us.ReadOnly = true;
                        Txt_nombres_us.ReadOnly = true;
                        Txt_cargo_us.ReadOnly = true;
                        Chk_es_admin.Enabled = false;

                        Tbc_principal.SelectedIndex = 0;
                        Codigo_us = 0;
                    }
                    else
                    {
                        MessageBox.Show(Rpta, "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void Btn_nuevo_Click(object sender, EventArgs e)
        {
            Estadoguarda = 1; //Nuevo Registro
            Estado_Botonesprincipales(false);
            Estado_Botonesprocesos(true);
            Txt_login_us.Text = "";
            Txt_password_us.Text = "";
            Txt_nombres_us.Text = "";
            Txt_cargo_us.Text = "";
            Chk_es_admin.Checked = false;

            Txt_login_us.ReadOnly = false;
            Txt_password_us.ReadOnly = false;
            Txt_nombres_us.ReadOnly = false;
            Txt_cargo_us.ReadOnly = false;
            Chk_es_admin.Enabled = true;

            Tbc_principal.SelectedIndex = 1;
            Txt_login_us.Focus();
        }

        private void Btn_actualizar_Click(object sender, EventArgs e)
        {
            Estadoguarda = 2; //Actualizar registro
            Estado_Botonesprincipales(false);
            Estado_Botonesprocesos(true);
            Selecciona_item();
            Tbc_principal.SelectedIndex = 1;

            Txt_password_us.ReadOnly = false;
            Txt_nombres_us.ReadOnly = false;
            Txt_cargo_us.ReadOnly = false;
            Chk_es_admin.Enabled = true;

            Txt_password_us.Focus();
        }

        private void Btn_cancelar_Click(object sender, EventArgs e)
        {
            Estadoguarda = 0; //Sin ninguna acción
            Codigo_us = 0;
            Estado_Botonesprincipales(true);
            Estado_Botonesprocesos(false);

            Txt_login_us.Text = "";
            Txt_password_us.Text = "";
            Txt_nombres_us.Text = "";
            Txt_cargo_us.Text = "";
            Chk_es_admin.Checked = false;

            Txt_login_us.ReadOnly = true;
            Txt_password_us.ReadOnly = true;
            Txt_nombres_us.ReadOnly = true;
            Txt_cargo_us.ReadOnly = true;
            Chk_es_admin.Enabled = false;

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
            Codigo_us = 0;

            Btn_retornar.Visible = false;

            Txt_login_us.Text = "";
            Txt_password_us.Text = "";
            Txt_nombres_us.Text = "";
            Txt_cargo_us.Text = "";
            Chk_es_admin.Checked = false;
        }

        private void Btn_eliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Dgv_principal.CurrentRow.Cells["codigo_us"].Value)))
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
                    Codigo_us = Convert.ToInt32(Dgv_principal.CurrentRow.Cells["codigo_us"].Value);
                    Rpta = N_Usuarios.Eliminar_us(Codigo_us);
                    if (Rpta.Equals("OK"))
                    {
                        Listado_us("%");
                        Codigo_us = 0;
                        MessageBox.Show("Registro Eliminado", "Aviso del Sistema",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                }
            }
        }

        private void Btn_buscar_Click(object sender, EventArgs e)
        {
            Listado_us(Txt_buscar.Text.Trim());
        }

        private void Btn_reporte_Click(object sender, EventArgs e)
        {
            //Reportes.Frm_Rpt_Unidades_Medidas oRpta3 = new Reportes.Frm_Rpt_Unidades_Medidas();
            //oRpta3.txt_p1.Text = Txt_buscar.Text;
            //oRpta3.ShowDialog();
        }

        private void Btn_salir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
