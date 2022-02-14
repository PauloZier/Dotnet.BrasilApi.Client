using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using BrasilApi.Client.V1.Interfaces.Services;
using BrasilApi.Client.V1.Models;

namespace BrasilApi.Client.V1.Services
{
    public class CepService : ICepService
    {
        public readonly string Uri = "api/cep/v1";
        
        private readonly BrasilApiConfiguration _configuration;

        public CepService(BrasilApiConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentException(nameof(configuration));
        }

        public async Task<CEP> GetAsync(string cep)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_configuration.Endpoint);
                client.Timeout = _configuration.TimeOut;

                var response = await client.GetAsync($"{this.Uri}/{cep}");
                
                if (!response.IsSuccessStatusCode)
                    response.EnsureSuccessStatusCode();

                return await response.Content.ReadFromJsonAsync<CEP>();
            }
        }
    }
}
