using System;
using System.Text.Json.Serialization;

namespace BrasilApi.Client.V1.Models.Fipe
{
    public class Preco
    {
        [JsonPropertyName("valor")]
        public string Valor { get; set; }

        [JsonPropertyName("marca")]
        public string Marca { get; set; }

        [JsonPropertyName("modelo")]
        public string Modelo { get; set; }

        [JsonPropertyName("anoModelo")]
        public int AnoModelo { get; set; }

        [JsonPropertyName("combustivel")]
        public string Combustivel { get; set; }

        [JsonPropertyName("codigoFipe")]
        public string CodigoFipe { get; set; }

        [JsonPropertyName("mesReferencia")]
        public string MesReferencia { get; set; }

        [JsonPropertyName("tipoVeiculo")]
        public int TipoVeiculo { get; set; }

        [JsonPropertyName("siglaCombustivel")]
        public string SiglaCombustivel { get; set; }

        [JsonPropertyName("dataConsulta")]
        public string DataConsulta { get; set; }
    }
}
