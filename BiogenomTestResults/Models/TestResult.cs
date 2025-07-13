using System;
using System.Collections.Generic;

namespace BiogenomTestResults.Models;

public partial class TestResult
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public long TestId { get; set; }

    public long UserId { get; set; }

    public virtual ICollection<HealthIndicatorResult> HealthIndicatorResults { get; set; } = new List<HealthIndicatorResult>();

    public virtual ICollection<NecessaryFoodSupplement> NecessaryFoodSupplements { get; set; } = new List<NecessaryFoodSupplement>();

    public virtual ICollection<NecessaryFood> NecessaryFoods { get; set; } = new List<NecessaryFood>();

    public virtual Test Test { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
