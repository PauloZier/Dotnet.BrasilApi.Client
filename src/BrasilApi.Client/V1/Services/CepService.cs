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
            return await this.ExecuteAsync<CEP>(async (client) 
                => await client.GetAsync($"{this.Uri}/{cep}"));
        }
    }
}
