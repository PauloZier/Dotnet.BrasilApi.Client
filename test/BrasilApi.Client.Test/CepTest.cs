using System;
using NUnit.Framework;

namespace BrasilApi.Client.Test
{
    public class CepTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            V1.Interfaces.Services.ICepService service = new V1.Services.CepService(new BrasilApiConfiguration());    

            V1.Models.CEP cep = service.GetAsync("89010025").Result;

            Assert.IsNotNull(cep);

            Assert.Pass();
        }

        [Test]
        public void Test2()
        {
            V2.Interfaces.Services.ICepService service = new V2.Services.CepService(new BrasilApiConfiguration());    

            V2.Models.CEP cep = service.GetAsync("89010025").Result;

            Assert.IsNotNull(cep);

            Assert.Pass();
        }
    }
}
