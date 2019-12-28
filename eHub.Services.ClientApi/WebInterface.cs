using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using eHub.Services.Core.Models;

namespace eHub.Services.Api
{
    public class WebInterface : IWebInterface
    {
        readonly HttpClient _client;

        public WebInterface()
        {
            _client = new HttpClient();
        }

        Task<T> IWebInterface.Get<T>(string route)
        {
            throw new NotImplementedException();
        }

        Task<Response<T>> IWebInterface.Get<T>(string route, object body)
        {
            throw new NotImplementedException();
        }

        Task<T> IWebInterface.Post<T>(string route)
        {
            throw new NotImplementedException();
        }

        Task<Response<T>> IWebInterface.Post<T>(string route, object body)
        {
            throw new NotImplementedException();
        }

        void IDisposable.Dispose()
        {
            _client?.Dispose();
        }
    }
}
