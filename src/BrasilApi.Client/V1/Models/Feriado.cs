using System;
using System.Text.Json.Serialization;

namespace BrasilApi.Client.V1.Models
{
    public class Feriado
    {
        [JsonPropertyName("date")]
        public string Date { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }
    }
}
