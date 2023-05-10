using HueFestivalTicketOnline.Data;
using HueFestivalTicketOnline.Repositories.IRepository;
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

        [HttpGet]
        public async Task<IActionResult> GetAllArtists()
        {
            try
            {
                return Ok(await _artistRepo.GetAllArtistsAsync());
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetArtistById(int id)
        {
            var Artist = await _artistRepo.GetArtistAsync(id);
            return Artist == null ? NotFound() : Ok(Artist);
        }

        [HttpPost]
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

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateArtist(int id, [FromBody] ArtistDTO model)
        {
            if (id != model.artistID)
            {
                return NotFound();
            }
            await _artistRepo.UpdateArtistAsync(id, model);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArtist([FromRoute] int id)
        {
            await _artistRepo.DeleteArtistAsync(id);
            return Ok();
        }
    }
}
