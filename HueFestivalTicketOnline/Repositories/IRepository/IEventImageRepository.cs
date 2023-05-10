using HueFestivalTicketOnline.Data;

namespace HueFestivalTicketOnline.Repositories.IRepository
{
    public interface IEventImageRepository
    {
        public Task<List<EventImageDTO>> GetAllEventImagesAsync();
        public Task<EventImageDTO> GetEventImageAsync(int id);
        public Task<int> AddEventImageAsync(EventImageDTO model);
        public Task UpdateEventImageAsync(int id, EventImageDTO model);
        public Task DeleteEventImageAsync(int id);
    }
}
