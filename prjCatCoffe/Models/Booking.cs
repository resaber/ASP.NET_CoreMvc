using System;
using System.Collections.Generic;

namespace prjCatCoffe.Models;

public partial class Booking
{
    public int ReservationId { get; set; }

    public int CafeId { get; set; }

    public int MemberId { get; set; }

    public int PeopleCount { get; set; }

    public DateOnly ReservationDate { get; set; }

    public TimeOnly StartTime { get; set; }

    public TimeOnly EndTime { get; set; }

    public string? Note { get; set; }

    public bool Status { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual Cafe Cafe { get; set; } = null!;

    public virtual Member Member { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
