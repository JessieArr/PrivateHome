using System;
using PrivateHome.ExtensionContracts;
using PrivateHome.ExtensionContracts.Utilities;

namespace PrivateHome.DefaultExtensions.HttpGet
{
    public class HttpGetExtension : IExtension
    {
        private IHttpClientWrapper _HttpClient;
        public HttpGetExtension(IHttpClientWrapper client)
        {
            _HttpClient = client;
        }

        public string GetSummary()
        {
            var result = _HttpClient.GetAsync("https://google.com").Result;
            return result.Content.ReadAsStringAsync().Result;
        }
    }
}