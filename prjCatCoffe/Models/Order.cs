using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace prjCatCoffe.Models;

public partial class Order
{
    [Column("order_id")]
    public int OrderId { get; set; }

    [Column("cafe_id")]
    public int CafeId { get; set; }

    [Column("member_id")]
    public int MemberId { get; set; }

    [Column("reservation_id")]
    public int? ReservationId { get; set; }

    [Column("total_amount")]
    public int TotalAmount { get; set; }

    [Column("reservation_date")]
    public DateOnly ReservationDate { get; set; }

    [Column("payment_method")]
    public string PaymentMethod { get; set; } = null!;

    [Column("payment_status")]
    public string PaymentStatus { get; set; } = null!;

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; }

    public virtual Cafe Cafe { get; set; } = null!;

    public virtual Member Member { get; set; } = null!;

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual Booking? Reservation { get; set; }
}