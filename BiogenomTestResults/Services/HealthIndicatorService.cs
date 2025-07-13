using BiogenomTestResults.DTO;
using BiogenomTestResults.Models;
using BiogenomTestResults.Repositories;

namespace BiogenomTestResults.Services;

public class HealthIndicatorService(HealthIndicatorResultsRepository healthIndicatorResultsRepository)
{
    private CurrentDailyIntakeResult FilterHealthIndicatorResults(HealthIndicatorResultDto[] healthIndicatorResults)
    {
        var lowList = new List<HealthIndicatorResultDto>();
        var normalList = new List<HealthIndicatorResultDto>();

        foreach (var result in healthIndicatorResults)
        {
            if (result.Result >= result.HealthIndicator.Norm)
            {
                normalList.Add(result);
            }
            else
            {
                lowList.Add(result);
            }
        }

        var normal = new FiltredHealthResult
        {
            Type = FilterHealthResultType.Normal,
            HealthResult = normalList.ToArray()
        };

        var low = new FiltredHealthResult
        {
            Type = FilterHealthResultType.Low,
            HealthResult = lowList.ToArray()
        };

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