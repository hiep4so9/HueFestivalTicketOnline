using HueFestivalTicketOnline.Data;

namespace HueFestivalTicketOnline.Repositories.IRepository
{
    public interface INewsRepository
    {
        public Task<List<NewsDTO>> GetAllNewsAsync();
        public Task<NewsDTO> GetNewsAsync(int id);
        public Task<int> AddNewsAsync(NewsDTO model);
        public Task UpdateNewsAsync(int id, NewsDTO model);
        public Task DeleteNewsAsync(int id);
    }
}
