using AutoMapper;
//using WeatherWebService.Api.Models;
using WeatherWebService.Api.NewModels;
using WeatherWebService.Api.ViewModels;

namespace WeatherWebService.Api.Mappers
{
    public class WeatherMapping : Profile
    {
        public WeatherMapping() {
            CreateMap<City, CityViewModel>();
            CreateMap<CityViewModel, City>();

            CreateMap<Observation, ObservationViewModel>();
            CreateMap<ObservationViewModel, Observation>();

            CreateMap<PrecipitationType, PrecipitationTypeViewModel>();
            CreateMap<PrecipitationTypeViewModel, PrecipitationType>();

            CreateMap<Region, RegionViewModel>();
            CreateMap<RegionViewModel, Region>();

            CreateMap<WeatherStation, WeatherStationViewModel>();
            CreateMap<WeatherStationViewModel, WeatherStation>();
        }
    }
}
