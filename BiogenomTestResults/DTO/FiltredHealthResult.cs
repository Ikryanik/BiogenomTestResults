namespace BiogenomTestResults.DTO;

public class FiltredHealthResult
{
    public FilterHealthResultType Type { get; set; }
    public int Count => HealthResult.Count;
    public List<HealthIndicatorResultDto> HealthResult { get; set; } = new List<HealthIndicatorResultDto>();
}

public enum FilterHealthResultType
{
    Low,
    Normal
}