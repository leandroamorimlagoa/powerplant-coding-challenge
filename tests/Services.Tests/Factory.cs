using Domain.Models.Request;

namespace Services.Tests
{
    internal static class Factory
    {
        internal static LoadData GetData(decimal load)
        => new LoadData
        {
            Load = load,
            Fuels = new FuelData
            {
                GasEuroPerMWh = 13.4M,
                KerosineEuroPerMWh = 50.8M,
                CO2EuroPerTon = 20,
                WindPercentage = 50
            },
            PowerPlants = new List<PowerPlant>
                {
                    new PowerPlant
                    {
                        Name = "gasfiredbig1",
                        Type = "gasfired",
                        Efficiency = 0.6M,
                        Pmin = 50,
                        Pmax = 150
                    },
                    new PowerPlant
                    {
                        Name = "gasfiredbig2",
                        Type = "gasfired",
                        Efficiency = 0.5M,
                        Pmin = 0,
                        Pmax = 150
                    },
                    new PowerPlant
                    {
                        Name = "gasfiredsomewhatsmaller",
                        Type = "gasfired",
                        Efficiency = 0.4M,
                        Pmin = 40,
                        Pmax = 60
                    },
                    new PowerPlant
                    {
                        Name = "tj1",
                        Type = "turbojet",
                        Efficiency = 0.3M,
                        Pmin = 0,
                        Pmax = 16
                    },
                    new PowerPlant
                    {
                        Name = "windpark1",
                        Type = "windturbine",
                        Efficiency = 1,
                        Pmin = 0,
                        Pmax = 100
                    },
                    new PowerPlant
                    {
                        Name = "windpark2",
                        Type = "windturbine",
                        Efficiency = 1,
                        Pmin = 0,
                        Pmax = 36
                    }
                }
        };
    }
}
