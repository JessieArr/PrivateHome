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
            var url = "http://google.com";
            var result = _HttpClient.GetAsync("https://google.com").Result;
            return $"<p><a href=\"{url}\" target=\"_blank\" >{url}</a> status: {result.StatusCode}</p>";
        }
    }
}