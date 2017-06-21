using DemoHarce.Application.Core.Engine;
using DemoHarce.CrossCutting.Pdf.Answers.IDataTypes;
using DemoHarce.CrossCutting.Pdf.Common;
using iTextSharp.text;

namespace DemoHarce.CrossCutting.Pdf.Answers.DataTypes
{
    public class IntegerType : IDataType
    {
        public void AddAnswer(Document _document, ResultDto result)
        {
            var formatInteger = result.ResultInteger.HasValue ? result.ResultInteger.Value.ToString("N0") : "";
            Paragraph paragraph = new Paragraph(formatInteger, new Font(CustomFont.BaseFontVerdana(), Context.SIZE));
            paragraph.SpacingBefore = Context.SPACINGBEFORE;
            paragraph.IndentationLeft = Context.SPACINGLEFT;
            _document.Add(paragraph);
        }
    }
}
