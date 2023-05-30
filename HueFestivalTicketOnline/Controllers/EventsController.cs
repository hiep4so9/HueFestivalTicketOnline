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
    public class EventsController : ControllerBase
    {
        private readonly IEventRepository _eventRepo;

        public EventsController(IEventRepository repo)
        {
            _eventRepo = repo;
        }

        [HttpGet, Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllEvents(int page = 1, int pageSize = 10)
        {
            try
            {
                var allEvents = await _eventRepo.GetAllEventsAsync();
                var paginatedEvents = Pagination.Paginate(allEvents, page, pageSize);

                var totalEvents = allEvents.Count;
                var totalPages = Pagination.CalculateTotalPages(totalEvents, pageSize);

                var paginationInfo = new
                {
                    TotalEvents = totalEvents,
                    Page = page,
                    PageSize = pageSize,
                    TotalPages = totalPages
                };

                return Ok(new { Events = paginatedEvents, Pagination = paginationInfo });
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}"), Authorize(Roles = "User")]
        public async Task<IActionResult> GetEventById(int id)
        {
            var _event = await _eventRepo.GetEventAsync(id);
            return _event == null ? NotFound() : Ok(_event);
        }

        [HttpPost, Authorize(Roles = "Admin")]
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

        [HttpPut("{id}"), Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateEvent(int id, [FromBody] EventDTO model)
        {
            if (id != model.eventID)
            {
                return NotFound();
            }
            await _eventRepo.UpdateEventAsync(id, model);
            return Ok();
        }

        [HttpDelete("{id}"), Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteEvent([FromRoute] int id)
        {
            await _eventRepo.DeleteEventAsync(id);
            return Ok();
        }
    }
}
