using System;
using System.Collections.Generic;

namespace WeatherWebService.Api.NewModels;

public partial class PrecipitationType
{
    public int Id { get; set; }

    public string TypeName { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<Observation> Observations { get; set; } = new List<Observation>();
}
