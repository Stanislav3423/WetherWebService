using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
//using WeatherWebService.Api.Models;
using WeatherWebService.Api.NewModels;
using WeatherWebService.Api.ViewModels;

namespace WeatherWebService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionController : ControllerBase
    {
        private readonly WeatherDbContext _context;
        private readonly IMapper _mapper;

        public RegionController(WeatherDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/region/all
        [HttpGet("all/")]
        public async Task<ActionResult<IEnumerable<RegionViewModel>>> GetRegions()
        {
            var regions = await _context.Regions.ToListAsync();
            return Ok(_mapper.Map<IEnumerable<RegionViewModel>>(regions));
        }

        // GET: api/region/get/num
        [HttpGet("get/{id}")]
        public async Task<ActionResult<RegionViewModel>> GetRegion(int id)
        {
            var region = await _context.Regions.FindAsync(id);

            if (region == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<RegionViewModel>(region));
        }

        // Post api/region/create
        [HttpPost("create/")]
        public async Task<IActionResult> PostRegion(RegionViewModel regionViewModel)
        {
            var region = _mapper.Map<Region>(regionViewModel);
            region.Id = 0;
            _context.Regions.Add(region);
            await _context.SaveChangesAsync();

            var createdRegionViewModel = _mapper.Map<RegionViewModel>(region);
            return CreatedAtAction("GetRegion", new { id = createdRegionViewModel.Id }, createdRegionViewModel);
        }

        // PUT: api/region/edit/num
        [HttpPut("edit/{id}")]
        public async Task<IActionResult> PutRegion(int id, RegionViewModel regionViewModel)
        {
            if (id != regionViewModel.Id)
            {
                return BadRequest();
            }

            var region = _mapper.Map<Region>(regionViewModel);
            _context.Entry(region).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Regions.Any(e => e.Id == id))
                {
                    return NotFound();
                }
                throw;
            }

            return NoContent();
        }

        // DELETE: api/region/delete/num
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteRegion(int id)
        {
            var region = await _context.Regions.FindAsync(id);
            if (region == null)
            {
                return NotFound();
            }

            _context.Regions.Remove(region);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
