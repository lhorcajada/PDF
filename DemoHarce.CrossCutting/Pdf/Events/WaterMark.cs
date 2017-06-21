using DemoHarce.CrossCutting.Pdf.Common;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace DemoHarce.CrossCutting.Pdf.Events
{
    public class WaterMark : PdfPageEventHelper
    {
        protected Phrase _watermark;
        private string _textWatermark = "";

        public WaterMark(string textWatermark)
        {
            _textWatermark = textWatermark;
            _watermark = new Phrase(_textWatermark, new Font(CustomFont.BaseFontVerdana(), 60, Font.NORMAL, BaseColor.LIGHT_GRAY));
        }

        public override void OnEndPage(PdfWriter writer, Document document)
        {
            PdfContentByte canvas = writer.DirectContentUnder;
            ColumnText.ShowTextAligned(canvas, Element.ALIGN_CENTER, _watermark, 298, 421, 45);
        }
    }
}
