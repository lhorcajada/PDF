using iTextSharp.text;
using iTextSharp.text.pdf;

namespace DemoHarce.CrossCutting.Pdf.Events
{
    public class ChapterBorder : PdfPageEventHelper
    {
        private bool active = false;
        private float offset = 5;
        private float startPosition;

        public void SetActive(bool active)
        {
            this.active = active;
        }

        public override void OnStartPage(PdfWriter writer, Document document)
        {
            startPosition = document.Top;
        }

        public override void OnChapter(PdfWriter writer, Document document, float paragraphPosition, Paragraph title)
        {
            startPosition = paragraphPosition;
        }

        public override void OnChapterEnd(PdfWriter writer, Document document, float position)
        {
            if (active)
            {
                PdfContentByte contentByte = writer.DirectContentUnder;
                contentByte.Rectangle(document.Left, position - offset,
                    document.Right - document.Left, startPosition - position);
                contentByte.SetColorStroke(BaseColor.WHITE);
                contentByte.SetCMYKColorFill(20, 14, 12, 40);
                contentByte.Fill();
                contentByte.Stroke();
            }
        }
    }
}
