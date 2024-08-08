using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Cotizaciones_Moserep
{
    public class profile_user
    {
        #region Propiedades

        public static profile_user perfilSeleccionado;
        public static List<profile_user> listaPerfiles = new List<profile_user>();

        private int ID;
        private string PROFILE;

        public int id { get => ID; set => ID = value; }
        public string profile { get => PROFILE; set => PROFILE = value; }
        #endregion

        #region Contructor
        public override string ToString()
        {
            return PROFILE;
        }
        #endregion

        #region Metodos
        #endregion
    }
}
