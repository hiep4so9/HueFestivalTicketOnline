using HueFestivalTicketOnline.Data;
using HueFestivalTicketOnline.Helpers;
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

        [HttpGet, Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllTicketTypes(int page = 1, int pageSize = 10)
        {
            try
            {
                var allTicketTypes = await _ticketTypeRepo.GetAllTicketTypesAsync();
                var paginatedTicketTypes = Pagination.Paginate(allTicketTypes, page, pageSize);

                var totalTicketTypes = allTicketTypes.Count;
                var totalPages = Pagination.CalculateTotalPages(totalTicketTypes, pageSize);

                var paginationInfo = new
                {
                    TotalTicketTypes = totalTicketTypes,
                    Page = page,
                    PageSize = pageSize,
                    TotalPages = totalPages
                };

                return Ok(new { TicketTypes = paginatedTicketTypes, Pagination = paginationInfo });
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}"), Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetTicketTypeById(int id)
        {
            var ticketType = await _ticketTypeRepo.GetTicketTypeAsync(id);
            return ticketType == null ? NotFound() : Ok(ticketType);
        }

        [HttpPost, Authorize(Roles = "Admin")]
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

        [HttpPut("{id}"), Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateTicketType(int id, [FromBody] TicketTypeDTO model)
        {
            if (id != model.ticketTypeID)
            {
                return NotFound();
            }
            await _ticketTypeRepo.UpdateTicketTypeAsync(id, model);
            return Ok();
        }

        [HttpDelete("{id}"), Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteTicketType([FromRoute] int id)
        {
            await _ticketTypeRepo.DeleteTicketTypeAsync(id);
            return Ok();
        }
    }
}
