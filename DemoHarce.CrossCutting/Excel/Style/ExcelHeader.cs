using ClosedXML.Excel;

namespace DemoHarce.CrossCutting.Excel.Style
{
    /// <summary>
    /// Clase que registra el estilo de la cabecera.
    /// </summary>
    public class ExcelHeader
    {
        /// <summary>
        /// Fondo de la celda
        /// </summary>
        public XLColor BackGroundColor { get; set; }
        /// <summary>
        /// Indica si la celda se pondrá en negrita
        /// </summary>
        public bool FontBold { get; set; }
        /// <summary>
        /// Indica el color de la fuente
        /// </summary>
        public XLColor FontColor { get; set; }
        /// <summary>
        /// Indica el tipo de letra
        /// </summary>
        public XLFontFamilyNumberingValues Font { get; set; }

    }
}
