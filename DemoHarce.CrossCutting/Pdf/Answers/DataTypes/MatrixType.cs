using DemoHarce.Application.Core.Engine;
using DemoHarce.CrossCutting.Pdf.Answers.IDataTypes;
using DemoHarce.CrossCutting.Pdf.Common;
using iTextSharp.text;
using System.Linq;

namespace DemoHarce.CrossCutting.Pdf.Answers.DataTypes
{
    public class MatrixType : IDataType
    {
        public void AddAnswer(Document _document, ResultDto result)
        {
            var matrixInOneList = result.ResultMatrix.SelectMany(x => x).ToList();
            var cell = matrixInOneList.Aggregate((current, next) => current + ", " + next);

            Paragraph paragraph = new Paragraph(cell, new Font(CustomFont.BaseFontVerdana(), Context.SIZE));
            paragraph.SpacingBefore = Context.SPACINGBEFORE;
            paragraph.IndentationLeft = Context.SPACINGLEFT;
            _document.Add(paragraph);
        }
    }
}
