using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace prjCatCoffe.Models;

public partial class Member
{
    [Column("member_id")]
    public int MemberId { get; set; }

    [Display(Name = "姓名")]
    public string Name { get; set; } = null!;

    [Display(Name = "帳號")]
    public string Account { get; set; } = null!;

    [Display(Name = "密碼")]
    public string Password { get; set; } = null!;

    [Display(Name = "電話")]
    public string Phone { get; set; } = null!;

    [Display(Name = "性別")]
    public byte? Gender { get; set; }

    [Display(Name = "電子信箱")]
    public string Email { get; set; } = null!;

    [Display(Name = "大頭貼")]
    [Column("image_url")]
    public string? ImageUrl { get; set; }

    [Display(Name = "是否為業者")]
    [Column("is_caterer")]
    public bool IsCaterer { get; set; }

    [Display(Name = "建立時間")]
    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [Display(Name = "更新時間")]
    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; }

    [Display(Name = "啟用狀態")]
    [Column("status")]
    public bool Status { get; set; }

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    public virtual ICollection<Caterer> Caterers { get; set; } = new List<Caterer>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}