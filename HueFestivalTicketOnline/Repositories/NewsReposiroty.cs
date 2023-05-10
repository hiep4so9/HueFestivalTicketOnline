using AutoMapper;
using HueFestivalTicketOnline.Data;
using HueFestivalTicketOnline.Models;
using HueFestivalTicketOnline.Repositories.IRepository;
using Microsoft.EntityFrameworkCore;

namespace HueFestivalTicketOnline.Repositories
{
    public class NewsRepository : INewsRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public NewsRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<int> AddNewsAsync(NewsDTO model)
        {
            var newNews = _mapper.Map<News>(model);
            _context.News!.Add(newNews);
            await _context.SaveChangesAsync();

            return newNews.newsID;
        }

        public async Task DeleteNewsAsync(int id)
        {
            var deleteNews = _context.News!.SingleOrDefault(b => b.newsID == id);
            if (deleteNews != null)
            {
                _context.News!.Remove(deleteNews);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<NewsDTO>> GetAllNewsAsync()
        {
            var Newss = await _context.News!.ToListAsync();
            return _mapper.Map<List<NewsDTO>>(Newss);
        }

        public async Task<NewsDTO> GetNewsAsync(int id)
        {
            var Newss = await _context.News!.FindAsync(id);
            return _mapper.Map<NewsDTO>(Newss);
        }

        public async Task UpdateNewsAsync(int id, NewsDTO model)
        {
            if (id == model.newsID)
            {
                var updateNews = _mapper.Map<News>(model);
                _context.News!.Update(updateNews);
                await _context.SaveChangesAsync();
            }
        }
    }
}
