using System.Text.Json.Serialization;

namespace ConsumerKafka.Domain.Entity
{
    public class BeneficiarioEntity
    {
        [JsonPropertyName("MES REFERENCIA")]
        public string MesReferencia { get; set; }

        [JsonPropertyName("MES COMPETENCIA")]
        public string MesCompetencia { get; set; }
        
        [JsonPropertyName("UF")]
        public string Uf { get; set; }
        
        [JsonPropertyName("CODIGO MUNICIPIO SIAFI")]
        public string CodigoMunicipioSiafi { get; set; }
       
        [JsonPropertyName("NOME MUNICIPIO")]
        public string NomeMunicipio { get; set; }
        
        [JsonPropertyName("NIS FAVORECIDO")]
        public string NisFavorecido { get; set; }
       
        [JsonPropertyName("NOME FAVORECIDO")]
        public string NomeFavorecido { get; set; }
       
        [JsonPropertyName("VALOR PARCELA")]
        public string ValorParcela { get; set; }
    }
}