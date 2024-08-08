using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cotizaciones_Moserep
{
    public class controladorProveedor
    {
        #region Propiedades
        #endregion

        #region Contructor
        #endregion

        #region Metodos
        public void obtenerProveedores()
        {
            string error = "";
            DataTable tablaUsuario = baseDatos.Tabla("select * from suppliers ", ref error);
            foreach (DataRow row in tablaUsuario.Rows)
            {

                suppliers proveedor = new suppliers();
                proveedor.id = Convert.ToInt32(row["ID"]);
                proveedor.name = row["NAME"].ToString();
                proveedor.rfc = row["RFC"].ToString();
                proveedor.address = row["ADDRESS"].ToString();
                proveedor.active = (bool)row["ACTIVE"];
                suppliers.listaProveedores.Add(proveedor);
            }
            suppliers.listaProveedoresActivos = suppliers.listaProveedores.Where(i => i.active.Equals(true)).ToList();
        }

        public static suppliers buscarProveedorPorID(int id)
        {
            suppliers proveedor = new suppliers();
            string error = "";
            DataTable tablaUsuario = baseDatos.Tabla("select * from suppliers where ID="+id.ToString(), ref error);
            foreach (DataRow row in tablaUsuario.Rows)
            {
                proveedor.id = Convert.ToInt32(row["ID"]);
                proveedor.name = row["NAME"].ToString();
                proveedor.rfc = row["RFC"].ToString();
                proveedor.address = row["ADDRESS"].ToString();
                proveedor.active = (bool)row["ACTIVE"];
            }
            return proveedor;
        }

        public void llenarProveedor(string proveedor, string rfc, string direccion, bool activo)
        {
            suppliers.proveedorSeleccionado.name = proveedor;
            suppliers.proveedorSeleccionado.rfc = rfc;
            suppliers.proveedorSeleccionado.address = direccion;
            suppliers.proveedorSeleccionado.active = activo;
        }
        public string validarCampos(string campoCliente)
        {
            if (campoCliente == "")
                return "Se necesita capturar el nombre de la empresa";
            else
                return "";
        }

        public string validarDuplicado(string campoProveedor)
        {
            var aa = suppliers.listaProveedores.Where(i => i.name.Equals(campoProveedor));
            if (aa.Count() > 0)
            {
                return "Existe un proveedor registrado con esta razon social";
            }
            else
                return "";
        }
        #endregion
    }
}
