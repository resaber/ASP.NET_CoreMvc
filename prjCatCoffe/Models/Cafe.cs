using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace prjCatCoffe.Models;

public partial class Cafe
{
    [Column("cafe_id")]
    public int CafeId { get; set; }

    [DisplayName("業者編號")]
    [Column("cater_id")]
    public int CaterId { get; set; }

    [DisplayName("餐廳名稱")]
    [Column("name")]
    public string? Name { get; set; }

    [DisplayName("餐廳介紹")]
    public string? Description { get; set; }

    [DisplayName("聯絡電話")]
    public string? Phone { get; set; }

    [DisplayName("地址")]
    public string Address { get; set; }

    [DisplayName("建立時間")]
    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [DisplayName("更新時間")]
    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; }

    // ✅ 加在這裡！不是資料庫欄位，只是顯示用
    [NotMapped]
    public string StatusDisplay => Status ? "啟用" : "停用";

    [DisplayName("狀態")]
    [Column("status")]
    public bool Status { get; set; }

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    public virtual ICollection<CafeAmbiencePhoto> CafeAmbiencePhotos { get; set; } = new List<CafeAmbiencePhoto>();

    public virtual ICollection<CafeCat> CafeCats { get; set; } = new List<CafeCat>();

    public virtual ICollection<CafeMeal> CafeMeals { get; set; } = new List<CafeMeal>();

    public virtual Caterer Cater { get; set; } = null!;

    public virtual ICollection<OpeningHour> OpeningHours { get; set; } = new List<OpeningHour>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}