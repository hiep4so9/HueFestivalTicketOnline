using HueFestivalTicketOnline.Data;
using HueFestivalTicketOnline.Repositories.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HueFestivalTicketOnline.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IEventRepository _eventRepo;

        public EventsController(IEventRepository repo)
        {
            _eventRepo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEvents()
        {
            try
            {
                return Ok(await _eventRepo.GetAllEventsAsync());
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEventById(int id)
        {
            var _event = await _eventRepo.GetEventAsync(id);
            return _event == null ? NotFound() : Ok(_event);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewEvent(EventDTO model)
        {
            try
            {
                var newEventId = await _eventRepo.AddEventAsync(model);
                var _event = await _eventRepo.GetEventAsync(newEventId);
                return _event == null ? NotFound() : Ok(_event);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEvent(int id, [FromBody] EventDTO model)
        {
            if (id != model.eventID)
            {
                return NotFound();
            }
            await _eventRepo.UpdateEventAsync(id, model);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvent([FromRoute] int id)
        {
            await _eventRepo.DeleteEventAsync(id);
            return Ok();
        }
    }
}
