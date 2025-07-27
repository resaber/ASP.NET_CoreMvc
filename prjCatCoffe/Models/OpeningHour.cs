using System;
using System.Collections.Generic;

namespace prjCatCoffe.Models;

public partial class OpeningHour
{
    public int OpenTimeId { get; set; }

    public int CafeId { get; set; }

    public string DayType { get; set; } = null!;

    public TimeOnly OpenTime { get; set; }

    public TimeOnly CloseTime { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual Cafe Cafe { get; set; } = null!;
}
