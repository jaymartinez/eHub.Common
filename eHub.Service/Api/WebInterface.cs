using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using eHub.Common.Models;
using Newtonsoft.Json;
using JsonHelper = eHub.Common.Helpers.SerializationHelper;

namespace eHub.Common.Api
{
    public class WebInterface : IWebInterface
    {
        const string BaseUrl = "http://192.168.0.17:9000/";

        readonly HttpClient _client;

        public WebInterface()
        {
            /*
            var handler = new HttpClientHandler
            {
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
            };
            _client = new HttpClient(handler)
            */

            _client = new HttpClient()
            {
                BaseAddress = new Uri(BaseUrl)
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
                Console.WriteLine($"\n\t--->Error in Get<T>({route})...{e.Message}\n\t{e.StackTrace}");
                throw e;
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
            var result = JsonConvert.DeserializeObject<T>(json);
            return result;
        }

        void IDisposable.Dispose()
        {
            _client?.Dispose();
        }
    }
}
