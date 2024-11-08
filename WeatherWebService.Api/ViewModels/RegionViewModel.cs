namespace WeatherWebService.Api.ViewModels
{
    public class RegionViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public List<CityViewModel> Cities { get; set; } = new List<CityViewModel>();
        public List<SeasonViewModel> Seasons { get; set; } = new List<SeasonViewModel>();
        public List<UserViewModel> Users { get; set; } = new List<UserViewModel>();
    }
}
