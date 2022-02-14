using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BrasilApi.Client.V1.Models.Fipe;

namespace BrasilApi.Client.V1.Interfaces.Services
{
    public interface IFipeService
    {
        Task<IEnumerable<Marca>> GetBrandsAsync(TipoVeiculo? tipoVeiculo = null, long? tabelaReferencia = null);
        Task<IEnumerable<Preco>> GetPricesAsync(string codigoFipe, long? tabelaReferencia = null);
        Task<IEnumerable<Tabela>> GetTablesAsync();
    }
}
