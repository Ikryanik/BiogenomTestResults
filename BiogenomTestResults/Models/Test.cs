using System;
using System.Collections.Generic;

namespace BiogenomTestResults.Models;

public partial class Test
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<TestResult> TestResults { get; set; } = new List<TestResult>();
}
