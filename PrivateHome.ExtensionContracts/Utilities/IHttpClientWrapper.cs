using System.Net.Http;
using System.Threading.Tasks;

namespace PrivateHome.ExtensionContracts.Utilities
{
    public interface IHttpClientWrapper
    {
        Task<HttpResponseMessage> GetAsync(string requestUri);
    }
}