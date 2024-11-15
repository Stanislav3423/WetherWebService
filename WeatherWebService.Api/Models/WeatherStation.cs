﻿using System;
using System.Collections.Generic;

namespace WeatherWebService.Api.Models;

public partial class WeatherStation
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int? CityId { get; set; }

    public DateOnly? InstallationDate { get; set; }

    public virtual City? City { get; set; }
}
