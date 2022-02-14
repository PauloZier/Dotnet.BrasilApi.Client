using System;
using System.Collections.Generic;
using BrasilApi.Client.V1.Interfaces.Services;
using BrasilApi.Client.V1.Models;
using BrasilApi.Client.V1.Services;
using NUnit.Framework;

namespace BrasilApi.Client.Test;

public class BankTest
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test1()
    {
        IBankService service = new BankService(new BrasilApiConfiguration());

        IEnumerable<Bank> banks = service.GetAsync().Result;

        Assert.IsNotEmpty(banks);

        Assert.Pass();
    }

    [Test]
    public void Test2()
    {
        IBankService service = new BankService(new BrasilApiConfiguration());

        Bank bank = service.GetAsync("1").Result;

        Assert.IsNotNull(bank);

        Assert.Pass();
    }

    [Test]
    public void Test3()
    {
        try
        {
            IBankService service = new BankService(new BrasilApiConfiguration());

            Bank bank = service.GetAsync("31231512").Result;
        }
        catch (BrasilApiClientException)
        {
            Assert.Pass();
        }

        Assert.Pass();
    }
}