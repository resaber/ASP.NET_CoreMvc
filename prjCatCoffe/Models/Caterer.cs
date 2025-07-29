using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace prjCatCoffe.Models;

public partial class Caterer
{
    [DisplayName("業者編號")]
    [Column("caterer_id")]
    public int CatererId { get; set; }

    [DisplayName("會員編號")]
    [Column("member_id")]
    public int MemberId { get; set; }

    [DisplayName("業者名稱")]
    [Column("legal_name")]
    public string? LegalName { get; set; }

    [DisplayName("聯絡電話")]
    public string? Phone { get; set; }

    [DisplayName("業者簡介")]
    [Column("intro_text")]
    public string? IntroText { get; set; }

    [DisplayName("業者封面照")]
    [Column("image_url")]
    public string? ImageUrl { get; set; }

    [DisplayName("申請原因")]
    [Column("apply_reason")]
    public string? ApplyReason { get; set; }

    [DisplayName("建立時間")]
    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [DisplayName("更新時間")]
    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; }

    [DisplayName("狀態")]
    public bool Status { get; set; }
    public virtual ICollection<Cafe> Caves { get; set; } = new List<Cafe>();

    public virtual Member Member { get; set; } = null!;
}