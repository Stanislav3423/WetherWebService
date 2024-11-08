namespace WeatherWebService.Api.ViewModels
{
    public class CityViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public int? RegionId { get; set; }
        public string? RegionName { get; set; }
    }
}
