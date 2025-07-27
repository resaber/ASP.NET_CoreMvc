using System;
using System.Collections.Generic;

namespace prjCatCoffe.Models;

public partial class CafeCatPhoto
{
    public int CatPhotoId { get; set; }

    public int CatId { get; set; }

    public string? Description { get; set; }

    public string? ImageUrl { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual CafeCat Cat { get; set; } = null!;
}
