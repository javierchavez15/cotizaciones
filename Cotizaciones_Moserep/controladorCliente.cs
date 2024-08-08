using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cotizaciones_Moserep
{
    public class controladorCliente
    {
        #region Propiedades
        #endregion

        #region Contructor
        #endregion

        #region Metodos
        public void obtenerClientes()
        {
            string error = "";
            DataTable tablaUsuario = baseDatos.Tabla("select * from clients ", ref error);
            foreach (DataRow row in tablaUsuario.Rows)
            {

                clients cliente = new clients();
                cliente.id = Convert.ToInt32(row["ID"]);
                cliente.idSeller = Convert.ToInt32(row["ID_SELLER"]);
                cliente.name = row["NAME"].ToString();
                cliente.rfc = row["RFC"].ToString();
                cliente.address = row["ADDRESS"].ToString();
                cliente.active = (bool)row["ACTIVE"];
                clients.listaClientes.Add(cliente);
            }
            clients.listaClientesActivos = clients.listaClientes.Where(i => i.active.Equals(true)).ToList();
        }

        public static clients buscarClientePorID(int id)
        {
            clients cliente =null;
            List<clients> lista = clients.listaClientes.Where(i => i.id.Equals(id)).ToList();
            if (lista.Count > 0)
                cliente = lista[0];
            return cliente;
        }

        public void llenarCliente(string cliente, string rfc, string direccion, bool activo, int idVendedor)
        {
            clients.clienteSeleccionado.name = cliente;
            clients.clienteSeleccionado.rfc = rfc;
            clients.clienteSeleccionado.address = direccion;
            clients.clienteSeleccionado.active = activo;
            clients.clienteSeleccionado.idSeller=idVendedor;
            clients.clienteSeleccionado.idIva = iva.ivaSeleccionado.id;
        }
        
        public string validarCampos(string campoCliente)
        {
            if (campoCliente == "")
                return "Se necesita capturar la razon social";
            else
                return "";
        }

        public string validarDuplicado(string campoCliente)
        {
            var aa = clients.listaClientes.Where(i => i.name.Equals(campoCliente));
            if (aa.Count() > 0)
            {
                return "Existe un cliente registrado con esta razon social";
            }
            else 
                return "";
        }
        #endregion
    }
}
