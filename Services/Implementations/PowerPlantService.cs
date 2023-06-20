namespace Services.Implementations
{
    using Domain.Interfaces.Services;
    using Domain.Models.Request;
    using Domain.Models.Response;

    public class PowerPlantService : IPowerPlantService
    {
        public void CalculateCostEffectiveness(LoadData loadData)
        {
            foreach (var powerPlant in loadData.PowerPlants)
            {
                powerPlant.EffectiveCostPerMW = CalculateEffectiveCostPerMW(powerPlant, loadData.Fuels);
                powerPlant.EffectivePower = CalculateEffectivePower(powerPlant, loadData.Fuels.WindPercentage);
            }
        }

        public List<PowerPlantProduction> CalculateProductionPlan(LoadData loadData)
        {
            loadData.PowerPlants = SortPowerPlantsByEffectiveCost(loadData.PowerPlants);

            var productionPlan = CalculatePowerDistribution(loadData.PowerPlants, loadData.Load);

            return productionPlan;
        }

        private decimal CalculateEffectivePower(PowerPlant powerPlant, decimal windPercentage)
        {
            if (powerPlant.Type == "windturbine")
            {
                return powerPlant.Pmax * windPercentage / 100;
            }
            return powerPlant.Pmax;
        }

        private decimal CalculateEffectiveCostPerMW(PowerPlant powerPlant, FuelData fuels)
        {
            switch (powerPlant.Type)
            {
                case "gasfired":
                    return fuels.GasEuroPerMWh / (1 - powerPlant.Efficiency);
                case "turbojet":
                    return fuels.KerosineEuroPerMWh / (1 - powerPlant.Efficiency);
                case "windturbine":
                    return 1;
                default:
                    return -1;
            }
        }

        private List<PowerPlant> SortPowerPlantsByEffectiveCost(List<PowerPlant> powerPlants)
        {
            return powerPlants.OrderBy(p => p.EffectiveCostPerMW).ToList();
        }

        private List<PowerPlantProduction> CalculatePowerDistribution(List<PowerPlant> powerPlants, decimal totalPower)
        {
            var productionPlan = new List<PowerPlantProduction>();
            decimal remainingLoad = totalPower;

            foreach (var powerPlant in powerPlants)
            {
                if (powerPlant.Pmin >= remainingLoad)
                {
                    continue;
                }
                if (powerPlant.EffectivePower >= remainingLoad)
                {
                    productionPlan.Add(new PowerPlantProduction { Name = powerPlant.Name, Power = remainingLoad });
                    remainingLoad = 0;
                    break;
                }
                productionPlan.Add(new PowerPlantProduction { Name = powerPlant.Name, Power = powerPlant.EffectivePower });
                remainingLoad -= powerPlant.EffectivePower;
            }

            if (remainingLoad > 0)
            {
                AdjustRemainingLoad(productionPlan, powerPlants, remainingLoad);
            }

            return productionPlan;
        }

        private void AdjustRemainingLoad(List<PowerPlantProduction> productionPlan, List<PowerPlant> powerPlants, decimal remainingLoad)
        {
            PowerPlant powerPlant;
            foreach (var item in productionPlan)
            {
                powerPlant = powerPlants.FirstOrDefault(p => p.Name == item.Name);
                if (powerPlant == null
                    || item.Power + remainingLoad >= powerPlant.EffectivePower)
                {
                    continue;
                }

                item.Power += remainingLoad;
                remainingLoad = 0;
                return;
            }

            powerPlant = powerPlants.Where(p => p.Pmin <= remainingLoad
                                                    && p.EffectivePower >= remainingLoad
                                                    && !productionPlan.Any(pp => p.Name == pp.Name))
                                        .OrderBy(p => p.EffectiveCostPerMW)
                                        .FirstOrDefault();
            if (powerPlant != null)
            {
                productionPlan.Add(new PowerPlantProduction { Name = powerPlant.Name, Power = remainingLoad });
                remainingLoad = 0;
            }
        }
    }
}
