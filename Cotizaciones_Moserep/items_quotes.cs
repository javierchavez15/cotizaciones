using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cotizaciones_Moserep
{
    public class items_quotes
    {
        #region Propiedades
        private int ID;
        private int ID_QUOTE;
        private int ITEM;
        private string CATALOGUE;
        private string ALIAS;
        private string DESCRIPTION;
        private int QUANTITY;
        private string IMAGE;
        private int ID_SUPPLIER;
        private int ID_CONTACT;
        private string URL1;
        private string URL2;
        private string NUMBER_QUOTE_SUPPLIER;
        private string NOTE_SUPPLIER;
        private DateTime DATE_SUPPLIER;
        private string CURRENCY;
        private double COST;
        private double TAX;
        private double SHIPPING;
        private double IMPORT;
        private double OTHER_COST;
        private double SUM_COST;
        private double COST_ITEM;
        private string NOTE_IMPORT;
        private int PERCENTAGE;
        private double PRICE;
        private double TOTAL;
        private bool ACTIVE;

        public int id { get => ID; set => ID = value; }
        public int id_quote { get => ID_QUOTE; set => ID_QUOTE = value; }
        public int item { get => ITEM; set => ITEM = value; }
        public string catalogue { get => CATALOGUE; set => CATALOGUE = value; }
        public string alias { get => ALIAS; set => ALIAS = value; }
        public string description { get => DESCRIPTION; set => DESCRIPTION = value; }
        public int quantity { get => QUANTITY; set => QUANTITY = value; }
        public string image { get => IMAGE; set => IMAGE = value; }
        public int idSupplier { get => ID_SUPPLIER; set => ID_SUPPLIER = value; }
        public int idContact { get => ID_CONTACT; set => ID_CONTACT = value; }
        public string url1 { get => URL1; set => URL1 = value; }
        public string url2 { get => URL2; set => URL2 = value; }
        public string numberQuoteSupplier { get => NUMBER_QUOTE_SUPPLIER; set => NUMBER_QUOTE_SUPPLIER = value; }
        public string noteSupplier { get => NOTE_SUPPLIER; set => NOTE_SUPPLIER = value; }
        public DateTime dateSupplier { get => DATE_SUPPLIER; set => DATE_SUPPLIER = value; }
        public string currency { get => CURRENCY; set => CURRENCY = value; }
        public double cost { get => COST; set => COST = value; }
        public double tax { get => TAX; set => TAX = value; }
        public double shipping { get => SHIPPING; set => SHIPPING = value; }
        public double import { get => IMPORT; set => IMPORT = value; }
        public double otherCost { get => OTHER_COST; set => OTHER_COST = value; }
        public double sumCost { get => SUM_COST; set => SUM_COST = value; }
        public double costItem { get => COST_ITEM; set => COST_ITEM = value; }
        public string noteImport { get => NOTE_IMPORT; set => NOTE_IMPORT = value; }
        public int percentage { get => PERCENTAGE; set => PERCENTAGE = value; }
        public double price { get => PRICE; set => PRICE = value; }
        public double total { get => TOTAL; set => TOTAL = value; }
        public bool active { get => ACTIVE; set => ACTIVE = value; }

        #endregion

        #region Contructor
        #endregion

        #region Metodos
        #endregion
    }
}
