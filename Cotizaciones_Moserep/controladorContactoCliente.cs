using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cotizaciones_Moserep
{
    public class controladorContactoCliente
    {
        #region Propiedades
        #endregion

        #region Contructor
        #endregion

        #region Metodos
        public void obtenerContactos()
        {
            string error = "";
            DataTable tablaUsuario = baseDatos.Tabla("select * from client_contact ", ref error);
            foreach (DataRow row in tablaUsuario.Rows)
            {
                client_contact contacto = new client_contact();
                contacto.id = Convert.ToInt32(row["ID"]);
                contacto.idClient = Convert.ToInt32(row["ID_CLIENT"]);
                contacto.name = row["NAME"].ToString();
                contacto.email = row["EMAIL"].ToString();
                contacto.phone = row["PHONE"].ToString();
                contacto.active = (bool)row["ACTIVE"];
                client_contact.listaContactos.Add(contacto);
            }
        }

        public static client_contact buscarContactoPorID(int id)
        {
            client_contact contacto = null;
            List<client_contact> lista = client_contact.listaContactos.Where(i => i.id.Equals(id)).ToList();
            if (lista.Count > 0)
                contacto = lista[0];
            return contacto;
        }

        public void llenarContacto(string nombre, string email, string telefono, bool activo)
        {
            client_contact.contactoSeleccionado.name = nombre;
            client_contact.contactoSeleccionado.email = email;
            client_contact.contactoSeleccionado.phone = telefono;
            client_contact.contactoSeleccionado.active = activo;
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
            var aa = client_contact.listaContactos.Where(i => i.name.Equals(campoCliente) && i.idClient.Equals(clients.clienteSeleccionado.id));
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
