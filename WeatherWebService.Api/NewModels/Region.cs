using System;
using System.Collections.Generic;

namespace WeatherWebService.Api.NewModels;

public partial class Region
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Country { get; set; } = null!;

    public virtual ICollection<City> Cities { get; set; } = new List<City>();
}
