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
    public partial class Frm_Departamentos : Form
    {
        public Frm_Departamentos()
        {
            InitializeComponent();
        }

        #region "Mis Variables"
        int Codigo_de = 0;
        int Estadoguarda = 0; //Sin ninguna acción
        #endregion

        #region "Mis Métodos"
        private void Formato_de()
        {
            Dgv_principal.Columns[0].Width = 100;
            Dgv_principal.Columns[0].HeaderText = "CÓDIGO_DE";
            Dgv_principal.Columns[1].Width = 300;
            Dgv_principal.Columns[1].HeaderText = "DEPARTAMENTO";
        }

        private void Listado_de(string cTexto)
        {
            try
            {
                Dgv_principal.DataSource = N_Departamentos.Listado_de(cTexto);
                this.Formato_de();
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
            if (string.IsNullOrEmpty(Convert.ToString(Dgv_principal.CurrentRow.Cells["codigo_de"].Value)))
            {
                MessageBox.Show("No se tiene información para visualizar", "Aviso del sistema",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                this.Codigo_de = Convert.ToInt32(Dgv_principal.CurrentRow.Cells["codigo_de"].Value);
                Txt_descripcion_de.Text = Convert.ToString(Dgv_principal.CurrentRow.Cells["descripcion_de"].Value);
            }
        }
        #endregion

        private void Frm_Departamentos_Load(object sender, EventArgs e)
        {
            this.Listado_de("%");
        }

        private void Btn_guardar_Click(object sender, EventArgs e)
        {
            if (Txt_descripcion_de.Text == string.Empty)
            {
                MessageBox.Show("Falta ingresar datos requeridos (*)", "Aviso del Sistema",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else //Se procedería a ingresar la información
            {
                E_Departamentos oDe = new E_Departamentos();
                string Rpta = "";
                oDe.Codigo_de = this.Codigo_de;
                oDe.Descripcion_de = Txt_descripcion_de.Text;
                Rpta = N_Departamentos.Guardar_de(Estadoguarda, oDe);
                if (Rpta == "OK")
                {
                    this.Listado_de("%");
                    MessageBox.Show("Los datos han sido guardados correctamente", "Aviso del Sistema",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Estadoguarda = 0; //Sin ninguna acción
                    this.Estado_Botonesprincipales(true);
                    this.Estado_Botonesprocesos(false);
                    Txt_descripcion_de.Text = "";
                    Txt_descripcion_de.ReadOnly = true;
                    Tbc_principal.SelectedIndex = 0;
                    this.Codigo_de = 0;
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
            Txt_descripcion_de.Text = "";
            Txt_descripcion_de.ReadOnly = false;
            Tbc_principal.SelectedIndex = 1;
            Txt_descripcion_de.Focus();
        }

        private void Btn_actualizar_Click(object sender, EventArgs e)
        {
            Estadoguarda = 2; //Actualizar registro
            this.Estado_Botonesprincipales(false);
            this.Estado_Botonesprocesos(true);
            this.Selecciona_item();
            Tbc_principal.SelectedIndex = 1;
            Txt_descripcion_de.ReadOnly = false;
            Txt_descripcion_de.Focus();
        }

        private void Btn_cancelar_Click(object sender, EventArgs e)
        {
            Estadoguarda = 0; //Sin ninguna acción
            this.Codigo_de = 0;
            this.Estado_Botonesprincipales(true);
            Txt_descripcion_de.Text = "";
            Txt_descripcion_de.ReadOnly = true;
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
            this.Codigo_de = 0;

            Btn_retornar.Visible = false;
            Txt_descripcion_de.Text = "";
        }

        private void Btn_eliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Dgv_principal.CurrentRow.Cells["codigo_de"].Value)))
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
                    this.Codigo_de = Convert.ToInt32(Dgv_principal.CurrentRow.Cells["codigo_de"].Value);
                    Rpta = N_Departamentos.Eliminar_de(this.Codigo_de);
                    if (Rpta.Equals("OK"))
                    {
                        this.Listado_de("%");
                        this.Codigo_de = 0;
                        MessageBox.Show("Registro Eliminado", "Aviso del Sistema",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                }
            }
        }

        private void Btn_buscar_Click(object sender, EventArgs e)
        {
            this.Listado_de(Txt_buscar.Text.Trim());
        }

        private void Btn_reporte_Click(object sender, EventArgs e)
        {
            Reportes.Frm_Rpt_Departamentos oRpta6 = new Reportes.Frm_Rpt_Departamentos();
            oRpta6.txt_p1.Text = Txt_buscar.Text;
            oRpta6.ShowDialog();
        }

        private void Btn_salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
