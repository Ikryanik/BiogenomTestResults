using System;
using System.Collections.Generic;

namespace BiogenomTestResults.Models;

public partial class HealthIndicator
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public decimal Norm { get; set; }

    public virtual ICollection<FoodInfluence> FoodInfluences { get; set; } = new List<FoodInfluence>();

    public virtual ICollection<FoodSupplementInfluence> FoodSupplementInfluences { get; set; } = new List<FoodSupplementInfluence>();

    public virtual ICollection<HealthIndicatorResult> HealthIndicatorResults { get; set; } = new List<HealthIndicatorResult>();
}
