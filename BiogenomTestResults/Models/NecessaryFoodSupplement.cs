using System;
using System.Collections.Generic;

namespace BiogenomTestResults.Models;

public partial class NecessaryFoodSupplement
{
    public long TestResultId { get; set; }

    public long FoodSupplementId { get; set; }

    public long Id { get; set; }

    public virtual FoodSupplement FoodSupplement { get; set; } = null!;

    public virtual TestResult TestResult { get; set; } = null!;
}
