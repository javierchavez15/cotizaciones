using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cotizaciones_Moserep
{
    public class controladorItems
    {
        #region Propiedades
        #endregion

        #region Contructor
        #endregion

        #region Metodos

        public static UserControlItems llenarControlItemsBusqueda(UserControlItems nuevoRenglon, items_quotes item, string itemSiguiente)
        {
            nuevoRenglon.txtItem.Text = itemSiguiente;
            nuevoRenglon.txtCatalogo.Text = item.catalogue;
            nuevoRenglon.txtAlias.Text = item.alias;
            nuevoRenglon.txtDescripcion.Text = item.description;
            nuevoRenglon.cbMone.Text = item.currency;
            nuevoRenglon.txtCant.Text = item.quantity.ToString();
            nuevoRenglon.imagen = item.image;
            nuevoRenglon.costo = item.cost;
            nuevoRenglon.shipping = item.shipping;
            nuevoRenglon.tax = item.tax;
            nuevoRenglon.import = item.import;
            nuevoRenglon.otroCosto = item.otherCost;
            nuevoRenglon.sumaCosto = item.sumCost;
            nuevoRenglon.txtCostoU.Text = item.costItem.ToString();
            nuevoRenglon.txtPorcentaje.Text = item.percentage.ToString();
            nuevoRenglon.txtPrecioU.Text = item.price.ToString();
            nuevoRenglon.txtTotalItem.Text = item.total.ToString();
            nuevoRenglon.notaProveedor = item.noteSupplier;
            nuevoRenglon.notaImportacion = item.noteImport;
            nuevoRenglon.proveedorSeleccionado = controladorProveedor.buscarProveedorPorID(item.idSupplier);
            nuevoRenglon.contactoSeleccionado = controladorContactoProveedor.buscarContactoPorID(item.idContact);
            nuevoRenglon.url1 = item.url1;
            nuevoRenglon.url2 = item.url2;
            nuevoRenglon.cotizacionProveedor = item.numberQuoteSupplier;
            nuevoRenglon.fecha = item.dateSupplier;
            if(nuevoRenglon.proveedorSeleccionado!=null)
                nuevoRenglon.btnProveedor.Text = nuevoRenglon.proveedorSeleccionado.name;
            return nuevoRenglon;
        }
        public string insertarItems(int idcotizacion, bool activo)
        {
            string error = "";
            foreach(UserControlItems item in controladorCotizacion.itemsCotizacion)
            {
                items_quotes items_Quotes = new items_quotes();
                items_Quotes.id_quote = idcotizacion;
                items_Quotes.catalogue = item.txtCatalogo.Text;
                items_Quotes.alias = item.txtAlias.Text;
                items_Quotes.description = item.txtDescripcion.Text;
                items_Quotes.quantity = Convert.ToInt32(item.txtCant.Text);
                items_Quotes.image = item.imagen;
                items_Quotes.idSupplier = item.proveedorSeleccionado.id;
                items_Quotes.idContact = 0;
                if(item.contactoSeleccionado!=null)
                    items_Quotes.idContact = item.contactoSeleccionado.id;
                items_Quotes.url1 = item.url1;
                items_Quotes.url2 = item.url2;
                items_Quotes.numberQuoteSupplier = item.cotizacionProveedor;
                items_Quotes.noteSupplier = item.notaProveedor;
                items_Quotes.dateSupplier = item.fecha;
                items_Quotes.currency = item.cbMone.Text;
                items_Quotes.item = Convert.ToInt32(item.txtItem.Text);
                items_Quotes.cost = item.costo;
                items_Quotes.tax = item.tax;
                items_Quotes.shipping = item.shipping;
                items_Quotes.import = item.import;
                items_Quotes.otherCost = item.otroCosto;
                items_Quotes.sumCost = item.sumaCosto;
                items_Quotes.costItem = Convert.ToDouble(item.txtCostoU.Text);
                items_Quotes.noteImport = item.notaImportacion;
                items_Quotes.percentage = Convert.ToInt32(item.txtPorcentaje.Text);
                items_Quotes.price = Convert.ToDouble(item.txtPrecioU.Text);
                items_Quotes.total = Convert.ToDouble(item.txtTotalItem.Text);
                items_Quotes.active = activo;
                baseDatos.insertarItem(items_Quotes, ref error);

            }
            return error;
        }

        public static List<items_quotes> obtenerItemsPorBusqueda(string campo, string tipoBusqueda)
        {
            List<items_quotes> listaitems = new List<items_quotes>();
            string error = "";
            string query = "";
            if (tipoBusqueda == "catalogo")
            {
                query = "select * from items_quotes where CATALOGUE like '%" + campo + "%'";
            }
            else if (tipoBusqueda == "descripcion")
            {
                query = "select * from items_quotes where DESCRIPTION like '%" + campo + "%'";
            }
            else if (tipoBusqueda == "cotizacion")
            {
                query = "select * from items_quotes where ID_QUOTE =" + campo ;
            }
            DataTable tablaItems = baseDatos.Tabla(query, ref error);
            foreach (DataRow row in tablaItems.Rows)
            {
                items_quotes items_Quotes = new items_quotes();
                items_Quotes.id = Convert.ToInt32(row["ID"]); 
                items_Quotes.id_quote = Convert.ToInt32(row["ID_QUOTE"]);
                items_Quotes.item = Convert.ToInt32(row["ITEM"]);
                items_Quotes.catalogue = row["CATALOGUE"].ToString();
                items_Quotes.alias = row["ALIAS"].ToString();
                items_Quotes.description = row["DESCRIPTION"].ToString();
                items_Quotes.quantity = Convert.ToInt32(row["QUANTITY"]);
                items_Quotes.image = row["IMAGE"].ToString();
                items_Quotes.idSupplier = Convert.ToInt32(row["ID_SUPPLIER"]); 
                items_Quotes.idContact = Convert.ToInt32(row["ID_CONTACT"]); ;
                items_Quotes.url1 = row["URL1"].ToString();
                items_Quotes.url2 = row["URL2"].ToString();
                items_Quotes.numberQuoteSupplier = row["NUMBER_QUOTE_SUPPLIER"].ToString();
                items_Quotes.noteSupplier = row["NOTE_SUPPLIER"].ToString();
                items_Quotes.dateSupplier = Convert.ToDateTime(row["DATE_SUPPLIER"]);
                items_Quotes.currency = row["CURRENCY"].ToString();
                items_Quotes.cost = Convert.ToDouble(row["COST"]);
                items_Quotes.tax = Convert.ToDouble(row["TAX"]);
                items_Quotes.shipping = Convert.ToDouble(row["SHIPPING"]);
                items_Quotes.import = Convert.ToDouble(row["IMPORT"]);
                items_Quotes.otherCost = Convert.ToDouble(row["OTHER_COST"]);
                items_Quotes.sumCost = Convert.ToDouble(row["SUM_COST"]);
                items_Quotes.costItem = Convert.ToDouble(row["COST_ITEM"]);
                items_Quotes.noteImport = row["NOTE_IMPORT"].ToString();
                items_Quotes.percentage = Convert.ToInt32(row["PERCENTAGE"]);
                items_Quotes.price = Convert.ToDouble(row["PRICE"]);
                items_Quotes.total = Convert.ToDouble(row["TOTAL"]);
                items_Quotes.active = Convert.ToBoolean(row["ACTIVE"]);
                listaitems.Add(items_Quotes);
            }
            return listaitems;
        }

        /*public static List<items_quotes> buscarItemsPorCotizacion(int idCotizacion)
        {
            List<items_quotes> listaitems = new List<items_quotes>();
            string error = "";
            string query = "";
            query = "select * from items_quotes where ID_QUOTE =" + idCotizacion.ToString();
            DataTable tablaItems = baseDatos.Tabla(query, ref error);
            foreach (DataRow row in tablaItems.Rows)
            {
                items_quotes items_Quotes = new items_quotes();
                items_Quotes.id = Convert.ToInt32(row["ID"]);
                items_Quotes.id_quote = Convert.ToInt32(row["ID_QUOTE"]);
                items_Quotes.item = Convert.ToInt32(row["ITEM"]);
                items_Quotes.catalogue = row["CATALOGUE"].ToString();
                items_Quotes.alias = row["ALIAS"].ToString();
                items_Quotes.description = row["DESCRIPTION"].ToString();
                items_Quotes.quantity = Convert.ToInt32(row["QUANTITY"]);
                items_Quotes.image = row["IMAGE"].ToString();
                items_Quotes.idSupplier = Convert.ToInt32(row["ID_SUPPLIER"]);
                items_Quotes.idContact = Convert.ToInt32(row["ID_CONTACT"]); ;
                items_Quotes.url1 = row["URL1"].ToString();
                items_Quotes.url2 = row["URL2"].ToString();
                items_Quotes.numberQuoteSupplier = row["NUMBER_QUOTE_SUPPLIER"].ToString();
                items_Quotes.noteSupplier = row["NOTE_SUPPLIER"].ToString();
                items_Quotes.dateSupplier = Convert.ToDateTime(row["DATE_SUPPLIER"]);
                items_Quotes.currency = row["CURRENCY"].ToString();
                items_Quotes.cost = Convert.ToDouble(row["COST"]);
                items_Quotes.tax = Convert.ToDouble(row["TAX"]);
                items_Quotes.shipping = Convert.ToDouble(row["SHIPPING"]);
                items_Quotes.import = Convert.ToDouble(row["IMPORT"]);
                items_Quotes.otherCost = Convert.ToDouble(row["OTHER_COST"]);
                items_Quotes.sumCost = Convert.ToDouble(row["SUM_COST"]);
                items_Quotes.costItem = Convert.ToDouble(row["COST_ITEM"]);
                items_Quotes.noteImport = row["NOTE_IMPORT"].ToString();
                items_Quotes.percentage = Convert.ToInt32(row["PERCENTAGE"]);
                items_Quotes.price = Convert.ToDouble(row["PRICE"]);
                items_Quotes.total = Convert.ToDouble(row["TOTAL"]);
                items_Quotes.active = Convert.ToBoolean(row["ACTIVE"]);
                listaitems.Add(items_Quotes);
            }
            return listaitems;
        }
        */
        #endregion
    }
}
