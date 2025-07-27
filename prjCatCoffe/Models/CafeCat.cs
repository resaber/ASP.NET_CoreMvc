using System;
using System.Collections.Generic;

namespace prjCatCoffe.Models;

public partial class CafeCat
{
    public int CatId { get; set; }

    public int CafeId { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string? ImageUrl { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual Cafe Cafe { get; set; } = null!;

    public virtual ICollection<CafeCatPhoto> CafeCatPhotos { get; set; } = new List<CafeCatPhoto>();
}
