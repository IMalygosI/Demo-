using Avalonia.Media;
using Avalonia.Media.Imaging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace UdaltcovDemo.Models;

public partial class ConstructionMaterial
{
    public int ConstructionMaterials { get; set; }

    public string Article { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string UnitOfMeasurement { get; set; } = null!;

    public int Price { get; set; }

    public int MaximumPossibleDiscountSize { get; set; }

    public int Mmanufacturer { get; set; }

    public int Supplier { get; set; }

    public int CurrentDiscount { get; set; }

    public int Count { get; set; }

    public string? Description { get; set; }

    public string? Picture { get; set; }

    public int ProductCategoryId { get; set; }

    public virtual Manufacturer MmanufacturerNavigation { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ProductCategory ProductCategory { get; set; } = null!;

    public virtual Supplier SupplierNavigation { get; set; } = null!;

    public Bitmap PictureImage => Picture != null ? new Bitmap(@$"Assets//{Picture}") : null!;

    SolidColorBrush Colors => Count > 0 ? new SolidColorBrush(Color.Parse("White")) : new SolidColorBrush(Color.Parse("Gray"));
}
