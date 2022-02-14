using System;
using System.Text.Json.Serialization;

namespace BrasilApi.Client.V1.Models.Ibge
{
    public class Regiao
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("sigla")]
        public string Sigla { get; set; }

        [JsonPropertyName("nome")]
        public string Nome { get; set; }
    }

    public class Estado
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("sigla")]
        public string Sigla { get; set; }

        [JsonPropertyName("nome")]
        public string Nome { get; set; }

        [JsonPropertyName("regiao")]
        public Regiao Regiao { get; set; }
    }
}
