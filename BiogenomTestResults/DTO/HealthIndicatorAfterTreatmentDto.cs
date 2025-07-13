namespace BiogenomTestResults.DTO;

public class HealthIndicatorAfterTreatmentDto
{
    public decimal OldResult { get; set; }

    public virtual HealthIndicatorDto HealthIndicator { get; set; } = null!;
}