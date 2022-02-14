using System;

namespace BrasilApi.Client
{
    public class BrasilApiConfiguration
    {
        public string Endpoint { get; set; } = "https://brasilapi.com.br";
        public TimeSpan TimeOut { get; set; } = TimeSpan.FromSeconds(5);

        public BrasilApiConfiguration()
        {
        }

        public BrasilApiConfiguration(string endpoint, TimeSpan timeOut)
        {
            Endpoint = endpoint;
            TimeOut = timeOut;
        }
    }
}
