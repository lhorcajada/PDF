using iTextSharp.text;
using iTextSharp.text.pdf;

namespace DemoHarce.CrossCutting.Pdf.Common
{
    public static class MethodExtensor
    {
        public static void SetSimpleColumnCover(this PdfWriter writer, Phrase phrase, float top)
        {
            ColumnText columnText = new ColumnText(writer.DirectContent);
            columnText.SetSimpleColumn(phrase,
                     100, 50, 545, top, 50, Element.ALIGN_RIGHT);

            columnText.Go();
        }
    }
}
