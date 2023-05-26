using HueFestivalTicketOnline.Data;
using HueFestivalTicketOnline.Models;
using HueFestivalTicketOnline.Repositories.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Sockets;

namespace HueFestivalTicketOnline.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketTypesController : ControllerBase
    {
        private readonly ITicketTypeRepository _ticketTypeRepo;

        public TicketTypesController(ITicketTypeRepository repo)
        {
            _ticketTypeRepo = repo;
        }

        [HttpGet, Authorize] 
        public async Task<IActionResult> GetAllTicketTypes()
        {
            try
            {
                return Ok(await _ticketTypeRepo.GetAllTicketTypesAsync());
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}"), Authorize]
        public async Task<IActionResult> GetTicketTypeById(int id)
        {
            var ticketType = await _ticketTypeRepo.GetTicketTypeAsync(id);
            return ticketType == null ? NotFound() : Ok(ticketType);
        }

        [HttpPost, Authorize]
        public async Task<IActionResult> AddNewTicketType(TicketTypeDTO model)
        {
            try
            {
                var newTicketTypeId = await _ticketTypeRepo.AddTicketTypeAsync(model);
                var ticketType = await _ticketTypeRepo.GetTicketTypeAsync(newTicketTypeId);
                return ticketType == null ? NotFound() : Ok(ticketType);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}"), Authorize]
        public async Task<IActionResult> UpdateTicketType(int id, [FromBody] TicketTypeDTO model)
        {
            if (id != model.ticketTypeID)
            {
                return NotFound();
            }
            await _ticketTypeRepo.UpdateTicketTypeAsync(id, model);
            return Ok();
        }

        [HttpDelete("{id}"), Authorize]
        public async Task<IActionResult> DeleteTicketType([FromRoute] int id)
        {
            await _ticketTypeRepo.DeleteTicketTypeAsync(id);
            return Ok();
        }
    }
}
