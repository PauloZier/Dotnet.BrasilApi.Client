using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BrasilApi.Client.V1.Models.Ibge;

namespace BrasilApi.Client.V1.Interfaces.Services
{
    public interface IIbgeService
    {
        Task<IEnumerable<Municipio>> GetMunicipalitiesAsync(string siglaUF);
        Task<Estado> GetStateAsync(string code);
        Task<IEnumerable<Estado>> GetStatesAsync();
    }
}
