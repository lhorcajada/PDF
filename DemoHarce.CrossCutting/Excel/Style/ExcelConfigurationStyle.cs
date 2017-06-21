namespace DemoHarce.CrossCutting.Excel.Style
{
    /// <summary>
    /// Clase que configura el estilo de las celdas
    /// TODO. De momento sólo se configura la cabecera.
    /// </summary>
    public class ExcelConfigurationStyle
    {
        /// <summary>
        /// El constructor instancia el estilo de la cabecera
        /// </summary>
        public ExcelConfigurationStyle()
        {
            _header = new ExcelHeader();
        }
        private ExcelHeader _header;
        /// <summary>
        /// Propiedad que contiene el estilo de la cabecera.
        /// </summary>
        public ExcelHeader Header
        {
            get { return _header; }
            set { _header = value; }
        }
    }
}
