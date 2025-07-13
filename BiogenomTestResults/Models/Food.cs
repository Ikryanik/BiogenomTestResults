using System;
using System.Collections.Generic;

namespace BiogenomTestResults.Models;

public partial class Food
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<FoodInfluence> FoodInfluences { get; set; } = new List<FoodInfluence>();

    public virtual ICollection<NecessaryFood> NecessaryFoods { get; set; } = new List<NecessaryFood>();
}
