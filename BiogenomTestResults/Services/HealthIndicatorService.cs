using BiogenomTestResults.DTO;
using BiogenomTestResults.Models;
using BiogenomTestResults.Repositories;

namespace BiogenomTestResults.Services;

public class HealthIndicatorService(HealthIndicatorResultsRepository healthIndicatorResultsRepository, FoodSupplementsService foodSupplementsService)
{
    private CurrentDailyIntakeResult FilterHealthIndicatorResults(HealthIndicatorResultDto[] healthIndicatorResults)
    {
        var normal = new FiltredHealthResult
        {
            Type = FilterHealthResultType.Normal
        };

        var low = new FiltredHealthResult
        {
            Type = FilterHealthResultType.Low
        };

        foreach (var result in healthIndicatorResults)
        {
            if (result.Result >= result.HealthIndicator.Norm)
            {
                normal.HealthResult.Add(result);
            }
            else
            {
                low.HealthResult.Add(result);
            }
        }

        return new CurrentDailyIntakeResult
        {
            NormalResult = normal,
            LowResult = low
        };
    }

    public async Task<CurrentDailyIntakeResult> GetCurrentDailyIntakeResult(CancellationToken cancellationToken)
    {
        var healthIndicatorResults = await healthIndicatorResultsRepository.GetHealthIndicatorResults(cancellationToken);

        var result = FilterHealthIndicatorResults(healthIndicatorResults);

        return result;
    }

    public async Task<IndicatorWithAmounts[]> GetNewDailyIntake(CancellationToken cancellationToken)
    {
        var healthIndicatorResults = await healthIndicatorResultsRepository.GetNewHealthIndicatorResults(cancellationToken);

        return healthIndicatorResults;
    }
}