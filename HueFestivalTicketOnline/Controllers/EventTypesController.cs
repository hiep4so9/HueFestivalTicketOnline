using HueFestivalTicketOnline.Data;
using HueFestivalTicketOnline.Repositories.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HueFestivalTicketOnline.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventTypesController : ControllerBase
    {
        private readonly IEventTypeRepository _eventTypeRepo;

        public EventTypesController(IEventTypeRepository repo)
        {
            _eventTypeRepo = repo;
        }

        [HttpGet, Authorize]
        public async Task<IActionResult> GetAllEventTypes()
        {
            try
            {
                return Ok(await _eventTypeRepo.GetAllEventTypesAsync());
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}"), Authorize]
        public async Task<IActionResult> GetEventTypeById(int id)
        {
            var eventType = await _eventTypeRepo.GetEventTypeAsync(id);
            return eventType == null ? NotFound() : Ok(eventType);
        }

        [HttpPost, Authorize]
        public async Task<IActionResult> AddNewEventType(EventTypeDTO model)
        {
            try
            {
                var newEventTypeId = await _eventTypeRepo.AddEventTypeAsync(model);
                var eventType = await _eventTypeRepo.GetEventTypeAsync(newEventTypeId);
                return eventType == null ? NotFound() : Ok(eventType);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}"), Authorize]
        public async Task<IActionResult> UpdateEventType(int id, [FromBody] EventTypeDTO model)
        {
            if (id != model.eventTypeID)
            {
                return NotFound();
            }
            await _eventTypeRepo.UpdateEventTypeAsync(id, model);
            return Ok();
        }

        [HttpDelete("{id}"), Authorize]
        public async Task<IActionResult> DeleteEventType([FromRoute] int id)
        {
            await _eventTypeRepo.DeleteEventTypeAsync(id);
            return Ok();
        }
    }
}
