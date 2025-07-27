using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace prjCatCoffe.Models;

public partial class Member
{
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
    public string? ImageUrl { get; set; }

    [Display(Name = "是否為業者")]
    public bool IsCaterer { get; set; }

    [Display(Name = "建立時間")]
    public DateTime CreatedAt { get; set; }

    [Display(Name = "更新時間")]
    public DateTime UpdatedAt { get; set; }

    [Display(Name = "啟用狀態")]
    public bool Status { get; set; }

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    public virtual ICollection<Caterer> Caterers { get; set; } = new List<Caterer>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}