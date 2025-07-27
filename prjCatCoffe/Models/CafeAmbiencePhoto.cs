using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace prjCatCoffe.Models;

public partial class CafeAmbiencePhoto
{
    [Column("cafe_photo_id")]
    public int CafePhotoId { get; set; }

    [Column("cafe_id")]
    public int CafeId { get; set; }

    [Column("type_id")]
    public int TypeId { get; set; }

    public string? Description { get; set; }

    [Column("image_url")]
    public string ImageUrl { get; set; } = null!;

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; }

    public virtual Cafe Cafe { get; set; } = null!;

    public virtual CafeAmbiencePhotoType Type { get; set; } = null!;
}