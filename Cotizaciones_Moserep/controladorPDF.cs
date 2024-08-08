using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Cotizaciones_Moserep
{
    public class controladorPDF
    {
        private bool pdfcorrecto = false;
        #region Propiedades
        #endregion

        #region Contructor
        #endregion

        #region Metodos

        public void CreatePDF(string ruta, quotes nuevaPrecotizacion, string ivaCotizacion)//crea el pdf
        {
            BaseColor colorazul = new BaseColor(46, 58, 151);//255
            //try
            //{
            using (FileStream msReport = new FileStream(@ruta, FileMode.Create))
                {
                    //step 1
                    using (Document pdfDoc = new Document(PageSize.LETTER, 22f, 20f, 240f, 40f))
                    {
                        //try
                        //{
                            // step 2
                            PdfWriter pdfWriter = PdfWriter.GetInstance(pdfDoc, msReport);
                            ITextEvents ITE = new ITextEvents();
                            ITE.NoCotizacion = nuevaPrecotizacion.id.ToString();
                            ITE.FechaQuote = nuevaPrecotizacion.dateQuote;
                            ITE.NombreCte = clients.clienteSeleccionado.name;
                            ITE.NombreContacto = client_contact.contactoSeleccionado.name;
                            ITE.NombreProyecto = "";
                    ITE.notas = nuevaPrecotizacion.note;
                            ITE.empresa = "BRANSTOR";
                             ITE.cotizo = "";
                            pdfWriter.PageEvent = ITE;
                            //open the stream 
                            pdfDoc.Open();
                            #region tablas
                            Conv conv = new Conv();
                            PdfPTable NombreColumnas2 = new PdfPTable(6);
                            NombreColumnas2.TotalWidth = pdfDoc.PageSize.Width - 50f;
                            NombreColumnas2.LockedWidth = true;
                            NombreColumnas2.WidthPercentage = 70;
                            float[] widths2 = new float[] { 2f, 4f, 8f, 2f, 2f, 2f };
                            NombreColumnas2.SetWidths(widths2);
                           // int i3 = 0;
                    int contador = 1;
                    foreach (UserControlItems partida in controladorCotizacion.itemsCotizacion)
                    {
                        PdfPCell item = new PdfPCell(new Phrase(partida.txtItem.Text, ITextEvents.arial2));
                        item.HorizontalAlignment = 1;
                        item.VerticalAlignment = Element.ALIGN_MIDDLE;
                        item.BorderColorBottom = BaseColor.WHITE;
                        item.BorderColorTop = BaseColor.WHITE;
                        item.Border = 8 | 4;
                        if (contador == 20)
                        {
                            item.Border = 2 | 8 | 4;
                            item.BorderColorBottom = BaseColor.BLACK;
                        }
                        NombreColumnas2.AddCell(item);
                        PdfPCell Catalogo = new PdfPCell(new Phrase("  " + partida.txtAlias.Text, ITextEvents.arial2));

                        //  PdfPCell Catalogo = new PdfPCell(new Phrase(partida.ALIAS, ITextEvents.arial2));
                        Catalogo.FixedHeight = 22f;
                        Catalogo.HorizontalAlignment = 0;
                        Catalogo.VerticalAlignment = Element.ALIGN_MIDDLE;
                        Catalogo.BorderColorBottom = BaseColor.WHITE;
                        Catalogo.BorderColorTop = BaseColor.WHITE;
                        Catalogo.Border = 8 | 4;
                        if (contador == 20)
                        {
                            Catalogo.Border = 2 | 8 | 4;
                            Catalogo.BorderColorBottom = BaseColor.BLACK;
                        }
                        NombreColumnas2.AddCell(Catalogo);
                        /*  if (partida.imagen != "")
                          {
                              if (System.IO.File.Exists(Application.StartupPath + "\\Imagenes\\" + partida.imagen))
                              {
                                  iTextSharp.text.Image jpg = iTextSharp.text.Image.GetInstance(Application.StartupPath + "\\Imagenes\\" + partida.imagen);
                                  jpg.ScaleToFit(50f, 50f);
                                  // jpg.IsNestable();
                                  jpg.SetAbsolutePosition(0, 13);
                                  NombreColumnas2.AddCell(jpg);
                              }
                              else
                              {
                                  PdfPCell nada = new PdfPCell(new Phrase("", ITextEvents.arial2));
                                  nada.HorizontalAlignment = 0;
                                  nada.VerticalAlignment = Element.ALIGN_MIDDLE;
                                  NombreColumnas2.AddCell(nada);
                              }
                          }
                          else
                          {
                              PdfPCell nada = new PdfPCell(new Phrase("", ITextEvents.arial2));
                              nada.HorizontalAlignment = 0;
                              nada.VerticalAlignment = Element.ALIGN_MIDDLE;
                              //  Descrip.BackgroundColor = BaseColor.LIGHT_GRAY;
                              NombreColumnas2.AddCell(nada);
                          }*/

                        PdfPCell Descrip = new PdfPCell(new Phrase("  " + partida.txtDescripcion.Text, ITextEvents.arial2));
                        Descrip.HorizontalAlignment = 0;
                        Descrip.VerticalAlignment = Element.ALIGN_MIDDLE;
                        Descrip.BorderColorBottom = BaseColor.WHITE;
                        Descrip.BorderColorTop = BaseColor.WHITE;
                        Descrip.Border = 8 | 4;
                        if (contador == 20)
                        {
                            Descrip.Border = 2 | 8 | 4;
                            Descrip.BorderColorBottom = BaseColor.BLACK;
                        }
                        NombreColumnas2.AddCell(Descrip);

                        PdfPCell Cantidad = new PdfPCell(new Phrase(partida.txtCant.Text, ITextEvents.arial2));
                        Cantidad.HorizontalAlignment = 1;
                        Cantidad.VerticalAlignment = Element.ALIGN_MIDDLE;
                        Cantidad.BorderColorBottom = BaseColor.WHITE;
                        Cantidad.BorderColorTop = BaseColor.WHITE;
                        Cantidad.Border = 8 | 4; 
                        if (contador == 20)
                        {
                            Cantidad.Border = 2 | 8 | 4;
                            Cantidad.BorderColorBottom = BaseColor.BLACK;
                        }
                        NombreColumnas2.AddCell(Cantidad);

                        PdfPCell Unitario = new PdfPCell(new Phrase(Convert.ToDouble(partida.txtPrecioU.Text).ToString("#,##0.00"), ITextEvents.arial2));
                        Unitario.HorizontalAlignment = 1;
                        Unitario.VerticalAlignment = Element.ALIGN_MIDDLE;
                        Unitario.BorderColorBottom = BaseColor.WHITE;
                        Unitario.BorderColorTop = BaseColor.WHITE;
                        Unitario.Border = 8 | 4;
                        if (contador == 20)
                        {
                            Unitario.Border = 2 | 8 | 4;
                            Unitario.BorderColorBottom = BaseColor.BLACK;
                        }
                        NombreColumnas2.AddCell(Unitario);

                        PdfPCell total = new PdfPCell(new Phrase(Convert.ToDouble(partida.txtTotalItem.Text).ToString("#,##0.00"), ITextEvents.arial2));//chavez
                        total.HorizontalAlignment = 1;
                        total.VerticalAlignment = Element.ALIGN_MIDDLE;
                        total.BorderColorBottom = BaseColor.WHITE;
                        total.BorderColorTop = BaseColor.WHITE;
                        total.Border = 8 | 4;
                        if (contador == 20)
                        {
                            total.Border = 2 | 8 | 4;
                            total.BorderColorBottom = BaseColor.BLACK;
                        }
                        NombreColumnas2.AddCell(total);
                        contador++;
                        if (partida.imagen != "")
                        {
                            for (int temp = 0; temp < 5; temp++)
                            {
                                PdfPCell item2 = new PdfPCell(new Phrase("", ITextEvents.arial2));
                                item2.BorderColorBottom = BaseColor.WHITE;
                                item2.BorderColorTop = BaseColor.WHITE;
                                item2.Border = 8 | 4;
                                if (contador == 20)
                                {
                                    item2.Border =2 | 8 | 4;
                                    item2.BorderColorBottom = BaseColor.BLACK;
                                }
                                NombreColumnas2.AddCell(item2);


                                PdfPCell Catalogo2 = new PdfPCell(new Phrase("", ITextEvents.arial2));
                                Catalogo2.FixedHeight = 22f;
                                Catalogo2.BorderColorBottom = BaseColor.WHITE;
                                Catalogo2.BorderColorTop = BaseColor.WHITE;
                                Catalogo2.Border = 8 | 4;
                                if (contador == 20)
                                {
                                    Catalogo2.Border = 2 | 8 | 4;
                                    Catalogo2.BorderColorBottom = BaseColor.BLACK;
                                }
                                NombreColumnas2.AddCell(Catalogo2);

                                PdfPCell Descrip2 = new PdfPCell(new Phrase("", ITextEvents.arial2));
                                Descrip2.BorderColorBottom = BaseColor.WHITE;
                                Descrip2.BorderColorTop = BaseColor.WHITE;
                                Descrip2.Border = 8 | 4;
                                if (contador == 20)
                                {
                                    Descrip2.Border = 2 | 8 | 4;
                                    Descrip2.BorderColorBottom = BaseColor.BLACK;
                                }
                                NombreColumnas2.AddCell(Descrip2);

                                PdfPCell Cantidad2 = new PdfPCell(new Phrase("", ITextEvents.arial2));
                                Cantidad2.BorderColorBottom = BaseColor.WHITE;
                                Cantidad2.BorderColorTop = BaseColor.WHITE;
                                Cantidad2.Border = 8 | 4;
                                if (contador == 20)
                                {
                                    Cantidad2.Border = 2 | 8 | 4;
                                    Cantidad2.BorderColorBottom = BaseColor.BLACK;
                                }
                                NombreColumnas2.AddCell(Cantidad2);

                                PdfPCell Unitario2 = new PdfPCell(new Phrase("", ITextEvents.arial2));
                                Unitario2.VerticalAlignment = Element.ALIGN_MIDDLE;
                                Unitario2.BorderColorBottom = BaseColor.WHITE;
                                Unitario2.BorderColorTop = BaseColor.WHITE;
                                Unitario2.Border = 8 | 4;
                                if (contador == 20)
                                {
                                    Unitario2.Border = 2 | 8 | 4;
                                    Unitario2.BorderColorBottom = BaseColor.BLACK;
                                }
                                NombreColumnas2.AddCell(Unitario2);

                                PdfPCell total2 = new PdfPCell(new Phrase("", ITextEvents.arial2));//chavez
                                total2.BorderColorBottom = BaseColor.WHITE;
                                total2.BorderColorTop = BaseColor.WHITE;
                                total2.Border = 8 | 4;
                                if (contador == 20)
                                {
                                    total2.Border = 2 | 8 | 4;
                                    total2.BorderColorBottom = BaseColor.BLACK;
                                }
                                NombreColumnas2.AddCell(total2);
                                contador++;
                            }
                        }

                    }
                            /////////////////////////////////////////////////////////////////

                            if(contador < 14)//////////////poner abajo
                    {
                        for( int temp= contador; temp < 14; temp++)
                        {
                            PdfPCell item = new PdfPCell(new Phrase("", ITextEvents.arial2));
                            item.BorderColorBottom = BaseColor.WHITE;
                            item.BorderColorTop = BaseColor.WHITE;
                            item.Border = 8 | 4;
                            NombreColumnas2.AddCell(item);


                            PdfPCell Catalogo = new PdfPCell(new Phrase("", ITextEvents.arial2));
                            Catalogo.FixedHeight = 22f;
                            Catalogo.BorderColorBottom = BaseColor.WHITE;
                            Catalogo.BorderColorTop = BaseColor.WHITE;
                            Catalogo.Border = 8 | 4;
                            NombreColumnas2.AddCell(Catalogo);

                            PdfPCell Descrip = new PdfPCell(new Phrase("", ITextEvents.arial2));
                            Descrip.BorderColorBottom = BaseColor.WHITE;
                            Descrip.BorderColorTop = BaseColor.WHITE;
                            Descrip.Border = 8 | 4;
                            NombreColumnas2.AddCell(Descrip);

                            PdfPCell Cantidad = new PdfPCell(new Phrase("", ITextEvents.arial2));
                            Cantidad.BorderColorBottom = BaseColor.WHITE;
                            Cantidad.BorderColorTop = BaseColor.WHITE;
                            Cantidad.Border = 8 | 4;
                            NombreColumnas2.AddCell(Cantidad);

                            PdfPCell Unitario = new PdfPCell(new Phrase("", ITextEvents.arial2));
                            Unitario.VerticalAlignment = Element.ALIGN_MIDDLE;
                            Unitario.BorderColorBottom = BaseColor.WHITE;
                            Unitario.BorderColorTop = BaseColor.WHITE;
                            Unitario.Border = 8 | 4;
                            NombreColumnas2.AddCell(Unitario);

                            PdfPCell total = new PdfPCell(new Phrase("", ITextEvents.arial2));//chavez
                            total.BorderColorBottom = BaseColor.WHITE;
                            total.BorderColorTop = BaseColor.WHITE;
                            total.Border = 8 | 4;
                            NombreColumnas2.AddCell(total);

                            
                        }
                    }
                            //PdfPCell espacio1 = new PdfPCell();
                            //espacio1.FixedHeight = 10F;
                            //espacio1.Colspan = 6;
                            //espacio1.Border = 0;
                           // NombreColumnas2.AddCell(espacio1);
                            //NombreColumnas2.AddCell(espacio1);
                            string nombreMoneda;
                            if (nuevaPrecotizacion.currency == "USD")
                            {
                                nombreMoneda = "DOLARES";
                            }
                            else
                            {
                                nombreMoneda = "PESOS";
                            }
                            string d1 = nuevaPrecotizacion.subtotal.ToString();
                            if (ivaCotizacion=="")
                                d1 = nuevaPrecotizacion.total.ToString();
                    //else if (ckiva16.Checked == true)
                    //    d1 = nuevaPrecotizacion.subtotal.ToString();



                    PdfPTable tableNota = new PdfPTable(1);
                    tableNota.HorizontalAlignment = Element.ALIGN_LEFT;
                    tableNota.TotalWidth = pdfDoc.PageSize.Width - 75f;
                    tableNota.LockedWidth = false;


                    PdfPTable tablaNotainterna = new PdfPTable(1);
                    tablaNotainterna.HorizontalAlignment = Element.ALIGN_LEFT;
                    tablaNotainterna.TotalWidth = pdfDoc.PageSize.Width - 75f;
                    tablaNotainterna.LockedWidth = true;
                    //float[] widths33 = new float[] { 1.6f, 18.4f, };
                    //tablaNotainterna.SetWidths(widths33);

                    PdfPCell notaLabel = new PdfPCell(new Phrase("Notas:", ITextEvents.arialNegrita));
                    notaLabel.HorizontalAlignment = Element.ALIGN_LEFT;
                    notaLabel.Border = 0;
                    notaLabel.FixedHeight = 18F;

                    PdfPCell notaCampo = new PdfPCell(new Phrase(nuevaPrecotizacion.note, ITextEvents.arial));
                    notaCampo.HorizontalAlignment = Element.ALIGN_LEFT;
                    notaCampo.Border = 0;

                    tablaNotainterna.AddCell(notaLabel);
                    tablaNotainterna.AddCell(notaCampo);


                    PdfPCell celTemporal = new PdfPCell(tablaNotainterna);
                    celTemporal.Border = 0;
                    tableNota.AddCell(celTemporal);

                    PdfPCell ImporteLetra = new PdfPCell(tableNota);



                    //PdfPCell ImporteLetra = new PdfPCell(new Phrase("Notas:  \n" + nuevaPrecotizacion.note, ITextEvents.arial2));
                            ImporteLetra.FixedHeight = 20F;
                            ImporteLetra.Colspan = 4;
                            ImporteLetra.UseVariableBorders = true;
                            ImporteLetra.BorderColorBottom = BaseColor.WHITE;
                    ImporteLetra.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
                    ImporteLetra.VerticalAlignment = Element.ALIGN_TOP;
                    ImporteLetra.Padding= 9;
                    ImporteLetra.SetLeading(1.7f, 1.5f);
                    NombreColumnas2.AddCell(ImporteLetra);

                            PdfPCell vacio1 = new PdfPCell(new Phrase("", ITextEvents.arial2));
                            vacio1.UseVariableBorders = true;
                            vacio1.BorderColorBottom = BaseColor.WHITE;
                            vacio1.HorizontalAlignment = 2;
                            vacio1.VerticalAlignment = Element.ALIGN_MIDDLE;
                            //NombreColumnas2.AddCell(vacio1);
                            string  dato3 = "\nP.UNITARIO\n\nIVA " + ivaCotizacion + " %\n\nTOTAL\n\nMONEDA\n\n";
                            PdfPCell subtotal = new PdfPCell(new Phrase(dato3, ITextEvents.arialBlanco));
                            subtotal.BackgroundColor = colorazul;
                            subtotal.UseVariableBorders = true;
                            subtotal.BorderColorBottom = BaseColor.LIGHT_GRAY;
                            subtotal.HorizontalAlignment = 0;
                            subtotal.VerticalAlignment = Element.ALIGN_MIDDLE;
                    subtotal.PaddingTop = 5;
                    subtotal.PaddingLeft = 5;
                    subtotal.PaddingBottom = 5;
                            NombreColumnas2.AddCell(subtotal);





                            string dato1 = "\n" + signomoneda(nuevaPrecotizacion.subtotal.ToString("#,##0.00"), nuevaPrecotizacion.total.ToString("#,##0.00")) + "\n\n" + signomoneda(nuevaPrecotizacion.iva.ToString("#,##0.00"), nuevaPrecotizacion.total.ToString("#,##0.00")) + "\n\n" + signomoneda(nuevaPrecotizacion.total.ToString("#,##0.00"), nuevaPrecotizacion.total.ToString("#,##0.00")) + "\n\n"+ nuevaPrecotizacion.currency+ "\n\n";
                            PdfPCell importeNumero = new PdfPCell(new Phrase(dato1, ITextEvents.arial2));
                            importeNumero.UseVariableBorders = true;
                            importeNumero.BorderColorBottom = BaseColor.WHITE;
                            importeNumero.HorizontalAlignment = 2;
                    importeNumero.PaddingRight = 15;
                    if (nuevaPrecotizacion.total > 999999.99)
                        importeNumero.PaddingRight = 2;

                    else if (nuevaPrecotizacion.total > 99999.99)
                        importeNumero.PaddingRight = 6;
                    else if(nuevaPrecotizacion.total>9999.99)
                        importeNumero.PaddingRight = 10;
                     
                    importeNumero.PaddingTop = 5;
                    importeNumero.PaddingBottom = 5;
                    importeNumero.VerticalAlignment = Element.ALIGN_MIDDLE;

                    importeNumero.PaddingBottom = 2;
                    NombreColumnas2.AddCell(importeNumero);
                           /* string dato4 = "";
                            if (ivaCotizacion != "")
                                dato4 = "";
                            PdfPCell NoIncluyeIva = new PdfPCell(new Phrase(dato4, ITextEvents.arial2));
                            NoIncluyeIva.FixedHeight = 10f;
                            NoIncluyeIva.Colspan = 5;
                            NoIncluyeIva.VerticalAlignment = Element.ALIGN_BOTTOM;
                            NoIncluyeIva.UseVariableBorders = true;
                            NoIncluyeIva.BorderColorTop = BaseColor.WHITE;
                            NombreColumnas2.AddCell(NoIncluyeIva);

                            //NombreColumnas2.AddCell(vacio1);
                            PdfPCell vacio2 = new PdfPCell(new Phrase("", ITextEvents.arial2));
                            //Moneda.FixedHeight = 15f;
                            vacio2.BackgroundColor = BaseColor.WHITE;
                            vacio2.HorizontalAlignment = 0;
                            vacio2.VerticalAlignment = Element.ALIGN_BOTTOM;
                            vacio2.UseVariableBorders = true;
                            vacio2.BorderColorTop = BaseColor.WHITE;
                            //NombreColumnas2.AddCell(vacio2);

                            PdfPCell Moneda = new PdfPCell(new Phrase("MONEDA", ITextEvents.arial2));
                            //Moneda.FixedHeight = 15f;
                            Moneda.BackgroundColor = colorazul;
                            Moneda.HorizontalAlignment = 0;
                            Moneda.VerticalAlignment = Element.ALIGN_BOTTOM;
                            Moneda.UseVariableBorders = true;
                            Moneda.BorderColorTop = BaseColor.LIGHT_GRAY;
                            NombreColumnas2.AddCell(Moneda);

                            PdfPCell USDoMX = new PdfPCell(new Phrase(nuevaPrecotizacion.currency, ITextEvents.arial2));
                            USDoMX.HorizontalAlignment = 2;
                            USDoMX.VerticalAlignment = Element.ALIGN_BOTTOM;
                            USDoMX.UseVariableBorders = true;
                            USDoMX.BorderColorTop = BaseColor.WHITE;
                            NombreColumnas2.AddCell(USDoMX);
                    */
                            PdfPCell espacio2 = new PdfPCell();
                            espacio2.FixedHeight = 10F;
                            espacio2.Colspan = 6;
                            espacio2.Border = 0;
                    // NombreColumnas2.AddCell(espacio2);
                    //NombreColumnas2.AddCell(espacio2);

                    PdfPTable table = new PdfPTable(1);
                    table.HorizontalAlignment = Element.ALIGN_LEFT;
                    table.TotalWidth = pdfDoc.PageSize.Width - 75f;
                    table.LockedWidth = false;
                    

                    PdfPTable tablaVigencia = new PdfPTable(2);
                    tablaVigencia.HorizontalAlignment = Element.ALIGN_LEFT;
                    tablaVigencia.TotalWidth = pdfDoc.PageSize.Width - 75f;
                    tablaVigencia.LockedWidth = true;
                    float[] widths3 = new float[] { 2f, 18f };
                    tablaVigencia.SetWidths(widths3);

                    PdfPCell vigencia1 = new PdfPCell(new Phrase("Vigencia:", ITextEvents.arialNegrita));
                    vigencia1.HorizontalAlignment = Element.ALIGN_LEFT;
                    vigencia1.Border = 0;

                    PdfPCell vigencia2 = new PdfPCell(new Phrase("Este documento tiene vigencia de 30 días naturales a partir de su emisión.", ITextEvents.arial));
                    vigencia2.HorizontalAlignment = Element.ALIGN_LEFT;
                    vigencia2.Border = 0;

                    tablaVigencia.AddCell(vigencia1);
                    tablaVigencia.AddCell(vigencia2);

                    PdfPTable tablaCondiciones = new PdfPTable(2);
                    tablaCondiciones.HorizontalAlignment = Element.ALIGN_LEFT;
                    tablaCondiciones.TotalWidth = pdfDoc.PageSize.Width - 75f;
                    tablaCondiciones.LockedWidth = true;
                    float[] widths4 = new float[] { 4.9f, 15.1f };
                    tablaCondiciones.SetWidths(widths4);

                    PdfPCell condiciones1 = new PdfPCell(new Phrase("Condiciones comerciales:", ITextEvents.arialNegrita));
                    condiciones1.HorizontalAlignment = Element.ALIGN_LEFT;
                    condiciones1.Border = 0;

                    PdfPCell condiciones2 = new PdfPCell(new Phrase(nuevaPrecotizacion.conditions, ITextEvents.arial));
                    condiciones2.HorizontalAlignment = Element.ALIGN_LEFT;
                    condiciones2.Border = 0;

                    tablaCondiciones.AddCell(condiciones1);
                    tablaCondiciones.AddCell(condiciones2);

                    PdfPTable tablaLugar = new PdfPTable(2);
                    tablaLugar.HorizontalAlignment = Element.ALIGN_LEFT;
                    tablaLugar.TotalWidth = pdfDoc.PageSize.Width - 75f;
                    tablaLugar.LockedWidth = true;
                    float[] widths5 = new float[] { 3.5f, 16.5f, };
                    tablaLugar.SetWidths(widths5);

                    PdfPCell lugar1 = new PdfPCell(new Phrase("Lugar de entrega:", ITextEvents.arialNegrita));
                    lugar1.HorizontalAlignment = Element.ALIGN_LEFT;
                    lugar1.Border = 0;

                    PdfPCell lugar2 = new PdfPCell(new Phrase(nuevaPrecotizacion.delivery, ITextEvents.arial));
                    lugar2.HorizontalAlignment = Element.ALIGN_LEFT;
                    lugar2.Border = 0;

                    tablaLugar.AddCell(lugar1);
                    tablaLugar.AddCell(lugar2);

                    PdfPTable tablaCotizador= new PdfPTable(2);
                    tablaCotizador.HorizontalAlignment = Element.ALIGN_LEFT;
                    tablaCotizador.TotalWidth = pdfDoc.PageSize.Width - 75f;
                    tablaCotizador.LockedWidth = true;
                    float[] widths6 = new float[] { 1.6f, 18.4f, };
                    tablaCotizador.SetWidths(widths6);

                    PdfPCell cotizo1 = new PdfPCell(new Phrase("Cotizo:", ITextEvents.arialNegrita));
                    cotizo1.HorizontalAlignment = Element.ALIGN_LEFT;
                    cotizo1.Border = 0;

                    PdfPCell cotizo2 = new PdfPCell(new Phrase(users.usuarioActual.name, ITextEvents.arial));
                    cotizo2.HorizontalAlignment = Element.ALIGN_LEFT;
                    cotizo2.Border = 0;

                    tablaCotizador.AddCell(cotizo1);
                    tablaCotizador.AddCell(cotizo2);

                    /*
                    PdfPCell condiciones1 = new PdfPCell(new Phrase("Condiciones comerciales:", ITextEvents.arialNegrita));
                    condiciones1.HorizontalAlignment = Element.ALIGN_LEFT;
                    //condiciones1.Width = 120F;

                    PdfPCell condiciones2 = new PdfPCell(new Phrase(nuevaPrecotizacion.conditions, ITextEvents.arial2));
                    condiciones2.HorizontalAlignment = Element.ALIGN_LEFT;
                    //condiciones1.Width =220F;

                    PdfPCell lugar1 = new PdfPCell(new Phrase("Lugar de entrega:", ITextEvents.arialNegrita));
                    lugar1.HorizontalAlignment = Element.ALIGN_LEFT;

                    PdfPCell lugar2 = new PdfPCell(new Phrase(nuevaPrecotizacion.delivery, ITextEvents.arial2));
                    lugar2.HorizontalAlignment = Element.ALIGN_LEFT;

                    PdfPCell cotizo1 = new PdfPCell(new Phrase("Cotizo:", ITextEvents.arialNegrita));
                    cotizo1.HorizontalAlignment = Element.ALIGN_LEFT;

                    PdfPCell cotizo2 = new PdfPCell(new Phrase(users.usuarioActual.name, ITextEvents.arial2));
                    cotizo2.HorizontalAlignment = Element.ALIGN_LEFT;
                    */
                    //TITULO,NUMERO Y FECHA

                    PdfPCell cel1 = new PdfPCell(tablaVigencia);
                    cel1.Border = 0;
                    cel1.FixedHeight = 16F;
                    PdfPCell cel2 = new PdfPCell(tablaCondiciones);
                    cel2.Border = 0;
                    cel2.FixedHeight = 16F;
                    PdfPCell cel3 = new PdfPCell(tablaLugar);
                    cel3.FixedHeight = 16F;
                    cel3.Border = 0;
                    PdfPCell cel4 = new PdfPCell(tablaCotizador);
                    cel4.FixedHeight = 10F;
                    cel4.Border = 0;

                    table.AddCell(cel1);
                    table.AddCell(cel2);
                    table.AddCell(cel3);
                    table.AddCell(cel4);

                    PdfPCell TiempoEntrega = new PdfPCell(table);





                    //PdfPCell TiempoEntrega = new PdfPCell(new Phrase("Vigencia:  " + "Este documento tiene vigencia de 30 días naturales a partir de su emisión.\nCondiciones comerciales:  " +nuevaPrecotizacion.conditions+ "\nLugar de entrega:  "+nuevaPrecotizacion.delivery+ "\nCotizo:  " +users.usuarioActual.name, ITextEvents.arial2));
                            TiempoEntrega.FixedHeight = 80F;
                            TiempoEntrega.Colspan = 6;
                            TiempoEntrega.UseVariableBorders = true;
                            TiempoEntrega.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
                            //TiempoEntrega.VerticalAlignment = Element.ALIGN_MIDDLE;
                        TiempoEntrega.SetLeading(1.7f,1.5f);

                    TiempoEntrega.Padding = 9;
                    // TiempoEntrega.Rowspan =2;
                    // TiempoEntrega.HasFixedHeight();
                    //TiempoEntrega.Colspan = 1;
                    NombreColumnas2.AddCell(TiempoEntrega);

                            
                            NombreColumnas2.DefaultCell.PaddingBottom = 60;
                            NombreColumnas2.DefaultCell.PaddingTop = 60;
                            pdfDoc.Add(NombreColumnas2);
                            #endregion tablas
                            pdfDoc.Close();
                            pdfcorrecto = true;
                       /* }
                        catch (Exception ex)
                        {
                        }
                        finally
                        {
                        }*/
                    }
                }
           /* }
            catch (Exception e)
            {
                pdfcorrecto = false;
                MessageBox.Show("Cierre el pdf");
            }*/
        }
        #endregion

        private string signomoneda(string valor, string valorTotal)
        {
            string valorTemp = valor;
            if (valor.Length == 4)
                valor = "$        " + valor;
            else if (valor.Length == 5)
                valor = "$      " + valor;
            else if (valor.Length == 6)
                valor = "$    " + valor;
            else if (valor.Length == 7)
                valor = "$   " + valor;
            else if (valor.Length == 8)
                valor = "$ " + valor;
            else if (valor.Length == 9)
                valor = "$" + valor;
            else if (valor.Length == 10)
                valor = "$ " + valor;
            else if (valor.Length == 11)
                valor = "$" + valor;
            else if (valor.Length == 12)
                valor = "$" + valor;
            else
                valor = "$" + valor;
            double total2 = Convert.ToDouble(valorTotal);
            if (total2 > 999999.99)
            {
                if (valorTemp.Length != valorTotal.Length)
                {
                    if (valorTemp.Length == 10)
                        valor = "$   " + valorTemp;
                    else if (valorTemp.Length == 11)
                        valor = "$ " + valorTemp;
                    else if (valorTemp.Length == 12)
                        valor = "$" + valorTemp;
                }
            }
            else if (total2 > 99999.99)
            {
                if (valorTemp.Length != valorTotal.Length)
                {
                    if (valorTemp.Length == 9)
                        valor = "$   " + valorTemp;
                    else if (valorTemp.Length == 10)
                        valor = "$   " + valorTemp;
                    else if (valorTemp.Length == 11)
                        valor = "$ " + valorTemp;
                    else if (valorTemp.Length == 12)
                        valor = "$" + valorTemp;
                }
            }

            else if (total2 > 9999.99)
            {
                if (valorTemp.Length != valorTotal.Length)
                {
                    if (valorTemp.Length == 8)
                        valor = "$  " + valorTemp;
                    else if (valorTemp.Length == 9)
                        valor = "$ " + valorTemp;
                    else if (valorTemp.Length == 10)
                        valor = "$" + valorTemp;
                    else if (valorTemp.Length == 11)
                        valor = "$" + valorTemp;
                    else if (valorTemp.Length == 12)
                        valor = "$" + valorTemp;
                }
            }
            return valor;
        }
    }
}
