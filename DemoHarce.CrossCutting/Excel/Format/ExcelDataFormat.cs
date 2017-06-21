using ClosedXML.Excel;
using DemoHarce.CrossCutting.Excel.DataTypes;

namespace DemoHarce.CrossCutting.Excel.Format
{
    /// <summary>
    /// Clase que gestiona el formato de datos.
    /// </summary>
    public class ExcelDataFormat
    {
        private readonly ExcelConfigurationDataFormat _configurationDataFormat;
        public ExcelDataFormat(ExcelConfigurationDataFormat configurationDataFormat)
        {
            _configurationDataFormat = configurationDataFormat;
        }
        public void ApplyFormat(IXLCell cell, object column, bool formatWithEuros = false)
        {
            BooleanFormat booleanFormat = new BooleanFormat();
            booleanFormat.SetFormat(cell, column, _configurationDataFormat);
            NumericFormat numericaFormat = new NumericFormat();
            if (formatWithEuros)
                _configurationDataFormat.NumericFormat = "0.00 €";
            else
                _configurationDataFormat.NumericFormat = "0.00";

            numericaFormat.SetFormat(cell, column, _configurationDataFormat);
            DateTimeFormat datetimeFormat = new DateTimeFormat();
            datetimeFormat.SetFormat(cell, column, _configurationDataFormat);
            TextFormat textFormat = new TextFormat();
            textFormat.SetFormat(cell, column, _configurationDataFormat);
        }
    }


}
