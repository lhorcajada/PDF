using DemoHarce.Application.Core.Engine;
using DemoHarce.CrossCutting.Pdf.Answers.IDataTypes;
using DemoHarce.CrossCutting.Pdf.Common;
using iTextSharp.text;

namespace DemoHarce.CrossCutting.Pdf.Answers.DataTypes
{
    public class DecimalType : IDataType
    {
        public void AddAnswer(Document _document, ResultDto result)
        {
            var decimalResult = result.ResultDecimal.HasValue ? result.ResultDecimal.Value.ToString("N2") : "";
            Paragraph paragraph = new Paragraph(decimalResult, new Font(CustomFont.BaseFontVerdana(), Context.SIZE));
            paragraph.SpacingBefore = Context.SPACINGBEFORE;
            paragraph.IndentationLeft = Context.SPACINGLEFT;
            _document.Add(paragraph);
        }
    }
}
