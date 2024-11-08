namespace WeatherWebService.Api.ViewModels
{
    public class SeasonViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateOnly? StartDate { get; set; }
        public DateOnly? EndDate { get; set; }
        public int? RegionId { get; set; }
    }
}
