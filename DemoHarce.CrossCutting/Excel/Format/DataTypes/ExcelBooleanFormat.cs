using ClosedXML.Excel;
using DemoHarce.CrossCutting.Excel.Format;

namespace DemoHarce.CrossCutting.Excel.DataTypes
{
    /// <summary>
    /// Clase que trata los valores booleanos.
    /// </summary>
    public class BooleanFormat : ExcelTypesFormat
    {
        /// <summary>
        /// Establece el formato
        /// </summary>
        /// <param name="cell">Celda a la que se aplicará el formato</param>
        /// <param name="column">Columna de los datos</param>
        /// <param name="dataFormat">Configuración del formato</param>
        public override void SetFormat(IXLCell cell, object column, ExcelConfigurationDataFormat dataFormat)
        {
            if (string.IsNullOrEmpty((string)cell.Value))
                return;
            if (column is bool && dataFormat.BooleanYesNo)
            {
                if (dataFormat.BooleanCapitalLetters)
                {
                    cell.Value = ((bool)cell.Value) ? "SI" : "NO";
                }
                else
                {
                    cell.Value = ((bool)cell.Value) ? "Sí" : "No";
                }
            }
        }


    }
}
