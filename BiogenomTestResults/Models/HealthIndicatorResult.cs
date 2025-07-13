using System;
using System.Collections.Generic;

namespace BiogenomTestResults.Models;

public partial class HealthIndicatorResult
{
    public long TestResultId { get; set; }

    public long HealthIndicatorid { get; set; }

    public decimal Result { get; set; }

    public long Id { get; set; }

    public virtual HealthIndicator HealthIndicator { get; set; } = null!;

    public virtual TestResult TestResult { get; set; } = null!;
}
