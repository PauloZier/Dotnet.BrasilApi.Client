using System;

namespace BrasilApi.Client
{
    public interface IBrasilApiClient
    {
        Versao1 V1 { get; }
        Versao2 V2 { get; }
    }
}
