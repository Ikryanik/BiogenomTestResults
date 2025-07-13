using BiogenomTestResults.Models;

namespace BiogenomTestResults.DTO;

public class HealthIndicatorResultDto
{
    public decimal Result { get; set; }

    public virtual HealthIndicatorDto HealthIndicator { get; set; } = null!;
}