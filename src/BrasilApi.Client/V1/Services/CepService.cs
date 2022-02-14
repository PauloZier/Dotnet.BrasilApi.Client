using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using BrasilApi.Client.V1.Interfaces.Services;
using BrasilApi.Client.V1.Models;

namespace BrasilApi.Client.V1.Services
{
    public class CepService : ServiceBase, ICepService
    {
        public readonly string Uri = "api/cep/v1";
        
        public CepService(BrasilApiConfiguration configuration) 
            : base(configuration)
        {
        }

        public async Task<CEP> GetAsync(string cep)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(this.Configuration.Endpoint);
                client.Timeout = this.Configuration.TimeOut;

                var response = await client.GetAsync($"{this.Uri}/{cep}");
                
                if (!response.IsSuccessStatusCode)
                    response.EnsureSuccessStatusCode();

                return await response.Content.ReadFromJsonAsync<CEP>();
            }
        }
    }
}
