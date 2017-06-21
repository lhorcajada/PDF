namespace DemoHarce.CrossCutting.Excel.Format.Factory
{
    /// <summary>
    /// Factoría que crea los objetos ExcelDataFormat
    /// </summary>
    public class ExcelDataFormatFactory
    {
        /// <summary>
        /// Crea un objeto ExcelDataFormat. Si el parámetro es nulo devuelve un objeto con el formato por defecto.
        /// </summary>
        /// <param name="configurationDataFormat">Configuración del formato de datos personalizado</param>
        /// <returns></returns>
        public static ExcelDataFormat GetDataFormat(ExcelConfigurationDataFormat configurationDataFormat)
        {
            if (configurationDataFormat == null)
            {
                configurationDataFormat = new ExcelConfigurationDataFormat();
                configurationDataFormat.BooleanCapitalLetters = false;
                configurationDataFormat.BooleanYesNo = true;
                configurationDataFormat.DateTimeFormat = 14;
                configurationDataFormat.TextFormat = true;
                configurationDataFormat.NumericFormat = "0.00 €";
                return new ExcelDataFormat(configurationDataFormat);

            }
            return new ExcelDataFormat(configurationDataFormat);
        }

    }
}
