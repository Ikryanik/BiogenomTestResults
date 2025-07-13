using BiogenomTestResults.Models;

namespace BiogenomTestResults.DTO;

public class FoodSupplementImageDto
{
    /// <summary>
    /// Идентификатор изображения
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// Ссылка на изображение
    /// </summary>
    public string Url { get; set; } = null!;
}