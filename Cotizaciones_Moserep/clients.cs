using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cotizaciones_Moserep
{
    public class clients
    {
        #region Propiedades
        public static clients clienteSeleccionado;
        public static List<clients> listaClientes = new List<clients>();
        public static List<clients> listaClientesActivos = new List<clients>();
        private int ID;
        private int ID_SELLER;
        private string NAME;
        private string RFC;
        private string ADDRESS;
        private bool ACTIVE;
        private int ID_IVA;

        public int id { get => ID; set => ID = value; }
        public int idSeller { get => ID_SELLER; set => ID_SELLER = value; }
        public string name { get => NAME; set => NAME = value; }
        public string rfc { get => RFC; set => RFC = value; }
        public string address { get => ADDRESS; set => ADDRESS = value; }
        public bool active { get => ACTIVE; set => ACTIVE = value; }
        public int idIva { get => ID_IVA; set => ID_IVA = value; }
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
