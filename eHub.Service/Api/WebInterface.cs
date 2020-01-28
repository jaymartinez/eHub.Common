using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using eHub.Common.Models;
using JsonHelper = eHub.Common.Helpers.SerializationHelper;

namespace eHub.Common.Api
{
    public class WebInterface : IWebInterface
    {
        readonly string _baseUrl;

        readonly HttpClient _client;

        public WebInterface(Configuration config)
        {
            _baseUrl = $"{config.Environment.ApiBaseRoute}:{config.Environment.Port}/";

            _client = new HttpClient()
            {
                BaseAddress = new Uri(_baseUrl)
            };
        }

        public async Task<T> Get<T>(string route)
        {
            try
            {
                var uri = new Uri(_client.BaseAddress, route);
                var request = new HttpRequestMessage(HttpMethod.Get, uri);
                _client.Timeout = TimeSpan.FromSeconds(5);
                var response = await _client.SendAsync(request);
                return await HandleResponse<T>(response);
            }
            catch (Exception)
            {
                Console.WriteLine($"\n\t--->Error in Get<T>({route})");
                return default(T);
            }
        }

        public async Task<T> Get<T>(string route, object body)
        {
            try
            {
                var uri = new Uri(_client.BaseAddress, route);
                var request = new HttpRequestMessage(HttpMethod.Get, uri)
                {
                    Content = GetBodyContent(body)
                };

                var response = await _client.SendAsync(request);
                return await HandleResponse<T>(response);
            }
            catch (Exception e)
            {
                Console.WriteLine($"\n\t--->Error in Get<T>(route, body)...{e.Message}\n\t{e.StackTrace}");
                throw e;
            }
        }

        Task<T> IWebInterface.Post<T>(string route)
        {
            throw new NotImplementedException();
        }

        Task<T> IWebInterface.Post<T>(string route, object body)
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
            var result = JsonHelper.JsonToObject<T>(json);
            return result;
        }

        void IDisposable.Dispose()
        {
            _client?.Dispose();
        }
    }
}
