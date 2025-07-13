using System;
using System.Collections.Generic;

namespace BiogenomTestResults.Models;

public partial class FoodSupplementInfluence
{
    public long FoodSupplementId { get; set; }

    public long HealthIndicatorId { get; set; }

    public decimal SubstanceAmount { get; set; }

    public long Id { get; set; }

    public virtual FoodSupplement FoodSupplement { get; set; } = null!;

    public virtual HealthIndicator HealthIndicator { get; set; } = null!;
}
