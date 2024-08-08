using Org.BouncyCastle.Crypto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cotizaciones_Moserep
{
    public partial class FormUsuario : Form
    {
        public bool nuevo=false;
        users usuario;
        users usuarioElegido;
        public FormUsuario()
        {
            InitializeComponent();
        }

        private void cbUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbUsuarios.SelectedItem != null)
            {
                usuarioElegido = (users)cbUsuarios.SelectedItem;
                usuario = usuarioElegido;
                llenarCampos();
            }
        }

        private void llenarCampos()
        {
            txtUsuario.Text = usuarioElegido.user;
            txtPassword.Text = usuarioElegido.password;
            txtNombre.Text = usuarioElegido.name;
            txtEmail.Text= usuarioElegido.email;
            if (usuarioElegido.idProfile >0) {
                profile_user perfil = controladorUsuario.obtenerPerfile(usuarioElegido.idProfile);
                cbPerfil.Text = perfil.profile;
            }
            ckActivo.Checked = usuarioElegido.active;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (cbPerfil.SelectedItem == null)
            {
                MessageBox.Show("Se deve elegir un perfil");
                return;
            }
            string error = "";
            controladorUsuario controladorusuario = new controladorUsuario();
            if (nuevo == true)
            {
                usuario = new users();
                error = controladorusuario.validarDuplicado(txtUsuario.Text);
                if (error != "")
                {
                    MessageBox.Show(error);
                    return;
                }
                ckActivo.Checked = true;
                controladorusuario.llenarContacto(txtUsuario.Text, txtPassword.Text, profile_user.perfilSeleccionado.id, txtNombre.Text, txtEmail.Text, ckActivo.Checked, ref usuario);
                usuario.id = Convert.ToInt32(baseDatos.insertarUsuario(usuario));
                users.listaUsuarios.Add(usuario);
                if (usuario.idProfile == 2 || usuario.idProfile == 3)
                    users.listaVendedores.Add(usuario);
            }
            else
            {
                controladorusuario.llenarContacto(txtUsuario.Text, txtPassword.Text, profile_user.perfilSeleccionado.id, txtNombre.Text, txtEmail.Text, ckActivo.Checked, ref usuario);
                baseDatos.editarUsuario(usuario);
                users.listaUsuarios.Remove(usuarioElegido);
                users.listaUsuarios.Add(usuario);
                if (usuario.idProfile == 2 || usuario.idProfile == 3)
                {
                    users.listaVendedores.Remove(usuarioElegido);
                    users.listaVendedores.Add(usuario);
                }
            }
            this.Close();
        }

        private void FormUsuario_Load(object sender, EventArgs e)
        {
            cbPerfil.DataSource = profile_user.listaPerfiles;
            cbPerfil.SelectedItem = null;
            profile_user.perfilSeleccionado = null;
            if (nuevo == false)
            {
                lblUsuarios.Visible = true;
                cbUsuarios.Visible = true;
                cbUsuarios.DataSource = users.listaUsuarios;
            }
        }

        private void cbPerfil_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbPerfil.SelectedItem != null)
                profile_user.perfilSeleccionado = (profile_user)cbPerfil.SelectedItem;
        }
    }
}
