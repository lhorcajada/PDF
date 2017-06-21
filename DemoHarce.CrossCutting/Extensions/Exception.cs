using DemoHarce.CrossCutting.Helpers;
using System.ServiceModel;
using System.Text;

namespace System
{
    public static class ExceptionExtensions
    {
        public static string GetDetails(this Exception exception, int indent = 0)
        {
            Throw<ArgumentNullException>.WhenObject.IsNull(() => exception);

            StringBuilder message = new StringBuilder();

            message.AppendLine(IndentText(exception.Message, indent));
            if (!string.IsNullOrWhiteSpace(exception.StackTrace))
            {
                message.AppendLine(IndentText("StackTrace:", indent));
                message.AppendLine(IndentText(exception.StackTrace, indent));
            }
            AggregateException aggregateException = exception as AggregateException;
            if (aggregateException != null)
            {
                message.AppendLine(IndentText("InnerExceptions:", indent));
                foreach (var innerException in aggregateException.InnerExceptions)
                    message.AppendLine(IndentText(GetDetails(innerException, indent + 1), indent));
            }
            else if (exception is FaultException<ExceptionDetail>)
            {
                var faultException = (FaultException<ExceptionDetail>)exception;
                message.AppendLine(IndentText("Detail:", indent));
                if (faultException.Detail != null)
                    message.AppendLine(IndentText(GetDetails(faultException.Detail, indent + 1), indent));
            }
            else if (exception.InnerException != null)
            {
                message.AppendLine(IndentText("InnerException:", indent));
                message.AppendLine(IndentText(GetDetails(exception.InnerException, indent + 1), indent));
            }
            return message.ToString().Trim('\r', '\n');
        }


        public static string GetDetails(this ExceptionDetail exceptionDetail, int indent = 0)
        {
            Throw<ArgumentNullException>.WhenObject.IsNull(() => exceptionDetail);

            StringBuilder message = new StringBuilder();

            message.AppendLine(IndentText(exceptionDetail.Message, indent));
            if (!string.IsNullOrWhiteSpace(exceptionDetail.StackTrace))
            {
                message.AppendLine(IndentText("StackTrace:", indent));
                message.AppendLine(IndentText(exceptionDetail.StackTrace, indent));
            }

            if (exceptionDetail.InnerException != null)
            {
                message.AppendLine(IndentText("InnerException:", indent));
                message.AppendLine(IndentText(GetDetails(exceptionDetail.InnerException, indent + 1), indent));
            }
            return message.ToString().Trim('\r', '\n');
        }

        private static string IndentText(string text, int indent)
        {
            if (text == null)
                return null;
            if (indent < 1)
                return text;
            string indentText = "\t";// new string('\t', indent);
            return indentText + text.Replace("\r\n", "\r\n" + indentText);
        }
    }
}
