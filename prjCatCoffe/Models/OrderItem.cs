using System;
using System.Collections.Generic;

namespace prjCatCoffe.Models;

public partial class OrderItem
{
    public int OrderItemId { get; set; }

    public int OrderId { get; set; }

    public int MealId { get; set; }

    public int Quantity { get; set; }

    public int UnitPrice { get; set; }

    public int SubTotal { get; set; }

    public virtual CafeMeal Meal { get; set; } = null!;

    public virtual Order Order { get; set; } = null!;
}
