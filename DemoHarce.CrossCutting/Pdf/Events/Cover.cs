using iTextSharp.text.pdf;
using System;
using iTextSharp.text;
using DemoHarce.CrossCutting.Pdf.Common;

namespace DemoHarce.CrossCutting.Pdf.Events
{
    public class Cover : PdfPageEventHelper
    {
        protected Phrase[] header; 

        public Cover(string title, string subject, string description1, string description2, string description3)
        {
            header = new Phrase[] {
            new Phrase(title, new Font(CustomFont.BaseFontVerdana(), 50f, Font.BOLD)),
            new Phrase(subject, new Font(CustomFont.BaseFontVerdana(), 35f, 1, BaseColor.GRAY)),
            new Phrase(description1, new Font(CustomFont.BaseFontVerdana(), 12f)),
            new Phrase(description2, new Font(CustomFont.BaseFontVerdana(), 12f)),
            new Phrase(description3, new Font(CustomFont.BaseFontVerdana(), 12f)) };
        }
        public override void OnOpenDocument(PdfWriter writer, Document document)
        {
            if (IsFirstPage(writer.PageNumber))
            {
                PdfContentByte canvas = writer.DirectContent;
                Rectangle rectangleBackground = new Rectangle(30, 30, 559, 825);
                rectangleBackground.BackgroundColor = BaseColor.WHITE;
                canvas.Rectangle(rectangleBackground);

                InsertImageCoverDeloitte(writer, rectangleBackground);
                RectangleLeftVertical(canvas);
                SetTextCover(writer);

                document.NewPage();
            }
        }

        private static bool IsFirstPage(int pageNumber)
        {
            return pageNumber == 1;
        }

        private static void InsertImageCoverDeloitte(PdfWriter writer, Rectangle rectangleBackground)
        {
            CustomImage.InsertImage(writer.DirectContent, rectangleBackground.Left + 40f, rectangleBackground.Top - 80f);
        }

        private static void RectangleLeftVertical(PdfContentByte canvas)
        {
            Rectangle rectangleLeft = new Rectangle(30, 50, 50, 800);
            rectangleLeft.BackgroundColor = BaseColor.GRAY;
            canvas.Rectangle(rectangleLeft);
        }

        private void SetTextCover(PdfWriter writer)
        {
            writer.SetSimpleColumnCover(header[0], 692);
            writer.SetSimpleColumnCover(header[1], 592);
            writer.SetSimpleColumnCover(header[2], 342);
            writer.SetSimpleColumnCover(header[3], 327);
            writer.SetSimpleColumnCover(header[4], 312);
        }
    }
}
