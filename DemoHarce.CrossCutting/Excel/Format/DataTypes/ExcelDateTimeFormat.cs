using ClosedXML.Excel;
using DemoHarce.CrossCutting.Excel.Format;
using System;

namespace DemoHarce.CrossCutting.Excel.DataTypes
{
    /// <summary>
    /// Clase que trata los valores de fecha
    /// </summary>
    public class DateTimeFormat : ExcelTypesFormat
    {
        /// <summary>
        /// Establece el formato
        /// </summary>
        /// <param name="cell">Celda a la que se aplicará el formato</param>
        /// <param name="column">Columna de los datos</param>
        /// <param name="dataFormat">Configuración del formato</param>
        public override void SetFormat(IXLCell cell, object column, ExcelConfigurationDataFormat dataFormat)
        {
            if (column is DateTime)
            {
                cell.Style.DateFormat.NumberFormatId = dataFormat.DateTimeFormat;
            }
        }
    }
}
