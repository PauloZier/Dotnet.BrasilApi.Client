using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using BrasilApi.Client.V1.Interfaces.Services;
using BrasilApi.Client.V1.Models;

namespace BrasilApi.Client.V1.Services
{
    public class DDDService : ServiceBase, IDDDService
    {
        public readonly string Uri = "api/ddd/v1";
        
        public DDDService(BrasilApiConfiguration configuration)
            : base(configuration)
        {
        }

        public async Task<DDD> GetAsync(string ddd)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(this.Configuration.Endpoint);
                client.Timeout = this.Configuration.TimeOut;

                var response = await client.GetAsync($"{this.Uri}/{ddd}");
                
                if (!response.IsSuccessStatusCode)
                    response.EnsureSuccessStatusCode();

                return await response.Content.ReadFromJsonAsync<DDD>();
            }
        }
    }
}
