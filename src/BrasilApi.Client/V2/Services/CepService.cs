using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using BrasilApi.Client.V2.Interfaces.Services;
using BrasilApi.Client.V2.Models;

namespace BrasilApi.Client.V2.Services
{
    public class CepService : ServiceBase, ICepService
    {
        public readonly string Uri = "api/cep/v2";
        
        public CepService(BrasilApiConfiguration configuration)
            : base(configuration)
        {
        }

        public async Task<CEP> GetAsync(string cep) =>
            await base.GetAsync<CEP>($"{this.Uri}/{cep}");
    }
}
