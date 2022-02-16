using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using BrasilApi.Client.V1.Interfaces.Services;
using BrasilApi.Client.V1.Models.Fipe;

namespace BrasilApi.Client.V1.Services
{
    public class FipeService : ServiceBase, IFipeService
    {
        public readonly string BrandsUri = "api/fipe/marcas/v1";
        public readonly string PricesUri = "api/fipe/preco/v1";
        public readonly string TablesUri = "api/fipe/tabelas/v1";
    
        public FipeService(BrasilApiConfiguration configuration)
            : base(configuration)
        {
        }

        public async Task<IEnumerable<Marca>> GetBrandsAsync(TipoVeiculo? tipoVeiculo = null, long? tabelaReferencia = null)
        {
            var uri = tipoVeiculo != null 
                ? $"{this.BrandsUri}/{tipoVeiculo.ToString().ToLower()}" 
                : this.BrandsUri;

            if (tabelaReferencia != null)
                uri = $"{uri}?tabela_referencia={tabelaReferencia}";

            return await base.GetAsync<IEnumerable<Marca>>(uri);            
        }

        public async Task<IEnumerable<Preco>> GetPricesAsync(string codigoFipe, long? tabelaReferencia = null)
        {
            var uri = $"{this.PricesUri}/{codigoFipe}";
            
            if (tabelaReferencia != null)
                uri = $"{uri}?tabela_referencia={tabelaReferencia}";

            return await base.GetAsync<IEnumerable<Preco>>(uri);
        }

        public async Task<IEnumerable<Tabela>> GetTablesAsync() => 
            await base.GetAsync<IEnumerable<Tabela>>($"{this.TablesUri}");
    }
}
