using System;
using System.Text.Json.Serialization;

namespace BrasilApi.Client.V1.Models.Ibge
{
    public class Municipio
    {
        [JsonPropertyName("nome")]
        public string Nome { get; set; }

        [JsonPropertyName("codigo_ibge")]
        public string CodigoIbge { get; set; }
    }
}
