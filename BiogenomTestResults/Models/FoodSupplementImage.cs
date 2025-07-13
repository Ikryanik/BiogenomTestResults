using System;
using System.Collections.Generic;

namespace BiogenomTestResults.Models;

public partial class FoodSupplementImage
{
    public long Id { get; set; }

    public long FoodSupplementId { get; set; }

    public string Url { get; set; } = null!;

    public virtual FoodSupplement FoodSupplement { get; set; } = null!;
}
