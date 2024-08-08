using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cotizaciones_Moserep
{
    public class supplier_contact
    {
        #region Propiedades
        private int ID;
        private int ID_SUPPLIER;
        private string NAME;
        private string EMAIL;
        private string PHONE;
        private bool ACTIVE;

        public int id { get => ID; set => ID = value; }
        public int idsupplier { get => ID_SUPPLIER; set => ID_SUPPLIER = value; }
        public string name { get => NAME; set => NAME = value; }
        public string email { get => EMAIL; set => EMAIL = value; }
        public string phone { get => PHONE; set => PHONE = value; }
        public bool active { get => ACTIVE; set => ACTIVE = value; }

        public static supplier_contact contactoSeleccionado;
        public static List<supplier_contact> listaContactos = new List<supplier_contact>();
        public static List<supplier_contact> listaContactosActivos = new List<supplier_contact>();
        public static List<supplier_contact> listaContactosDeProveedor = new List<supplier_contact>();
        #endregion

        #region Contructor
        public override string ToString()
        {
            return NAME;
        }
        #endregion

        #region Metodos
        #endregion
    }
}
