using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using System.Data.Sql;
using MySql.Data.MySqlClient;
using System.Reflection;
using System.Collections;

namespace Cotizaciones_Moserep
{
    public class baseDatos
    {
        #region Propiedades
        public string _Key = "ID";
        public string _Tabla = "";
        public static MySqlDataAdapter mysqlDataAdapter;
        public static string cs = "";
        public static MySqlConnection MySqlConnection;
        public string mError = "";
        public static bool Mysql=true;
        #endregion

        #region Contructor

        public static void SetConnectionString(string connectionString)
        {
            cs = connectionString;
            MySqlConnection = new MySqlConnection(cs);
        }
        public baseDatos()
        {
        }
        public baseDatos(DataRow dr)
        {
            Leer(dr);
        }
        #endregion

        #region Metodos

        public static long agregarCliente()
        {
            try
            {
                if (MySqlConnection.State == ConnectionState.Closed)
                    MySqlConnection.Open();
                var comando = "INSERT INTO clients (NAME, RFC, ADDRESS, ACTIVE, ID_SELLER, ID_IVA) "
                    + "VALUES (@name, @rfc, @address, @active, @id_seller, @iva) ";
                MySqlCommand comandoIngresar = new MySqlCommand(comando, MySqlConnection);
                comandoIngresar.Parameters.AddWithValue("@name", clients.clienteSeleccionado.name);
                comandoIngresar.Parameters.AddWithValue("@rfc", clients.clienteSeleccionado.rfc);
                comandoIngresar.Parameters.AddWithValue("@address", clients.clienteSeleccionado.address);
                comandoIngresar.Parameters.AddWithValue("@active", clients.clienteSeleccionado.active);
                comandoIngresar.Parameters.AddWithValue("@id_seller", clients.clienteSeleccionado.idSeller);
                comandoIngresar.Parameters.AddWithValue("@iva", clients.clienteSeleccionado.idIva);
                comandoIngresar.ExecuteNonQuery();
                MySqlConnection.Close();
                return comandoIngresar.LastInsertedId;
            }catch(Exception ex)
            {
                MySqlConnection.Close();
                return 0;
            }
        }

        public static long insertarProveedor()
        {
            try
            {
                if (MySqlConnection.State == ConnectionState.Closed)
                    MySqlConnection.Open();
                var comando = "INSERT INTO suppliers (NAME, RFC, ADDRESS, ACTIVE) "
                    + "VALUES (@name, @rfc, @address, @active) ";
                MySqlCommand comandoIngresar = new MySqlCommand(comando, MySqlConnection);
                comandoIngresar.Parameters.AddWithValue("@name", suppliers.proveedorSeleccionado.name);
                comandoIngresar.Parameters.AddWithValue("@rfc", suppliers.proveedorSeleccionado.rfc);
                comandoIngresar.Parameters.AddWithValue("@address", suppliers.proveedorSeleccionado.address);
                comandoIngresar.Parameters.AddWithValue("@active", suppliers.proveedorSeleccionado.active);
                comandoIngresar.ExecuteNonQuery();
                MySqlConnection.Close();
                return comandoIngresar.LastInsertedId;
            }
            catch (Exception ex)
            {
                MySqlConnection.Close();
                return 0;
            }
        }

        public static long insertarContactoCliente()
        {
            try
            {
                if (MySqlConnection.State == ConnectionState.Closed)
                    MySqlConnection.Open();
                var comando = "INSERT INTO client_contact (ID_CLIENT, NAME, EMAIL, PHONE, ACTIVE) "
                    + "VALUES (@id_client, @name, @email, @phone, @active) ";
                MySqlCommand comandoIngresar = new MySqlCommand(comando, MySqlConnection);
                comandoIngresar.Parameters.AddWithValue("@id_client", clients.clienteSeleccionado.id);
                comandoIngresar.Parameters.AddWithValue("@name", client_contact.contactoSeleccionado.name);
                comandoIngresar.Parameters.AddWithValue("@email", client_contact.contactoSeleccionado.email);
                comandoIngresar.Parameters.AddWithValue("@phone", client_contact.contactoSeleccionado.phone);
                comandoIngresar.Parameters.AddWithValue("@active", client_contact.contactoSeleccionado.active);
                comandoIngresar.ExecuteNonQuery();
                MySqlConnection.Close();
                return comandoIngresar.LastInsertedId;
            }
            catch (Exception ex)
            {
                MySqlConnection.Close();
                return 0;
            }
        }

        public static long insertarUsuario(users usuario)
        {
            try
            {
                if (MySqlConnection.State == ConnectionState.Closed)
                    MySqlConnection.Open();
                var comando = "INSERT INTO users (USER, PASSWORD, ID_PROFILE, NAME, EMAIL, ACTIVE) "
                    + "VALUES (@user, @password, @idprofile, @name, @email, @active) ";
                MySqlCommand comandoIngresar = new MySqlCommand(comando, MySqlConnection);
                comandoIngresar.Parameters.AddWithValue("@user", usuario.user);
                comandoIngresar.Parameters.AddWithValue("@password", usuario.password);
                comandoIngresar.Parameters.AddWithValue("@idprofile", usuario.idProfile);
                comandoIngresar.Parameters.AddWithValue("@name", usuario.name);
                comandoIngresar.Parameters.AddWithValue("@email", usuario.email);
                comandoIngresar.Parameters.AddWithValue("@active", usuario.active);
                comandoIngresar.ExecuteNonQuery();
                MySqlConnection.Close();
                return comandoIngresar.LastInsertedId;
            }
            catch (Exception ex)
            {
                MySqlConnection.Close();
                return 0;
            }
        }

        public static void editarUsuario(users usuario)
        {
            try
            {

                if (MySqlConnection.State == ConnectionState.Closed)
                    MySqlConnection.Open();
                var comando = "UPDATE users SET USER=@user, PASSWORD=@password, ID_PROFILE=@idprofile, NAME=@name, EMAIL=@email, ACTIVE=@active WHERE ID=@id ";
                MySqlCommand comandoIngresar = new MySqlCommand(comando, MySqlConnection);
                comandoIngresar.Parameters.AddWithValue("@user", usuario.user);
                comandoIngresar.Parameters.AddWithValue("@password", usuario.password);
                comandoIngresar.Parameters.AddWithValue("@idprofile", usuario.idProfile);
                comandoIngresar.Parameters.AddWithValue("@name", usuario.name);
                comandoIngresar.Parameters.AddWithValue("@email", usuario.email);
                comandoIngresar.Parameters.AddWithValue("@active", usuario.active);
                comandoIngresar.Parameters.AddWithValue("@id", usuario.id);
                comandoIngresar.ExecuteNonQuery();
                MySqlConnection.Close();
            }
            catch (Exception ex)
            {
                MySqlConnection.Close();
            }
        }


        public static long insertarCotizacion(quotes cotizacion, ref string error)
        {
            try
            {
                if (MySqlConnection.State == ConnectionState.Closed)
                    MySqlConnection.Open();
                var comando = "INSERT INTO quotes (ID, DATE_QUOTE, CURRENNCY, TC, ID_SELLER, ID_QUOTER, " +
                    "ID_CLIENT, ID_CONTACT, ID_IVA, SUBTOTAL, IVA, TOTAL, REMISION, ACTIVE, NOTE, CONDITIONS, DELIVERY) "
                    + "VALUES (@id, @dateQuote, @currency, @tc, @id_seller, @id_quoter, @id_client, @id_contact, @id_iva, @subtotal, @iva, @total, @remision, @active, @note, @conditions, @delivery) ";
                MySqlCommand comandoIngresar = new MySqlCommand(comando, MySqlConnection);
                comandoIngresar.Parameters.AddWithValue("@id", cotizacion.id);
                comandoIngresar.Parameters.AddWithValue("@dateQuote", cotizacion.dateQuote);
                comandoIngresar.Parameters.AddWithValue("@currency", cotizacion.currency);
                comandoIngresar.Parameters.AddWithValue("@tc", cotizacion.tc);
                comandoIngresar.Parameters.AddWithValue("@id_seller", cotizacion.id_seller);
                comandoIngresar.Parameters.AddWithValue("@id_quoter", cotizacion.id_quoter);
                comandoIngresar.Parameters.AddWithValue("@id_client", cotizacion.id_client);
                comandoIngresar.Parameters.AddWithValue("@id_contact", cotizacion.id_contact);
                comandoIngresar.Parameters.AddWithValue("@id_iva", cotizacion.id_iva);
                comandoIngresar.Parameters.AddWithValue("@subtotal", cotizacion.subtotal);
                comandoIngresar.Parameters.AddWithValue("@iva", cotizacion.iva);
                comandoIngresar.Parameters.AddWithValue("@total", cotizacion.total);
                comandoIngresar.Parameters.AddWithValue("@remision", cotizacion.remision);
                comandoIngresar.Parameters.AddWithValue("@active", cotizacion.active);
                comandoIngresar.Parameters.AddWithValue("@note", cotizacion.note);
                comandoIngresar.Parameters.AddWithValue("@conditions", cotizacion.conditions);
                comandoIngresar.Parameters.AddWithValue("@delivery", cotizacion.delivery);
                comandoIngresar.ExecuteNonQuery();
                MySqlConnection.Close();
                return comandoIngresar.LastInsertedId;
            }
            catch (Exception ex)
            {
                MySqlConnection.Close();
                error = ex.Message;
                return 0;
            }
        }

        public static long insertarItem(items_quotes item, ref string error)
        {
            try
            {
                if (MySqlConnection.State == ConnectionState.Closed)
                    MySqlConnection.Open();
                var comando = "INSERT INTO items_quotes (" +
                    "ID_QUOTE, " +//2
                    "ITEM, " +//3
                    "CATALOGUE, " +//4
                    "ALIAS, " +//5
                    "DESCRIPTION, " +//6
                    "QUANTITY, " +//7
                    "IMAGE, " +//8
                    "ID_SUPPLIER, " +//9
                    "ID_CONTACT, " +//10
                    "URL1, " +//11
                    "URL2, " +//12
                    "NUMBER_QUOTE_SUPPLIER, " +//13
                    "NOTE_SUPPLIER, " +//14
                    "DATE_SUPPLIER, " +//15
                    "CURRENCY, " +//16
                    "COST, " +//17
                    "TAX, " +//18
                    "SHIPPING, " +//19
                    "IMPORT, " +//20
                    "OTHER_COST, " +//21
                    "SUM_COST, " +//22
                    "COST_ITEM, " +//23
                    "NOTE_IMPORT, " +//24
                    "PERCENTAGE, " +//25
                    "PRICE, " +//26
                    "TOTAL, " +//27
                    "ACTIVE) "//28
                    + "VALUES (" +
                    "@id_quote, " +//2
                    "@item, " +//3
                    "@catalogue, " +//4
                    "@alias, " +//5
                    "@description, " +//6
                    "@quantity, " +//7
                    "@image, " +//8
                    "@idSupplier, " +//9
                    "@idContact, " +//10
                    "@url1, " +//11
                    "@url2, " +//12
                    "@numberQuoteSupplier, " +//13
                    "@noteSupplier, " +//14
                    "@dateSupplier, " +//15
                    "@currency, " +//16
                    "@cost, " +//17
                    "@tax, " +//18
                    "@shipping, " +//19
                    "@import, " +//20
                    "@otherCost, " +//21
                    "@sumCost, " +//22
                    "@costItem, " +//23
                    "@noteImport, " +//24
                    "@percentage, " +//25
                    "@price, " +//26
                    "@total, " +//27
                    "@active) ";//28
                MySqlCommand comandoIngresar = new MySqlCommand(comando, MySqlConnection);
                comandoIngresar.Parameters.AddWithValue("@id_quote", item.id_quote);//2
                comandoIngresar.Parameters.AddWithValue("@item", item.item);//3
                comandoIngresar.Parameters.AddWithValue("@catalogue", item.catalogue);//4
                comandoIngresar.Parameters.AddWithValue("@alias", item.alias);//5
                comandoIngresar.Parameters.AddWithValue("@description", item.description);//6
                comandoIngresar.Parameters.AddWithValue("@quantity", item.quantity);//7
                comandoIngresar.Parameters.AddWithValue("@image", item.image);//8
                comandoIngresar.Parameters.AddWithValue("@idSupplier", item.idSupplier);//9
                comandoIngresar.Parameters.AddWithValue("@idContact", item.idContact);//10
                comandoIngresar.Parameters.AddWithValue("@url1", item.url1);//11
                comandoIngresar.Parameters.AddWithValue("@url2", item.url2);//12
                comandoIngresar.Parameters.AddWithValue("@numberQuoteSupplier", item.numberQuoteSupplier);//13 
                comandoIngresar.Parameters.AddWithValue("@noteSupplier", item.noteSupplier);//14
                comandoIngresar.Parameters.AddWithValue("@dateSupplier", item.dateSupplier);//15
                comandoIngresar.Parameters.AddWithValue("@currency", item.currency);//16
                comandoIngresar.Parameters.AddWithValue("@cost", item.cost);//17
                comandoIngresar.Parameters.AddWithValue("@tax", item.tax);//18
                comandoIngresar.Parameters.AddWithValue("@shipping", item.shipping);//19
                comandoIngresar.Parameters.AddWithValue("@import", item.import);//20
                comandoIngresar.Parameters.AddWithValue("@otherCost", item.otherCost);//21
                comandoIngresar.Parameters.AddWithValue("@sumCost", item.sumCost);//22
                comandoIngresar.Parameters.AddWithValue("@costItem", item.costItem);//23
                comandoIngresar.Parameters.AddWithValue("@noteImport", item.noteImport);//24
                comandoIngresar.Parameters.AddWithValue("@percentage", item.percentage);//25
                comandoIngresar.Parameters.AddWithValue("@price", item.price);//26
                comandoIngresar.Parameters.AddWithValue("@total", item.total);//27
                comandoIngresar.Parameters.AddWithValue("@active", item.active);//28
                comandoIngresar.ExecuteNonQuery();
                MySqlConnection.Close();
                return comandoIngresar.LastInsertedId;
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return 0;
            }
        }

        public static long insertarContactoProveedor()
        {
            try
            {
                if (MySqlConnection.State == ConnectionState.Closed)
                    MySqlConnection.Open();
                var comando = "INSERT INTO supplier_contact (ID_SUPPLIER, NAME, EMAIL, PHONE, ACTIVE) "
                    + "VALUES (@id_supplier, @name, @email, @phone, @active) ";
                MySqlCommand comandoIngresar = new MySqlCommand(comando, MySqlConnection);
                comandoIngresar.Parameters.AddWithValue("@id_supplier", suppliers.proveedorSeleccionado.id);
                comandoIngresar.Parameters.AddWithValue("@name", supplier_contact.contactoSeleccionado.name);
                comandoIngresar.Parameters.AddWithValue("@email", supplier_contact.contactoSeleccionado.email);
                comandoIngresar.Parameters.AddWithValue("@phone", supplier_contact.contactoSeleccionado.phone);
                comandoIngresar.Parameters.AddWithValue("@active", supplier_contact.contactoSeleccionado.active);
                comandoIngresar.ExecuteNonQuery();
                MySqlConnection.Close();
                return comandoIngresar.LastInsertedId;
            }
            catch (Exception ex)
            {
                MySqlConnection.Close();
                return 0;
            }
        }

        public static void editarCliente()
        {
            try
            {
                if (MySqlConnection.State == ConnectionState.Closed)
                    MySqlConnection.Open();
                var comando = "UPDATE clients SET NAME=@name, RFC=@rfc, ADDRESS=@address, ACTIVE=@active, ID_SELLER=@id_seller WHERE ID=@id ";
                MySqlCommand comandoEditar = new MySqlCommand(comando, MySqlConnection);
                comandoEditar.Parameters.AddWithValue("@name", clients.clienteSeleccionado.name);
                comandoEditar.Parameters.AddWithValue("@rfc", clients.clienteSeleccionado.rfc);
                comandoEditar.Parameters.AddWithValue("@address", clients.clienteSeleccionado.address);
                comandoEditar.Parameters.AddWithValue("@active", clients.clienteSeleccionado.active);
                comandoEditar.Parameters.AddWithValue("@id_seller", clients.clienteSeleccionado.idSeller);
                comandoEditar.Parameters.AddWithValue("@id", clients.clienteSeleccionado.id);
                comandoEditar.ExecuteScalar();
                MySqlConnection.Close();
            }
            catch (Exception ex)
            {
                MySqlConnection.Close();
            }
        }

        public static void editarProveedor()
        {
            try
            {
                if (MySqlConnection.State == ConnectionState.Closed)
                    MySqlConnection.Open();
                var comando = "UPDATE suppliers SET NAME=@name, RFC=@rfc, ADDRESS=@address, ACTIVE=@active WHERE ID=@id ";
                MySqlCommand comandoEditar = new MySqlCommand(comando, MySqlConnection);
                comandoEditar.Parameters.AddWithValue("@name", suppliers.proveedorSeleccionado.name);
                comandoEditar.Parameters.AddWithValue("@rfc", suppliers.proveedorSeleccionado.rfc);
                comandoEditar.Parameters.AddWithValue("@address", suppliers.proveedorSeleccionado.address);
                comandoEditar.Parameters.AddWithValue("@active", suppliers.proveedorSeleccionado.active);
                comandoEditar.Parameters.AddWithValue("@id", suppliers.proveedorSeleccionado.id);
                comandoEditar.ExecuteScalar();
                MySqlConnection.Close();
            }
            catch (Exception ex)
            {
                MySqlConnection.Close();
            }
        }


        public static void editarBorrarpersona()
        {
            string query = "select Email, OrganizationID from personasdescargas";
            DataTable dt = new DataTable();
            if (Mysql)
            {
                mysqlDataAdapter = new MySqlDataAdapter(query, MySqlConnection);
                try
                {
                    mysqlDataAdapter.Fill(dt);
                }
                catch (Exception ex)
                {
                    // error = ex.Message;
                }
            }

            foreach (DataRow dr in dt.Rows)
            {

                string email = dr.ItemArray[0].ToString();
                int organizacionid = Convert.ToInt32(dr.ItemArray[1]);

                string query2 = "select ID, Organization from personasbranstor where Email='" + email + "' and OrganizationID="+ organizacionid.ToString();
                DataTable dt2 = new DataTable();
                if (Mysql)
                {
                    mysqlDataAdapter = new MySqlDataAdapter(query2, MySqlConnection);
                    try
                    {
                        mysqlDataAdapter.Fill(dt2);
                    }
                    catch (Exception ex)
                    {
                        // error = ex.Message;
                    }
                }
                foreach (DataRow dr2 in dt2.Rows)
                {
                    int id = Convert.ToInt32(dr2.ItemArray[0]);
                    string organizacion = dr2.ItemArray[1].ToString();
                    try
                    {
                        if (MySqlConnection.State == ConnectionState.Closed)
                            MySqlConnection.Open();
                        var comando = "UPDATE personasdescargas SET ID=@id, Organization=@organizacion WHERE Email=@email and OrganizationID=@organizacionid ";
                        MySqlCommand comandoEditar = new MySqlCommand(comando, MySqlConnection);
                        comandoEditar.Parameters.AddWithValue("@id", id);
                        comandoEditar.Parameters.AddWithValue("@organizacion", organizacion);
                        comandoEditar.Parameters.AddWithValue("@email", email);
                        comandoEditar.Parameters.AddWithValue("@organizacionid", organizacionid);
                        comandoEditar.ExecuteScalar();
                        MySqlConnection.Close();
                    }
                    catch (Exception ex)
                    {
                        MySqlConnection.Close();
                    }
                }

            }
        }

        public static void editarBorrar()
        {
            string query = "select ID, NOMBRE from branstor";
            DataTable dt = new DataTable();
            if (Mysql)
            {
                mysqlDataAdapter = new MySqlDataAdapter(query, MySqlConnection);
                try
                {
                    mysqlDataAdapter.Fill(dt);
                }
                catch (Exception ex)
                {
                   // error = ex.Message;
                }
            }

            foreach (DataRow dr in dt.Rows)
            {
                string query2 = "select NOMBRE, DIRECCION from descargado where NOMBRE like '%" + dr.ItemArray[1].ToString()+"%'";
                DataTable dt2 = new DataTable();
                if (Mysql)
                {
                    mysqlDataAdapter = new MySqlDataAdapter(query2, MySqlConnection);
                    try
                    {
                        mysqlDataAdapter.Fill(dt2);
                    }
                    catch (Exception ex)
                    {
                        // error = ex.Message;
                    }
                }
                int contador = 0;
                foreach(DataRow dr2 in dt2.Rows)
                {
                    string tipo = "NUEVO";
                    if (dt2.Rows.Count > 1)
                        tipo = "REP";
                    try
                    {
                        if (MySqlConnection.State == ConnectionState.Closed)
                            MySqlConnection.Open();
                        var comando = "UPDATE descargado SET ID=@id, TIPO=@tipo WHERE NOMBRE=@nombre and DIRECCION=@direccion ";
                        MySqlCommand comandoEditar = new MySqlCommand(comando, MySqlConnection);
                        comandoEditar.Parameters.AddWithValue("@id", dr.ItemArray[0].ToString());
                        comandoEditar.Parameters.AddWithValue("@tipo", tipo);
                        comandoEditar.Parameters.AddWithValue("@nombre", dr2.ItemArray[0].ToString());
                        comandoEditar.Parameters.AddWithValue("@direccion", dr2.ItemArray[1].ToString());
                        comandoEditar.ExecuteScalar();
                        MySqlConnection.Close();
                    }
                    catch (Exception ex)
                    {
                        MySqlConnection.Close();
                    }
                    contador++;
                }
            }

            

            
        }

        public static void editarContactoCliente()
        {
            try
            {
                if (MySqlConnection.State == ConnectionState.Closed)
                    MySqlConnection.Open();
                var comando = "UPDATE client_contact SET ID_CLIENT=@id_client, NAME=@name, EMAIL=@email, PHONE=@phone, ACTIVE=@active WHERE ID=@id ";
                MySqlCommand comandoEditar = new MySqlCommand(comando, MySqlConnection);
                comandoEditar.Parameters.AddWithValue("@id_client", clients.clienteSeleccionado.id);
                comandoEditar.Parameters.AddWithValue("@name", client_contact.contactoSeleccionado.name);
                comandoEditar.Parameters.AddWithValue("@email", client_contact.contactoSeleccionado.email);
                comandoEditar.Parameters.AddWithValue("@phone", client_contact.contactoSeleccionado.phone);
                comandoEditar.Parameters.AddWithValue("@active", client_contact.contactoSeleccionado.active);
                comandoEditar.Parameters.AddWithValue("@id", client_contact.contactoSeleccionado.id);
                comandoEditar.ExecuteScalar();
                MySqlConnection.Close();
            }
            catch (Exception ex)
            {
                MySqlConnection.Close();
            }
        }

        public static void editarContactoProveedor()
        {
            try
            {
                if (MySqlConnection.State == ConnectionState.Closed)
                    MySqlConnection.Open();
                var comando = "UPDATE supplier_contact SET ID_SUPPLIER=@id_supplier, NAME=@name, EMAIL=@email, PHONE=@phone, ACTIVE=@active WHERE ID=@id ";
                MySqlCommand comandoEditar = new MySqlCommand(comando, MySqlConnection);
                comandoEditar.Parameters.AddWithValue("@id_supplier", suppliers.proveedorSeleccionado.id);
                comandoEditar.Parameters.AddWithValue("@name", supplier_contact.contactoSeleccionado.name);
                comandoEditar.Parameters.AddWithValue("@email", supplier_contact.contactoSeleccionado.email);
                comandoEditar.Parameters.AddWithValue("@phone", supplier_contact.contactoSeleccionado.phone);
                comandoEditar.Parameters.AddWithValue("@active", supplier_contact.contactoSeleccionado.active);
                comandoEditar.Parameters.AddWithValue("@id", supplier_contact.contactoSeleccionado.id);
                comandoEditar.ExecuteScalar();
                MySqlConnection.Close();
            }
            catch (Exception ex)
            {
                MySqlConnection.Close();
            }
        }

        public static void editarSolicitud(string estatus, string id)
        {
            try
            {
                if (MySqlConnection.State == ConnectionState.Closed)
                    MySqlConnection.Open();
                var comando = "UPDATE cotizaciones SET `status`=@estatus, fecha_estatus=@fechaEstatus WHERE id=@Id ";
                if(estatus== "Enviada")
                    comando = "UPDATE cotizaciones SET `status`=@estatus, fecha_estatus=@fechaEstatus, fechaEnviada=@enviada WHERE id =@Id ";
                MySqlCommand comandoEditar = new MySqlCommand(comando, MySqlConnection);
                comandoEditar.Parameters.AddWithValue("@estatus", estatus);
                comandoEditar.Parameters.AddWithValue("@fechaEstatus", DateTime.Now);
                if (estatus == "Enviada")
                    comandoEditar.Parameters.AddWithValue("@enviada", DateTime.Now);
                comandoEditar.Parameters.AddWithValue("@Id", id);
                comandoEditar.ExecuteScalar();
                MySqlConnection.Close();
            }
            catch (Exception ex)
            {
                MySqlConnection.Close();
            }
        }

        public virtual string Insertar()
        {
            FieldInfo[] miembros;
            Type tipo = this.GetType();
            miembros = tipo.GetFields(BindingFlags.Instance
                | BindingFlags.Public | BindingFlags.NonPublic);

            if (_Tabla == "")
            {
                _Tabla = this.GetType().Name.ToLower();
            }
            string columnas = "";
            string valores = "";
            string[,] parametros = new string[100, 100];

            for (int i = 0; i != miembros.Length; i++)
            {
                if (miembros[i].GetValue(this) != null && miembros[i].Name.Substring(0, 1) != "_" && miembros[i].Name.Substring(0, 2) != "mE")
                {

                    string tipoDato = miembros[i].GetValue(this).GetType().ToString();

                    if (tipoDato == "System.String")
                    {
                        if (columnas != "")
                        {

                            columnas += ",";
                            valores += ",";
                        }
                        columnas += miembros[i].Name;
                        //  parametros[i,i]= {{"a","b"}};
                        //{{"@" + i.ToString();,"25"}};
                        valores += "'" + miembros[i].GetValue(this).ToString().Replace("'", "´").Replace('"', '¨') + "'";

                        /*
                             valores += "@" + miembros[i].Name;
                             parametro p = new parametro();
                             p.nombre = "@" + miembros[i].Name;
                             p.objeto = miembros[i].GetValue(this);
                             parametro.listaParametros.Add(p);
                         */

                    }

                    if (tipoDato == "System.DateTime")
                    {
                        if (columnas != "")
                        {
                            columnas += ",";
                            valores += ",";
                        }
                        columnas += miembros[i].Name;
                        valores += FormatoFecha((DateTime)miembros[i].GetValue(this));
                        /*    
                           valores += "@" + miembros[i].Name;
                           parametro p = new parametro();
                           p.nombre = "@" + miembros[i].Name;
                           p.objeto = miembros[i].GetValue(this);
                           parametro.listaParametros.Add(p);

                         * */
                    }

                    if (tipoDato == "System.Int32" || tipoDato == "System.Double")
                    {
                        if (columnas != "")
                        {
                            columnas += ",";
                            valores += ",";
                        }
                        columnas += miembros[i].Name;
                        valores += miembros[i].GetValue(this).ToString();

                        /*  
                           valores += "@" + miembros[i].Name;
                           parametro p = new parametro();
                           p.nombre = "@" + miembros[i].Name;
                           p.objeto = miembros[i].GetValue(this);
                           parametro.listaParametros.Add(p);
                         */
                    }
                }
            }

            string query = "INSERT INTO " + _Tabla + " (" + columnas + ") VALUES (" + valores + ")";
            string Mensaje = "";

            if (Mysql)
            {
                try
                {
                    if (this.GetType().Name == "cotizaciones")
                    {
                        query = query.Replace("0001-01-01 00:00:00", "0000-00-00 00:00:00.000000");
                    }
                    if (MySqlConnection.State == ConnectionState.Closed)
                        MySqlConnection.Open();
                    MySqlCommand cmd = new MySqlCommand(query, MySqlConnection);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Mensaje = ex.Message + "\n" + query;
                    return Mensaje;
                }
                finally
                {
                    MySqlConnection.Close();
                }
            }

            return Mensaje;
        }
        public void Leer(DataRow campos)
        {

            FieldInfo[] miembros;
            Type tipo = this.GetType();
            miembros = tipo.GetFields(BindingFlags.Instance
                | BindingFlags.Public | BindingFlags.NonPublic);

            string Nombre;
            string stipo;

            for (int i = 0; i != miembros.Length; i++)
            {
                Nombre = miembros[i].Name;
                if (miembros[i].GetValue(this) == null)
                {
                    //string aaaaa = campos[Nombre].ToString();
                    string aaaaa = this.GetType().Name;
                }
                if (miembros[i].GetValue(this) != null && miembros[i].Name.Substring(0, 1) != "_" && miembros[i].Name.Substring(0, 2) != "mE")
                {
                    stipo = miembros[i].GetValue(this).GetType().ToString();
                }
                else
                {
                    stipo = "";
                }

                if (stipo == "System.String" || stipo == "System.DateTime" || stipo == "System.Int32" || stipo == "System.Double")
                {
                    if (campos[Nombre].GetType().ToString() != "System.DBNull")
                    {
                        string aaaaa = campos[Nombre].ToString();
                        if (stipo == "System.String") miembros[i].SetValue(this, campos[Nombre].ToString());
                        if (stipo == "System.DateTime") miembros[i].SetValue(this, Convert.ToDateTime(campos[Nombre].ToString()));
                        if (stipo == "System.Int32") miembros[i].SetValue(this, int.Parse(campos[Nombre].ToString()));
                        if (stipo == "System.Double") miembros[i].SetValue(this, double.Parse(campos[Nombre].ToString()));
                    }
                }
            }
        }
        public static string consultas(string cadena)//espera la consulta y regresa el resultado
        {
            try
            {
                if (MySqlConnection.State == ConnectionState.Closed)
                    MySqlConnection.Open();
                MySqlCommand comando = new MySqlCommand(cadena, MySqlConnection);
                var resultado = comando.ExecuteScalar();
                if (resultado != null)
                    cadena = resultado.ToString();
                else
                    cadena = "0";
                MySqlConnection.Close();
            }
            catch (Exception ex)
            {
                cadena = "0";
            }
            finally
            {
                MySqlConnection.Close();
            }
            return cadena;
        }

        public int NumeroLibre(string campo, string tabla, int idUsuario)
        {
            int inicio = (idUsuario - 1) * 100000 + 1;
            int fin = inicio + 99999;

            mError = "";
            int n = 0;
            _Tabla = tabla;
            string query = "SELECT " + campo + " FROM " + _Tabla + " WHERE " + campo + " >= " + inicio + " AND " + campo + " <= " + fin + " ORDER BY " + campo + " DESC";

            if (Mysql)
            {
                query = "SELECT " + campo + " FROM " + _Tabla + " WHERE " + campo + " >= " + inicio + " AND " + campo + " <= " + fin + " ORDER BY " + campo + " DESC limit 1";
                try
                {
                    if (MySqlConnection.State == ConnectionState.Closed)
                        MySqlConnection.Open();
                }
                catch (Exception ex)
                {
                    mError = ex.Message;
                }

                MySqlCommand cmd = new MySqlCommand(query, MySqlConnection);
                try
                {
                    object o = cmd.ExecuteScalar();
                    if (o == null) return inicio;
                    n = (int)(o);
                }
                catch (Exception ex)
                {

                    mError = ex.Message;
                }
                finally
                {
                    MySqlConnection.Close();
                }
            }
            return n + 1;
        }

        public static DataTable Tabla(string query, ref string error)
        {
            DataTable dt = new DataTable();
            if (Mysql)
            {
                mysqlDataAdapter = new MySqlDataAdapter(query, MySqlConnection);
                try
                {
                    mysqlDataAdapter.Fill(dt);
                }
                catch (Exception ex)
                {
                    error = ex.Message;
                }
            }
            return dt;
        }

        public static string FormatoFecha(DateTime fecha)
        {
            string fechaMysql;
            fechaMysql = "'" + fecha.Year.ToString("0000") + "-" + fecha.Month.ToString("00") + "-" + fecha.Day.ToString("00") + " " + fecha.Hour.ToString("00") + ":" + fecha.Minute.ToString("00") + ":" + fecha.Second.ToString("00") + "'";
            
            return fechaMysql;
        }

        public void actualizar(string cadena)
        {
            string query = cadena;
            string Mensaje = "";
            MySqlConnection cn;
            cn = new MySqlConnection(cs);
            cn.Open();
            MySqlCommand cmd = new MySqlCommand(query, cn);

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Mensaje = ex.Message + "\n" + query;
            }
            finally
            {
                cn.Close();
            }
        }

        #endregion
    }
}
