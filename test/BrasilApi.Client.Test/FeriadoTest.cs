using System;
using System.Collections.Generic;
using BrasilApi.Client.V1.Interfaces.Services;
using BrasilApi.Client.V1.Models;
using BrasilApi.Client.V1.Services;
using NUnit.Framework;

namespace BrasilApi.Client.Test
{
    public class FeriadoTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            IFeriadoService service = new FeriadoService(new BrasilApiConfiguration());    

            IEnumerable<Feriado> feriados = service.GetAsync("2022").Result;

            Assert.IsNotEmpty(feriados);

            Assert.Pass();
        }
    }
}
