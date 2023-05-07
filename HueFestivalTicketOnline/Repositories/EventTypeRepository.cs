using AutoMapper;
using HueFestivalTicketOnline.Data;
using HueFestivalTicketOnline.Models;
using HueFestivalTicketOnline.Repositories.IRepository;
using Microsoft.EntityFrameworkCore;

namespace HueFestivalTicketOnline.Repositories
{
    public class EventTypeRepository : IEventTypeRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public EventTypeRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> AddEventTypeAsync(EventTypeDTO model)
        {
            var newEventType = _mapper.Map<EventType>(model);
            _context.EventTypes!.Add(newEventType);
            await _context.SaveChangesAsync();

            return newEventType.eventTypeID;
        }

        public async Task DeleteEventTypeAsync(int id)
        {
            var deleteEventType = _context.EventTypes!.SingleOrDefault(b => b.eventTypeID == id);
            if (deleteEventType != null)
            {
                _context.EventTypes!.Remove(deleteEventType);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<EventTypeDTO>> GetAllEventTypesAsync()
        {
            var eventTypes = await _context.EventTypes!.ToListAsync();
            return _mapper.Map<List<EventTypeDTO>>(eventTypes);
        }

        public async Task<EventTypeDTO> GetEventTypeAsync(int id)
        {
            var eventTypes = await _context.EventTypes!.FindAsync(id);
            return _mapper.Map<EventTypeDTO>(eventTypes);
        }

        public async Task UpdateEventTypeAsync(int id, EventTypeDTO model)
        {
            if (id == model.eventTypeID)
            {
                var updateEventType = _mapper.Map<EventType>(model);
                _context.EventTypes!.Update(updateEventType);
                await _context.SaveChangesAsync();
            }
        }
    }
}
