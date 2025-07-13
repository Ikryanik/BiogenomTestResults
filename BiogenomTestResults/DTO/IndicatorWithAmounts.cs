namespace BiogenomTestResults.DTO;

public class IndicatorWithAmounts
{
    public long IndicatorId { get; set; }
    public string IndicatorName { get; set;}
    public decimal CurrentValue { get; set;}
    public decimal NormalValue { get; set;}
    public decimal FoodSupplementValue { get; set;}
    public decimal FoodValue { get; set;}
}