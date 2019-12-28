using eHub.Services.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eHub.Services.Api
{
    public interface IWebInterface : IDisposable
    {
        Task<T> Get<T>(string route);
        Task<Response<T>> Get<T>(string route, object body);
        Task<T> Post<T>(string route);
        Task<Response<T>> Post<T>(string route, object body);
    }
}
