﻿using System;
using System.Collections.Generic;

namespace WeatherWebService.Api.Models;

public partial class City
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public decimal Latitude { get; set; }

    public decimal Longitude { get; set; }

    public int? RegionId { get; set; }

    public virtual Region? Region { get; set; }
}
