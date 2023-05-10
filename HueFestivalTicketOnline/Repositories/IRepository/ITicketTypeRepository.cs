using HueFestivalTicketOnline.Data;

namespace HueFestivalTicketOnline.Repositories.IRepository
{
    public interface ITicketTypeRepository
    {
        public Task<List<TicketTypeDTO>> GetAllTicketTypesAsync();
        public Task<TicketTypeDTO> GetTicketTypeAsync(int id);
        public Task<int> AddTicketTypeAsync(TicketTypeDTO model);
        public Task UpdateTicketTypeAsync(int id, TicketTypeDTO model);
        public Task DeleteTicketTypeAsync(int id);
    }
}
