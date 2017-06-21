using System;

namespace DemoHarce.CrossCutting.Exceptions
{
    [Serializable]
    public class BusinessException : Exception
    {
        public BusinessException()
            : base()
        {

        }
        public BusinessException(string message)
            : base(message)
        {

        }
        public BusinessException(string message, Exception innerException)
            : base(message, innerException)
        {

        }
    }
}
