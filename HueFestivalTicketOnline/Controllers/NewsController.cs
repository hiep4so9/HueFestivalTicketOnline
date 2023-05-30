using HueFestivalTicketOnline.Data;
using HueFestivalTicketOnline.Helpers;
using HueFestivalTicketOnline.Models;
using HueFestivalTicketOnline.Repositories.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HueFestivalTicketOnline.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly INewsRepository _newsRepo;

        public NewsController(INewsRepository repo)
        {
            _newsRepo = repo;
        }

        [HttpGet, Authorize(Roles ="Admin")]
        public async Task<IActionResult> GetAllNews(int page = 1, int pageSize = 10)
        {
            try
            {
                var allNews = await _newsRepo.GetAllNewsAsync();
                var paginatedNews = Pagination.Paginate(allNews, page, pageSize);

                var totalNews = allNews.Count;
                var totalPages = Pagination.CalculateTotalPages(totalNews, pageSize);

                var paginationInfo = new
                {
                    TotalNews = totalNews,
                    Page = page,
                    PageSize = pageSize,
                    TotalPages = totalPages
                };

                return Ok(new { News = paginatedNews, Pagination = paginationInfo });
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}"), Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetNewsById(int id)
        {
            var news = await _newsRepo.GetNewsAsync(id);
            return news == null ? NotFound() : Ok(news);
        }

        [HttpPost, Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddNewNews(NewsDTO model)
        {
            try
            {
                var newNewsId = await _newsRepo.AddNewsAsync(model);
                var news = await _newsRepo.GetNewsAsync(newNewsId);
                return news == null ? NotFound() : Ok(news);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}"), Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateNews(int id, [FromBody] NewsDTO model)
        {
            if (id != model.newsID)
            {
                return NotFound();
            }
            await _newsRepo.UpdateNewsAsync(id, model);
            return Ok();
        }

        [HttpDelete("{id}"), Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteNews([FromRoute] int id)
        {
            await _newsRepo.DeleteNewsAsync(id);
            return Ok();
        }
    }
}
