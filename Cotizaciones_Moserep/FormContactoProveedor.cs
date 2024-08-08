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
    public partial class FormContactoProveedor : Form
    {
        public bool nuevo = false;
        public FormContactoProveedor()
        {
            InitializeComponent();
        }

        private void cmbContacto_SelectedIndexChanged(object sender, EventArgs e)
        {
            llenarCampos();
        }

        private void limpiarCampos()
        {
            txtNombre.Text = ""; ;
            txtEmail.Text = "";
            txtTelefono.Text = "";
            ckActivo.Checked = false;
        }

        private void llenarCampos()
        {
            if (cmbContacto.SelectedItem != null)
            {
                supplier_contact.contactoSeleccionado = (supplier_contact)cmbContacto.SelectedItem;
                txtNombre.Text = supplier_contact.contactoSeleccionado.name;
                txtEmail.Text = supplier_contact.contactoSeleccionado.email;
                txtTelefono.Text = supplier_contact.contactoSeleccionado.phone;
                ckActivo.Checked = supplier_contact.contactoSeleccionado.active;
            }
            else
            {
                limpiarCampos();
            }
        }

        private void FormContactoProveedor_Load(object sender, EventArgs e)
        {
            inicioFormulario();
        }

        private void inicioFormulario()
        {
            if (nuevo == true)
            {
                lblContacto.Visible = false;
                cmbContacto.Visible = false;
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
            cmbContacto.DataSource = supplier_contact.listaContactos.Where(i => i.idsupplier.Equals(suppliers.proveedorSeleccionado.id)).ToList();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string error = "";
            controladorContactoProveedor controladorContactoProveedor = new controladorContactoProveedor();
            error = controladorContactoProveedor.validarCampos(txtNombre.Text);
            if (error != "")
            {
                MessageBox.Show(error);
                return;
            }
            if (nuevo == true)
            {
                error = controladorContactoProveedor.validarDuplicado(txtNombre.Text);
                if (error != "")
                {
                    MessageBox.Show(error);
                    return;
                }
                supplier_contact.contactoSeleccionado = new supplier_contact();
                supplier_contact.listaContactosDeProveedor = null;
                controladorContactoProveedor.llenarContacto(txtNombre.Text, txtEmail.Text, txtTelefono.Text, ckActivo.Checked);
                supplier_contact.contactoSeleccionado.id = Convert.ToInt32(baseDatos.insertarContactoProveedor());
                supplier_contact.listaContactos.Add(supplier_contact.contactoSeleccionado);
                supplier_contact.listaContactosDeProveedor = supplier_contact.listaContactos.Where(i => i.active.Equals(true) && i.idsupplier.Equals(suppliers.proveedorSeleccionado.id)).ToList();
                this.Close();
            }
            else
            {
                supplier_contact.listaContactos.Remove(supplier_contact.contactoSeleccionado);
                supplier_contact.listaContactosDeProveedor = null;
                controladorContactoProveedor.llenarContacto(txtNombre.Text, txtEmail.Text, txtTelefono.Text, ckActivo.Checked);
                baseDatos.editarContactoProveedor();
                supplier_contact.listaContactos.Add(supplier_contact.contactoSeleccionado);
                supplier_contact.listaContactosDeProveedor = supplier_contact.listaContactos.Where(i => i.active.Equals(true) && i.idsupplier.Equals(suppliers.proveedorSeleccionado.id)).ToList();
                this.Close();
            }
        }
    }
}
