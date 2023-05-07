using HueFestivalTicketOnline.Data;

namespace HueFestivalTicketOnline.Repositories.IRepository
{
    public interface IEventTypeRepository
    {
        public Task<List<EventTypeDTO>> GetAllEventTypesAsync();
        public Task<EventTypeDTO> GetEventTypeAsync(int id);
        public Task<int> AddEventTypeAsync(EventTypeDTO model);
        public Task UpdateEventTypeAsync(int id, EventTypeDTO model);
        public Task DeleteEventTypeAsync(int id);
    }
}
