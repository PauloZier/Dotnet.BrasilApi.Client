using System;
using System.Threading.Tasks;
using BrasilApi.Client.V1.Models;

namespace BrasilApi.Client.V1.Interfaces.Services
{
    public interface IDDDService
    {
        Task<DDD> GetAsync(string ddd);
    }
}
