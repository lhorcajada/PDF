using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Drawing;

namespace DemoHarce.CrossCutting.Pdf.Common
{
    public static class CustomImage
    {
        private static Bitmap image = Resources.Resources.DeloittePdf;

        public static void InsertImage(PdfContentByte writer, float absoluteX, float absoluteY)
        {
            try
            {
                PdfContentByte cb = writer;
                
                iTextSharp.text.Image imgSoc = iTextSharp.text.Image.GetInstance(ImageToByte(image));
                imgSoc.ScaleToFit(110, 110);
                imgSoc.SetAbsolutePosition(absoluteX, absoluteY);

                cb.AddImage(imgSoc);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static byte[] ImageToByte(System.Drawing.Image img)
        {
            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(img, typeof(byte[]));
        }
    }
}
