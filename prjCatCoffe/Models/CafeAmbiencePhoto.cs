using System;
using System.Collections.Generic;

namespace prjCatCoffe.Models;

public partial class CafeAmbiencePhoto
{
    public int CafePhotoId { get; set; }

    public int CafeId { get; set; }

    public int TypeId { get; set; }

    public string? Description { get; set; }

    public string ImageUrl { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual Cafe Cafe { get; set; } = null!;

    public virtual CafeAmbiencePhotoType Type { get; set; } = null!;
}
