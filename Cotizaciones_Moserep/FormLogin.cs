using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cotizaciones_Moserep
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void btnGuardarCotizacion_Click(object sender, EventArgs e)
        {
            string nombreUsuario = baseDatos.consultas("select NAME from users where USER='" + txtUsuario.Text + "' and PASSWORD='"+ txtPassword.Text+"' limit 1");
            users.usuarioActual = null;
            controladorUsuario controladorUsuario = new controladorUsuario();
            //SecureString theSecureString = new NetworkCredential("", txtPassword.Text).SecurePassword;
            controladorUsuario.login(txtUsuario.Text, txtPassword.Text);
            if (users.usuarioActual == null)
            {
                MessageBox.Show("Los datos son incorrectos");
                return;
            }
            else
            {
                if (ckActivo.Checked == true)
                {
                    Properties.Settings.Default.idUsuario = users.usuarioActual.id;
                    Properties.Settings.Default.Save();
                }
                this.Close();
            }
            //users.usuarioActual = new users(txtUsuario.Text, txtPassword.Text);
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
