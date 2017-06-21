using DemoHarce.Application.Core.Engine;
using DemoHarce.CrossCutting.Pdf.Answers.DataTypes;
using DemoHarce.CrossCutting.Pdf.Answers.IDataTypes;
using iTextSharp.text;
using System.Collections.Generic;

namespace DemoHarce.CrossCutting.Pdf.Answers
{
    public class Context
    {
        private static Dictionary<string, IDataType> _dataTypes = new Dictionary<string, IDataType>();
        public const float SIZE = 10f;
        public const float SPACINGBEFORE = 5f;
        public const float SPACINGLEFT = 10f;

        static Context()
        {
            _dataTypes.Add("datetime", new DateTimeType());
            _dataTypes.Add("decimal", new DecimalType());
            _dataTypes.Add("integer", new IntegerType());
            _dataTypes.Add("list", new ListType());
            _dataTypes.Add("matrix", new MatrixType());
            _dataTypes.Add("string", new StringType());
        }

        public static void AddAnswer(ResultDto result, Document _document)
        {
            _dataTypes[result.DataType].AddAnswer(_document, result);
        }
    }
}
