using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using BrasilApi.Client.V1.Interfaces.Services;
using BrasilApi.Client.V1.Models.Ibge;

namespace BrasilApi.Client.V1.Services
{
    public class IbgeService : IIbgeService
    {
        public readonly string StatesUri = "api/ibge/uf/v1";
        public readonly string MunicipalitiesUri = "api/ibge/municipios/v1";
        
        private readonly BrasilApiConfiguration _configuration;

        public IbgeService(BrasilApiConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentException(nameof(configuration));
        }

        public async Task<IEnumerable<Municipio>> GetMunicipalitiesAsync(string siglaUF)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_configuration.Endpoint);
                client.Timeout = _configuration.TimeOut;

                var response = await client.GetAsync($"{this.MunicipalitiesUri}/{siglaUF}");
                
                if (!response.IsSuccessStatusCode)
                    response.EnsureSuccessStatusCode();

                return await response.Content.ReadFromJsonAsync<Municipio[]>();
            }
        }

        public async Task<IEnumerable<Estado>> GetStatesAsync()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_configuration.Endpoint);
                client.Timeout = _configuration.TimeOut;

                var response = await client.GetAsync($"{this.StatesUri}");
                
                if (!response.IsSuccessStatusCode)
                    response.EnsureSuccessStatusCode();

                return await response.Content.ReadFromJsonAsync<Estado[]>();
            }
        }

        
        public async Task<Estado> GetStateAsync(string code)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_configuration.Endpoint);
                client.Timeout = _configuration.TimeOut;

                var response = await client.GetAsync($"{this.StatesUri}/{code}");
                
                if (!response.IsSuccessStatusCode)
                    response.EnsureSuccessStatusCode();

                return await response.Content.ReadFromJsonAsync<Estado>();
            }
        }
    }
}
