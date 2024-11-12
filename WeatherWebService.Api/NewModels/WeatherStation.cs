using System;
using System.Collections.Generic;

namespace WeatherWebService.Api.NewModels;

public partial class WeatherStation
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int? CityId { get; set; }

    public DateOnly? InstallationDate { get; set; }

    public virtual City? City { get; set; }

    public virtual ICollection<Observation> Observations { get; set; } = new List<Observation>();
}
