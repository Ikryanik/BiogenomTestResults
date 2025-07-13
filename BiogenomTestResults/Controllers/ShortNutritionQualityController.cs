using BiogenomTestResults.DTO;
using BiogenomTestResults.Models;
using BiogenomTestResults.Services;
using Microsoft.AspNetCore.Mvc;

namespace BiogenomTestResults.Controllers;

[ApiController]
[Route("short-nutrition-quality")]
public class ShortNutritionQualityController(FoodSupplementsService foodSupplementsService, HealthIndicatorService healthIndicatorService) : ControllerBase
{
    /// <summary>
    /// Получить текущее суточное потребление
    /// </summary>
    [HttpGet("get-current-daily-intake")]
    public async Task<CurrentDailyIntakeResult> GetCurrentDailyIntake()
    {
        return await healthIndicatorService.GetCurrentDailyIntakeResult(HttpContext.RequestAborted);
    }

    /// <summary>
    /// Получить персонализированный набор
    /// </summary>
    [HttpGet("get-personalized-set")]
    public async Task<FoodSupplementDto[]> GetPersonalizedSet()
    {
        return await foodSupplementsService.GetNecessaryFoodSupplement(HttpContext.RequestAborted);
    }
    
    /// <summary>
    /// Получить новое суточное потребление с учетом персонализированного набора
    /// </summary>
    [HttpGet("get-new-daily-intake")]
    public async Task<IndicatorWithAmounts[]> GetNewDailyIntake()
    {
        return await healthIndicatorService.GetNewDailyIntake(HttpContext.RequestAborted);
    }
}