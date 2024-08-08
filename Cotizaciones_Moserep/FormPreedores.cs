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
    public partial class FormPreedores : Form
    {
        public bool nuevo = true;
        public FormPreedores()
        {
            InitializeComponent();
        }

        private void cmbProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            llenarCampos();
        }

        private void limpiarCampos()
        {
            txtProveedor.Text = ""; ;
            txtRfc.Text = "";
            txtDireccion.Text = "";
            ckActivo.Checked = false;
        }
        
        private void llenarCampos()
        {
            if (cmbProveedor.SelectedItem != null)
            {
                suppliers.proveedorSeleccionado = (suppliers)cmbProveedor.SelectedItem;
                txtProveedor.Text = suppliers.proveedorSeleccionado.name;
                txtRfc.Text = suppliers.proveedorSeleccionado.rfc;
                txtDireccion.Text = suppliers.proveedorSeleccionado.address;
                ckActivo.Checked = suppliers.proveedorSeleccionado.active;
            }
            else
            {
                limpiarCampos();
            }
        }

        private void FormPreedores_Load(object sender, EventArgs e)
        {
            inicioFormulario();
        }

        private void inicioFormulario()
        {
            if (nuevo == true)
            {
                lblProveedores.Visible = false;
                cmbProveedor.Visible = false;
                btnContactos.Visible = false;
            }
            else
            {
                lblProveedores.Visible = true;
                cmbProveedor.Visible = true;
                traerProveedores();
                btnContactos.Visible = true;
            }
            cmbProveedor.SelectedItem = null;
            suppliers.proveedorSeleccionado = null;
        }
        
        private void traerProveedores()
        {
            cmbProveedor.DataSource = suppliers.listaProveedores;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string error = "";
            controladorProveedor controladorProveedor = new controladorProveedor();
            error = controladorProveedor.validarCampos(txtProveedor.Text);
            if (error != "")
            {
                MessageBox.Show(error);
                return;
            }
            if (nuevo == true)
            {

                error = controladorProveedor.validarDuplicado(txtProveedor.Text);
                if (error != "")
                {
                    MessageBox.Show(error);
                    return;
                }
                suppliers.proveedorSeleccionado = new suppliers();
                controladorProveedor.llenarProveedor(txtProveedor.Text, txtRfc.Text, txtDireccion.Text, ckActivo.Checked);
                suppliers.proveedorSeleccionado.id = Convert.ToInt32(baseDatos.insertarProveedor());
                suppliers.listaProveedores.Add(suppliers.proveedorSeleccionado);
                suppliers.listaProveedoresActivos.Add(suppliers.proveedorSeleccionado);
                this.Close();
            }
            else
            {
                controladorProveedor.llenarProveedor(txtProveedor.Text, txtRfc.Text, txtDireccion.Text, ckActivo.Checked);
                baseDatos.editarProveedor();
                suppliers.listaProveedores.Add(suppliers.proveedorSeleccionado);
                if (suppliers.proveedorSeleccionado.active == true)
                    suppliers.listaProveedoresActivos.Add(suppliers.proveedorSeleccionado);
                this.Close();
            }
        }

        private void btnContactos_Click(object sender, EventArgs e)
        {
            if (suppliers.proveedorSeleccionado == null)
            {
                MessageBox.Show("Se debe elegir un proveedor");
                return;
            }
            FormContactoProveedor formcontacto = new FormContactoProveedor();
            this.Hide();
            formcontacto.nuevo = false;
            formcontacto.ShowDialog();
            this.Show();
        }
    }
}
