using BiogenomTestResults.DbContext;
using BiogenomTestResults.DTO;
using BiogenomTestResults.Models;
using Microsoft.EntityFrameworkCore;

namespace BiogenomTestResults.Repositories;

public class NecessaryFoodSupplementRepository(BopgenomdbContext context)
{
    private FoodSupplementDto[] MapFoodSupplementToDto(FoodSupplement[] foodSupplements)
    {
        return foodSupplements.Select(Map).ToArray();
    }

    private static FoodSupplementImageDto Map(FoodSupplementImage model)
    {
        return new FoodSupplementImageDto
        {
            Id = model.Id,
            Url = model.Url,
        };
    }
    private static FoodSupplementDto Map(FoodSupplement model)
    {
        return new FoodSupplementDto
        {
            Id = model.Id,
            Description = model.Description,
            Name = model.Name,
            FoodSupplementImages = model.FoodSupplementImages.Select(Map).ToArray()
        };
    }

    public async Task<FoodSupplementDto[]> GetNecessaryFoodSupplement(CancellationToken cancellationToken)
    {
        var foodSupplements = await context.NecessaryFoodSupplements.Select(x => x.FoodSupplement).ToArrayAsync(cancellationToken);

        return MapFoodSupplementToDto(foodSupplements);
    }
}