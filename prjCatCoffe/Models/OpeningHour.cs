using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace prjCatCoffe.Models;

public partial class OpeningHour
{
    [Column("open_time_id")]
    public int OpenTimeId { get; set; }

    [Column("cafe_id")]
    public int CafeId { get; set; }

    [Column("day_type")]
    public string DayType { get; set; } = null!;

    [Column("open_time")]
    public TimeOnly OpenTime { get; set; }

    [Column("close_time")]
    public TimeOnly CloseTime { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; }

    public virtual Cafe Cafe { get; set; } = null!;
}