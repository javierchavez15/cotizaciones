using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Cotizaciones_Moserep
{
    public class iva
    {
        #region Propiedades
        public static iva ivaSeleccionado;
        public static List<iva> listaIvas = new List<iva>();
        private int ID;
        private double MONTO;
        private bool ACTIVE;

        public int id { get => ID; set => ID = value; }
        public double monto { get => MONTO; set => MONTO = value; }
        public bool active { get => ACTIVE; set => ACTIVE = value; }

        #endregion

        #region Contructor
        public override string ToString()
        {
            return MONTO.ToString();
        }
        #endregion

        #region Metodos
        #endregion
    }
}
