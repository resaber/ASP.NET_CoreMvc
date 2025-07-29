using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace prjCatCoffe.Models;

public partial class OrderItem
{
    [Column("order_item_id")]
    public int OrderItemId { get; set; }

    [Column("order_id")]
    public int OrderId { get; set; }

    [Column("meal_id")]
    public int MealId { get; set; }

    public int Quantity { get; set; }

    [Column("unit_price")]
    public int UnitPrice { get; set; }

    [Column("sub_total")]
    public int SubTotal { get; set; }

    public virtual CafeMeal Meal { get; set; } = null!;

    public virtual Order Order { get; set; } = null!;
}