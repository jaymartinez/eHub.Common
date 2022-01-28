using System.Collections;
using System.Collections.Generic;

namespace eHub.Common.Api
{
    public interface IRequestHeaders : IEnumerable<KeyValuePair<string, string>>
    {
        string this[string headerName] { get; set; }
        bool ContainsHeader(string headerName);
        void AddOrReplaceUserHeaders(string email, string token);
        bool RemoveHeader(string headerName);
        void RemoveUserHeaders();
        void AddDeviceInfoHeaders(string os, string osVersion, string appVersion, string deviceModel);
    }

    public class EhubRequestHeaders : IRequestHeaders
    {
        IDictionary<string, string> _headers;

        public string this[string headerName]
        {
            get
            {
                if (_headers.ContainsKey(headerName))
                    return _headers[headerName];
                return null;
            }
            set
            {
                if (_headers.ContainsKey(headerName))
                    _headers[headerName] = value;
                else
                    _headers.Add(headerName, value);
            }
        }

        public EhubRequestHeaders()
        {
            _headers = new Dictionary<string, string>();
        }

        public bool ContainsHeader(string headerName) => _headers.ContainsKey(headerName);

        public void AddOrReplaceUserHeaders(string email, string token)
        {
            this["X-PoolController-Email"] = email;
            this["X-PoolController-Auth"] = token;
        }

        public bool RemoveHeader(string headerName) => _headers.Remove(headerName);

        public void RemoveUserHeaders()
        {
            _headers.Remove("X-PoolController-Email");
            _headers.Remove("X-PoolController-Auth");
        }

        public IEnumerator<KeyValuePair<string, string>> GetEnumerator()
        {
            return _headers.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void AddDeviceInfoHeaders(string os, string osVersion, string appVersion, string deviceModel)
        {
            this["X-PoolController-Ver"] = appVersion;
            this["X-PoolController-OS"] = os;
            this["X-PoolController-OSVer"] = osVersion;
            this["X-PoolController-Mod"] = deviceModel;
        }
    }
}
