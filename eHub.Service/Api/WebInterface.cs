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
        readonly HttpClient _client;

        /// <summary>
        /// Add and remove request headers from this property. These headers will be added to each web request made.
        /// </summary>
        public IRequestHeaders RequestHeaders { get; }

        public WebInterface(Configuration config)
        {
            var baseUrl = $"{config.Environment.ApiBaseRoute}:{config.Environment.Port}/";

            _client = new HttpClient()
            {
                BaseAddress = new Uri(baseUrl),
                Timeout = TimeSpan.FromSeconds(8)
            };
        }

        public async Task<T> Get<T>(string route)
        {
            try
            {
                var uri = new Uri(_client.BaseAddress, route);
                var request = new HttpRequestMessage(HttpMethod.Get, uri);
                var response = await _client.SendAsync(request);
                return await HandleResponse<T>(response);
            }
            catch (Exception e)
            {
                Console.WriteLine($"\n\t--->Error in Get<T>({route}) - ERROR MSG: {e.Message}");
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

        public async Task<Response<WaterTemp>> GetWaterTemp(string route)
        {
            var url = "http://192.168.0.16";
            var port = 5000;

            try
            {
                var baseAddr = new Uri($"{url}:{port}/");
                var uri = new Uri(baseAddr, route);
                var request = new HttpRequestMessage(HttpMethod.Get, uri);
                var response = await _client.SendAsync(request);
                return await HandleResponse<Response<WaterTemp>>(response);
            }
            catch (Exception e)
            {
                Console.WriteLine($"\n\t--->Error in GetWaterTemp(route)...{e.Message}\n\t{e.StackTrace}");
                return new Response<WaterTemp>()
                {
                    Data = new WaterTemp()
                    {
                        ValueF = 0,
                        ValueC = 0
                    }
                };
            }

        }

        Task<T> IWebInterface.Post<T>(string route)
        {
            throw new NotImplementedException();
        }

        async Task<T> IWebInterface.Post<T>(string route, object body)
        {
            
            var uri = new Uri(_client.BaseAddress, route);
            var content = GetBodyContent(body);
            var request = AssembleRequest(HttpMethod.Post, uri, content);

            try
            {
                var response = await _client.SendAsync(request);
                return await HandleResponse<T>(response);
            }
            catch (Exception e)
            {
                Console.WriteLine($"\n\t--->Error in Get<T>(route, body)...{e.Message}\n\t{e.StackTrace}");
                throw e;
            }
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

        HttpRequestMessage AssembleRequest(HttpMethod method, Uri uri, HttpContent content = null)
        {
            var req = new HttpRequestMessage(method, uri);

            if (RequestHeaders != null)
            {
                foreach (var header in RequestHeaders)
                {
                    req.Headers.Add(header.Key, header.Value);
                }
            }

            if (content != null)
            {
                req.Content = content;
            }

            return req;
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
