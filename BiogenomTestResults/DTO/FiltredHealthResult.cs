namespace BiogenomTestResults.DTO;

public class FiltredHealthResult
{
    /// <summary>
    /// Тип суточного потребления (снижено/достаточно)
    /// </summary>
    public FilterHealthResultType Type { get; set; }

    /// <summary>
    /// Количество показателей здоровья
    /// </summary>
    public int Count => HealthResult.Length;

    /// <summary>
    /// Список показателей здоровья
    /// </summary>
    public HealthIndicatorResultDto[] HealthResult { get; set; } = Array.Empty<HealthIndicatorResultDto>();
}

public enum FilterHealthResultType
{
    Low,
    Normal
}