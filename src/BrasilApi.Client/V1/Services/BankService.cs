using System.Net.Http;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BrasilApi.Client.V1.Interfaces.Services;
using BrasilApi.Client.V1.Models;
using System.Net.Http.Json;

namespace BrasilApi.Client.V1.Services
{
    public class BankService : IBankService
    {
        public readonly string Uri = "api/banks/v1";
        
        private readonly BrasilApiConfiguration _configuration;

        public BankService(BrasilApiConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentException(nameof(configuration));
        }

        public async Task<IEnumerable<Bank>> GetAsync()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_configuration.Endpoint);
                client.Timeout = _configuration.TimeOut;

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
                client.BaseAddress = new Uri(_configuration.Endpoint);
                client.Timeout = _configuration.TimeOut;
                
                var response = await client.GetAsync($"{this.Uri}/{code}");
                
                if (!response.IsSuccessStatusCode)
                    response.EnsureSuccessStatusCode();

                return await response.Content.ReadFromJsonAsync<Bank>();
            }
        }
    }
}
