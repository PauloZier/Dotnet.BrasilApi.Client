using System.Net.Http;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BrasilApi.Client.V1.Interfaces.Services;
using BrasilApi.Client.V1.Models;
using System.Net.Http.Json;

namespace BrasilApi.Client.V1.Services
{
    public class BankService : ServiceBase, IBankService
    {
        public readonly string Uri = "api/banks/v1";
        
        public BankService(BrasilApiConfiguration configuration) 
            : base(configuration)
        {
        }

        public async Task<IEnumerable<Bank>> GetAsync()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(this.Configuration.Endpoint);
                client.Timeout = this.Configuration.TimeOut;

                var response = await client.GetAsync(this.Uri);
                
                if (!response.IsSuccessStatusCode)
                    response.EnsureSuccessStatusCode();

                return await response.Content.ReadFromJsonAsync<Bank[]>();
            }
        }

        public async Task<Bank> GetAsync(string code)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(this.Configuration.Endpoint);
                client.Timeout = this.Configuration.TimeOut;
                
                var response = await client.GetAsync($"{this.Uri}/{code}");
                
                if (!response.IsSuccessStatusCode)
                    response.EnsureSuccessStatusCode();

                return await response.Content.ReadFromJsonAsync<Bank>();
            }
        }
    }
}
