using AutoMapper;
using HueFestivalTicketOnline.Data;
using HueFestivalTicketOnline.Models;
using HueFestivalTicketOnline.Repositories.IRepository;
using Microsoft.EntityFrameworkCore;

namespace HueFestivalTicketOnline.Repositories
{
    public class TicketTypeRepository : ITicketTypeRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public TicketTypeRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<int> AddTicketTypeAsync(TicketTypeDTO model)
        {
            var newTicketType = _mapper.Map<TicketType>(model);
            _context.TicketTypes!.Add(newTicketType);
            await _context.SaveChangesAsync();

            return newTicketType.ticketTypeID;
        }

        public async Task DeleteTicketTypeAsync(int id)
        {
            var deleteTicketType = _context.TicketTypes!.SingleOrDefault(b => b.ticketTypeID == id);
            if (deleteTicketType != null)
            {
                _context.TicketTypes!.Remove(deleteTicketType);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<TicketTypeDTO>> GetAllTicketTypesAsync()
        {
            var TicketTypes = await _context.TicketTypes!.ToListAsync();
            return _mapper.Map<List<TicketTypeDTO>>(TicketTypes);
        }

        public async Task<TicketTypeDTO> GetTicketTypeAsync(int id)
        {
            var TicketTypes = await _context.TicketTypes!.FindAsync(id);
            return _mapper.Map<TicketTypeDTO>(TicketTypes);
        }

        public async Task UpdateTicketTypeAsync(int id, TicketTypeDTO model)
        {
            if (id == model.ticketTypeID)
            {
                var updateTicketType = _mapper.Map<TicketType>(model);
                _context.TicketTypes!.Update(updateTicketType);
                await _context.SaveChangesAsync();
            }
        }
    }
}
