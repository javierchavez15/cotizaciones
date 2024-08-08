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
    public partial class FormClientes : Form
    {
        public bool nuevo = true;
        public FormClientes()
        {
            InitializeComponent();
        }

        private void cmbCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            llenarCampos();
        }

        private void llenarCampos()
        {
            if (cmbCliente.SelectedItem != null)
            {
                clients.clienteSeleccionado = (clients)cmbCliente.SelectedItem;
                txtCliente.Text = clients.clienteSeleccionado.name;
                txtRfc.Text = clients.clienteSeleccionado.rfc;
                txtDireccion.Text = clients.clienteSeleccionado.address;
                ckActivo.Checked = clients.clienteSeleccionado.active;
                controladorUsuario controladorUsuario = new controladorUsuario();
                cbVendedor.SelectedItem = controladorUsuario.obetenerVendedorCliente(clients.clienteSeleccionado.idSeller);
            }
            else
            {
                limpiarCampos();
            }
        }

        private void limpiarCampos()
        {
            txtCliente.Text= ""; ;
            txtRfc.Text = "";
            txtDireccion.Text = "";
            ckActivo.Checked = false;
        }

        private void FormClientes_Load(object sender, EventArgs e)
        {
            cmbIva.DataSource = iva.listaIvas;
            cmbIva.SelectedItem = null;
            inicioFormulario();
            limpiarCampos();
            if (nuevo == true)
                ckActivo.Checked = true;
        }

        private void inicioFormulario()
        {
            cbVendedor.DataSource = users.listaVendedores;
            if(nuevo==true)
            {
                lblCliente.Visible = false;
                cmbCliente.Visible=false;
                ckActivo.Checked = true;
            }
            else
            {
                lblCliente.Visible = true;
                cmbCliente.Visible=true;
                traerClientes();
            }
            cmbCliente.SelectedItem = null;
            cbVendedor.SelectedItem = null;
        }

        private void traerClientes()
        {
            cmbCliente.DataSource=clients.listaClientes;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string error="";
            controladorCliente controladorCliente = new controladorCliente();
            error = controladorCliente.validarCampos(txtCliente.Text);
            if (error != "")
            {
                MessageBox.Show(error);
                return;
            }
            int idvendedor = 0;
            if (cbVendedor.SelectedItem != null)
            {
                users vendedor = (users)cbVendedor.SelectedItem;
                idvendedor = vendedor.id;
            }
            if (nuevo==true) 
            {
                error= controladorCliente.validarDuplicado(txtCliente.Text);
                if (error != "")
                {
                    MessageBox.Show(error);
                    return;
                }
                ckActivo.Checked = true;
                clients.clienteSeleccionado = new clients();
                controladorCliente.llenarCliente(txtCliente.Text, txtRfc.Text, txtDireccion.Text,ckActivo.Checked, idvendedor);
                clients.clienteSeleccionado.id=Convert.ToInt32(baseDatos.agregarCliente());
                clients.listaClientes.Add(clients.clienteSeleccionado);
                clients.listaClientesActivos.Add(clients.clienteSeleccionado);
                this.Close();
            }
            else
            {
                clients.listaClientes.Remove(clients.clienteSeleccionado);
                clients.listaClientesActivos.Remove(clients.clienteSeleccionado);
                controladorCliente.llenarCliente(txtCliente.Text, txtRfc.Text, txtDireccion.Text, ckActivo.Checked, idvendedor);
                baseDatos.editarCliente();
                clients.listaClientes.Add(clients.clienteSeleccionado);
                if(clients.clienteSeleccionado.active==true)
                    clients.listaClientesActivos.Add(clients.clienteSeleccionado);
                this.Close();
            }
        }

        private void cmbIva_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbIva.SelectedItem!=null)
                iva.ivaSeleccionado=(iva)cmbIva.SelectedItem;
        }
    }
}
