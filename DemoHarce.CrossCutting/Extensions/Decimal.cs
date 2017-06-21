
using System.Globalization;

namespace System
{
    public static class DecimalExtensions
    {
        public static string GetIntegralPart(this decimal number)
        {
            decimal integralPart = decimal.Truncate(number);
            if (integralPart < 0)
                integralPart = decimal.Negate(integralPart);

            string text = integralPart.ToString("#");

            return text;
        }

        public static string GetDecimalPart(this decimal number)
        {
            decimal integralPart = decimal.Truncate(number);
            decimal result = 0;

            result = number - integralPart;
            if (result < 0)
                result = decimal.Negate(result);
            string text = result.ToString(CultureInfo.InvariantCulture);
            if (text.Length == 1)
                return string.Empty;

            return text.Substring(2);
        }
    }
}
