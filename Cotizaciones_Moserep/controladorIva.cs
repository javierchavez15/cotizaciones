using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cotizaciones_Moserep
{
    public class controladorIva
    {
        #region Propiedades
        #endregion

        #region Contructor
        #endregion

        #region Metodos
        public void obtenerIvas()
        {
            string error = "";
            DataTable tablaUsuario = baseDatos.Tabla("select * from iva ", ref error);
            foreach (DataRow row in tablaUsuario.Rows)
            {
                iva iva = new iva();
                iva.id = Convert.ToInt32(row["ID"]);
                iva.monto =Convert.ToDouble(row["MONTO"]);
                iva.active = (bool)row["ACTIVE"];
                iva.listaIvas.Add(iva);
            }
        }

        public static iva buscarIvaPorID(int id)
        {
            iva ivaTemp = null;
            List<iva> lista = iva.listaIvas.Where(i => i.id.Equals(id)).ToList();
            if(lista.Count>0)
                ivaTemp = lista[0];
            return ivaTemp;
        }
        #endregion
    }
}
