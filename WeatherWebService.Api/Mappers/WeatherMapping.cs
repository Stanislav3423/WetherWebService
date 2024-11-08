using AutoMapper;
using WeatherWebService.Api.Models;
using WeatherWebService.Api.ViewModels;

namespace WeatherWebService.Api.Mappers
{
    public class WeatherMapping : Profile
    {
        public WeatherMapping() {
            CreateMap<City, CityViewModel>();
            CreateMap<Observation, ObservationViewModel>();
            CreateMap<PrecipitationType, PrecipitationTypeViewModel>();
            CreateMap<Region, RegionViewModel>();
            CreateMap<Season, SeasonViewModel>();
            CreateMap<User, UserViewModel>();
            CreateMap<WeatherStation, WeatherStationViewModel>();
        }
    }
}
