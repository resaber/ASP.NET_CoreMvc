using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace prjCatCoffe.Models;

public partial class CafeCat
{
    [Column("cat_id")]
    public int CatId { get; set; }

    [Column("cafe_id")]
    public int CafeId { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    [Column("image_url")]
    public string? ImageUrl { get; set; }

    [Column("is_active")]
    public bool IsActive { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; }

    public virtual Cafe Cafe { get; set; } = null!;

    public virtual ICollection<CafeCatPhoto> CafeCatPhotos { get; set; } = new List<CafeCatPhoto>();
}