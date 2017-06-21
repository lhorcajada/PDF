using ClosedXML.Excel;
using DemoHarce.CrossCutting.Excel.Format;

namespace DemoHarce.CrossCutting.Excel.DataTypes
{
    /// <summary>
    /// Clase abstrata que gestiona los tipos de formato
    /// </summary>
    public abstract class ExcelTypesFormat
    {
        /// <summary>
        /// Establece el formato de la celda
        /// </summary>
        /// <param name="cell">Celda a la que se aplicará el formato</param>
        /// <param name="column">Columna de los datos</param>
        /// <param name="dataFormat">Configuración del formato</param>
        public abstract void SetFormat(IXLCell cell, object column, ExcelConfigurationDataFormat dataFormat);
    }
}
