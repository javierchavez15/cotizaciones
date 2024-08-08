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
    public partial class FormDetalleCompra : Form
    {
        public FormDetalleCompra()
        {
            InitializeComponent();
        }

        private void FormDetalleCompra_Load(object sender, EventArgs e)
        {
        }

        private void cbProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbProveedor.SelectedItem != null)
            {
                suppliers.proveedorSeleccionado = (suppliers)cbProveedor.SelectedItem;
                cbContacto.DataSource = supplier_contact.listaContactos.Where(i => i.active.Equals(true) && i.idsupplier.Equals(suppliers.proveedorSeleccionado.id)).ToList();
            }
            else
                suppliers.proveedorSeleccionado = null;
        }

        private void btnALtaContacto_Click(object sender, EventArgs e)
        {
            if (suppliers.proveedorSeleccionado == null)
            {
                MessageBox.Show("Se debe elegir un proveedor");
                return;
            }
            FormContactoProveedor formcontacto = new FormContactoProveedor();
            this.Hide();
            formcontacto.nuevo = true;
            formcontacto.ShowDialog();
            cbContacto.DataSource = supplier_contact.listaContactosDeProveedor;
            cbContacto.SelectedItem = null;
            this.Show();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnALtaClinte_Click(object sender, EventArgs e)
        {
            FormPreedores formproveedores = new FormPreedores();
            this.Hide();
            formproveedores.nuevo = true;
            formproveedores.ShowDialog();
            this.Show();
            cbProveedor.DataSource = null;
            cbProveedor.DataSource = suppliers.listaProveedores;
            cbProveedor.SelectedItem = null;
            cbContacto.SelectedItem= null;
        }
    }
}
