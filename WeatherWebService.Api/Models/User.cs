using System;
using System.Collections.Generic;

namespace WeatherWebService.Api.Models;

public partial class User
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public string? Role { get; set; }

    public int? RegionId { get; set; }

    public virtual Region? Region { get; set; }
}
