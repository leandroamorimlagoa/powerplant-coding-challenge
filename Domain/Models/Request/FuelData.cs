using System.Text.Json;
using System.Text.Json.Serialization;

namespace Domain.Models.Request
{
    public class FuelData
    {
        [JsonPropertyName("gas(euro/MWh)")]
        public decimal GasEuroPerMWh { get; set; }

        [JsonPropertyName("kerosine(euro/MWh)")]
        public decimal KerosineEuroPerMWh { get; set; }

        [JsonPropertyName("co2(euro/ton)")]
        public decimal CO2EuroPerTon { get; set; }

        [JsonPropertyName("wind(%)")]
        public decimal WindPercentage { get; set; }
    }
}
