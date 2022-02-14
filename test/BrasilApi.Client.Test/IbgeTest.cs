using System.Collections.Generic;
using BrasilApi.Client.V1.Interfaces.Services;
using BrasilApi.Client.V1.Models.Ibge;
using BrasilApi.Client.V1.Services;
using NUnit.Framework;

namespace BrasilApi.Client.Test
{
    public class IbgeTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase("PR")]
        [TestCase("SP")]
        [TestCase("MG")]

        public void Test1(string siglaUF)
        {
            IIbgeService service = new IbgeService(new BrasilApiConfiguration());    

            IEnumerable<Municipio> municipios = service.GetMunicipalitiesAsync(siglaUF).Result;

            Assert.IsNotEmpty(municipios);

            Assert.Pass();
        }

        [Test]
        public void Test2()
        {
            IIbgeService service = new IbgeService(new BrasilApiConfiguration());    

            IEnumerable<Estado> estados = service.GetStatesAsync().Result;

            Assert.IsNotEmpty(estados);

            Assert.Pass();
        }

        [Test]
        [TestCase("35")]
        [TestCase("PR")]
        public void Test3(string code)
        {
            IIbgeService service = new IbgeService(new BrasilApiConfiguration());    

            Estado estado = service.GetStateAsync(code).Result;

            Assert.IsNotNull(estado);

            Assert.Pass();
        }
    }
}
