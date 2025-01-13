using System;
using System.Collections.Generic;

namespace UdaltcovDemo.Models;

public partial class Order
{
    public int OrderNumber { get; set; }

    public string OrderSostav { get; set; } = null!;

    public DateOnly OrderDataZakaz { get; set; }

    public DateOnly OrderDataDostavka { get; set; }

    public int PickUpPoint { get; set; }

    public string? FirstName { get; set; }

    public string? Name { get; set; }

    public string? Patronical { get; set; }

    public int OrderCode { get; set; }

    public int OrderStatus { get; set; }

    public int? UserId { get; set; }

    public int? ConstructionMaterialsId { get; set; }

    public int? CodeDivision { get; set; }

    public virtual PickUpPoint? CodeDivisionNavigation { get; set; }

    public virtual ConstructionMaterial? ConstructionMaterials { get; set; }

    public virtual OrderStatus OrderStatusNavigation { get; set; } = null!;

    public virtual User? User { get; set; }
}
