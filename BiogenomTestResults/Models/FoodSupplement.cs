using System;
using System.Collections.Generic;

namespace BiogenomTestResults.Models;

public partial class FoodSupplement
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<FoodSupplementImage> FoodSupplementImages { get; set; } = new List<FoodSupplementImage>();

    public virtual ICollection<FoodSupplementInfluence> FoodSupplementInfluences { get; set; } = new List<FoodSupplementInfluence>();

    public virtual ICollection<NecessaryFoodSupplement> NecessaryFoodSupplements { get; set; } = new List<NecessaryFoodSupplement>();
}
