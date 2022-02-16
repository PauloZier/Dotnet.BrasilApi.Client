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

        public async Task<IEnumerable<Bank>> GetAsync() => 
            await base.GetAsync<IEnumerable<Bank>>(this.Uri);

        public async Task<Bank> GetAsync(string code) =>
            await base.GetAsync<Bank>($"{this.Uri}/{code}");
    }
}
