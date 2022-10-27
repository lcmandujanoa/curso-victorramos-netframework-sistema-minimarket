using Sol_Minimarket.Negocio;
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
    public partial class Frm_Login : Form
    {
        public Frm_Login()
        {
            InitializeComponent();
        }

        # region "Mis Métodos"

        private void Login_us(string cLogin_us, string cPassword_us)
        {
            try
            {
                DataTable data_login = new DataTable();
                data_login = N_Usuarios.Login_us(cLogin_us, cPassword_us);
                if (data_login.Rows.Count > 0)
                {
                    string cNombres = "";
                    string cCargo = "";
                    bool bEs_admin = false;
                    cNombres = data_login.Rows[0][3].ToString();
                    cCargo = data_login.Rows[0][4].ToString();
                    bEs_admin = Convert.ToBoolean(data_login.Rows[0][5]);
                    
                    Frm_DashBoard oDashBoard = new Frm_DashBoard();
                    oDashBoard.Lbl_nombres_us.Text = "Nombres: " + cNombres;
                    oDashBoard.Lbl_cargo_us.Text = "Cargo: " + cCargo;
                    oDashBoard.Chk_es_admin.Checked = bEs_admin;
                    oDashBoard.Chk_es_admin.Visible = bEs_admin;

                    if (bEs_admin) // Administrador
                    {
                        oDashBoard.Btn_procesos.Enabled = true;
                        oDashBoard.Btn_reportes.Enabled = true;
                        oDashBoard.Btn_datos_maestros.Enabled = true;
                        oDashBoard.Btn_sistemas.Enabled = true;
                    }
                    else // Usuario normal
                    {
                        oDashBoard.Btn_procesos.Enabled = true;
                        oDashBoard.Btn_reportes.Enabled = true;
                        oDashBoard.Btn_datos_maestros.Enabled = false;
                        oDashBoard.Btn_sistemas.Enabled = false;
                    }

                    oDashBoard.Show();
                    oDashBoard.FormClosed += Logout;
                    Hide();
                }
                else
                {
                    MessageBox.Show("Acceso errado", "Aviso del sistema");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void Logout(object sender, FormClosedEventArgs e)
        {
            Txt_login_us.Text = "";
            Txt_password_us.Text = "";
            Show();
            Txt_login_us.Focus();
        }
        #endregion

        private void Btn_iniciar_Click(object sender, EventArgs e)
        {
            Login_us(Txt_login_us.Text, Txt_password_us.Text);
        }

        private void Btn_salir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Txt_password_us_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Btn_iniciar.PerformClick();
            }
        }
    }
}
