using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cotizaciones_Moserep
{
    public class controladorCotizacion
    {
        #region Propiedades
        public static string moneda="";
        public static double tc = 0;
        public static List<UserControlItems> itemsCotizacion = new List<UserControlItems>();
        public Point Esquina = new Point(1, 0);
        public int SeparacionVertical = 32;
        #endregion

        #region Contructor
        #endregion

        #region Metodos

        public static quotes buscarCotizacion(int id)
        {
            string error = "";
            quotes cotizacion= new quotes();
            DataTable tablaUsuario = baseDatos.Tabla("select * from quotes where ID="+id.ToString(), ref error);
            foreach (DataRow row in tablaUsuario.Rows)
            {
                cotizacion.id = Convert.ToInt32(row["ID"]);
                cotizacion.dateQuote = Convert.ToDateTime(row["DATE_QUOTE"]);
                cotizacion.currency = row["CURRENNCY"].ToString();
                cotizacion.tc = Convert.ToDouble(row["TC"]);
                cotizacion.id_seller = Convert.ToInt32(row["ID_SELLER"]);
                cotizacion.id_quoter = Convert.ToInt32(row["ID_QUOTER"]);
                cotizacion.id_client = Convert.ToInt32(row["ID_CLIENT"]);
                cotizacion.id_contact = Convert.ToInt32(row["ID_CONTACT"]);
                cotizacion.id_iva = Convert.ToInt32(row["ID_IVA"]);
                cotizacion.subtotal = Convert.ToDouble(row["SUBTOTAL"]);
                cotizacion.iva = Convert.ToDouble(row["IVA"]);
                cotizacion.total = Convert.ToDouble(row["TOTAL"]);
                cotizacion.remision = Convert.ToBoolean(row["REMISION"]);
                cotizacion.active = Convert.ToBoolean(row["ACTIVE"]);
                cotizacion.note = Convert.ToString(row["NOTE"]);
                cotizacion.conditions = Convert.ToString(row["CONDITIONS"]);
                cotizacion.delivery = Convert.ToString(row["DELIVERY"]);
            }
            return cotizacion;
        }

        public static DataTable verRemisiones()
        {

            string error = "";
            return  baseDatos.Tabla("select quotes.ID as FOLIO, DATE_QUOTE AS FECHA, clients.NAME AS CLIENTE, client_contact.NAME  AS CONTACTO, SUBTOTAL, IVA TOTAL, quotes.CURRENNCY AS MONEDA, NOTE AS NOTAS FROM quotes left join clients on quotes.ID_CLIENT=clients.ID left join client_contact on quotes.ID_CONTACT=client_contact.ID where quotes.REMISION=1", ref error);
        }
        public string insertarCotizacion(int id, string moneda, DateTime fecha, double subtotal, double ivaCotizaion, double total, bool remision, bool activo, string notas, string condiciones, string entrega, int cantidadItems, bool necesitaPdf)
        {
            string error = "";
            quotes cotizacion = new quotes();
            cotizacion.id = id;
            cotizacion.id_client = clients.clienteSeleccionado.id;
            cotizacion.id_contact = client_contact.contactoSeleccionado.id;
            cotizacion.id_iva = 0;
            if (iva.ivaSeleccionado != null)
                cotizacion.id_iva = iva.ivaSeleccionado.id;
            cotizacion.id_seller = users.vendedorSeleccionado.id;
            cotizacion.id_quoter = users.usuarioActual.id;
            cotizacion.tc = controladorCotizacion.tc;
            cotizacion.currency = moneda;
            cotizacion.dateQuote = fecha;
            cotizacion.subtotal = subtotal;
            cotizacion.iva = ivaCotizaion;
            cotizacion.total = total;
            cotizacion.remision = remision;
            cotizacion.active = activo;
            cotizacion.note = notas;
            cotizacion.conditions = condiciones;
            cotizacion.delivery = entrega;
            if (necesitaPdf == true)
            {
                SaveFileDialog save = new SaveFileDialog();
                save.DefaultExt = "pdf";
                save.Filter = "PDF files|*.pdf";

                if (save.ShowDialog() == DialogResult.OK)
                {
                    /*if (!(Directory.Exists("C:/Descoa/")))
                    {
                        Directory.CreateDirectory("C:/Descoa/");
                    }*/
                    // string rutalocal = "C:/Descoa/" + txtNoPrecotizacion.Text + ".pdf";
                    string ruta = save.FileName;
                    //CreatePDF(rutalocal);
                    controladorPDF pdf = new controladorPDF();
                    string ivaCot = "";
                    if (iva.ivaSeleccionado != null)
                        ivaCot = iva.ivaSeleccionado.monto.ToString();
                    pdf.CreatePDF(ruta, cotizacion, ivaCot);
                    //File.Copy(ruta, rutaServidor);
                    System.Diagnostics.Process.Start(ruta);
                }
                string status = "¿Desea guardar los datos capturados?";
                string leyenda = "GUARDAR";
                DialogResult result = MessageBox.Show(status, leyenda, MessageBoxButtons.YesNo);
                if (result == DialogResult.No)
                {
                    error = "NOGUARDAR";
                }
            }
            if(error=="")
                baseDatos.insertarCotizacion(cotizacion, ref error);
            return error;
        }
        public void numerarItems()//enumera items
        {
            for (int i = 0; i != itemsCotizacion.Count; i++)
            {
                itemsCotizacion[i].Top = Esquina.Y + (SeparacionVertical * i);
                itemsCotizacion[i].txtItem.Text = (i+1).ToString();
            }
        }

        public string guardar(string tipo, string filtro, string nombre, string imagen)
        {
            string fileName = "";
            string sourcePath = "";
            string targetPath = "";
            string destFile = "";
            OpenFileDialog abrir = new OpenFileDialog();
            abrir.FileName = "Elegir  " + tipo;
            abrir.Filter = filtro;
            abrir.FilterIndex = 1;
            if (abrir.ShowDialog() == DialogResult.OK)
            {
                sourcePath = abrir.FileName;
                fileName = abrir.SafeFileName;

                targetPath = Application.StartupPath + "\\" + tipo + "\\";
                if (!(Directory.Exists(targetPath)))
                {
                    Directory.CreateDirectory(targetPath);
                }
                destFile = System.IO.Path.Combine(targetPath, nombre + ".jpg");
                VaryQualityLevel(sourcePath, destFile);
                return nombre + ".jpg";
            }
            else
            {
                return imagen;
            }

        }

        private void VaryQualityLevel(string origen, string destino)
        {
            Bitmap bmp1 = new Bitmap(origen);
            ImageCodecInfo jpgEncoder = GetEncoder(ImageFormat.Jpeg);
            System.Drawing.Imaging.Encoder myEncoder = System.Drawing.Imaging.Encoder.Quality;
            EncoderParameters myEncoderParameters = new EncoderParameters(1);
            EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, 20L);
            myEncoderParameters.Param[0] = myEncoderParameter;
            bmp1.Save(destino, jpgEncoder, myEncoderParameters);
        }

        private ImageCodecInfo GetEncoder(ImageFormat format)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();
            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                    return codec;
            }
            return null;
        }

        public string borrarItems(string campoBorrar, ref List<UserControlItems> renglonesParaBorrar)
        {
            List<int> numerosDeRollo = new List<int>();
            string error = partidasNumeradas(numerosDeRollo, campoBorrar);
            if (error == "")
            {
                partidasNumeradas(numerosDeRollo, campoBorrar);
                //List<UserControlItems> renglonesParaBorrar = new List<UserControlItems>();
                foreach (UserControlItems r in itemsCotizacion)
                {
                    int Nitem = Convert.ToInt32(r.txtItem.Text);
                    if (numerosDeRollo.Contains(Nitem))
                    {
                        renglonesParaBorrar.Add(r);
                    }
                }
                string status = "¿Desea borrar los items " + campoBorrar + " ? ";
                string leyenda = "Borrar";
                DialogResult result = MessageBox.Show(status, leyenda, MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    foreach (UserControlItems n in renglonesParaBorrar)
                    {
                        borrarItemSeleccionado(n);
                    }
                    numerarItems();
                }
            }
            return error;
        }

        public void borrarItemSeleccionado(UserControlItems selecto)//borra partida
        {
            if (selecto != null)
            {
                itemsCotizacion.Remove(selecto);
                selecto = null;
            }
        }

        private string partidasNumeradas(List<int> numerosDeRollo, string texto)
        {
            string error = "";
            string[] gruposRollos = texto.Split(',');
            if (gruposRollos.Length == 0)
            {
                error = "Numero de partidas no valido";
            }
            for (int i = 0; i != gruposRollos.Length; i++)
            {
                string[] seriesRollos = gruposRollos[i].Split('-');
                int rolloInicial = 0;
                int rolloFinal = 0;
                if (seriesRollos.Length > 2)
                {
                    error = "Hay un error en la nomenclatura de los numeros de partidas";
                }
                try
                {
                    rolloInicial = int.Parse(seriesRollos[0]);
                }
                catch
                {
                    error = "Se encontraron caracteres no validos en los numeros de partidas";
                }

                if (numerosDeRollo.Contains(rolloInicial))
                {
                    error = "Se detectaron numeros de partidas repetidos";
                }

                if (seriesRollos.Length == 1)
                {
                    numerosDeRollo.Add(rolloInicial);
                }

                if (seriesRollos.Length == 2)
                {
                    try
                    {
                        rolloFinal = int.Parse(seriesRollos[1]);
                    }
                    catch
                    {
                        error = "Se encontraron caracteres no validos en los numeros de rollo";
                    }
                    if (rolloInicial >= rolloFinal)
                    {
                        error = "El rollo final de una serie debe ser mayor que el rollo inicial";
                    }

                    for (int j = rolloInicial; j <= rolloFinal; j++)
                    {
                        if (numerosDeRollo.Contains(j))
                        {
                            error = "Se detectaron numeros de rollo repetidos en una serie";
                        }
                        numerosDeRollo.Add(j);
                    }
                }
            }
            return error;
        }
        #endregion
    }
}
