using System;
using System.Threading.Tasks;

namespace DemoHarce.CrossCutting.Exceptions
{
    public interface IExceptionsManager
    {
        Task<bool> SaveException(Exception exception, string login, string comments);
    }
}
