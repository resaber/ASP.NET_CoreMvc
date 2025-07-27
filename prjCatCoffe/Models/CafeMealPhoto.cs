using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace prjCatCoffe.Models;

public partial class CafeMealPhoto
{
    [Column("meal_photo_id")]
    public int MealPhotoId { get; set; }

    [Column("meal_id")]
    public int MealId { get; set; }

    public string? Description { get; set; }

    [Column("image_url")]
    public string? ImageUrl { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; }

    public virtual CafeMeal Meal { get; set; } = null!;
}