using System;
using System.Collections.Generic;

namespace prjCatCoffe.Models;

public partial class Caterer
{
    public int CatererId { get; set; }

    public int MemberId { get; set; }

    public string? LegalName { get; set; }

    public string? Phone { get; set; }

    public string? IntroText { get; set; }

    public string? ImageUrl { get; set; }

    public string? ApplyReason { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public bool Status { get; set; }

    public virtual ICollection<Cafe> Caves { get; set; } = new List<Cafe>();

    public virtual Member Member { get; set; } = null!;
}
