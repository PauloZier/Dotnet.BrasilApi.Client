<h1 align="center">BrasilApi.Client</h1>

<hr />

<p align="center">Cliente para a [BrasilApi](https://brasilapi.com.br)</p>

<hr />

**Adicionar o pacote via NuGet:**
```
dotnet add package BrasilApi.Client --version 1.0.0
```

**Exemplo de uso:**
```cs
IBrasilApiClient brasilApi = new BrasilApiClient();

IEnumerable<Bank> banks = await brasilApi.V1.Banks.GetAsync();
```

<p>Para mais exemplos basta visualizar o [projeto de testes](https://github.com/PauloZier/Dotnet.BrasilApi.Client/tree/main/test/BrasilApi.Client.Test) deste repositório </p>