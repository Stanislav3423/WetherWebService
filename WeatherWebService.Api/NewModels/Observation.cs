using System;
using System.Collections.Generic;

namespace WeatherWebService.Api.NewModels;

public partial class Observation
{
    public int Id { get; set; }

    public int? StationId { get; set; }

    public DateTime? ObservationDate { get; set; }

    public decimal? Temperature { get; set; }

    public decimal? Humidity { get; set; }

    public decimal? WindSpeed { get; set; }

    public decimal? Precipitation { get; set; }

    public int? PrecipitationTypeId { get; set; }

    public virtual PrecipitationType? PrecipitationType { get; set; }

    public virtual WeatherStation? Station { get; set; }
}
