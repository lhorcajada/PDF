using DemoHarce.CrossCutting.Pdf.Common;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace DemoHarce.CrossCutting.Pdf.Events
{
    public class Header : PdfPageEventHelper
    {
        protected Phrase[] header = new Phrase[1];
        private string _textHeaderRight;

        public Header(string textHeaderRight)
        {
            _textHeaderRight = textHeaderRight;
        }
        public override void OnOpenDocument(PdfWriter writer, Document document)
        {
            header[0] = new Phrase(_textHeaderRight, new Font(CustomFont.BaseFontVerdana()));
        }

        public override void OnEndPage(PdfWriter writer, Document document)
        {
            Rectangle rect = new Rectangle(50, 50, 545, 792);
            InsertImageHeaderDeloitte(writer, rect);
            SetTextHeaderRight(writer, rect);

            Line.InsertLine(writer, document, 787);
        }

        private static void InsertImageHeaderDeloitte(PdfWriter writer, Rectangle rect)
        {
            CustomImage.InsertImage(writer.DirectContentUnder, rect.Left, rect.Top);
        }

        private void SetTextHeaderRight(PdfWriter writer, Rectangle rect)
        {
            header[0].Font.SetColor(0, 0, 0);
            ColumnText.ShowTextAligned(writer.DirectContentUnder,
                        Element.ALIGN_RIGHT, header[0],
                        rect.Right, rect.Top, 0);
        }
    }
}
