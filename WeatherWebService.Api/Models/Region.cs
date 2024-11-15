﻿using System;
using System.Collections.Generic;

namespace WeatherWebService.Api.Models;

public partial class Region
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Country { get; set; } = null!;
}
