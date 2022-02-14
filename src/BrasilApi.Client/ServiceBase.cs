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

        protected async Task<T> ExecuteAsync<T>(Func<HttpClient, Task<HttpResponseMessage>> func)
        {
            HttpResponseMessage responseMessage = null;

            try
            {
                using (var client = this.CreateHttpClient())
                {
                    responseMessage = await func(client);
                    responseMessage.EnsureSuccessStatusCode();
                    return await responseMessage.Content.ReadFromJsonAsync<T>();
                }
            }
            catch (HttpRequestException ex)
            {
                throw new BrasilApiClientException(responseMessage, ex.Message, ex);
            }
            catch
            {
                throw;
            }
        }
    }
}
