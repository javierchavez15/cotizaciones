using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cotizaciones_Moserep
{
    public class users
    {
        #region Propiedades
        public static users usuarioActual;
        public static users vendedorSeleccionado;
        public static List<users> listaUsuarios = new List<users>();
        public static List<users> listaVendedores = new List<users>();
        private int ID;
        private string USER;
        private string PASSWORD;
        private int ID_PROFILE;
        private string NAME;
        private string EMAIL;
        private bool ACTIVE;

        public int id { get => ID; set => ID = value; }
        public string user { get => USER; set => USER = value; }
        public string password { get => PASSWORD; set => PASSWORD = value; }
        public int idProfile { get => ID_PROFILE; set => ID_PROFILE = value; }
        public string name { get => NAME; set => NAME = value; }
        public string email { get => EMAIL; set => EMAIL = value; }
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
