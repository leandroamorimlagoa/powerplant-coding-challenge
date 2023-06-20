namespace Presentation.Controllers
{
    using Domain.Interfaces.Services;
    using Domain.Models.Request;
    using Domain.Models.Response;
    using Microsoft.AspNetCore.Mvc;
    using Presentation.Extensions;

    [Route("api/[controller]")]
    [ApiController]
    public class PowerPlantController : ControllerBase
    {
        public IPowerPlantService PowerPlantService { get; }

        public PowerPlantController(IPowerPlantService powerPlantService)
        {
            PowerPlantService = powerPlantService;
        }

        [HttpGet]
        public ActionResult<string> Get()
        {
            return Ok("PowerPlantController is running.");
        }

        [HttpPost]
        public ActionResult<List<PowerPlantProduction>> CalculateProductionPlan([FromBody] LoadData loadData)
        {
            if (!loadData.IsValid(out var errors))
            {
                  return BadRequest(errors.First());
            }

            this.PowerPlantService.CalculateCostEffectiveness(loadData);
            var effectiveTotalLoad = loadData.PowerPlants.Sum(p => p.EffectivePower);

            // What we do if the requested load is greater than the effective total load?
            if (effectiveTotalLoad < loadData.Load)
            {
                return BadRequest($"Effective total load is less than requested load ({effectiveTotalLoad}).");
            }

            var productionPlan = PowerPlantService.CalculateProductionPlan(loadData);

            var totalProduction = productionPlan.Sum(p => p.Power);
            if(totalProduction != loadData.Load)
            {
                return BadRequest($"Total production is not equal to requested load ({totalProduction}).");
            }

            return productionPlan;
        }
    }
}
