using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using BrasilApi.Client.V1.Interfaces.Services;
using BrasilApi.Client.V1.Models;

namespace BrasilApi.Client.V1.Services
{
    public class DadosCnpjService : ServiceBase, IDadosCnpjService
    {
        public readonly string Uri = "api/cnpj/v1";
        
        public DadosCnpjService(BrasilApiConfiguration configuration)
            : base(configuration)
        {
        }

        public async Task<DadosCnpj> GetAsync(string cnpj)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(this.Configuration.Endpoint);
                client.Timeout = this.Configuration.TimeOut;

                var response = await client.GetAsync($"{this.Uri}/{cnpj}");
                
                if (!response.IsSuccessStatusCode)
                    response.EnsureSuccessStatusCode();

                return await response.Content.ReadFromJsonAsync<DadosCnpj>();
            }
        }
    }
}
