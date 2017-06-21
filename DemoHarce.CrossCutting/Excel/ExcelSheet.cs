using System.Collections.Generic;

namespace DemoHarce.CrossCutting.Excel
{
    /// <summary>
    /// Clase que contiene la información de la hoja excel a rellenar
    /// </summary>
    public class ExcelSheet
    {
        /// <summary>
        /// Nombre de la hoja excel
        /// </summary>
        public string Name { get; set; }
        public List<ExcelDataRegion> Regions { get; set; }
    }
}
