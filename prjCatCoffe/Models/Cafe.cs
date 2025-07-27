using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace prjCatCoffe.Models;

public partial class Cafe
{
    [Column("cafe_id")]
    public int CafeId { get; set; }

    [Column("cater_id")]
    public int CaterId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? Phone { get; set; }

    public string Address { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; }

    [Column("status")]
    public bool Status { get; set; }

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    public virtual ICollection<CafeAmbiencePhoto> CafeAmbiencePhotos { get; set; } = new List<CafeAmbiencePhoto>();

    public virtual ICollection<CafeCat> CafeCats { get; set; } = new List<CafeCat>();

    public virtual ICollection<CafeMeal> CafeMeals { get; set; } = new List<CafeMeal>();

    public virtual Caterer Cater { get; set; } = null!;

    public virtual ICollection<OpeningHour> OpeningHours { get; set; } = new List<OpeningHour>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}