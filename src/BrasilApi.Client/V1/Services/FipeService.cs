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
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(this.Configuration.Endpoint);
                client.Timeout = this.Configuration.TimeOut;

                var uri = tipoVeiculo != null 
                    ? $"{this.BrandsUri}/{tipoVeiculo.ToString().ToLower()}" 
                    : this.BrandsUri;

                if (tabelaReferencia != null)
                    uri = $"{uri}?tabela_referencia={tabelaReferencia}";

                var response = await client.GetAsync(uri);
                
                if (!response.IsSuccessStatusCode)
                    response.EnsureSuccessStatusCode();

                return await response.Content.ReadFromJsonAsync<Marca[]>();
            }
        }

        public async Task<IEnumerable<Preco>> GetPricesAsync(string codigoFipe, long? tabelaReferencia = null)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(this.Configuration.Endpoint);
                client.Timeout = this.Configuration.TimeOut;

                var uri = $"{this.PricesUri}/{codigoFipe}";
                
                if (tabelaReferencia != null)
                    uri = $"{uri}?tabela_referencia={tabelaReferencia}";

                var response = await client.GetAsync(uri);
                
                if (!response.IsSuccessStatusCode)
                    response.EnsureSuccessStatusCode();

                return await response.Content.ReadFromJsonAsync<Preco[]>();
            }
        }

        public async Task<IEnumerable<Tabela>> GetTablesAsync()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(this.Configuration.Endpoint);
                client.Timeout = this.Configuration.TimeOut;

                var response = await client.GetAsync($"{this.TablesUri}");
                
                if (!response.IsSuccessStatusCode)
                    response.EnsureSuccessStatusCode();

                return await response.Content.ReadFromJsonAsync<Tabela[]>();
            }
        }
    }
}
