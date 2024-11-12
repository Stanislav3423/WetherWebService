namespace WeatherWebService.Api.ViewModels
{
    public class WeatherStationViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? CityId { get; set; }
        public DateOnly? InstallationDate { get; set; }
    }
}
