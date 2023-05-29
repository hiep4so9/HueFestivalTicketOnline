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
    public class ArtistsController : ControllerBase
    {
        private readonly IArtistRepository _artistRepo;

        public ArtistsController(IArtistRepository repo)
        {
            _artistRepo = repo;
        }

        [HttpGet, Authorize]
        public async Task<IActionResult> GetAllArtists(int page = 1, int pageSize = 10)
        {
            try
            {
                var allArtists = await _artistRepo.GetAllArtistsAsync();
                var paginatedArtists = Pagination.Paginate(allArtists, page, pageSize);

                var totalArtists = allArtists.Count;
                var totalPages = Pagination.CalculateTotalPages(totalArtists, pageSize);

                var paginationInfo = new
                {
                    TotalArtists = totalArtists,
                    Page = page,
                    PageSize = pageSize,
                    TotalPages = totalPages
                };

                return Ok(new { Artists = paginatedArtists, Pagination = paginationInfo });
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}"), Authorize]
        public async Task<IActionResult> GetArtistById(int id)
        {
            var Artist = await _artistRepo.GetArtistAsync(id);
            return Artist == null ? NotFound() : Ok(Artist);
        }

        [HttpPost, Authorize]
        public async Task<IActionResult> AddNewArtist(ArtistDTO model)
        {
            try
            {
                var newArtistId = await _artistRepo.AddArtistAsync(model);
                var artist = await _artistRepo.GetArtistAsync(newArtistId);
                return artist == null ? NotFound() : Ok(artist);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}"), Authorize]
        public async Task<IActionResult> UpdateArtist(int id, [FromBody] ArtistDTO model)
        {
            if (id != model.artistID)
            {
                return NotFound();
            }
            await _artistRepo.UpdateArtistAsync(id, model);
            return Ok();
        }

        [HttpDelete("{id}"), Authorize]
        public async Task<IActionResult> DeleteArtist([FromRoute] int id)
        {
            await _artistRepo.DeleteArtistAsync(id);
            return Ok();
        }
    }
}
