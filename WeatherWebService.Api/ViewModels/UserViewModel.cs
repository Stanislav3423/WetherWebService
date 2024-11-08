namespace WeatherWebService.Api.ViewModels
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string? Role { get; set; }
        public int? RegionId { get; set; }
    }
}
