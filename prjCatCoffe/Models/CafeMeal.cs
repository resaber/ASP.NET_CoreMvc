using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace prjCatCoffe.Models;

public partial class CafeMeal
{
    [Column("meal_id")]
    [Display(Name = "料理編號")]
    public int MealId { get; set; }

    [Column("cafe_id")]
    [Display(Name = "所屬餐廳")]
    public int CafeId { get; set; }

    [Column("type_id")]
    [Display(Name = "料理分類")]
    public int TypeId { get; set; }

    [Column("meal_name")]
    [Display(Name = "料理名稱")]
    public string MealName { get; set; } = null!;

    [Display(Name = "價格")]
    public int Price { get; set; }

    [Display(Name = "餐點簡介")]
    public string Description { get; set; } = null!;

    [Column("image_url")]
    [Display(Name = "餐點封面照")]
    public string? ImageUrl { get; set; }

    [Column("is_active")]
    [Display(Name = "上架狀態")]
    public bool IsActive { get; set; }

    [Column("created_at")]
    [Display(Name = "建立時間")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at")]
    [Display(Name = "更新時間")]
    public DateTime UpdatedAt { get; set; }

    // ✅ 前端顯示：啟用 / 停用
    [NotMapped]
    public string IsActiveDisplay => IsActive ? "上架" : "下架";

    public virtual Cafe Cafe { get; set; } = null!;

    public virtual ICollection<CafeMealPhoto> CafeMealPhotos { get; set; } = new List<CafeMealPhoto>();

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual CafeMealType Type { get; set; } = null!;
}