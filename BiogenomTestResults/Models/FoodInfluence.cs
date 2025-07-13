using System;
using System.Collections.Generic;

namespace BiogenomTestResults.Models;

public partial class FoodInfluence
{
    public long FoodId { get; set; }

    public long HealthIndicatorId { get; set; }

    public decimal SubstanceAmount { get; set; }

    public long Id { get; set; }

    public virtual Food Food { get; set; } = null!;

    public virtual HealthIndicator HealthIndicator { get; set; } = null!;
}
