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

        public async Task<DDD> GetAsync(string ddd) =>
            await base.GetAsync<DDD>($"{this.Uri}/{ddd}");
        
    }
}
