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
    public class ObservationController : ControllerBase
    {
        private readonly WeatherDbContext _context;
        private readonly IMapper _mapper;

        public ObservationController(WeatherDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/observation/all
        [HttpGet("all/")]
        public async Task<ActionResult<IEnumerable<ObservationViewModel>>> GetObservations()
        {
            var observations = await _context.Observations.ToListAsync();
            return Ok(_mapper.Map<IEnumerable<ObservationViewModel>>(observations));
        }

        // GET: api/observation/get/num
        [HttpGet("get/{id}")]
        public async Task<ActionResult<ObservationViewModel>> GetObservation(int id)
        {
            var observation = await _context.Observations.FindAsync(id);

            if (observation == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<ObservationViewModel>(observation));
        }

        // Post api/observation/create
        [HttpPost("create/")]
        public async Task<IActionResult> PostObservation(ObservationViewModel observationViewModel)
        {
            var observation = _mapper.Map<Observation>(observationViewModel);
            observation.Id = 0;
            _context.Observations.Add(observation);
            await _context.SaveChangesAsync();

            var createdObservationViewModel = _mapper.Map<ObservationViewModel>(observation);
            return CreatedAtAction("GetObservation", new { id = createdObservationViewModel.Id }, createdObservationViewModel);
        }

        // PUT: api/observation/edit/num
        [HttpPut("edit/{id}")]
        public async Task<IActionResult> PutObservation(int id, ObservationViewModel observationViewModel)
        {
            if (id != observationViewModel.Id)
            {
                return BadRequest();
            }

            var observation = _mapper.Map<Observation>(observationViewModel);
            _context.Entry(observation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Observations.Any(e => e.Id == id))
                {
                    return NotFound();
                }
                throw;
            }

            return NoContent();
        }

        // DELETE: api/observation/delete/num
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteObservation(int id)
        {
            var observation = await _context.Observations.FindAsync(id);
            if (observation == null)
            {
                return NotFound();
            }

            _context.Observations.Remove(observation);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
