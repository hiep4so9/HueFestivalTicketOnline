using AutoMapper;
using HueFestivalTicketOnline.Data;
using HueFestivalTicketOnline.Models;
using HueFestivalTicketOnline.Repositories.IRepository;
using Microsoft.EntityFrameworkCore;

namespace HueFestivalTicketOnline.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public EventRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<int> AddEventAsync(EventDTO model)
        {
            var newEvent = _mapper.Map<Event>(model);
            _context.Events!.Add(newEvent);
            await _context.SaveChangesAsync();

            return newEvent.eventID;
        }

        public async Task DeleteEventAsync(int id)
        {
            var deleteEvent = _context.Events!.SingleOrDefault(b => b.eventID == id);
            if (deleteEvent != null)
            {
                _context.Events!.Remove(deleteEvent);
                await _context.SaveChangesAsync();
            }
        }

            public async Task<List<EventDTO>> GetAllEventsAsync()
        {
            var events = await _context.Events!.ToListAsync();
            return _mapper.Map<List<EventDTO>>(events);
        }

        public async Task<EventDTO> GetEventAsync(int id)
        {
            var events = await _context.Events!.FindAsync(id);
            return _mapper.Map<EventDTO>(events);
        }

        public async Task UpdateEventAsync(int id, EventDTO model)
        {
            if (id == model.eventID)
            {
                var updateEvent = _mapper.Map<Event>(model);
                _context.Events!.Update(updateEvent);
                await _context.SaveChangesAsync();
            }
        }
    }
}
