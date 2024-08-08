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
    public partial class FormContactocliente : Form
    {
        public bool nuevo=false;
        public FormContactocliente()
        {
            InitializeComponent();
        }

        private void cmbCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            llenarCampos();
        }
        private void llenarCampos()
        {
            if (cmbContacto.SelectedItem != null)
            {
                client_contact.contactoSeleccionado = (client_contact)cmbContacto.SelectedItem;
                txtNombre.Text = client_contact.contactoSeleccionado.name;
                txtEmail.Text = client_contact.contactoSeleccionado.email;
                txtTelefono.Text = client_contact.contactoSeleccionado.phone;
                ckActivo.Checked = client_contact.contactoSeleccionado.active;
            }
            else
            {
                limpiarCampos();
            }
        }

        private void limpiarCampos()
        {
            txtNombre.Text = ""; ;
            txtEmail.Text = "";
            txtTelefono.Text = "";
            ckActivo.Checked = false;
        }
        private void FormContactocliente_Load(object sender, EventArgs e)
        {
            inicioFormulario();
        }
        private void inicioFormulario()
        {
            if (nuevo == true)
            {
                lblContacto.Visible = false;
                cmbContacto.Visible = false;
                ckActivo.Checked = true;
            }
            else
            {
                lblContacto.Visible = true;
                cmbContacto.Visible = true;
                traerContactos();
            }
            cmbContacto.SelectedItem = null;
        }

        private void traerContactos()
        {
            cmbContacto.DataSource = null;
            client_contact.listaContactosDeCliente = null;
            client_contact.listaContactosDeCliente = client_contact.listaContactos.Where(i => i.idClient.Equals(clients.clienteSeleccionado.id)).ToList();
            cmbContacto.DataSource = client_contact.listaContactosDeCliente;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string error = "";
            controladorContactoCliente controladorContactoCliente = new controladorContactoCliente();
            error = controladorContactoCliente.validarCampos(txtNombre.Text);
            if (error != "")
            {
                MessageBox.Show(error);
                return;
            }
            if (nuevo == true)
            {

                error = controladorContactoCliente.validarDuplicado(txtNombre.Text);
                if (error != "")
                {
                    MessageBox.Show(error);
                    return;
                }
                client_contact.contactoSeleccionado = new client_contact();
                client_contact.listaContactosDeCliente = null;
                ckActivo.Checked = true;
                controladorContactoCliente.llenarContacto(txtNombre.Text, txtEmail.Text, txtTelefono.Text, ckActivo.Checked);
                client_contact.contactoSeleccionado.id = Convert.ToInt32(baseDatos.insertarContactoCliente());
                client_contact.contactoSeleccionado.idClient = clients.clienteSeleccionado.id;
                client_contact.listaContactos.Add(client_contact.contactoSeleccionado);
                client_contact.listaContactosDeCliente= client_contact.listaContactos.Where(i => i.active.Equals(true) && i.idClient.Equals(clients.clienteSeleccionado.id)).ToList();
                this.Close();
            }
            else
            {
                client_contact.listaContactos.Remove(client_contact.contactoSeleccionado);
                client_contact.listaContactosDeCliente=null;
                controladorContactoCliente.llenarContacto(txtNombre.Text, txtEmail.Text, txtTelefono.Text, ckActivo.Checked);
                baseDatos.editarContactoCliente();
                client_contact.listaContactos.Add(client_contact.contactoSeleccionado);
                client_contact.listaContactosDeCliente = client_contact.listaContactos.Where(i => i.active.Equals(true) && i.idClient.Equals(clients.clienteSeleccionado.id)).ToList();
                this.Close();
            }
        }
    }
}
