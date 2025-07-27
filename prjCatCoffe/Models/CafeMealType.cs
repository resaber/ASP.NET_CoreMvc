using System;
using System.Collections.Generic;

namespace prjCatCoffe.Models;

public partial class CafeMealType
{
    public int TypeId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<CafeMeal> CafeMeals { get; set; } = new List<CafeMeal>();
}
