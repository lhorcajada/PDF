using DemoHarce.CrossCutting.Pdf.Common;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace DemoHarce.CrossCutting.Pdf.Events
{
    public class Footer : PdfPageEventHelper
    {
        protected Phrase[] footer = new Phrase[1];
        private string _textFooterLeft;

        public Footer(string textFooterLeft)
        {
            _textFooterLeft = textFooterLeft;
        }

        public override void OnOpenDocument(PdfWriter writer, Document document)
        {
            footer[0] = new Phrase(_textFooterLeft, new Font(CustomFont.BaseFontVerdana()));
        }

        public override void OnEndPage(PdfWriter writer, Document document)
        {
            Rectangle rect = new Rectangle(50, 50, 545, 792);
            SetTextFooterLeft(writer, rect);
            SetTextFooterRight(writer, document, rect);

            Line.InsertLine(writer, document, 65);
        }

        private static void SetTextFooterRight(PdfWriter writer, Document document, Rectangle rect)
        {
            var pageNumber = new Phrase(string.Format("{0}", document.PageNumber));
            pageNumber.Font.SetColor(0, 0, 0);
            ColumnText.ShowTextAligned(writer.DirectContentUnder,
                        Element.ALIGN_RIGHT, pageNumber,
                        rect.Right, rect.Bottom, 0);
        }

        private void SetTextFooterLeft(PdfWriter writer, Rectangle rect)
        {
            footer[0].Font.SetColor(0, 0, 0);
            ColumnText.ShowTextAligned(writer.DirectContentUnder,
                        Element.ALIGN_LEFT, footer[0],
                        rect.Left, rect.Bottom, 0);
        }
    }
}
