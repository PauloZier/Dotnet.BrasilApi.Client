using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using BrasilApi.Client.V1.Interfaces.Services;
using BrasilApi.Client.V1.Models;

namespace BrasilApi.Client.V1.Services
{
    public class FeriadoService : IFeriadoService
    {
        public readonly string Uri = "api/feriados/v1";
        
        private readonly BrasilApiConfiguration _configuration;

        public FeriadoService(BrasilApiConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentException(nameof(configuration));
        }

        public async Task<IEnumerable<Feriado>> GetAsync(string ano)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_configuration.Endpoint);
                client.Timeout = _configuration.TimeOut;

                var response = await client.GetAsync($"{this.Uri}/{ano}");
                
                if (!response.IsSuccessStatusCode)
                    response.EnsureSuccessStatusCode();

                return await response.Content.ReadFromJsonAsync<Feriado[]>();
            }
        }
    }
}
