using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cotizaciones_Moserep
{
    public class quotes
    {
        #region Propiedades
        private int ID;
        private DateTime DATE_QUOTE;
        private string CURRENNCY;
        private double TC;
        private int ID_SELLER;
        private int ID_QUOTER;
        private int ID_CLIENT;
        private int ID_CONTACT;
        private int ID_IVA;
        private double SUBTOTAL;
        private double IVA;
        private double TOTAL;
        private bool REMISION;
        private bool ACTIVE;
        private string NOTE;
        private string CONDITIONS;
        private string DELIVERY;

        public int id { get => ID; set => ID = value; }
        public DateTime dateQuote { get => DATE_QUOTE; set => DATE_QUOTE = value; }
        public string currency { get => CURRENNCY; set => CURRENNCY = value; }
        public double tc { get => TC; set => TC = value; }
        public int id_seller { get => ID_SELLER; set => ID_SELLER = value; }
        public int id_quoter { get => ID_QUOTER; set => ID_QUOTER = value; }
        public int id_client { get => ID_CLIENT; set => ID_CLIENT = value; }
        public int id_contact { get => ID_CONTACT; set => ID_CONTACT = value; }
        public int id_iva { get => ID_IVA; set => ID_IVA = value; }
        public double subtotal { get => SUBTOTAL; set => SUBTOTAL = value; }
        public double iva { get => IVA; set => IVA = value; }
        public double total { get => TOTAL; set => TOTAL = value; }
        public bool remision { get => REMISION; set => REMISION = value; }
        public bool active { get => ACTIVE; set => ACTIVE = value; }
        public string note { get => NOTE; set => NOTE = value; }
        public string conditions { get => CONDITIONS; set => CONDITIONS = value; }
        public string delivery { get => DELIVERY; set => DELIVERY = value; }

        #endregion

        #region Contructor
        #endregion

        #region Metodos
        #endregion
    }
}
