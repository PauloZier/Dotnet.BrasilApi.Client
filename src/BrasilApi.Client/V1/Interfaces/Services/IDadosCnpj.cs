using System;
using System.Threading.Tasks;
using BrasilApi.Client.V1.Models;

namespace BrasilApi.Client.V1.Interfaces.Services
{
    public interface IDadosCnpjService
    {
        Task<DadosCnpj> GetAsync(string cnpj);
    }
}
