namespace BiogenomTestResults.DTO;

public class HealthIndicatorAfterTreatmentDto
{
    public decimal OldResult { get; set; }

    public HealthIndicatorDto HealthIndicator { get; set; } = null!;
}