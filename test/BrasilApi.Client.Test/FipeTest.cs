using System;
using System.Collections.Generic;
using BrasilApi.Client.V1.Interfaces.Services;
using BrasilApi.Client.V1.Models.Fipe;
using BrasilApi.Client.V1.Services;
using NUnit.Framework;

namespace BrasilApi.Client.Test
{
    public class FipeTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase(null, null)]
        [TestCase(TipoVeiculo.Caminhoes, 271)]
        [TestCase(TipoVeiculo.Carros, 271)]
        [TestCase(TipoVeiculo.Motos, 271)]
        [TestCase(TipoVeiculo.Caminhoes, null)]
        [TestCase(TipoVeiculo.Carros, null)]
        [TestCase(TipoVeiculo.Motos, null)]
        [TestCase(null, 271)]
        [TestCase(null, 271)]
        [TestCase(null, 271)]
        public void Test1(TipoVeiculo? tipoVeiculo = null, long? tabelaReferencia = null)
        {
            IFipeService service = new FipeService(new BrasilApiConfiguration());    

            IEnumerable<Marca> marcas = service.GetBrandsAsync(tipoVeiculo, tabelaReferencia).Result;

            Assert.IsNotEmpty(marcas);

            Assert.Pass();
        }

        [Test]
        [TestCase("001004-9")]
        public void Test2(string codigoFipe)
        {
            IFipeService service = new FipeService(new BrasilApiConfiguration());    

            IEnumerable<Preco> precos = service.GetPricesAsync(codigoFipe).Result;

            Assert.IsNotEmpty(precos);

            Assert.Pass();
        }

        [Test]
        public void Test3()
        {
            IFipeService service = new FipeService(new BrasilApiConfiguration());    

            IEnumerable<Tabela> tabelas = service.GetTablesAsync().Result;

            Assert.IsNotEmpty(tabelas);

            Assert.Pass();
        }
    }
}
