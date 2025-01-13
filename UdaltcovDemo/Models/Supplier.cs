using System;
using System.Collections.Generic;

namespace UdaltcovDemo.Models;

public partial class Supplier
{
    public int SupplierId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<ConstructionMaterial> ConstructionMaterials { get; set; } = new List<ConstructionMaterial>();
}
