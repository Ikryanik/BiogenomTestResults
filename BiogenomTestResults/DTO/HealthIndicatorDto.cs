namespace BiogenomTestResults.DTO;

public class HealthIndicatorDto
{
    /// <summary>
    /// Идентификатор показателя здоровья
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// Наименование показателя здоровья
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// Норма показателя здоровья
    /// </summary>
    public decimal Norm { get; set; }
}