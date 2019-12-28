using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using eHub.Service.Core.Models;

using JsonHelper = eHub.Service.Core.Api.SerializationHelper;

namespace eHub.Service.Core.Api
{
    public class WebInterface : IWebInterface
    {
        const string BaseUrl = "http://192.168.0.17:9000";

        readonly HttpClient _client;

        public WebInterface()
        {
            var handler = new HttpClientHandler
            {
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
            };

            _client = new HttpClient(handler)
            {
                BaseAddress = new Uri(BaseUrl)
            };
        }

        public async Task<Response<T>> Get<T>(string route)
        {
            var uri = new Uri(_client.BaseAddress, route);
            var request = new HttpRequestMessage(HttpMethod.Get, uri);
            try
            {
                var response = await _client.SendAsync(request);
                return await HandleResponse<Response<T>>(response);
            }
            catch (Exception e)
            {
                return new Response<T>
                {
                    Messages = new List<string> { $"Error: {e.Message} \\nStackTrace:{e.StackTrace}" }
                };
            }
        }

        public async Task<Response<T>> Get<T>(string route, object body)
        {
            var uri = new Uri(_client.BaseAddress, route);
            var request = new HttpRequestMessage(HttpMethod.Get, uri)
            {
                Content = GetBodyContent(body)
            };

            try
            {
                var response = await _client.SendAsync(request);
                return await HandleResponse<Response<T>>(response);
            }
            catch (Exception e)
            {
                return new Response<T>
                {
                    Messages = new List<string> { $"Error: {e.Message} \\nStackTrace:{e.StackTrace}" }
                };
            }

        }

        Task<Response<T>> IWebInterface.Post<T>(string route)
        {
            throw new NotImplementedException();
        }

        Task<Response<T>> IWebInterface.Post<T>(string route, object body)
        {
            throw new NotImplementedException();
        }


        HttpContent GetBodyContent(object body)
        {
            if (body == null)
            {
                return new StringContent("");
            }

            var json = JsonHelper.ObjectToJson(body);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            return content;
        }

        async Task<T> HandleResponse<T>(HttpResponseMessage response)
        {
            if (response.StatusCode != HttpStatusCode.OK
                || (int)response.StatusCode != 200)
            {
                return default(T);
            }

            var json = await response.Content.ReadAsStringAsync();
            return JsonHelper.JsonToObject<T>(json);
        }


        void IDisposable.Dispose()
        {
            _client?.Dispose();
        }
    }
}
