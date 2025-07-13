using BiogenomTestResults.Models;

namespace BiogenomTestResults.DTO;

public class FoodSupplementDto
{
    /// <summary>
    /// Идентификатор БАДа
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// Наименование БАДа
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// Описание БАДа
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Список изображений БАДа
    /// </summary>
    public FoodSupplementImageDto[] FoodSupplementImages { get; set; } = Array.Empty<FoodSupplementImageDto>();
}