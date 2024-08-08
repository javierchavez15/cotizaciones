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
    public partial class FormBuscarCotizacion : Form
    {
        int idItem = 0;
        items_quotes itemTempotal = null;
        public items_quotes itemElegido = null;
        quotes cotizacionTemporal=null;
        public quotes cotizacionElegida = null;
        public List<items_quotes> listItems = new List<items_quotes>();
        public bool busquedaEnItem = false;
        public string tipoBusqueda = "";
        public string campoBusqueda="";
        public FormBuscarCotizacion()
        {
            InitializeComponent();
        }

        private void FormBuscarCotizacion_Load(object sender, EventArgs e)
        {
            if (busquedaEnItem == true)
                btnCopiarPoducto.Visible = true;
            else
                btnGuardarCotizacion.Visible = true;
            controladorItems controladorItems = new controladorItems();
            dtgItems.DataSource = controladorItems.obtenerItemsPorBusqueda(campoBusqueda, tipoBusqueda);
            if(dtgItems.SelectedRows.Count>0)
                dtgItems.SelectedRows[0].Selected = false;
            try
            {
                dtgItems.Columns["id"].Visible = false;
                dtgItems.Columns["idSupplier"].Visible = false;
                dtgItems.Columns["idContact"].Visible = false;
                dtgItems.Columns["image"].Visible = false;
                dtgItems.Columns["url1"].Visible = false;
                dtgItems.Columns["url2"].Visible = false;
                dtgItems.Columns["numberQuoteSupplier"].Visible = false;
                dtgItems.Columns["noteSupplier"].Visible = false;
                dtgItems.Columns["dateSupplier"].Visible = false;
                dtgItems.Columns["cost"].Visible = false;
                dtgItems.Columns["tax"].Visible = false;
                dtgItems.Columns["shipping"].Visible = false;
                dtgItems.Columns["import"].Visible = false;
                dtgItems.Columns["otherCost"].Visible = false;
                dtgItems.Columns["sumCost"].Visible = false;
                dtgItems.Columns["noteImport"].Visible = false;
                dtgItems.Columns["percentage"].Visible = false;
                dtgItems.Columns["active"].Visible = false; 
                dtgItems.Columns["id_quote"].HeaderText = "FOLIO";
                dtgItems.Columns["item"].HeaderText = "ITEM";
                dtgItems.Columns["catalogue"].HeaderText = "CATALOGO";
                dtgItems.Columns["alias"].HeaderText = "ALIAS";
                dtgItems.Columns["description"].HeaderText = "DESCRIPCION";
                dtgItems.Columns["quantity"].HeaderText = "CANTIDAD";
                dtgItems.Columns["currency"].HeaderText = "MONEDA";
                dtgItems.Columns["costItem"].HeaderText = "COSTO";
                dtgItems.Columns["price"].HeaderText = "PRECIO";
                dtgItems.Columns["total"].HeaderText = "TOTAL";
            }
            catch { }
        }

        private void btnGuardarCotizacion_Click(object sender, EventArgs e)
        {
            if (cotizacionTemporal == null)
            {
                MessageBox.Show("Se debe elegir una cotizacion");
                return;
            }
            cotizacionElegida = cotizacionTemporal;
            listItems = controladorItems.obtenerItemsPorBusqueda(cotizacionElegida.id.ToString(), "cotizacion");
            this.Close();
        }

        private void dtgItems_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgItems.SelectedRows.Count > 0)
            {
                idItem = (int)(dtgItems.SelectedRows[0].Cells[1].Value);
                cotizacionTemporal = controladorCotizacion.buscarCotizacion(idItem);
                lblCliente.Text = controladorCliente.buscarClientePorID(cotizacionTemporal.id_client).name;
                lblContacto.Text = controladorContactoCliente.buscarContactoPorID(cotizacionTemporal.id_contact).name;
                lblFecha.Text= cotizacionTemporal.dateQuote.ToShortDateString();
                lblSubtotal.Text = cotizacionTemporal.subtotal.ToString("##0.00")+" "+ cotizacionTemporal.currency;
                itemTempotal = (items_quotes)dtgItems.Rows[dtgItems.SelectedRows[0].Index].DataBoundItem;
                txtNoPrecotizacion.Text = cotizacionTemporal.id.ToString();
                lblCliente.Visible = true;
                lblContacto.Visible = true;
                lblFecha.Visible = true;
                lblSubtotal.Visible = true;
            }
        }

        private void btnCopiarPoducto_Click(object sender, EventArgs e)
        {
            if (itemTempotal != null)
                itemElegido = itemTempotal;
            this.Close();
        }
    }
}
