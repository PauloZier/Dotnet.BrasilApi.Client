using System;
using System.Text.Json.Serialization;

namespace BrasilApi.Client.V1.Models.Fipe
{
    public class Marca
    {
        [JsonPropertyName("nome")]
        public string Nome { get; set; }

        [JsonPropertyName("valor")]
        public string Valor { get; set; }
    }
}
