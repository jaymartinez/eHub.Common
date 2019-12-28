using eHub.Service.Core.Models;
using System;
using System.Threading.Tasks;

namespace eHub.Service.Core.Api
{
    public interface IWebInterface : IDisposable
    {
        Task<Response<T>> Get<T>(string route);
        Task<Response<T>> Get<T>(string route, object body);
        Task<Response<T>> Post<T>(string route);
        Task<Response<T>> Post<T>(string route, object body);
    }
}
