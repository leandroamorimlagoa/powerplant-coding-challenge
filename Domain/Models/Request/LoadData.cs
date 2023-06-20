namespace Domain.Models.Request
{
    public class LoadData
    {
        public decimal Load { get; set; }
        public FuelData Fuels { get; set; }
        public List<PowerPlant> PowerPlants { get; set; }
    }
}
