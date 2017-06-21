using Pms.CoreServices.ProxyExceptions;
using System;
using System.Threading.Tasks;

namespace DemoHarce.CrossCutting.Exceptions
{
    /// <summary>
    /// Clase que gestiona la excepciones que ocurren en la aplicación.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ExceptionsManager : IExceptionsManager
    {
        public ExceptionsManager()
        {

        }
        public Task<bool> SaveException(Exception exception, string login, string comments)
        {
            using (var proxy = new ExceptionsServiceClient())
            {

                var exceptionString = Pms.Core.Exceptions.Serialization.ExceptionSerializer.Serialize(exception);
                var result = proxy.AddException(Resources.Resources.AppName, exceptionString, login, comments);
                return new Task<bool>(() => result);
            }
        }
    }
}
