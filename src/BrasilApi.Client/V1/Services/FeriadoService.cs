using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using BrasilApi.Client.V1.Interfaces.Services;
using BrasilApi.Client.V1.Models;

namespace BrasilApi.Client.V1.Services
{
    public class FeriadoService : ServiceBase, IFeriadoService
    {
        public readonly string Uri = "api/feriados/v1";
        
        public FeriadoService(BrasilApiConfiguration configuration)
            : base(configuration)
        {
        }

        public async Task<IEnumerable<Feriado>> GetAsync(string ano)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(this.Configuration.Endpoint);
                client.Timeout = this.Configuration.TimeOut;

                var response = await client.GetAsync($"{this.Uri}/{ano}");
                
                if (!response.IsSuccessStatusCode)
                    response.EnsureSuccessStatusCode();

                return await response.Content.ReadFromJsonAsync<Feriado[]>();
            }
        }
    }
}
