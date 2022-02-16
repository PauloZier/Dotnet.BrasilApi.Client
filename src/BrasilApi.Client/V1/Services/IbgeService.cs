using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using BrasilApi.Client.V1.Interfaces.Services;
using BrasilApi.Client.V1.Models.Ibge;

namespace BrasilApi.Client.V1.Services
{
    public class IbgeService : ServiceBase, IIbgeService
    {
        public readonly string StatesUri = "api/ibge/uf/v1";
        public readonly string MunicipalitiesUri = "api/ibge/municipios/v1";
        
        public IbgeService(BrasilApiConfiguration configuration)
            : base(configuration)
        {
        }

        public async Task<IEnumerable<Municipio>> GetMunicipalitiesAsync(string siglaUF) =>
            await base.GetAsync<IEnumerable<Municipio>>($"{this.MunicipalitiesUri}/{siglaUF}");

        public async Task<IEnumerable<Estado>> GetStatesAsync() =>   
            await base.GetAsync<IEnumerable<Estado>>($"{this.StatesUri}");

        public async Task<Estado> GetStateAsync(string code) =>
            await base.GetAsync<Estado>($"{this.StatesUri}/{code}");
    }
}
