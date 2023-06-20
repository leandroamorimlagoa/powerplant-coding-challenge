using Domain.Models.Request;

namespace Presentation.Extensions
{
    public static class LoadDataExtensions
    {
        public static bool IsValid(this LoadData loadData, out List<string> errors)
        {
            errors = new List<string>();
            if (loadData == null)
            {
                errors.Add("LoadData is null.");
                return false;
            }

            if (loadData.Load <= 0 || loadData.PowerPlants.Count == 0)
            {
                errors.Add("Load must be greater than 0.");
            }

            if (loadData.Fuels == null)
            {
                errors.Add("Fuels is null.");
            }

            if (loadData.PowerPlants == null || loadData.PowerPlants.Count == 0)
            {
                errors.Add("PowerPlants is null or empty.");
            }
            return errors.Count == 0;
        }
    }
}
