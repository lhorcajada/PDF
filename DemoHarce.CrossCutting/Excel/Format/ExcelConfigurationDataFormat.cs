namespace DemoHarce.CrossCutting.Excel.Format
{
    /// <summary>
    /// Clase que registra la configuración del formato de datos
    /// </summary>
    public class ExcelConfigurationDataFormat
    {
        /// <summary>
        /// Convierte los valores Si/No en mayúsculas.
        /// </summary>
        public bool BooleanCapitalLetters { get; set; }
        /// <summary>
        /// True: El valor boolean se convierte en Sí/No.
        /// False: El valor boolean es 0/1.
        /// </summary>
        /// 
        public bool BooleanYesNo { get; set; }

        /// <summary>
        /// 14: dd/mm/yyyy 07/03/1973
        /// 15: dd-MMM-yy 07-mar-1973
        /// 16: dd-MMM 07-mar
        /// 17: MMM-yy
        /// 18: HH:MM AM 12:00 AM
        /// 19: HH:MM:SS AM 12:00:00 AM
        /// 20: HH:MM 12:00
        /// 21: HH:MM:SS 12:00:00
        /// 22: dd/MM/yyyy HH:MM 07/03/2016 12:00
        /// </summary>
        public int DateTimeFormat { get; set; }
        public string NumericFormat { get; set; }
        public bool TextFormat { get; set; }

    }
}
