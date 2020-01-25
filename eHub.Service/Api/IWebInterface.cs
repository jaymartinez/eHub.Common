using System;
using System.Threading.Tasks;

namespace eHub.Common.Api
{
    public interface IWebInterface : IDisposable
    {
        Task<T> Get<T>(string route);
        Task<T> Get<T>(string route, object body);
        Task<T> Post<T>(string route);
        Task<T> Post<T>(string route, object body);
    }
}
