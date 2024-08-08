using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cotizaciones_Moserep
{
    public class suppliers
    {
        #region Propiedades
        private int ID;
        private string NAME;
        private string RFC;
        private string ADDRESS;
        private bool ACTIVE;

        public int id { get => ID; set => ID = value; }
        public string name { get => NAME; set => NAME = value; }
        public string rfc { get => RFC; set => RFC = value; }
        public string address { get => ADDRESS; set => ADDRESS = value; }
        public bool active { get => ACTIVE; set => ACTIVE = value; }

        public static suppliers proveedorSeleccionado;
        public static List<suppliers> listaProveedores = new List<suppliers>();
        public static List<suppliers> listaProveedoresActivos = new List<suppliers>();
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
