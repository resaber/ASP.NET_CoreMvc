using System;
using System.Collections.Generic;

namespace prjCatCoffe.Models;

public partial class CafeMealPhoto
{
    public int MealPhotoId { get; set; }

    public int MealId { get; set; }

    public string? Description { get; set; }

    public string? ImageUrl { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual CafeMeal Meal { get; set; } = null!;
}
