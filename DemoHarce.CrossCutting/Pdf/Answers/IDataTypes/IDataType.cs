using DemoHarce.Application.Core.Engine;
using iTextSharp.text;

namespace DemoHarce.CrossCutting.Pdf.Answers.IDataTypes
{
    public interface IDataType
    {
        void AddAnswer(Document _document, ResultDto result);
    }
}
