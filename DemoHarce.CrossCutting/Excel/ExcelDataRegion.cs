using DemoHarce.CrossCutting.Excel.Format;
using DemoHarce.CrossCutting.Excel.Style;
using System;
using System.Collections.Generic;

namespace DemoHarce.CrossCutting.Excel
{
    /// <summary>
    /// Clase que identifica un rango de la hoja excel donde se insertarán datos.
    /// </summary>
    public class ExcelDataRegion
    {
        /// <summary>
        /// Nombres de la cabeceras
        /// </summary>
        public string[] HeaderNames { get; set; }
        /// <summary>
        /// Columnas a insertar en la hoja excel
        /// </summary>
        public ExcelColumn[] ColumnsToExcel { get; set; }
        /// <summary>
        /// Listado de datos a insertar
        /// </summary>
        public List<Object> DataList { get; set; }
        /// <summary>
        /// Configuración del formato de los datos
        /// </summary>
        public ExcelConfigurationDataFormat ConfigurationDataFormat { get; set; }
        /// <summary>
        /// Configuración de los estilos para las celdas.
        /// TODO: De momento solo se aplica a las cabeceras
        /// </summary>
        public ExcelConfigurationStyle ConfigurationExcelStyle { get; set; }
        /// <summary>
        /// Registra las celdas de inicio de la cabecera y los datos.
        /// </summary>
        public ExcelCoordinates Coordinates { get; set; }

    }

}
