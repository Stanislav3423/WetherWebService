using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
//using WeatherWebService.Api.Models;
using WeatherWebService.Api.NewModels;
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

        // GET: api/city/all
        [HttpGet("all/")]
        public async Task<ActionResult<IEnumerable<CityViewModel>>> GetCities()
        {
            var cities = await _context.Cities.ToListAsync();
            return Ok(_mapper.Map<IEnumerable<CityViewModel>>(cities));
        }

        // GET: api/city/get/num
        [HttpGet("get/{id}")]
        public async Task<ActionResult<CityViewModel>> GetCity(int id)
        {
            var city = await _context.Cities.FindAsync(id);

            if (city == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<CityViewModel>(city));
        }

        // Post api/city/create
        [HttpPost("create/")]
        public async Task<IActionResult> PostCity(CityViewModel cityViewModel)
        {
            var city = _mapper.Map<City>(cityViewModel);
            city.Id = 0;
            _context.Cities.Add(city);
            await _context.SaveChangesAsync();

            var createdCityViewModel = _mapper.Map<CityViewModel>(city);
            return CreatedAtAction("GetCity", new { id = createdCityViewModel.Id }, createdCityViewModel);
        }

        // PUT: api/city/edit/num
        [HttpPut("edit/{id}")]
        public async Task<IActionResult> PutCity(int id, CityViewModel cityViewModel)
        {
            if (id != cityViewModel.Id)
            {
                return BadRequest();
            }

            var city = _mapper.Map<City>(cityViewModel);
            _context.Entry(city).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Cities.Any(e => e.Id == id))
                {
                    return NotFound();
                }
                throw;
            }

            return NoContent();
        }

        // DELETE: api/city/delete/num
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteCity(int id)
        {
            var city = await _context.Cities.FindAsync(id);
            if (city == null)
            {
                return NotFound();
            }

            _context.Cities.Remove(city);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
