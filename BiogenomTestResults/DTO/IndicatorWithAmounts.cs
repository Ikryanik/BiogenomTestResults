namespace BiogenomTestResults.DTO;

public class IndicatorWithAmounts
{
    /// <summary>
    /// Идентификатор показателя здоровья
    /// </summary>
    public long IndicatorId { get; set; }

    /// <summary>
    /// Наименование показателя здоровья
    /// </summary>
    public string IndicatorName { get; set; } = null!;
    
    /// <summary>
    /// Текущий результат показателя здоровья
    /// </summary>
    public decimal CurrentValue { get; set;}

    /// <summary>
    /// Норма показателя здоровья
    /// </summary>
    public decimal NormalValue { get; set;}

    /// <summary>
    /// Добор показателя из БАДов
    /// </summary>
    public decimal FoodSupplementValue { get; set;}
    
    /// <summary>
    /// Добор показателя из еды
    /// </summary>
    public decimal FoodValue { get; set;}
}