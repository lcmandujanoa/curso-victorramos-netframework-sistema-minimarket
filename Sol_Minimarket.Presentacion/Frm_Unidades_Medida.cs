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
    public partial class Frm_Unidades_Medida : Form
    {
        public Frm_Unidades_Medida()
        {
            InitializeComponent();
        }

        #region "Mis Variables"
        int Codigo_um = 0;
        int Estadoguarda = 0; //Sin ninguna acción
        #endregion

        #region "Mis Métodos"
        private void Formato_um()
        {
            Dgv_principal.Columns[0].Width = 100;
            Dgv_principal.Columns[0].HeaderText = "CÓDIGO_UM";
            Dgv_principal.Columns[1].Width = 100;
            Dgv_principal.Columns[1].HeaderText = "ABREVIATURA";
            Dgv_principal.Columns[2].Width = 300;
            Dgv_principal.Columns[2].HeaderText = "MEDIDA";
        }

        private void Listado_um(string cTexto)
        {
            try
            {
                Dgv_principal.DataSource = N_Unidades_Medida.Listado_um(cTexto);
                this.Formato_um();
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
            if (string.IsNullOrEmpty(Convert.ToString(Dgv_principal.CurrentRow.Cells["codigo_um"].Value)))
            {
                MessageBox.Show("No se tiene información para visualizar", "Aviso del sistema",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                this.Codigo_um = Convert.ToInt32(Dgv_principal.CurrentRow.Cells["codigo_um"].Value);
                Txt_abreviatura_um.Text = Convert.ToString(Dgv_principal.CurrentRow.Cells["abreviatura_um"].Value);
                Txt_descripcion_um.Text = Convert.ToString(Dgv_principal.CurrentRow.Cells["descripcion_um"].Value);
            }
        }
        #endregion

        private void Frm_Unidades_Medida_Load(object sender, EventArgs e)
        {
            this.Listado_um("%");
        }

        private void Btn_guardar_Click(object sender, EventArgs e)
        {
            if (Txt_abreviatura_um.Text == string.Empty || Txt_descripcion_um.Text == string.Empty)
            {
                MessageBox.Show("Falta ingresar datos requeridos (*)", "Aviso del Sistema",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else //Se procedería a ingresar la información
            {
                E_Unidades_Medida oUm = new E_Unidades_Medida();
                string Rpta = "";
                oUm.Codigo_um = this.Codigo_um;
                oUm.Abreviatura_um = Txt_abreviatura_um.Text.Trim();
                oUm.Descripcion_um = Txt_descripcion_um.Text.Trim();
                Rpta = N_Unidades_Medida.Guardar_um(Estadoguarda, oUm);
                if (Rpta == "OK")
                {
                    this.Listado_um("%");
                    MessageBox.Show("Los datos han sido guardados correctamente", "Aviso del Sistema",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Estadoguarda = 0; //Sin ninguna acción
                    this.Estado_Botonesprincipales(true);
                    this.Estado_Botonesprocesos(false);
                    Txt_abreviatura_um.Text = "";
                    Txt_descripcion_um.Text = "";

                    Txt_abreviatura_um.ReadOnly = true;
                    Txt_descripcion_um.ReadOnly = true;

                    Tbc_principal.SelectedIndex = 0;
                    this.Codigo_um = 0;
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
            this.Estado_Botonesprincipales(false);
            this.Estado_Botonesprocesos(true);
            Txt_abreviatura_um.Text = "";
            Txt_descripcion_um.Text = "";

            Txt_abreviatura_um.ReadOnly = false;
            Txt_descripcion_um.ReadOnly = false;

            Tbc_principal.SelectedIndex = 1;
            Txt_abreviatura_um.Focus();
        }

        private void Btn_actualizar_Click(object sender, EventArgs e)
        {
            Estadoguarda = 2; //Actualizar registro
            this.Estado_Botonesprincipales(false);
            this.Estado_Botonesprocesos(true);
            this.Selecciona_item();
            Tbc_principal.SelectedIndex = 1;
            Txt_abreviatura_um.ReadOnly = false;
            Txt_descripcion_um.ReadOnly = false;
            Txt_abreviatura_um.Focus();
        }

        private void Btn_cancelar_Click(object sender, EventArgs e)
        {
            Estadoguarda = 0; //Sin ninguna acción
            this.Codigo_um = 0;
            this.Estado_Botonesprincipales(true);
            Txt_abreviatura_um.Text = "";
            Txt_descripcion_um.Text = "";
            Txt_abreviatura_um.ReadOnly = true;
            Txt_descripcion_um.ReadOnly = true;
            this.Estado_Botonesprocesos(false);
            Tbc_principal.SelectedIndex = 0;
        }

        private void Dgv_principal_DoubleClick(object sender, EventArgs e)
        {
            this.Selecciona_item();
            this.Estado_Botonesprocesos(false);
            Tbc_principal.SelectedIndex = 1;
        }

        private void Btn_retornar_Click(object sender, EventArgs e)
        {
            this.Estado_Botonesprocesos(false);
            Tbc_principal.SelectedIndex = 0;
            this.Codigo_um = 0;

            Btn_retornar.Visible = false;
            Txt_abreviatura_um.Text = "";
            Txt_descripcion_um.Text = "";
        }

        private void Btn_eliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Dgv_principal.CurrentRow.Cells["codigo_um"].Value)))
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
                    this.Codigo_um = Convert.ToInt32(Dgv_principal.CurrentRow.Cells["codigo_um"].Value);
                    Rpta = N_Unidades_Medida.Eliminar_um(this.Codigo_um);
                    if (Rpta.Equals("OK"))
                    {
                        this.Listado_um("%");
                        this.Codigo_um = 0;
                        MessageBox.Show("Registro Eliminado", "Aviso del Sistema",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                }
            }
        }

        private void Btn_buscar_Click(object sender, EventArgs e)
        {
            this.Listado_um(Txt_buscar.Text.Trim());
        }

        private void Btn_reporte_Click(object sender, EventArgs e)
        {
            Reportes.Frm_Rpt_Unidades_Medidas oRpta3 = new Reportes.Frm_Rpt_Unidades_Medidas();
            oRpta3.txt_p1.Text = Txt_buscar.Text;
            oRpta3.ShowDialog();
        }

        private void Btn_salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
