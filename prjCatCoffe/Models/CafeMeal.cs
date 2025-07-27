using System;
using System.Collections.Generic;

namespace prjCatCoffe.Models;

public partial class CafeMeal
{
    public int MealId { get; set; }

    public int CafeId { get; set; }

    public int TypeId { get; set; }

    public string MealName { get; set; } = null!;

    public int Price { get; set; }

    public string Description { get; set; } = null!;

    public string? ImageUrl { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual Cafe Cafe { get; set; } = null!;

    public virtual ICollection<CafeMealPhoto> CafeMealPhotos { get; set; } = new List<CafeMealPhoto>();

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual CafeMealType Type { get; set; } = null!;
}
