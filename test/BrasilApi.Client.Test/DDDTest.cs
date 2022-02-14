using System;
using BrasilApi.Client.V1.Interfaces.Services;
using BrasilApi.Client.V1.Models;
using BrasilApi.Client.V1.Services;
using NUnit.Framework;

namespace BrasilApi.Client.Test
{
    public class DDDTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            IDDDService service = new DDDService(new BrasilApiConfiguration());    

            DDD ddd = service.GetAsync("11").Result;

            Assert.IsNotNull(ddd);

            Assert.Pass();
        }
    }
}
