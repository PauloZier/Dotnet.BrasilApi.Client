using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BrasilApi.Client.V1.Models;

namespace BrasilApi.Client.V1.Interfaces.Services
{
    public interface IBankService
    {
        Task<IEnumerable<Bank>> GetAsync();
        Task<Bank> GetAsync(string code);
    }
}
