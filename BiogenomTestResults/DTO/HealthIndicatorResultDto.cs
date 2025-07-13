using BiogenomTestResults.Models;

namespace BiogenomTestResults.DTO;

public class HealthIndicatorResultDto
{
    /// <summary>
    /// Результат показателя здоровья после тестирования
    /// </summary>
    public decimal Result { get; set; }

    /// <summary>
    /// Показатель здоровья
    /// </summary>
    public HealthIndicatorDto HealthIndicator { get; set; } = null!;
}