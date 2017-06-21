using DemoHarce.CrossCutting.Pdf.Answers.IDataTypes;
using System;
using DemoHarce.CrossCutting.Pdf.Common;
using iTextSharp.text;
using DemoHarce.Application.Core.Engine;

namespace DemoHarce.CrossCutting.Pdf.Answers.DataTypes
{
    public class DateTimeType : IDataType
    {
        public void AddAnswer(Document _document, ResultDto result)
        {
            var dateTimeResult = result.ResultDateTime.HasValue ? result.ResultDateTime.Value.ToShortDateString() : "";
            Paragraph paragraph = new Paragraph(dateTimeResult, new Font(CustomFont.BaseFontVerdana(), Context.SIZE));
            paragraph.SpacingBefore = Context.SPACINGBEFORE;
            paragraph.IndentationLeft = Context.SPACINGLEFT;
            _document.Add(paragraph);
        }
    }
}
