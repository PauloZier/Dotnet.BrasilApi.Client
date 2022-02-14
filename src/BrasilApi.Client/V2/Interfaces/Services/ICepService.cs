using System;
using System.Threading.Tasks;
using BrasilApi.Client.V2.Models;

namespace BrasilApi.Client.V2.Interfaces.Services
{
    public interface ICepService
    {
        Task<CEP> GetAsync(string cep);
    }
}
