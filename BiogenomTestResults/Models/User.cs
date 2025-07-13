using System;
using System.Collections.Generic;

namespace BiogenomTestResults.Models;

public partial class User
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<TestResult> TestResults { get; set; } = new List<TestResult>();
}
