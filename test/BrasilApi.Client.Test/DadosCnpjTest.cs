using System;
using BrasilApi.Client.V1.Interfaces.Services;
using BrasilApi.Client.V1.Models;
using BrasilApi.Client.V1.Services;
using NUnit.Framework;

namespace BrasilApi.Client.Test
{
    public class DadosCnpjTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            IDadosCnpjService service = new DadosCnpjService(new BrasilApiConfiguration());    

            DadosCnpj dadosCnpj = service.GetAsync("19131243000197").Result;

            Assert.IsNotNull(dadosCnpj);

            Assert.Pass();
        }
    }
}
