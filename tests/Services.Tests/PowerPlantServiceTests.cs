using Domain.Models.Request;
using Domain.Models.Response;
using Services.Implementations;

namespace Services.Tests
{
    public class PowerPlantServiceTests
    {
        [Fact]
        public void CalculateProductionPlan_ShouldReturnCorrectProductionPlan()
        {
            // Arrange
            var service = new PowerPlantService();

            var loadData = Factory.GetData(100);
            service.CalculateCostEffectiveness(loadData);

            var expectedProductionPlan = new List<PowerPlantProduction>
            {
                new PowerPlantProduction { Name = "windpark1", Power = 50.0M },
                new PowerPlantProduction { Name = "windpark2", Power = 18M },
                new PowerPlantProduction { Name = "gasfiredbig2", Power = 32M },
            };

            // Act
            var actualProductionPlan = service.CalculateProductionPlan(loadData);

            // Assert
            Assert.Equal(expectedProductionPlan.Count, actualProductionPlan.Count);
            for (int i = 0; i < expectedProductionPlan.Count; i++)
            {
                Assert.Equal(expectedProductionPlan[i].Name, actualProductionPlan[i].Name);
                Assert.Equal(expectedProductionPlan[i].Power, actualProductionPlan[i].Power);
            }
        }
    }
}
