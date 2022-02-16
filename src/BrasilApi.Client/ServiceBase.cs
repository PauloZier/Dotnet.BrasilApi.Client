using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BrasilApi.Client
{
    public abstract class ServiceBase
    {
        protected BrasilApiConfiguration Configuration { get; }

        public ServiceBase(BrasilApiConfiguration configuration)
        {
            Configuration = configuration ?? throw new ArgumentException(nameof(configuration));
        }

        protected HttpClient CreateHttpClient()
        {
            return new HttpClient
            {
                BaseAddress = new Uri(this.Configuration.Endpoint),
                Timeout = this.Configuration.TimeOut
            };
        }

        protected void EnsureSuccessStatusCode(HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
                throw new BrasilApiClientException(response, "Ocorreu um erro ao tentar consultar a BrasilAPI!");
        }

        protected async Task<T> GetAsync<T>(string uri)
        {
            using (var client = this.CreateHttpClient())
            {
                var response = await client.GetAsync(uri);
                this.EnsureSuccessStatusCode(response);
                return await response.Content.ReadFromJsonAsync<T>();
            }
        }
    }
}
