using System;
using System.Collections.Generic;

namespace UdaltcovDemo.Models;

public partial class PickUpPoint
{
    public string City { get; set; } = null!;

    public string Street { get; set; } = null!;

    public int CodeDivision { get; set; }

    public int HomeNumber { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
