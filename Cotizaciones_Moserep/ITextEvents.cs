using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.IO;
using System.Diagnostics;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using iTextSharp.text.pdf.qrcode;

namespace Cotizaciones_Moserep
{
    public class ITextEvents : PdfPageEventHelper
    {
        #region Properties
        // This is the contentbyte object of the writer
        PdfContentByte cb;
        // we will put the final number of pages in a template
        PdfTemplate headerTemplate, footerTemplate, footerTemplate2;
        // this is the BaseFont we are going to use for the header / footer
        BaseFont bf = null;
        BaseFont bfFolio = null;
        // This keeps track of the creation time
        DateTime PrintTime = DateTime.Now;

        private DateTime _FechaQuote;
        public DateTime FechaQuote
        {
            get { return _FechaQuote; }
            set { _FechaQuote = value; }
        }

        private string _NoCotizacion;
        public string NoCotizacion
        {
            get { return _NoCotizacion; }
            set { _NoCotizacion = value; }
        }

        private string _NombreCte;
        public string NombreCte
        {
            get { return _NombreCte; }
            set { _NombreCte = value; }
        }

        private string _NombreContacto;
        public string NombreContacto
        {
            get { return _NombreContacto; }
            set { _NombreContacto = value; }
        }

        private string _NombreProyecto;
        public string NombreProyecto
        {
            get { return _NombreProyecto; }
            set { _NombreProyecto = value; }
        }

        private string _empresa;
        public string empresa
        {
            get { return _empresa; }
            set { _empresa = value; }
        }

        private string _cotizo;
        public string cotizo
        {
            get { return _cotizo; }
            set { _cotizo = value; }
        }

        private string _notas;
        public string notas
        {
            get { return _notas; }
            set { _notas = value; }
        }


        #endregion Properties

        #region TiposLetra
        public static BaseColor colornaranga = new BaseColor(255, 68, 0);//255
        public static iTextSharp.text.Font arial = FontFactory.GetFont("arial", 10, 0, BaseColor.BLACK);
        public static iTextSharp.text.Font arial2 = FontFactory.GetFont("arial", 8, 0, BaseColor.BLACK);
        public static iTextSharp.text.Font arial3 = FontFactory.GetFont("arial", 9, 0, BaseColor.BLACK);
        public static iTextSharp.text.Font arialNegrita = FontFactory.GetFont("Arial Black", 10, 1, BaseColor.BLACK);//1= negrita
       // iTextSharp.text.Font baseFontBig = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 14f, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK);

        public static iTextSharp.text.Font arialBlanco = FontFactory.GetFont("arial", 8, 0, BaseColor.WHITE);
        public static iTextSharp.text.Font verdana = FontFactory.GetFont("Arial Black", 16, 1, colornaranga);

        #endregion TiposLetra

        public override void OnOpenDocument(PdfWriter writer, Document document)
        {
            try
            {

                PrintTime = DateTime.Now;
                bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);

                bfFolio = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                cb = writer.DirectContent;
                headerTemplate = cb.CreateTemplate(200, 100);
                footerTemplate = cb.CreateTemplate(100, 50);
            }
            catch (DocumentException)
            {

            }
            catch (System.IO.IOException)
            {

            }
        }

        public override void OnEndPage(iTextSharp.text.pdf.PdfWriter writer, iTextSharp.text.Document document)
        {
            base.OnEndPage(writer, document);

            BaseColor colorazul = new BaseColor(46, 58, 151);

            #region LOGOTIPO
            string imageFilePath = Application.StartupPath + @"/LOGOTIPO.png";



            iTextSharp.text.Image jpg = iTextSharp.text.Image.GetInstance(imageFilePath);
            jpg.ScaleToFit(180f, 180f);
            jpg.SetAbsolutePosition(0, 0);


            string imageFilePathEngranes = Application.StartupPath + @"/ENGRANAJES.png";
            iTextSharp.text.Image jpgEngranes = iTextSharp.text.Image.GetInstance(imageFilePathEngranes);
            jpgEngranes.SetAbsolutePosition(0, 0);

            iTextSharp.text.Image imagenSobre = iTextSharp.text.Image.GetInstance(Application.StartupPath + @"/SOBRE.png");
            imagenSobre.ScaleToFit(18f, 18f);
            imagenSobre.SetAbsolutePosition(document.PageSize.GetRight(586), document.PageSize.GetBottom(44));

            iTextSharp.text.Image imagenLocalizacion = iTextSharp.text.Image.GetInstance(Application.StartupPath + @"/UBICACION.png");
            imagenLocalizacion.ScaleToFit(18f, 18f);
            imagenLocalizacion.SetAbsolutePosition(document.PageSize.GetRight(390), document.PageSize.GetBottom(42));

            iTextSharp.text.Image imagenWhatsapp = iTextSharp.text.Image.GetInstance(Application.StartupPath + @"/TELEFONO.png");
            imagenWhatsapp.ScaleToFit(18f, 18f);
            imagenWhatsapp.SetAbsolutePosition(document.PageSize.GetRight(115), document.PageSize.GetBottom(42));



            #endregion LOGOTIPO

            String text2 = "Blvd. Federico Benítez 401-B La mesa, Tijuana B.C. C.P.22105 Tel/Fax: 6262712 http//:www.descoa.com";
            String text3 = "R.F.C.  JIN171010643";
            

            String text = "ventas@moserep.com                                                   Blvd. Federico Benítez 401-B. Col. La Mesa, Tijuana                                           +52 663 127 7830";

            #region Numeracion de pagina y Fijacion de LOGOTIPO
            

            //Agregar la direccion al Footer
            {
                cb.SetColorFill(colorazul);
                cb.Rectangle(0, 0, document.PageSize.Width, 20);
                cb.SetColorStroke(colorazul);
                /*
                cb.SetColorFill(colorazul);
                cb.Rectangle(470, 750, 120, 21);
                cb.SetColorStroke(colorazul);
                */

                cb.BeginText();
                cb.SetFontAndSize(bf, 8);
                cb.SetTextMatrix(document.PageSize.GetRight(480), document.PageSize.GetBottom(10));
                cb.ShowText(text2);//rfc
                cb.EndText();
            }

            //Add paging to footer
            {
                cb.BeginText();
                cb.SetFontAndSize(bf, 8);
                cb.SetColorFill(BaseColor.BLACK);
                cb.SetColorStroke(BaseColor.BLACK);
                cb.SetTextMatrix(document.PageSize.GetRight(564), document.PageSize.GetBottom(50));
                cb.ShowText(text);//////////////////////////////////////ventas, direccio telefono

                cb.SetColorFill(BaseColor.BLACK);
                cb.SetColorStroke(BaseColor.BLACK);
                cb.EndText();

                cb.BeginText();
                cb.SetFontAndSize(bf, 8);
                cb.SetColorFill(BaseColor.BLACK);
                cb.SetColorStroke(BaseColor.BLACK);
                cb.SetTextMatrix(document.PageSize.GetRight(370), document.PageSize.GetBottom(35));
                cb.ShowText("Baja California, México C.P. 22105");//////////////////////////////////////iconos

                cb.SetColorFill(BaseColor.BLACK);
                cb.SetColorStroke(BaseColor.BLACK);
                cb.EndText();


                cb.BeginText();
                cb.SetFontAndSize(bf, 8);
                cb.SetTextMatrix(document.PageSize.GetRight(600), document.PageSize.GetBottom(44));
                cb.ShowText("");
                cb.AddImage(imagenSobre);
                cb.EndText();

                cb.BeginText();
                cb.SetFontAndSize(bf, 8);
                cb.SetTextMatrix(document.PageSize.GetRight(398), document.PageSize.GetBottom(42));
                cb.ShowText("");
                cb.AddImage(imagenLocalizacion);
                cb.EndText();

                cb.BeginText();
                cb.SetFontAndSize(bf, 8);
                cb.SetTextMatrix(document.PageSize.GetRight(111), document.PageSize.GetBottom(42));
                cb.ShowText("");
                cb.AddImage(imagenWhatsapp);
                cb.EndText();


                cb.AddImage(jpgEngranes);

                float len = bf.GetWidthPoint(text, 8);
                cb.AddTemplate(footerTemplate, document.PageSize.GetRight(330) + len, document.PageSize.GetBottom(25));
            }

            #endregion Numeracion de pagina y Fijacion de LOGOTIPO

            #region Tabla Titulo y Numero de Cotizacion
            //Create PdfTable object
            

            PdfPTable pdfTab = new PdfPTable(3);
            float[] widths255552255 = new float[] { 7f, 7f, 6f };
            pdfTab.SetWidths(widths255552255);






























            



























            PdfPTable tablaRfcRazon = new PdfPTable(1);
            tablaRfcRazon.HorizontalAlignment = Element.ALIGN_LEFT;





















            PdfPTable tablaRfc = new PdfPTable(1);
            tablaRfc.HorizontalAlignment = Element.ALIGN_LEFT;


            PdfPCell rfcCampo = new PdfPCell(new Phrase("R.F.C. JIN171010643", arialNegrita));
            rfcCampo.HorizontalAlignment = Element.ALIGN_LEFT;
            rfcCampo.Border = 0;
            rfcCampo.FixedHeight = 20F;

            tablaRfc.AddCell(rfcCampo);


            PdfPCell celTemporal1 = new PdfPCell(tablaRfc);
            celTemporal1.Border = 0;
            tablaRfcRazon.AddCell(celTemporal1);






























































            PdfPTable tablaRazonSocial = new PdfPTable(2);
            float[] widths2555555 = new float[] { 5f, 9f };
            tablaRazonSocial.SetWidths(widths2555555);
            tablaRazonSocial.HorizontalAlignment = Element.ALIGN_LEFT;

            PdfPCell razonLabel = new PdfPCell(new Phrase("Razón social:", arialNegrita));
            razonLabel.HorizontalAlignment = Element.ALIGN_LEFT;
            razonLabel.Border = 0;
            razonLabel.FixedHeight = 20F;

            PdfPCell razonCampo = new PdfPCell(new Phrase("JJF INDUSTRIAL S.A. de C.V.", arial2));
            razonCampo.HorizontalAlignment = Element.ALIGN_LEFT;
            razonCampo.Border = 0;
            razonCampo.FixedHeight = 20F;

            tablaRazonSocial.AddCell(razonLabel);
            tablaRazonSocial.AddCell(razonCampo);









            PdfPCell celTemporal2 = new PdfPCell(tablaRazonSocial);
            celTemporal2.Border = 0;
            tablaRfcRazon.AddCell(celTemporal2);





            /*
            PdfPCell ImporteLetra = new PdfPCell(tablaRfcRazon);

            Phrase p1Header1 = new Phrase(razon, arial3);*/
            PdfPCell pdfCell1 = new PdfPCell(tablaRfcRazon);//razon
            pdfCell1.VerticalAlignment = Element.ALIGN_CENTER;















            Phrase p1Header = new Phrase("COTIZACIÓN", verdana);
            PdfPCell pdfCell2 = new PdfPCell(p1Header);//cotizaciom
            pdfCell1.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfCell2.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfCell2.VerticalAlignment = Element.ALIGN_CENTER;

            pdfCell1.Border = 0;
            pdfCell2.Border = 0;

            //TABLA ANIDADA DE NUMERO DE COTIZACION Y FECHA

            PdfPTable table = new PdfPTable(1);
            table.TotalWidth = 124f;
            table.LockedWidth = true;
            table.HorizontalAlignment = 2;


            PdfPCell header = new PdfPCell(new Phrase(8, "NO. COTIZACION", arialBlanco));
            header.HorizontalAlignment = Element.ALIGN_CENTER;
            header.BackgroundColor = colorazul;
            header.VerticalAlignment = Element.ALIGN_CENTER;
            header.PaddingTop = 4;

            PdfPCell no = new PdfPCell(new Phrase(8, NoCotizacion, arial));                                    //TITULO,NUMERO Y FECHA
            no.HorizontalAlignment = Element.ALIGN_CENTER;
            no.VerticalAlignment = Element.ALIGN_CENTER;
            no.PaddingTop = 4;

            PdfPCell header2 = new PdfPCell(new Phrase(8, "FECHA", arialBlanco));
            header2.HorizontalAlignment = Element.ALIGN_CENTER;
            header2.BackgroundColor = colorazul;
            header2.VerticalAlignment = Element.ALIGN_CENTER;
            header2.PaddingTop = 4;

            PdfPCell fecha = new PdfPCell(new Phrase(8, FechaQuote.Day + "/" + FechaQuote.Month + "/" + FechaQuote.Year, arial));
            fecha.HorizontalAlignment = Element.ALIGN_CENTER;
            fecha.VerticalAlignment = Element.ALIGN_CENTER;
            fecha.PaddingTop = 4;


            //TITULO,NUMERO Y FECHA

            table.AddCell(header);
            table.AddCell(no);
            table.AddCell(header2);
            table.AddCell(fecha);

            PdfPCell anidado = new PdfPCell(table);
            anidado.HorizontalAlignment = 2;
            anidado.Border = 0;


            PdfPCell espacio100 = new PdfPCell(new Phrase(8, "", arialBlanco));
            // header.HorizontalAlignment = 1;
            espacio100.Border=0;

            pdfTab.AddCell(espacio100);
            pdfTab.AddCell(espacio100);
            pdfTab.AddCell(anidado);

            pdfTab.AddCell(pdfCell1);///razon social
            pdfTab.AddCell(pdfCell2);
            pdfTab.AddCell(espacio100);

            pdfTab.TotalWidth = document.PageSize.Width - 50f;
            pdfTab.WidthPercentage = 70;

            pdfTab.WriteSelectedRows(0, -1, 25, document.PageSize.Height - 60, writer.DirectContent);

            
            iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(imageFilePath);
            logo.SetAbsolutePosition(25, 700); //esta es la ubicación en la hoja en mi caso es carta
            logo.ScalePercent(12); // el tamaño de la imagen
            document.Add(logo);  //lo agregas al documento
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            #endregion Tabla Titulo y Numero de Cotizacion

            #region Tabla Nombre del cliente

            PdfPTable tablaCte = new PdfPTable(2);
            tablaCte.TotalWidth = document.PageSize.Width - 50f;
            tablaCte.LockedWidth = true;
            tablaCte.WidthPercentage = 70;
            float[] widths = new float[] { 1f, 9f };
            tablaCte.SetWidths(widths);
            tablaCte.SpacingAfter = 10;

            PdfPCell cte = new PdfPCell(new Phrase("Cliente:", arialNegrita));
            cte.Border = 0;
            cte.VerticalAlignment = Element.ALIGN_CENTER;
            tablaCte.AddCell(cte);

            PdfPCell cte2 = new PdfPCell(new Phrase(NombreCte, arial));
            cte2.Border = 0;
            cte2.HorizontalAlignment = Element.ALIGN_LEFT;
            cte2.VerticalAlignment = Element.ALIGN_CENTER;
            tablaCte.AddCell(cte2);

            PdfPCell proyecto22 = new PdfPCell(new Phrase("", arial));
            proyecto22.Border = 0;
            proyecto22.VerticalAlignment = Element.ALIGN_CENTER;
            tablaCte.AddCell(proyecto22);

            PdfPCell proyecto2555 = new PdfPCell(new Phrase("", arial));
            proyecto2555.Border = 0;
            proyecto2555.VerticalAlignment = Element.ALIGN_CENTER;
            tablaCte.AddCell(proyecto2555);

            tablaCte.AddCell(proyecto22);
            tablaCte.AddCell(proyecto2555);

            PdfPCell cto = new PdfPCell(new Phrase("Contacto:", arialNegrita));
            cto.Border = 0;
            cto.VerticalAlignment = Element.ALIGN_MIDDLE;
            tablaCte.AddCell(cto);

            PdfPCell cto2 = new PdfPCell(new Phrase(NombreContacto, arial));
            cto2.Border = 0;
            cto2.HorizontalAlignment = Element.ALIGN_LEFT;
            cto2.VerticalAlignment = Element.ALIGN_CENTER;
            tablaCte.AddCell(cto2);

            tablaCte.WriteSelectedRows(0, -1,25, document.PageSize.Height - 170, writer.DirectContent);

            #endregion Tabla Nombre del cliente

            #region Titulos de Columnas

            PdfPTable NombreColumnas = new PdfPTable(6);
            NombreColumnas.TotalWidth = document.PageSize.Width - 50f;
            NombreColumnas.LockedWidth = true;
            NombreColumnas.WidthPercentage = 70;
            float[] widths2 = new float[] { 2f, 4f, 8f, 2f, 2f, 2f };
            NombreColumnas.SetWidths(widths2);

            PdfPCell item = new PdfPCell(new Phrase("PARTIDA", arialBlanco));
            item.HorizontalAlignment = 1;
            item.VerticalAlignment = Element.ALIGN_MIDDLE;
            item.BackgroundColor = colorazul;
            item.Padding = 5;
            NombreColumnas.AddCell(item);

            PdfPCell Catalogo = new PdfPCell(new Phrase("NO. DE PARTIDA", arialBlanco));
            Catalogo.HorizontalAlignment = 1;
            Catalogo.VerticalAlignment = Element.ALIGN_MIDDLE;
            Catalogo.BackgroundColor = colorazul;
            Catalogo.Padding = 5;
            NombreColumnas.AddCell(Catalogo);

            PdfPCell Descrip = new PdfPCell(new Phrase("DESCRIPCION", arialBlanco));
            Descrip.HorizontalAlignment = 1;
            Descrip.VerticalAlignment = Element.ALIGN_MIDDLE;
            Descrip.BackgroundColor = colorazul;
            Descrip.Padding = 5;
            NombreColumnas.AddCell(Descrip);

            PdfPCell Cantidad = new PdfPCell(new Phrase("CANT.", arialBlanco));
            Cantidad.HorizontalAlignment = 1;
            Cantidad.VerticalAlignment = Element.ALIGN_MIDDLE;
            Cantidad.BackgroundColor = colorazul;
            Cantidad.Padding = 5;
            NombreColumnas.AddCell(Cantidad);

            PdfPCell Unitario = new PdfPCell(new Phrase("P.UNITARIO", arialBlanco));
            Unitario.HorizontalAlignment = 1;
            Unitario.VerticalAlignment = Element.ALIGN_MIDDLE;
            Unitario.BackgroundColor = colorazul;
            Unitario.Padding = 5;
            NombreColumnas.AddCell(Unitario);

            PdfPCell total = new PdfPCell(new Phrase("TOTAL", arialBlanco));
            total.HorizontalAlignment = 1;
            total.VerticalAlignment = Element.ALIGN_MIDDLE;
            total.BackgroundColor = colorazul;
            total.Padding = 5;
            NombreColumnas.AddCell(total);

            NombreColumnas.WriteSelectedRows(0, -1, 26, document.PageSize.Height - 221, writer.DirectContent);

            #endregion Titulos de Columnas
        }

        public override void OnCloseDocument(PdfWriter writer, Document document)
        {
            base.OnCloseDocument(writer, document);
            footerTemplate.BeginText();
            footerTemplate.SetFontAndSize(bf, 8);
            footerTemplate.SetTextMatrix(0, 0);
            footerTemplate.ShowText("");
            //footerTemplate.ShowText((writer.PageNumber - 1).ToString());
            footerTemplate.EndText();


        }
    }
}
