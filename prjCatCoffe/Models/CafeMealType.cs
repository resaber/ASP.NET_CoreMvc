using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace prjCatCoffe.Models;

public partial class CafeMealType
{
    [Column("type_id")]
    public int TypeId { get; set; }

    [DisplayName("餐點分類")]
    public string Name { get; set; } = null!;

    public virtual ICollection<CafeMeal> CafeMeals { get; set; } = new List<CafeMeal>();
}