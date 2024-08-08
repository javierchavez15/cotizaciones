using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cotizaciones_Moserep
{
    public class controladorContactoProveedor
    {
        #region Propiedades
        #endregion

        #region Contructor
        public void obtenerContactos()
        {
            string error = "";
            DataTable tablaUsuario = baseDatos.Tabla("select * from supplier_contact ", ref error);
            foreach (DataRow row in tablaUsuario.Rows)
            {
                supplier_contact contacto = new supplier_contact();
                contacto.id = Convert.ToInt32(row["ID"]);
                contacto.idsupplier = Convert.ToInt32(row["ID_SUPPLIER"]);
                contacto.name = row["NAME"].ToString();
                contacto.email = row["EMAIL"].ToString();
                contacto.phone = row["PHONE"].ToString();
                contacto.active = (bool)row["ACTIVE"];
                supplier_contact.listaContactos.Add(contacto);
            }
        }

        public static supplier_contact buscarContactoPorID(int id)
        {
            supplier_contact contacto = new supplier_contact();
            string error = "";
            DataTable tablaUsuario = baseDatos.Tabla("select * from supplier_contact where ID="+id.ToString(), ref error);
            foreach (DataRow row in tablaUsuario.Rows)
            {
                contacto.id = Convert.ToInt32(row["ID"]);
                contacto.idsupplier = Convert.ToInt32(row["ID_SUPPLIER"]);
                contacto.name = row["NAME"].ToString();
                contacto.email = row["EMAIL"].ToString();
                contacto.phone = row["PHONE"].ToString();
                contacto.active = (bool)row["ACTIVE"];
            }
            return contacto;
        }
        #endregion

        #region Metodos
        public void llenarContacto(string nombre, string email, string telefono, bool activo)
        {
            supplier_contact.contactoSeleccionado.idsupplier = suppliers.proveedorSeleccionado.id;
            supplier_contact.contactoSeleccionado.name = nombre;
            supplier_contact.contactoSeleccionado.email = email;
            supplier_contact.contactoSeleccionado.phone = telefono;
            supplier_contact.contactoSeleccionado.active = activo;
        }
        public string validarCampos(string campocontacto)
        {
            if (campocontacto == "")
                return "Se necesita capturar un contacto";
            else
                return "";
        }

        public string validarDuplicado(string campoCliente)
        {
            var aa = supplier_contact.listaContactos.Where(i => i.name.Equals(campoCliente) && i.idsupplier.Equals(suppliers.proveedorSeleccionado.id));
            if (aa.Count() > 0)
            {
                return "Existe un contacto registrado con este nombre";
            }
            else
                return "";
        }
        #endregion
    }
}
