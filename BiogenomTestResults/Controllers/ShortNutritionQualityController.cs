using BiogenomTestResults.DTO;
using BiogenomTestResults.Models;
using BiogenomTestResults.Services;
using Microsoft.AspNetCore.Mvc;

namespace BiogenomTestResults.Controllers;

[ApiController]
[Route("[controller]")]
public class ShortNutritionQualityController(FoodSupplementsService foodSupplementsService, HealthIndicatorService healthIndicatorService) : ControllerBase
{
    [HttpGet("get-personalized-set")]
    public async Task<FoodSupplementDto[]> GetPersonalizedSet()
    {
        return await foodSupplementsService.GetNecessaryFoodSupplement(HttpContext.RequestAborted);
    }

    [HttpGet("get-current-daily-intake")]
    public async Task<CurrentDailyIntakeResult> GetCurrentDailyIntake()
    {
        return await healthIndicatorService.GetCurrentDailyIntakeResult(HttpContext.RequestAborted);
    }

    [HttpGet("get-new-daily-intake")]
    public async Task<IndicatorWithAmounts[]> GetNewDailyIntake()
    {
        return await healthIndicatorService.GetNewDailyIntake(HttpContext.RequestAborted);
    }
}