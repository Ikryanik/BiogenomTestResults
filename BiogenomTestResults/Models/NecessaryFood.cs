using System;
using System.Collections.Generic;

namespace BiogenomTestResults.Models;

public partial class NecessaryFood
{
    public long TestResultId { get; set; }

    public long FoodId { get; set; }

    public long Id { get; set; }

    public virtual Food Food { get; set; } = null!;

    public virtual TestResult TestResult { get; set; } = null!;
}
