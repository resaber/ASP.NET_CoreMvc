using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace prjCatCoffe.Models;

public partial class Booking
{
    [Column("reservation_id")]
    public int ReservationId { get; set; }

    [Column("cafe_id")]
    public int CafeId { get; set; }

    [Column("member_id")]
    public int MemberId { get; set; }

    [Column("people_count")]
    public int PeopleCount { get; set; }

    [Column("reservation_date")]
    public DateOnly ReservationDate { get; set; }

    [Column("start_time")]
    public TimeOnly StartTime { get; set; }

    [Column("end_time")]
    public TimeOnly EndTime { get; set; }

    public string? Note { get; set; }

    public bool Status { get; set; }
    [Column("created_at")]
    public DateTime CreatedAt { get; set; }
    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; }

    public virtual Cafe Cafe { get; set; } = null!;

    public virtual Member Member { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
