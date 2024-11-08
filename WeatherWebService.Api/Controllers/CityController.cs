using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WeatherWebService.Api.Models;
using WeatherWebService.Api.ViewModels;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace WeatherWebService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly WeatherDbContext _context;
        private readonly IMapper _mapper;

        public CityController(WeatherDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/city
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CityViewModel>>> GetCities()
        {
            var cities = await _context.Cities.ToListAsync();
            return Ok(_mapper.Map<IEnumerable<CityViewModel>>(cities));
        }
    }
}
