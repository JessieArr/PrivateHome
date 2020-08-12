using PrivateHome.ExtensionContracts.Utilities;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PrivateHome.Utilities
{
    public class HttpClientWrapper : IHttpClientWrapper
    {
        private HttpClient _WrappedClient { get; set; }
        public HttpClientWrapper(HttpClient client)
        {
            _WrappedClient = client;            
        }

        public async Task<HttpResponseMessage> GetAsync(string requestUri)
        {
            return await _WrappedClient.GetAsync(requestUri);
        }
    }
}
