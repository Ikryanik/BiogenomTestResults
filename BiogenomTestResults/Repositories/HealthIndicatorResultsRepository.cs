using BiogenomTestResults.DbContext;
using BiogenomTestResults.DTO;
using BiogenomTestResults.Models;
using Microsoft.EntityFrameworkCore;

namespace BiogenomTestResults.Repositories;

public class HealthIndicatorResultsRepository(BopgenomdbContext context)
{
    public Task<HealthIndicatorResultDto[]> GetHealthIndicatorResults(CancellationToken cancellationToken)
    {
        return context.HealthIndicatorResults.Select(x=> new HealthIndicatorResultDto
        {
            Result = x.Result,
            HealthIndicator = Map(x.HealthIndicator)
        }) .ToArrayAsync(cancellationToken);
    }

    public async Task<IndicatorWithAmounts[]> GetNewHealthIndicatorResults(CancellationToken cancellationToken)
    {
        var result = await context.TestResults.Where(x => x.TestId == 1).Select(x =>
            new
            {
                FoodsSuplementsIndicators = x.NecessaryFoodSupplements
                    .SelectMany(z=> 
                        z.FoodSupplement.FoodSupplementInfluences
                            .Where(c => c.HealthIndicator.HealthIndicatorResults.Any(z=>z.TestResultId == 1 && z.HealthIndicator.Norm > z.Result))
                            .Select(c => new
                            {
                                c.HealthIndicatorId,
                                c.HealthIndicator.Norm,
                                c.HealthIndicator.Name,
                                FoodSupplementAmount = c.SubstanceAmount,
                                FoodAmount = 0M,
                                CurrentValue = c.HealthIndicator.HealthIndicatorResults.FirstOrDefault(c=> c.TestResultId == 1).Result
                            })).Union(
                        x.NecessaryFoods.SelectMany(z => z.Food.FoodInfluences
                            .Where(c => c.HealthIndicator.HealthIndicatorResults.Any(z => z.TestResultId == 1 && z.HealthIndicator.Norm > z.Result))
                            .Select(c => new
                            {
                                c.HealthIndicatorId,
                                c.HealthIndicator.Norm,
                                c.HealthIndicator.Name,
                                FoodSupplementAmount = 0M,
                                FoodAmount = c.SubstanceAmount,
                                CurrentValue = c.HealthIndicator.HealthIndicatorResults.FirstOrDefault(c => c.TestResultId == 1).Result
                            }))).GroupBy(x=> new { x.HealthIndicatorId, x.Name, x.Norm, x.CurrentValue }).Select(c => new IndicatorWithAmounts
                    {
                                IndicatorId = c.Key.HealthIndicatorId,
                                NormalValue = c.Key.Norm,
                                IndicatorName = c.Key.Name,
                                CurrentValue = c.Key.CurrentValue,
                                FoodSupplementValue = c.Sum(z=>z.FoodSupplementAmount),
                                FoodValue = c.Sum(z=>z.FoodAmount)
                            }).ToArray()
            }).FirstOrDefaultAsync(cancellationToken);

        return result?.FoodsSuplementsIndicators ?? Array.Empty<IndicatorWithAmounts>();
    }

    private static HealthIndicatorDto Map(HealthIndicator model)
    {
        return new HealthIndicatorDto
        {
            Id = model.Id,
            Name = model.Name,
            Norm = model.Norm
        };
    }
}