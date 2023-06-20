namespace Domain.Models.Request
{
    public class PowerPlant
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public decimal Efficiency { get; set; }
        public decimal EffectiveCostPerMW { get; set; }
        public decimal Pavailable { get; set; }
        public decimal Pmin { get; set; }
        public decimal Pmax { get; set; }
        public decimal EffectivePower { get; set; }
    }
}
