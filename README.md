<h1 align="center">BrasilApi.Client</h1>

<hr />

<p align="center">Cliente para a <a href="https://brasilapi.com.br">BrasilApi</a></p>

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

<p>Para mais exemplos basta visualizar o <a href="https://github.com/PauloZier/Dotnet.BrasilApi.Client/tree/main/test/BrasilApi.Client.Test">projeto de testes</a> deste repositório </p>
