namespace DemoHarce.CrossCutting.Excel
{
    /// <summary>
    /// Clase que registra las celdas de inicio de la cabecera y los datos.
    /// </summary>
    public class ExcelCoordinates
    {
        /// <summary>
        /// Registro donde se comenzará a escribir la cabecera
        /// </summary>
        public int HeaderRowInitial { get; set; }
        /// <summary>
        /// Columna donde se comenzará a escribir la cabecera
        /// </summary>
        public int HeaderColumnInitial { get; set; }
        /// <summary>
        /// Registro donde se comenzará a escribir los datos
        /// </summary>
        public int DataRowInitial { get; set; }
        /// <summary>
        /// Columna donde se comenzará a escribir los datos
        /// </summary>
        public int DataColumnInitial { get; set; }
    }
}
