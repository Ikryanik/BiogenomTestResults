using BiogenomTestResults.Models;

namespace BiogenomTestResults.DTO;

public class FoodSupplementDto
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<FoodSupplementImageDto> FoodSupplementImages { get; set; } = new List<FoodSupplementImageDto>();
}