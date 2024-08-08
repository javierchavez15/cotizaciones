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
    public partial class UserControlItems : UserControl
    {
        #region propiedades
        public static UserControlItems itemSeleccionado;
        public suppliers proveedorSeleccionado;
        public supplier_contact contactoSeleccionado;
        public double costo=0;
        public double tax=0;
        public double shipping=0;
        public double import =0;
        public double otroCosto = 0;
        public double sumaCosto = 0;
        public string notaImportacion="" ;
        public double precio;
        public double total;
        public bool tieneCostoExtra=false;

        public string url1 = "";
        public string url2 = "";
        public string cotizacionProveedor = "";
        public string notaProveedor = "";
        public DateTime fecha=DateTime.Now;
        public string imagen = "";

        #endregion 
        public UserControlItems()
        {
            InitializeComponent();
        }

        private void btnProveedor_Click(object sender, EventArgs e)
        {
            FormDetalleCompra formDetalle = new FormDetalleCompra();

            formDetalle.cbProveedor.DataSource = suppliers.listaProveedoresActivos;
            //cbProveedor.SelectedItem = null;
            //cbContacto.SelectedItem = null;
            suppliers.proveedorSeleccionado = null;
            formDetalle.cbProveedor.SelectedItem = proveedorSeleccionado;
            formDetalle.cbContacto.SelectedItem = contactoSeleccionado;
            formDetalle.txtUrl1.Text = url1;
            formDetalle.txtUrl2.Text = url2;
            formDetalle.txtCotizacion.Text = cotizacionProveedor;
            formDetalle.txtNotas.Text = notaProveedor;
            formDetalle.dtpFecha.Value = fecha;
            formDetalle.ShowDialog();
            if (formDetalle.cbProveedor.SelectedItem != null)
            {
                proveedorSeleccionado = (suppliers)formDetalle.cbProveedor.SelectedItem;
                if(formDetalle.cbContacto.SelectedItem != null)
                    contactoSeleccionado = (supplier_contact)formDetalle.cbContacto.SelectedItem;
                btnProveedor.Text = proveedorSeleccionado.name;
            }
            url1 =formDetalle.txtUrl1.Text;
            url2=formDetalle.txtUrl2.Text;
            cotizacionProveedor=formDetalle.txtCotizacion.Text;
            notaProveedor=formDetalle.txtNotas.Text;
            fecha = formDetalle.dtpFecha.Value;
        }

        #region seleccionarItem
        private void txtCatalogo_Enter(object sender, EventArgs e)
        {
            seleccionarItem();
        }

        private void seleccionarItem()
        {
            UserControlItems.itemSeleccionado = this;
            UserControlItems.itemSeleccionado.BackColor = Color.LightGreen;
            foreach (UserControlItems item in controladorCotizacion.itemsCotizacion)
            {
                if (item != UserControlItems.itemSeleccionado)
                    item.BackColor = SystemColors.Control;
            }
        }

        private void txtAlias_Enter(object sender, EventArgs e)
        {
            seleccionarItem();
        }

        private void button1_Enter(object sender, EventArgs e)
        {
            seleccionarItem();
        }

        private void txtDescripcion_Enter(object sender, EventArgs e)
        {
            seleccionarItem();
        }

        private void txtCant_Enter(object sender, EventArgs e)
        {
            seleccionarItem();
        }

        private void txtCostoU_Enter(object sender, EventArgs e)
        {
            seleccionarItem();
        }

        private void cbMone_Enter(object sender, EventArgs e)
        {
            seleccionarItem();
        }

        private void btnProveedor_Enter(object sender, EventArgs e)
        {
            seleccionarItem();
        }

        private void txtPorcentaje_Enter(object sender, EventArgs e)
        {
            seleccionarItem();
        }

        private void txtPrecioU_Enter(object sender, EventArgs e)
        {
            seleccionarItem();
        }

        private void txtTotalItem_Enter(object sender, EventArgs e)
        {
            seleccionarItem();
        }

        private void txtItem_Enter(object sender, EventArgs e)
        {
            seleccionarItem();
        }
        #endregion
        private void button1_Click(object sender, EventArgs e)
        {
            if(imagen=="")
            {
                imagen = "1";
                button1.BackColor = Color.GreenYellow;

            }
            else {

                imagen = "";
                button1.BackColor = Color.Gainsboro;
            }
            /*
            if (txtCatalogo.Text != "")
            {
                string nombre = txtCatalogo.Text.Replace("/", "");
                nombre = nombre.Replace(":", "");
                nombre = nombre.Replace("*", "");
                nombre = nombre.Replace(":", "");
                nombre = nombre.Replace(">", "");
                nombre = nombre.Replace("<", "");
                nombre = nombre.Replace("|", "");
                nombre = nombre.Replace("?", "");
                nombre = nombre.Replace('"'.ToString(), "");
                string filtro = ".bmp;*.gif;*.jpg;*.png|*.bmp;*.gif;*.jpg;*.png|Imagen Jpg(*.jpg)|*.jpg|Imagen PNG(*.png)|*.png|Imagen Gif(*.gif*)|*.gif";

                controladorCotizacion controladorCotizacion = new controladorCotizacion();
                if (imagen != "")
                {
                    DialogResult result = MessageBox.Show("DESEA QUITAR LA IMAGEN?", "QUITAR IMAGEN", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        imagen = "";
                    }
                    else
                    {
                        imagen = controladorCotizacion.guardar("Imagenes", filtro, nombre, imagen);
                    }
                }
                else
                {
                    imagen = controladorCotizacion.guardar("Imagenes", filtro, nombre, imagen);
                }
                if(imagen !="")
                    button1.BackColor = System.Drawing.Color.GreenYellow;
                else
                    button1.BackColor = System.Drawing.Color.Gainsboro;
            }*/
        }

        private void txtCostoU_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FormCosto formCosto= new FormCosto();
            if (tieneCostoExtra == true)
            {
                formCosto.txtCosto.Text = costo.ToString("##0.00");
                formCosto.txtTax.Text = tax.ToString("##0.00");
                formCosto.txtShipping.Text = shipping.ToString("##0.00");
                formCosto.txtImportacion.Text = import.ToString("##0.00");
                formCosto.txtOtros.Text = otroCosto.ToString("##0.00");
            }
            formCosto.tieneCosto = tieneCostoExtra;
            formCosto.txtNota.Text = notaImportacion;
            formCosto.ShowDialog();



            tieneCostoExtra = formCosto.tieneCosto;
            if (tieneCostoExtra==true)
            {
                costo = Convert.ToDouble(formCosto.txtCosto.Text);
                tax = Convert.ToDouble(formCosto.txtTax.Text);
                shipping = Convert.ToDouble(formCosto.txtShipping.Text);
                import = Convert.ToDouble(formCosto.txtImportacion.Text);
                otroCosto = Convert.ToDouble(formCosto.txtOtros.Text);

                sumaCosto = costo + tax + shipping + import + otroCosto;
                if (sumaCosto == 0)
                {
                    tieneCostoExtra = false;
                    txtCostoU.ReadOnly = false;
                }
                else
                {
                    txtCostoU.ReadOnly = true;
                    txtCostoU.Text = sumaCosto.ToString("##0.00");
                }

            }
            notaImportacion = formCosto.txtNota.Text;
        }

        #region calcularItem
        private void cacularItem()
        {
            try
            {
                if (cbMone.Text != "") 
                {
                    if (controladorCotizacion.moneda == "")
                    {
                        MessageBox.Show("Se necesita elegir moneda de la cotizacion");
                        return;
                    }
                    else if(controladorCotizacion.moneda == "USD")
                    {
                        if(cbMone.Text == "USD")
                        {
                            txtPrecioU.Text = Math.Round(Convert.ToDouble(txtCostoU.Text) * (1 + (Convert.ToDouble(txtPorcentaje.Text) / 100)), 2).ToString("##0.00");
                            txtTotalItem.Text = Math.Round(Convert.ToDouble(txtPrecioU.Text) * Convert.ToInt32(txtCant.Text), 2).ToString("##0.00");
                        }
                        else if (controladorCotizacion.tc > 0)
                        {
                            txtPrecioU.Text = Math.Round((Convert.ToDouble(txtCostoU.Text) * (1 + (Convert.ToDouble(txtPorcentaje.Text) / 100)))/ controladorCotizacion.tc, 2).ToString("##0.00");
                            txtTotalItem.Text = Math.Round(Convert.ToDouble(txtPrecioU.Text) * Convert.ToInt32(txtCant.Text), 2).ToString("##0.00");
                        }
                        else {
                            MessageBox.Show("Se necesita elegir TC de la cotizacion");
                            return;
                        }
                    }
                    else if (controladorCotizacion.moneda == "MXN")
                    {
                        if (cbMone.Text == "MXN")
                        {
                            txtPrecioU.Text = Math.Round(Convert.ToDouble(txtCostoU.Text) * (1 + (Convert.ToDouble(txtPorcentaje.Text) / 100)), 2).ToString("##0.00");
                            txtTotalItem.Text = Math.Round(Convert.ToDouble(txtPrecioU.Text) * Convert.ToInt32(txtCant.Text), 2).ToString("##0.00");
                        }
                        else if(controladorCotizacion.tc>0)
                        {
                            txtPrecioU.Text = Math.Round((Convert.ToDouble(txtCostoU.Text) * (1 + (Convert.ToDouble(txtPorcentaje.Text) / 100))) * controladorCotizacion.tc, 2).ToString("##0.00");
                            txtTotalItem.Text = Math.Round(Convert.ToDouble(txtPrecioU.Text) * Convert.ToInt32(txtCant.Text), 2).ToString("##0.00");
                        }
                        else
                        {
                            MessageBox.Show("Se necesita elegir TC de la cotizacion");
                            return;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Se necesita elegir moneda");
                    return;
                }
                
            }
            catch
            {
                MessageBox.Show("Los montos no son correctos");
            }            

        }

        private void txtCant_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cacularItem();
            }
        }

        private void txtCostoU_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cacularItem();
            }
        }

        private void txtPorcentaje_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cacularItem();
            }
        }
        #endregion

        private void txtCatalogo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtCatalogo.Text != "")
                {
                    items_quotes item=null;
                    FormBuscarCotizacion formBusqueda = new FormBuscarCotizacion();
                    formBusqueda.busquedaEnItem = true;
                    formBusqueda.tipoBusqueda = "catalogo";
                    formBusqueda.campoBusqueda = txtCatalogo.Text;
                    formBusqueda.ShowDialog();
                    this.Show();
                    item = formBusqueda.itemElegido;
                    if (item != null)
                    {
                        UserControlItems.itemSeleccionado = this;
                        UserControlItems.itemSeleccionado = controladorItems.llenarControlItemsBusqueda(this, item, txtItem.Text);
                    }
                }
                else
                {
                    //txtCatalogo.Text = "a";
                    //Program.formaprincipal.buscar();
                }
            }
            else if (e.KeyCode == Keys.Down)
            {
                txtAlias.Text = txtCatalogo.Text;
                txtDescripcion.Focus();
            }
        }

        private void cbMone_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtCant_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }

        private void txtPorcentaje_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }
    }
}
