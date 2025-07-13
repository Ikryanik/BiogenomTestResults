namespace BiogenomTestResults.DTO;

public class CurrentDailyIntakeResult
{
    /// <summary>
    /// Текущее сниженное суточное потребление
    /// </summary>
    public FiltredHealthResult LowResult { get; set; }

    /// <summary>
    /// Текущее нормальное суточное потребление
    /// </summary>
    public FiltredHealthResult NormalResult { get; set; }
}