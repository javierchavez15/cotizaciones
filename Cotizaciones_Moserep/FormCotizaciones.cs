using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cotizaciones_Moserep
{
    public partial class FormCotizaciones : Form
    {
        controladorCotizacion controladorCotizacion = new controladorCotizacion();

        private quotes cotizacionCopiar = null;
        private static List<items_quotes> listItemsCopiar = new List<items_quotes>();
        public FormCotizaciones()
        {
            InitializeComponent();
        }

        private void FormCotizaciones_Load(object sender, EventArgs e)
        {
            cmbCliente.DataSource = clients.listaClientesActivos;
            cbVendedor.DataSource = users.listaVendedores;
            cmbCliente.SelectedItem = null;
            cmbContacto.SelectedItem=null;
            if (users.usuarioActual.idProfile < 3)
                vendedorToolStripMenuItem.Visible = false;
            cbVendedor.SelectedItem = null;
            cmbIva.DataSource = iva.listaIvas;
            baseDatos db = new baseDatos();
            txtNoPrecotizacion.Text = db.NumeroLibre("ID", "quotes", users.usuarioActual.id).ToString();
            txtTipoCambio.Text= controladorCotizacion.tc.ToString("##0.00");

            resetComponents();
            resertVariables();

            cmbIva.Text = "16";
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            UserControlItems nuevoRenglon = new UserControlItems();
            nuevoRenglon = llenarControlItems(nuevoRenglon);
            nuevoRenglon.Left = controladorCotizacion.Esquina.X;
            nuevoRenglon.Top = controladorCotizacion.Esquina.Y + (controladorCotizacion.SeparacionVertical * panel1.Controls.Count);
            controladorCotizacion.itemsCotizacion.Insert(panel1.Controls.Count, nuevoRenglon);
            panel1.Controls.Add(nuevoRenglon);
        }

        private UserControlItems llenarControlItems(UserControlItems nuevoRenglon)
        {
            nuevoRenglon.txtItem.Text = (panel1.Controls.Count + 1).ToString();
            return nuevoRenglon;
        }

        private void resetComponents()
        {
            cmbCliente.SelectedItem = null;
            cmbContacto.SelectedItem = null;
            rbPesos.Checked=false;
            rbUsd.Checked=false;
            panel1.Controls.Clear();
            cbVendedor.SelectedItem = null;
            txtNotas.Text = string.Empty;
            txtSubtotal.Text = "0";
            txtIva.Text = "0";
            txtTotal.Text = "0";
            cbRemision.Checked= false;
            cmbIva.Text = "16";
            txtItemsBorrar.Text = string.Empty;
            txtComerciales.Text = string.Empty;
            txtEntrega.Text= string.Empty;
        }

        private void resertVariables()
        {
            controladorCotizacion.itemsCotizacion = new List<UserControlItems>();
            controladorCotizacion.moneda = "";
            cotizacionCopiar = null;
            listItemsCopiar = new List<items_quotes>();
            controladorCotizacion = new controladorCotizacion();
            UserControlItems.itemSeleccionado = null;
            clients.clienteSeleccionado = null;
            client_contact.contactoSeleccionado = null;
            users.vendedorSeleccionado = null;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            string status = "¿Desea borrar los datos capturados?";
            string leyenda = "RESET";
            DialogResult result = MessageBox.Show(status, leyenda, MessageBoxButtons.YesNo);
            if (result == DialogResult.No)
            {
                return;
            }
            resetComponents();
            resertVariables();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (txtItemsBorrar.Text != "")
            {
                List<UserControlItems> renglonesParaBorrar = new List<UserControlItems>();
                string error= controladorCotizacion.borrarItems(txtItemsBorrar.Text, ref renglonesParaBorrar);
                if (error != "")
                    MessageBox.Show(error);
                else
                {
                    foreach (UserControlItems n in renglonesParaBorrar)
                    {
                        panel1.Controls.Remove(n);
                    }
                    panel1.Controls.Remove(UserControlItems.itemSeleccionado);
                }
            }
            else if (UserControlItems.itemSeleccionado != null)
            {

                string status = "¿Desea borrar el el producto " + UserControlItems.itemSeleccionado.txtCatalogo.Text + " ? ";
                string leyenda = "Borrar";
                DialogResult result = MessageBox.Show(status, leyenda, MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    controladorCotizacion.borrarItemSeleccionado(UserControlItems.itemSeleccionado);
                    controladorCotizacion.numerarItems();
                    panel1.Controls.Remove(UserControlItems.itemSeleccionado);
                    UserControlItems.itemSeleccionado = null;
                }
            }
        }

        private void btnALtaContacto_Click(object sender, EventArgs e)
        {
            FormClientes formClientes = new FormClientes();
            this.Hide();
            formClientes.nuevo = true;
            formClientes.ShowDialog();
            this.Show();
            cmbCliente.DataSource = null;
            cmbCliente.DataSource = clients.listaClientesActivos;
            cmbCliente.SelectedItem = null;
            cmbContacto.SelectedItem = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(clients.clienteSeleccionado==null)
            {
                MessageBox.Show("Se debe elegir un cliente");
                return;
            }
            FormContactocliente formcontacto = new FormContactocliente();
            this.Hide();
            formcontacto.nuevo = true;
            formcontacto.ShowDialog();
            this.Show();
            cmbContacto.DataSource = null;
            cmbContacto.DataSource = client_contact.listaContactosDeCliente;
            cmbContacto.SelectedItem = null;
        }

        private void altaClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormClientes formClientes = new FormClientes();
            this.Hide();
            formClientes.nuevo = false;
            formClientes.ShowDialog();
            this.Show();
            cmbCliente.DataSource = null;
            cmbCliente.DataSource = clients.listaClientesActivos;
            cmbCliente.SelectedItem = null;
            cmbContacto.SelectedItem = null;
        }

        private void contactoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (clients.clienteSeleccionado == null)
            {
                MessageBox.Show("Se debe elegir un cliente");
                return;
            }
            FormContactocliente formcontacto = new FormContactocliente();
            this.Hide();
            formcontacto.nuevo = false;
            formcontacto.ShowDialog();
            this.Show();
            cmbContacto.DataSource = null;
            cmbContacto.DataSource = client_contact.listaContactosDeCliente;
            cmbContacto.SelectedItem = null;
        }

        private void cmbCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCliente.SelectedItem != null)
            {
                //client_contact.listaContactosDeCliente = null;
                clients.clienteSeleccionado = (clients)cmbCliente.SelectedItem;
                //client_contact.listaContactosDeCliente =  client_contact.listaContactos.Where(i => i.active.Equals(true) && i.idClient.Equals(clients.clienteSeleccionado.id)).ToList();
                cmbContacto.DataSource = client_contact.listaContactos.Where(i => i.active.Equals(true) && i.idClient.Equals(clients.clienteSeleccionado.id)).ToList();
                if (clients.clienteSeleccionado.idSeller > 0)
                {
                    users.vendedorSeleccionado = controladorUsuario.obtenerUsuario(clients.clienteSeleccionado.idSeller);
                    cbVendedor.Text = users.vendedorSeleccionado.name;
                }
                if (clients.clienteSeleccionado.idIva > 0)
                {
                    iva.ivaSeleccionado = controladorIva.buscarIvaPorID(clients.clienteSeleccionado.idIva);
                    cmbIva.Text = iva.ivaSeleccionado.monto.ToString();
                }
            }
            else
                clients.clienteSeleccionado = null;
        }

        private void button3_Click(object sender, EventArgs e)
        { 
            string error = validacionCotizaciones();
            if (error != "")
            {
                MessageBox.Show(error);
                return;
            }
            error = validarPartidas();
            if (error != "")
            {
                MessageBox.Show(error);
                return;
            }
            calcularItems();
            string moneda = "USD";
            if (rbPesos.Checked == true)
                moneda = "MXN";
            error = controladorCotizacion.insertarCotizacion(Convert.ToInt32(txtNoPrecotizacion.Text), moneda, dtpFecha.Value, Convert.ToDouble(txtSubtotal.Text), Convert.ToDouble(txtIva.Text), Convert.ToDouble(txtTotal.Text), cbRemision.Checked, true, txtNotas.Text, txtComerciales.Text, txtEntrega.Text, panel1.Controls.Count, true);
            if (error != "")
            {
                if (error != "NOGUARDAR")
                {
                    baseDatos db = new baseDatos();
                    txtNoPrecotizacion.Text = db.NumeroLibre("ID", "quotes", users.usuarioActual.id).ToString();
                    MessageBox.Show(error);
                }
                return;
            }
            controladorItems controladorItems = new controladorItems();
            error = controladorItems.insertarItems(Convert.ToInt32(txtNoPrecotizacion.Text), true);
            if(error=="")
            {
                resetComponents();
                resertVariables();
                txtNoPrecotizacion.Text = (Convert.ToInt32(txtNoPrecotizacion.Text) + 1).ToString();
            }
            else
            {
                MessageBox.Show(error);
                return;
            }

        }

        private bool esEntero(string valor)
        {
            try
            {
                if(Convert.ToInt32(valor)>0)
                    return true;
                else
                    return false;
            }
            catch { return true; }
        }

        private bool esDouble(string valor)
        {
            try
            {
                if(Convert.ToDouble(valor)>0)
                    return true;
                else
                    return false;
            }
            catch { return false; }
        }

        private string validarPartidas()
        {
            string error = "";
            foreach(UserControlItems item in controladorCotizacion.itemsCotizacion)
            {
                if (item.txtCatalogo.Text=="")
                    error = "Se necesita el catalogo del item "+ item.txtItem.Text;
                else if (item.txtAlias.Text == "")
                    error = "Se necesita el alias del item " + item.txtItem.Text;
                else if (item.txtDescripcion.Text == "")
                    error = "Se necesita la descripcion del item " + item.txtItem.Text;
                else if (item.txtDescripcion.Text == "")
                    error = "Se necesita la descripcion del item " + item.txtItem.Text;
                else if (esEntero(item.txtCant.Text) ==false)
                    error = "Se necesita una cantidad del item " + item.txtItem.Text;
                else if (esDouble(item.txtCostoU.Text) == false)
                    error = "Se necesita el costo del item " + item.txtItem.Text;
                else if (item.cbMone.SelectedItem==null)
                    error = "Se necesita la moneda del item " + item.txtItem.Text;
                else if (item.proveedorSeleccionado == null)
                    error = "Se necesita el proveedor del item " + item.txtItem.Text;
                else if (item.url1=="" && item.url2=="" && item.cotizacionProveedor=="" && item.notaProveedor=="")
                    error = "Se necesita url, # cotizacion o nota en detalle de compra del item " + item.txtItem.Text;
                else if (esEntero(item.txtPorcentaje.Text) == false)
                    error = "Verificar el % del item " + item.txtItem.Text;
            }
            if (controladorCotizacion.itemsCotizacion.Count == 0)
                error = "Se necesita agregar items";
            return error;
        } 

        private string validacionCotizaciones()
        {
            string error = "";
            if (cmbIva.SelectedItem == null)
                error = "Se necesita elegir un iva";
            else if(cmbCliente.SelectedItem == null)
                error = "Se necesita elegir un cliente";
            else if(cmbContacto.SelectedItem== null)
                error = "Se necesita elegir un contacto";
            else if(cbVendedor.SelectedItem==null)
                error = "Se necesita elegir un vendedor";
            else if(rbPesos.Checked==false && rbUsd.Checked == false)
                error = "Se necesita elegir una moneda";
            return error;
        }

        private void lblCantidad_Click(object sender, EventArgs e)
        {
            FormCantidadesItems formCantidadesItems = new FormCantidadesItems();
            formCantidadesItems.ShowDialog();
            formCantidadesItems.lblCantidad.Text = "CANTIDAD";
            foreach (UserControlItems item in controladorCotizacion.itemsCotizacion)
            {
                if(item.txtCant.Text=="" ||item.txtCant.Text=="0")
                    item.txtCant.Text= formCantidadesItems.txtCantidad.Text;
            }
        }

        private void lblPorcentaje_Click(object sender, EventArgs e)
        {
            FormCantidadesItems formCantidadesItems = new FormCantidadesItems();
            formCantidadesItems.lblCantidad.Text = "PORCENTAJE";
            formCantidadesItems.ShowDialog();
            foreach (UserControlItems item in controladorCotizacion.itemsCotizacion)
            {
                if (item.txtPorcentaje.Text == "" || item.txtPorcentaje.Text == "0")
                    item.txtPorcentaje.Text = formCantidadesItems.txtCantidad.Text;
            }
        }

        private void label15_Click(object sender, EventArgs e)
        {
            FormMonedaItems formMonedaItems = new FormMonedaItems();
            formMonedaItems.ShowDialog();
            foreach (UserControlItems item in controladorCotizacion.itemsCotizacion)
            {
                if (item.cbMone.Text == "")
                    item.cbMone.Text = formMonedaItems.cbMoneda.Text;
            }
        }

        private void label19_Click(object sender, EventArgs e)
        {
            FormDetalleCompra formDetalle = new FormDetalleCompra();
            formDetalle.cbProveedor.DataSource = suppliers.listaProveedoresActivos;
            formDetalle.cbProveedor.SelectedItem = null;
            suppliers.proveedorSeleccionado = null;
            formDetalle.ShowDialog();
            foreach (UserControlItems item in controladorCotizacion.itemsCotizacion)
            {
                if (item.proveedorSeleccionado == null)
                {
                    if (formDetalle.cbProveedor.SelectedItem != null)
                    {
                        item.proveedorSeleccionado = (suppliers)formDetalle.cbProveedor.SelectedItem;
                        if (formDetalle.cbContacto.SelectedItem != null)
                            item.contactoSeleccionado = (supplier_contact)formDetalle.cbContacto.SelectedItem;
                    }
                    item.url1 = formDetalle.txtUrl1.Text;
                    item.url2 = formDetalle.txtUrl2.Text;
                    item.cotizacionProveedor = formDetalle.txtCotizacion.Text;
                    item.notaProveedor = formDetalle.txtNotas.Text;
                    item.btnProveedor.Text = item.proveedorSeleccionado.name;
                }
            }
            
        }

        private void proveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormPreedores formProveedores = new FormPreedores();
            formProveedores.nuevo = false;
            this.Hide();
            formProveedores.nuevo = false;
            formProveedores.ShowDialog();
            this.Show();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            calcularItems();
        }

        private void calcularItems()
        {
            double suma = 0;
            foreach(UserControlItems item in controladorCotizacion.itemsCotizacion)
            {
                try
                {
                    if (item.cbMone.Text != "")
                    {
                        if (controladorCotizacion.moneda == "")
                        {
                            return;
                        }
                        else if (controladorCotizacion.moneda == "USD")
                        {
                            if (item.cbMone.Text == "USD")
                            {
                                item.txtPrecioU.Text = Math.Round(Convert.ToDouble(item.txtCostoU.Text) * (1 + (Convert.ToDouble(item.txtPorcentaje.Text) / 100)), 2).ToString("##0.00");
                                item.txtTotalItem.Text = Math.Round(Convert.ToDouble(item.txtPrecioU.Text) * Convert.ToInt32(item.txtCant.Text), 2).ToString("##0.00");
                            }
                            else if (controladorCotizacion.tc > 0)
                            {
                                item.txtPrecioU.Text = Math.Round((Convert.ToDouble(item.txtCostoU.Text) * (1 + (Convert.ToDouble(item.txtPorcentaje.Text) / 100))) / controladorCotizacion.tc, 2).ToString("##0.00");
                                item.txtTotalItem.Text = Math.Round(Convert.ToDouble(item.txtPrecioU.Text) * Convert.ToInt32(item.txtCant.Text), 2).ToString("##0.00");
                            }
                            else
                            {
                                return;
                            }
                        }
                        else if (controladorCotizacion.moneda == "MXN")
                        {
                            if (item.cbMone.Text == "MXN")
                            {
                                item.txtPrecioU.Text = Math.Round(Convert.ToDouble(item.txtCostoU.Text) * (1 + (Convert.ToDouble(item.txtPorcentaje.Text) / 100)), 2).ToString("##0.00");
                                item.txtTotalItem.Text = Math.Round(Convert.ToDouble(item.txtPrecioU.Text) * Convert.ToInt32(item.txtCant.Text), 2).ToString("##0.00");
                            }
                            else if (controladorCotizacion.tc > 0)
                            {
                                item.txtPrecioU.Text = Math.Round((Convert.ToDouble(item.txtCostoU.Text) * (1 + (Convert.ToDouble(item.txtPorcentaje.Text) / 100))) * controladorCotizacion.tc, 2).ToString("##0.00");
                                item.txtTotalItem.Text = Math.Round(Convert.ToDouble(item.txtPrecioU.Text) * Convert.ToInt32(item.txtCant.Text), 2).ToString("##0.00");
                            }
                            else
                            {
                                return;
                            }
                        }
                    }
                    suma += Convert.ToDouble(item.txtTotalItem.Text);
                }
                catch {
                    item.txtTotalItem.Text = "0.00";

                }
            }
            txtSubtotal.Text= suma.ToString("##0.00");
            if (cmbIva.SelectedItem != null)
            {
                txtIva.Text = (suma * (Convert.ToDouble(cmbIva.Text) / 100)).ToString("##0.00");
            }
            else
                txtIva.Text = "0.00";
            txtTotal.Text=(suma+ Convert.ToDouble(txtIva.Text)).ToString("##0.00");
        }

        private void rbPesos_CheckedChanged(object sender, EventArgs e)
        {
            if (rbPesos.Checked)
                controladorCotizacion.moneda = "MXN";
        }

        private void rbUsd_CheckedChanged(object sender, EventArgs e)
        {
            if (rbUsd.Checked)
                controladorCotizacion.moneda = "USD";
        }

        private void txtTipoCambio_TextChanged(object sender, EventArgs e)
        {
            try
            {
                controladorCotizacion.tc = Convert.ToDouble(txtTipoCambio.Text);
                Properties.Settings.Default.tc = controladorCotizacion.tc;
                Properties.Settings.Default.Save();
            }
            catch { controladorCotizacion.tc = 0; }
        }

        private void ckiva_CheckedChanged(object sender, EventArgs e)
        {
            /*if (ckiva.Checked == true)
            {
                cmbIva.Visible = true;
                try
                {
                    if (cmbIva.SelectedItem != null)
                    {
                        txtIva.Text = (Convert.ToDouble(txtSubtotal.Text) * (Convert.ToDouble(cmbIva.Text) / 100)).ToString("##0.00");
                    }
                    else
                        txtIva.Text = "0.00";
                    txtTotal.Text = (Convert.ToDouble(txtSubtotal.Text) + Convert.ToDouble(txtIva.Text)).ToString("##0.00");
                }
                catch { txtTotal.Text = txtSubtotal.Text; }
            }
            else
            {
                cmbIva.Visible = false;
                cmbIva.SelectedItem = null;
                txtIva.Text = "0.00";
                txtTotal.Text = txtSubtotal.Text;
                iva.ivaSeleccionado = null;
            }*/
        }

        private void cmbIva_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbIva.SelectedItem != null)
                {
                    iva.ivaSeleccionado = (iva)cmbIva.SelectedItem;
                    txtIva.Text = (Convert.ToDouble(txtSubtotal.Text) * (Convert.ToDouble(cmbIva.Text) / 100)).ToString("##0.00");
                }
                else
                {
                    txtIva.Text = "0.00";
                    iva.ivaSeleccionado = null;
                }
                txtTotal.Text = (Convert.ToDouble(txtSubtotal.Text) + Convert.ToDouble(txtIva.Text)).ToString("##0.00");
            }
            catch { txtTotal.Text = txtSubtotal.Text; }
        }

        private void label40_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("iexplore.exe", "http://omawww.sat.gob.mx/informacion_fiscal/tablas_indicadores/Paginas/tipo_cambio.aspx");
        }

        private void btnGuardarCotizacion_Click(object sender, EventArgs e)
        {
            string error = "";
            calcularItems();
            string moneda = "";
            if (rbPesos.Checked == true)
                moneda = "MXN";
            else if(rbUsd.Checked==true)
                moneda = "USD";
            error = controladorCotizacion.insertarCotizacion(Convert.ToInt32(txtNoPrecotizacion.Text), moneda, dtpFecha.Value, Convert.ToDouble(txtSubtotal.Text), Convert.ToDouble(txtIva.Text), Convert.ToDouble(txtTotal.Text), cbRemision.Checked, true, txtNotas.Text, txtComerciales.Text, txtEntrega.Text, panel1.Controls.Count,false);
            if (error != "")
            {
                baseDatos db = new baseDatos();
                txtNoPrecotizacion.Text = db.NumeroLibre("ID", "quotes", users.usuarioActual.id).ToString();
                MessageBox.Show(error);
                return;
            }
            controladorItems controladorItems = new controladorItems();
            error = controladorItems.insertarItems(Convert.ToInt32(txtNoPrecotizacion.Text), true);
            if (error == "")
            {
                resetComponents();
                resertVariables();
                txtNoPrecotizacion.Text = (Convert.ToInt32(txtNoPrecotizacion.Text) + 1).ToString();
            }
            else
            {
                MessageBox.Show(error);
                return;
            }
        }

        private void cbVendedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbVendedor.SelectedItem!=null)
                users.vendedorSeleccionado = (users)cbVendedor.SelectedItem;
        }

        private void cmbContacto_SelectedIndexChanged(object sender, EventArgs e)
        {
            client_contact.contactoSeleccionado = (client_contact)cmbContacto.SelectedItem;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            buscar();
        }

        private void txtBusqueda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buscar();
            }
        }

        private void buscar()
        {
            if(rbCatalogo.Checked==false && rbDescripcion.Checked==false && rbCotizacion.Checked == false)
            {
                MessageBox.Show("Se necesita elegir un tipo de busqueda");
                return;
            }
            else if (rbCotizacion.Checked == true)
            {
                try
                {
                    Convert.ToInt32(txtBusqueda.Text);
                }
                catch
                {
                    MessageBox.Show("El campo debe ser numerico");
                    return;
                }
            }
            cotizacionCopiar = null;
            listItemsCopiar = new List<items_quotes>();
            FormBuscarCotizacion formBusqueda = new FormBuscarCotizacion();
            if (rbCotizacion.Checked == true)
                formBusqueda.tipoBusqueda = "cotizacion";
            else if (rbCatalogo.Checked == true)
                formBusqueda.tipoBusqueda = "catalogo";
            else if (rbDescripcion.Checked == true)
                formBusqueda.tipoBusqueda = "descripcion";
            formBusqueda.campoBusqueda = txtBusqueda.Text;
            this.Hide();
            formBusqueda.ShowDialog();
            this.Show();
            cotizacionCopiar = formBusqueda.cotizacionElegida;
            if (cotizacionCopiar != null)
            {
                cmbCliente.Text = controladorCliente.buscarClientePorID(cotizacionCopiar.id_client).name;
                cmbContacto.Text= controladorContactoCliente.buscarContactoPorID(cotizacionCopiar.id_contact).name;
                cbVendedor.Text = controladorUsuario.buscarUsuarioPorID(cotizacionCopiar.id_seller).name;
                txtComerciales.Text = cotizacionCopiar.conditions;
                txtEntrega.Text = cotizacionCopiar.delivery;
                if (cotizacionCopiar.currency == "USD")
                    rbUsd.Checked = true;
                else
                    rbPesos.Checked = true;
                txtNotas.Text = cotizacionCopiar.note;
                listItemsCopiar = formBusqueda.listItems;
                foreach (items_quotes item in listItemsCopiar)
                {
                    UserControlItems nuevoRenglon = new UserControlItems();
                    nuevoRenglon = llenarControlItems(nuevoRenglon);
                    nuevoRenglon = controladorItems.llenarControlItemsBusqueda(nuevoRenglon, item, nuevoRenglon.txtItem.Text);
                    nuevoRenglon.Left = controladorCotizacion.Esquina.X;
                    nuevoRenglon.Top = controladorCotizacion.Esquina.Y + (controladorCotizacion.SeparacionVertical * panel1.Controls.Count);
                    if (nuevoRenglon.imagen == "")
                    {
                        nuevoRenglon.button1.BackColor = Color.Gainsboro;

                    }
                    else
                    {
                        nuevoRenglon.button1.BackColor = Color.GreenYellow;
                    }
                    controladorCotizacion.itemsCotizacion.Insert(panel1.Controls.Count, nuevoRenglon);
                    panel1.Controls.Add(nuevoRenglon);
                }
                iva ivaTemp = controladorIva.buscarIvaPorID(cotizacionCopiar.id_iva);
                if(ivaTemp!=null)
                {
                    cmbIva.Text = ivaTemp.monto.ToString();
                }
                calcularItems();
                txtBusqueda.Text="";
            }
        }

        private void rEMISIONESToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormClientes formClientes = new FormClientes();
            this.Hide();
            formClientes.nuevo = false;
            formClientes.ShowDialog();
            this.Show();
        }

        private void aSIGNARPOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormVerRemisiones formClientes = new FormVerRemisiones();
            this.Hide();
            formClientes.ShowDialog();
            this.Show();
        }

        private void vendedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void rbCotizacion_CheckedChanged(object sender, EventArgs e)
        {
            txtBusqueda.Focus();
        }

        private void rbCatalogo_CheckedChanged(object sender, EventArgs e)
        {
            txtBusqueda.Focus();
        }

        private void rbDescripcion_CheckedChanged(object sender, EventArgs e)
        {
            txtBusqueda.Focus();
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormUsuario formUsuario = new FormUsuario();
            formUsuario.nuevo = true;
            this.Hide();
            formUsuario.ShowDialog();
            this.Show();
        }

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormUsuario formUsuario = new FormUsuario();
            formUsuario.nuevo = false;
            this.Hide();
            formUsuario.ShowDialog();
            this.Show();
        }
    }
}
