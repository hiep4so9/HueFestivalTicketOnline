using HueFestivalTicketOnline.Data;
using HueFestivalTicketOnline.Models;
using HueFestivalTicketOnline.Repositories.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HueFestivalTicketOnline.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventImagesController : ControllerBase
    {
        private readonly IEventImageRepository _eventImageRepo;

        public EventImagesController(IEventImageRepository repo)
        {
            _eventImageRepo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEventImages()
        {
            try
            {
                return Ok(await _eventImageRepo.GetAllEventImagesAsync());
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEventImageById(int id)
        {
            var eventImage = await _eventImageRepo.GetEventImageAsync(id);
            return eventImage == null ? NotFound() : Ok(eventImage);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewEventImage(EventImageDTO model)
        {
            try
            {
                var newEventImageId = await _eventImageRepo.AddEventImageAsync(model);
                var eventImage = await _eventImageRepo.GetEventImageAsync(newEventImageId);
                return eventImage == null ? NotFound() : Ok(eventImage);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEventImage(int id, [FromBody] EventImageDTO model)
        {
            if (id != model.eventImageID)
            {
                return NotFound();
            }
            await _eventImageRepo.UpdateEventImageAsync(id, model);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEventImage([FromRoute] int id)
        {
            await _eventImageRepo.DeleteEventImageAsync(id);
            return Ok();
        }
    }
}
