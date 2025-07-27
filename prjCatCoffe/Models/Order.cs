using System;
using System.Collections.Generic;

namespace prjCatCoffe.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public int CafeId { get; set; }

    public int MemberId { get; set; }

    public int? ReservationId { get; set; }

    public int TotalAmount { get; set; }

    public DateOnly ReservationDate { get; set; }

    public string PaymentMethod { get; set; } = null!;

    public string PaymentStatus { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual Cafe Cafe { get; set; } = null!;

    public virtual Member Member { get; set; } = null!;

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual Booking? Reservation { get; set; }
}
