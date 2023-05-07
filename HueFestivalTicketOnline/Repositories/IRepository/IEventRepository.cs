using HueFestivalTicketOnline.Data;

namespace HueFestivalTicketOnline.Repositories.IRepository
{
    public interface IEventRepository
    {
        public Task<List<EventDTO>> GetAllEventsAsync();
        public Task<EventDTO> GetEventAsync(int id);
        public Task<int> AddEventAsync(EventDTO model);
        public Task UpdateEventAsync(int id, EventDTO model);
        public Task DeleteEventAsync(int id);
    }
}
