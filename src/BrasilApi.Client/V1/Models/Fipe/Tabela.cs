using System;
using System.Text.Json.Serialization;

namespace BrasilApi.Client.V1.Models.Fipe
{
    public class Tabela
    {
        [JsonPropertyName("codigo")]
        public int Codigo { get; set; }

        [JsonPropertyName("mes")]
        public string Mes { get; set; }
    }
}
