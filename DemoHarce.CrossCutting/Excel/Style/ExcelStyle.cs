using ClosedXML.Excel;

namespace DemoHarce.CrossCutting.Excel.Style
{
    /// <summary>
    /// Clase que gestiona los estilos de cada hoja excel
    /// </summary>
    public class ExcelStyle
    {
        private ExcelConfigurationStyle _configurationExcelStyle;
        /// <summary>
        /// Constructor 
        /// </summary>
        /// <param name="configurationExcelStyle">Valores de configuración de los estilos</param>
        public ExcelStyle(ExcelConfigurationStyle configurationExcelStyle)
        {
            _configurationExcelStyle = configurationExcelStyle;
        }
        internal void ApplyStyles(IXLRange rngHeader)
        {
            BackGroundColor(rngHeader, _configurationExcelStyle.Header.BackGroundColor);
            FontColor(rngHeader, _configurationExcelStyle.Header.FontColor);
            SetBold(rngHeader, _configurationExcelStyle.Header.FontBold);
        }
        private static void BackGroundColor(IXLRange rngHeader, XLColor color)
        {
            rngHeader.FirstRow().Style.Fill.BackgroundColor = color;
        }

        private static void FontColor(IXLRange rngHeader, XLColor color)
        {
            rngHeader.FirstRow().Style.Font.FontColor = color;
        }

        private static void SetBold(IXLRange rngHeader, bool isBold)
        {
            if (isBold)
            {
                rngHeader.FirstRow().Style.Font.SetBold();
            }
        }
    }

}
