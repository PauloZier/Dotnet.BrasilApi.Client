using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BrasilApi.Client.V1.Models
{
    public class DDD
    {
        [JsonPropertyName("state")]
        public string State { get; set; }

        [JsonPropertyName("cities")]
        public IList<string> Cities { get; set; }
    }
}
