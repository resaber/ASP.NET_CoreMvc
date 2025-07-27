using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace prjCatCoffe.Models;

public partial class CafeMeal
{
    [Column("meal_id")]
    public int MealId { get; set; }

    [Column("cafe_id")]
    public int CafeId { get; set; }

    [Column("type_id")]
    public int TypeId { get; set; }

    [Column("meal_name")]
    public string MealName { get; set; } = null!;

    public int Price { get; set; }

    public string Description { get; set; } = null!;

    [Column("image_url")]
    public string? ImageUrl { get; set; }

    [Column("is_active")]
    public bool IsActive { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; }

    public virtual Cafe Cafe { get; set; } = null!;

    public virtual ICollection<CafeMealPhoto> CafeMealPhotos { get; set; } = new List<CafeMealPhoto>();

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual CafeMealType Type { get; set; } = null!;
}