using iTextSharp.text;
using iTextSharp.text.pdf;

namespace DemoHarce.CrossCutting.Pdf.Common
{
    public static class Line
    {
        public static void InsertLine(PdfWriter writer, Document document, int heightY)
        {
            PdfPTable table = new PdfPTable(1);
            table.SetTotalWidth(new float[] { document.Right - 30 });
            table.DefaultCell.Border = Rectangle.BOTTOM_BORDER;
            table.AddCell("");
            table.WriteSelectedRows(0, -1, 34, heightY, writer.DirectContentUnder);
        }
    }
}
