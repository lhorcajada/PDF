using iTextSharp.text.pdf;
using System;
using System.IO;
using System.Web;

namespace DemoHarce.CrossCutting.Pdf.Common
{
    public static class CustomFont
    {
        private static byte[] font = Resources.Resources.Verdana;

        public static BaseFont BaseFontVerdana()
        {
            return BaseFont.CreateFont("Verdana.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED, BaseFont.CACHED, font, null);
        }
    }
}
