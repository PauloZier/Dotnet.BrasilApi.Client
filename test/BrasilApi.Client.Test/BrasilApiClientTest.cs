using System;
using NUnit.Framework;

namespace BrasilApi.Client.Test
{
    public class BrasilApiClientTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            IBrasilApiClient brasilApi = new BrasilApiClient();

            brasilApi.V1.Banks.GetAsync().Wait();
            brasilApi.V2.Cep.GetAsync("89010025").Wait();

            Assert.Pass();
        }
    }
}
