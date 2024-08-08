using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Cotizaciones_Moserep
{
    public class controladorUsuario
    {
        #region Propiedades
        #endregion

        #region Contructor
        #endregion

        #region Metodos

        public void llenarContacto(string usuario, string contra, int idperfil, string nombre, string email, bool activo, ref users userTemp)
        {
            userTemp.user = usuario;
            userTemp.password = contra;
            userTemp.idProfile = idperfil;
            userTemp.name = nombre;
            userTemp.email = email;
            userTemp.active = activo;
        }

        public string validarDuplicado(string campoUsuario)
        {
            var aa = users.listaUsuarios.Where(i => i.user.Equals(campoUsuario));
            if (aa.Count() > 0)
            {
                return "Existe un usuario registrado";
            }
            else
                return "";
        }

        public void obtenerPerfiles()
        {
            string error = "";
            DataTable tablaUsuario = baseDatos.Tabla("select * from profile_user ", ref error);
            foreach (DataRow row in tablaUsuario.Rows)
            {
                profile_user perfil = new profile_user();
                perfil.id = Convert.ToInt32(row["ID"]);
                perfil.profile = row["PROFILE"].ToString();
                profile_user.listaPerfiles.Add(perfil);
            }
        }

        public static profile_user obtenerPerfile(int id)
        {
            string error = "";
            profile_user perfil = new profile_user();
            DataTable tablaUsuario = baseDatos.Tabla("select * from profile_user where ID="+id.ToString(), ref error);
            foreach (DataRow row in tablaUsuario.Rows)
            {               
                perfil.id = Convert.ToInt32(row["ID"]);
                perfil.profile = row["PROFILE"].ToString();
            }
            return perfil;
        }

        public void login(string usuario, string password)
        {
            string error = "";
            string nombreUsuario = baseDatos.consultas("select NAME from users where USER='" + usuario + "' and PASSWORD='" + password + "' limit 1");
            DataTable tablaUsuario = baseDatos.Tabla("select * from users where USER='" + usuario + "' and PASSWORD='" + password + "' limit 1", ref error);
            foreach (DataRow row in tablaUsuario.Rows)
            {
                users.usuarioActual = new users();
                users.usuarioActual.id =Convert.ToInt32(row["ID"]);
                users.usuarioActual.user = row["USER"].ToString();
                users.usuarioActual.password = row["PASSWORD"].ToString();
                users.usuarioActual.idProfile = Convert.ToInt32(row["ID_PROFILE"]);
                users.usuarioActual.name = row["NAME"].ToString();
                users.usuarioActual.email = row["EMAIL"].ToString();
            }
        }

        public void obtenerUsuarioLogin(int id)
        {
            List<users> listaUsuariosTemporal = users.listaUsuarios.Where(i => i.id.Equals(id)).ToList();
            if (listaUsuariosTemporal.Count > 0)
                users.usuarioActual = listaUsuariosTemporal[0];
        }

        public static users obtenerUsuario(int id)
        {
            List<users> listaUsuariosTemporal = users.listaUsuarios.Where(i => i.id.Equals(id)).ToList();
            if (listaUsuariosTemporal.Count > 0)
                return listaUsuariosTemporal[0];
            else
                return null;
        }

        public users obetenerVendedorCliente(int idCliente)
        {
            users userTemp=null;
            if (idCliente > 0)
            {
                List<users> listaVendedoresTemporal = users.listaUsuarios.Where(i => i.id.Equals(idCliente)).ToList();
                if (listaVendedoresTemporal.Count > 0)
                    userTemp = listaVendedoresTemporal[0];
            }
            return userTemp;
        }

        public void obtenerUsuarios()
        {
            string error = "";
            DataTable tablaUsuario = baseDatos.Tabla("select * from users ", ref error);
            foreach (DataRow row in tablaUsuario.Rows)
            {
                users usuario = new users();
                usuario.id = Convert.ToInt32(row["ID"]);
                usuario.user = row["USER"].ToString();
                usuario.password = row["PASSWORD"].ToString();
                usuario.idProfile = Convert.ToInt32(row["ID_PROFILE"]);
                usuario.name = row["NAME"].ToString();
                usuario.email = row["EMAIL"].ToString();
                usuario.active =(bool) row["ACTIVE"];
                users.listaUsuarios.Add(usuario);
            }
            users.listaVendedores = users.listaUsuarios.Where(i => i.active.Equals(true) && (i.idProfile.Equals(2) || i.idProfile.Equals(3))).ToList();
        }

        public static users buscarUsuarioPorID(int id)
        {
            users usuario = null;
            List<users> lista =  users.listaUsuarios.Where(i => i.id.Equals(id) ).ToList();
            if (lista.Count > 0)
                usuario = lista[0];
            return usuario;
        }
        #endregion
    }
}
