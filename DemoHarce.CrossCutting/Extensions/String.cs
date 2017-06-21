namespace System
{
    /// <summary>
    /// Contenedos de los métodos de extensión para la clase String
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Realiza el format de una cadena a partir de una instancia
        /// </summary>
        /// <param name="format"></param>
        /// <param name="args"></param>
        /// <returns>
        /// Un String al que se le ha aplicado el formato <paramref name="format"/>
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Cuando <paramref name="args"/> es null
        /// </exception>
        /// <exception cref="FormatException">
        /// Cuando el numero de argumentos en <paramref name="args"/> no es suficiente.
        /// </exception>
        public static string StringFormat(this string format, params object[] args)
        {
            return string.Format(format, args);
        }

        /// <summary>
        /// Recorta una cadena al número de caracteres indicados. 
        /// </summary>
        /// <param name="str">La cadena</param>
        /// <param name="length">Número máxima de caracteres</param>
        /// <returns></returns>
        public static string Left(this string str, int length)
        {
            if (string.IsNullOrEmpty(str))
                return str;

            if (str.Length < length)
                return str;

            return str.Substring(0, length);
        }
    }
}
