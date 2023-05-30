using HueFestivalTicketOnline.Data;
using HueFestivalTicketOnline.Helpers;
using HueFestivalTicketOnline.Repositories.IRepository;
using Microsoft.AspNetCore.Authorization;
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

        [HttpGet, Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllLocations(int page = 1, int pageSize = 10)
        {
            try
            {
                var allLocations = await _locationRepo.GetAllLocationsAsync();
                var paginatedLocations = Pagination.Paginate(allLocations, page, pageSize);

                var totalLocations = allLocations.Count;
                var totalPages = Pagination.CalculateTotalPages(totalLocations, pageSize);

                var paginationInfo = new
                {
                    TotalLocations = totalLocations,
                    Page = page,
                    PageSize = pageSize,
                    TotalPages = totalPages
                };

                return Ok(new { Locations = paginatedLocations, Pagination = paginationInfo });
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}"), Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetLocationById(int id)
        {
            var location = await _locationRepo.GetLocationAsync(id);
            return location == null ? NotFound() : Ok(location);
        }

        [HttpPost, Authorize(Roles = "Admin")]
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

        [HttpPut("{id}"), Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateLocation(int id, [FromBody] LocationDTO model)
        {
            if (id != model.locationID)
            {
                return NotFound();
            }
            await _locationRepo.UpdateLocationAsync(id, model);
            return Ok();
        }

        [HttpDelete("{id}"), Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteLocation([FromRoute] int id)
        {
            await _locationRepo.DeleteLocationAsync(id);
            return Ok();
        }
    }
}
