using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BrasilApi.Client.V1.Models;

namespace BrasilApi.Client.V1.Interfaces.Services
{
    public interface IFeriadoService
    {
        Task<IEnumerable<Feriado>> GetAsync(string ano);
    }
}
