using HueFestivalTicketOnline.Data;
using HueFestivalTicketOnline.Models;
using HueFestivalTicketOnline.Repositories.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HueFestivalTicketOnline.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private readonly ITicketRepository _ticketRepo;

        public TicketsController(ITicketRepository repo)
        {
            _ticketRepo = repo;
        }

        [HttpGet, Authorize]
        public async Task<IActionResult> GetAllTickets()
        {
            try
            {
                return Ok(await _ticketRepo.GetAllTicketsAsync());
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}"), Authorize]
        public async Task<IActionResult> GetTicketById(int id)
        {
            var ticket = await _ticketRepo.GetTicketAsync(id);
            return ticket == null ? NotFound() : Ok(ticket);
        }

        [HttpPost, Authorize]
        public async Task<IActionResult> AddNewTicket(TicketDTO model)
        {
            try
            {
                var newTicketId = await _ticketRepo.AddTicketAsync(model);
                var ticket = await _ticketRepo.GetTicketAsync(newTicketId);
                return ticket == null ? NotFound() : Ok(ticket);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}"), Authorize]
        public async Task<IActionResult> UpdateTicket(int id, [FromBody] TicketDTO model)
        {
            if (id != model.ticketID)
            {
                return NotFound();
            }
            await _ticketRepo.UpdateTicketAsync(id, model);
            return Ok();
        }

        [HttpDelete("{id}"), Authorize]
        public async Task<IActionResult> DeleteTicket([FromRoute] int id)
        {
            await _ticketRepo.DeleteTicketAsync(id);
            return Ok();
        }
    }
}
