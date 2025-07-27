using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace prjCatCoffe.Models;

public partial class Caterer
{
    [Column("caterer_id")]
    public int CatererId { get; set; }

    [Column("member_id")]
    public int MemberId { get; set; }

    [Column("legal_name")]
    public string? LegalName { get; set; }

    public string? Phone { get; set; }

    [Column("intro_text")]
    public string? IntroText { get; set; }

    [Column("image_url")]
    public string? ImageUrl { get; set; }

    [Column("apply_reason")]
    public string? ApplyReason { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; }

    public bool Status { get; set; }
    public virtual ICollection<Cafe> Caves { get; set; } = new List<Cafe>();

    public virtual Member Member { get; set; } = null!;
}