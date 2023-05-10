using AutoMapper;
using HueFestivalTicketOnline.Data;
using HueFestivalTicketOnline.Models;
using HueFestivalTicketOnline.Repositories.IRepository;
using Microsoft.EntityFrameworkCore;

namespace HueFestivalTicketOnline.Repositories
{
    public class TicketRepository : ITicketRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public TicketRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<int> AddTicketAsync(TicketDTO model)
        {
            var newTicket = _mapper.Map<Ticket>(model);
            _context.Tickets!.Add(newTicket);
            await _context.SaveChangesAsync();

            return newTicket.ticketID;
        }

        public async Task DeleteTicketAsync(int id)
        {
            var deleteTicket = _context.Tickets!.SingleOrDefault(b => b.ticketID == id);
            if (deleteTicket != null)
            {
                _context.Tickets!.Remove(deleteTicket);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<TicketDTO>> GetAllTicketsAsync()
        {
            var Tickets = await _context.Tickets!.ToListAsync();
            return _mapper.Map<List<TicketDTO>>(Tickets);
        }

        public async Task<TicketDTO> GetTicketAsync(int id)
        {
            var Tickets = await _context.Tickets!.FindAsync(id);
            return _mapper.Map<TicketDTO>(Tickets);
        }

        public async Task UpdateTicketAsync(int id, TicketDTO model)
        {
            if (id == model.ticketID)
            {
                var updateTicket = _mapper.Map<Ticket>(model);
                _context.Tickets!.Update(updateTicket);
                await _context.SaveChangesAsync();
            }
        }
    }
}
