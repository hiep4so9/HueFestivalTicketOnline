using AutoMapper;
using HueFestivalTicketOnline.Data;
using HueFestivalTicketOnline.Models;
using HueFestivalTicketOnline.Repositories.IRepository;
using Microsoft.EntityFrameworkCore;

namespace HueFestivalTicketOnline.Repositories
{
    public class EventImageRepository : IEventImageRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public EventImageRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<int> AddEventImageAsync(EventImageDTO model)
        {
            var newEventImage = _mapper.Map<EventImage>(model);
            _context.EventImages!.Add(newEventImage);
            await _context.SaveChangesAsync();

            return newEventImage.eventImageID;
        }

        public async Task DeleteEventImageAsync(int id)
        {
            var deleteEventImage = _context.EventImages!.SingleOrDefault(b => b.eventImageID == id);
            if (deleteEventImage != null)
            {
                _context.EventImages!.Remove(deleteEventImage);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<EventImageDTO>> GetAllEventImagesAsync()
        {
            var EventImages = await _context.EventImages!.ToListAsync();
            return _mapper.Map<List<EventImageDTO>>(EventImages);
        }

        public async Task<EventImageDTO> GetEventImageAsync(int id)
        {
            var EventImages = await _context.EventImages!.FindAsync(id);
            return _mapper.Map<EventImageDTO>(EventImages);
        }

        public async Task UpdateEventImageAsync(int id, EventImageDTO model)
        {
            if (id == model.eventImageID)
            {
                var updateEventImage = _mapper.Map<EventImage>(model);
                _context.EventImages!.Update(updateEventImage);
                await _context.SaveChangesAsync();
            }
        }
    }
}
