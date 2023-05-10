using HueFestivalTicketOnline.Data;
using HueFestivalTicketOnline.Repositories.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HueFestivalTicketOnline.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        private readonly ILocationRepository _locationRepo;

        public LocationsController(ILocationRepository repo)
        {
            _locationRepo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllLocations()
        {
            try
            {
                return Ok(await _locationRepo.GetAllLocationsAsync());
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetLocationById(int id)
        {
            var location = await _locationRepo.GetLocationAsync(id);
            return location == null ? NotFound() : Ok(location);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewLocation(LocationDTO model)
        {
            try
            {
                var newLocationId = await _locationRepo.AddLocationAsync(model);
                var location = await _locationRepo.GetLocationAsync(newLocationId);
                return location == null ? NotFound() : Ok(location);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLocation(int id, [FromBody] LocationDTO model)
        {
            if (id != model.locationID)
            {
                return NotFound();
            }
            await _locationRepo.UpdateLocationAsync(id, model);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLocation([FromRoute] int id)
        {
            await _locationRepo.DeleteLocationAsync(id);
            return Ok();
        }
    }
}
