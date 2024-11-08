using System;
using System.Collections.Generic;

namespace WeatherWebService.Api.Models;

public partial class Season
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public DateOnly? StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public int? RegionId { get; set; }

    public virtual Region? Region { get; set; }
}
