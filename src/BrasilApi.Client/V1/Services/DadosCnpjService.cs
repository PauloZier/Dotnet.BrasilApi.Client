using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using BrasilApi.Client.V1.Interfaces.Services;
using BrasilApi.Client.V1.Models;

namespace BrasilApi.Client.V1.Services
{
    public class DadosCnpjService : ServiceBase, IDadosCnpjService
    {
        public readonly string Uri = "api/cnpj/v1";
        
        public DadosCnpjService(BrasilApiConfiguration configuration)
            : base(configuration)
        {
        }

        public async Task<DadosCnpj> GetAsync(string cnpj) =>
            await base.GetAsync<DadosCnpj>($"{this.Uri}/{cnpj}");
    }
}
