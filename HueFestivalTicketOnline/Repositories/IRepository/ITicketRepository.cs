using HueFestivalTicketOnline.Data;

namespace HueFestivalTicketOnline.Repositories.IRepository
{
    public interface ITicketRepository
    {
        public Task<List<TicketDTO>> GetAllTicketsAsync();
        public Task<TicketDTO> GetTicketAsync(int id);
        public Task<int> AddTicketAsync(TicketDTO model);
        public Task UpdateTicketAsync(int id, TicketDTO model);
        public Task DeleteTicketAsync(int id);
    }
}
