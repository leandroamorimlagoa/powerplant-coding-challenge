namespace Domain.Interfaces.Services
{
    using Domain.Models.Request;
    using Domain.Models.Response;

    public interface IPowerPlantService
    {
        public List<PowerPlantProduction> CalculateProductionPlan(LoadData loadData);
        public void CalculateCostEffectiveness(LoadData loadData);
    }
}
