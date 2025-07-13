using BiogenomTestResults.DTO;
using BiogenomTestResults.Repositories;

namespace BiogenomTestResults.Services;

public class FoodSupplementsService(NecessaryFoodSupplementRepository necessaryFoodSupplementRepository)
{
    public async Task<FoodSupplementDto[]> GetNecessaryFoodSupplement(CancellationToken cancellationToken)
    {
        return await necessaryFoodSupplementRepository.GetNecessaryFoodSupplement(cancellationToken);
    }
}