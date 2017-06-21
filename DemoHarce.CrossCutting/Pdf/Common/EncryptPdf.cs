using iTextSharp.text.pdf;
using System.IO;

namespace DemoHarce.CrossCutting.Pdf.Common
{
    public class EncryptPdf
    {
        public void EncryptPdfOnlyPrint(string src, string dest)
        {
            PdfReader reader = new PdfReader(src);
            PdfStamper stamper = new PdfStamper(reader, new FileStream(dest, FileMode.Create));
            stamper.SetEncryption(null, null,
                PdfWriter.AllowPrinting, PdfWriter.ENCRYPTION_AES_256);
            stamper.Close();
        }
    }
}
