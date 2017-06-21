namespace System.Text
{
    /// <summary>
    /// Extensiones para la clase StringBuilder
    /// </summary>
    public static class StringBuilderExtensions
    {
        /// <summary>
        /// Agrega una nueva línea sin lineas vacías al final.
        /// </summary>
        /// <param name="sb"></param>
        /// <param name="text">
        /// Texto para agregar.
        /// </param>
        public static void AppendTrimLine(this StringBuilder sb, string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return;
            var str = sb.Length > 0 ? string.Format("{0}{1}", Environment.NewLine, text) : text;
            sb.Append(str);
        }

        /// <summary>
        /// Devuelve la cadena si hay algo. Si no hay nada devuelve el valor de defaultValue (por defecto null)
        /// </summary>
        /// <param name="sb"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static string ToStringOrDefault(this StringBuilder sb, string defaultValue = null)
        {
            if (sb.Length > 0)
                return sb.ToString();

            return defaultValue;
        }
    }
}
