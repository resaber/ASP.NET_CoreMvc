using System;
using System.Collections.Generic;

namespace prjCatCoffe.Models;

public partial class CafeAmbiencePhotoType
{
    public int TypeId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<CafeAmbiencePhoto> CafeAmbiencePhotos { get; set; } = new List<CafeAmbiencePhoto>();
}
