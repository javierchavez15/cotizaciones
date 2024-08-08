using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cotizaciones_Moserep
{
    public class client_contact
    {
        #region Propiedades

        public static client_contact contactoSeleccionado;
        public static List<client_contact> listaContactos = new List<client_contact>();
        public static List<client_contact> listaContactosDeCliente = new List<client_contact>();

        private int ID;
        private int ID_CLIENT;
        private string NAME;
        private string EMAIL;
        private string PHONE;
        private bool ACTIVE;

        public int id { get => ID; set => ID = value; }
        public int idClient { get => ID_CLIENT; set => ID_CLIENT = value; }
        public string name { get => NAME; set => NAME = value; }
        public string email { get => EMAIL; set => EMAIL = value; }
        public string phone { get => PHONE; set => PHONE = value; }
        public bool active { get => ACTIVE; set => ACTIVE = value; }

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
