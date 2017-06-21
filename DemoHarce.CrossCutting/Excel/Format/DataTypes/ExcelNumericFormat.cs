using ClosedXML.Excel;
using DemoHarce.CrossCutting.Excel.Format;

namespace DemoHarce.CrossCutting.Excel.DataTypes
{
    /// <summary>
    /// Clase que trata los valores numéricos
    /// </summary>
    public class NumericFormat : ExcelTypesFormat
    {
        /// <summary>
        /// Establece el formato de la celda
        /// </summary>
        /// <param name="cell">Celda a la que se aplicará el formato</param>
        /// <param name="column">Columna de los datos</param>
        /// <param name="dataFormat">Configuración del formato</param>
        public override void SetFormat(IXLCell cell, object column, ExcelConfigurationDataFormat dataFormat)
        {
            if (column is double || column is decimal)
            {
                cell.Style.NumberFormat.Format = dataFormat.NumericFormat;
            }
        }
    }
}
