using HueFestivalTicketOnline.Data;
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

        [HttpGet, Authorize]
        public async Task<IActionResult> GetAllNewss()
        {
            try
            {
                return Ok(await _newsRepo.GetAllNewsAsync());
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetNewsById(int id)
        {
            var news = await _newsRepo.GetNewsAsync(id);
            return news == null ? NotFound() : Ok(news);
        }

        [HttpPost]
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

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateNews(int id, [FromBody] NewsDTO model)
        {
            if (id != model.newsID)
            {
                return NotFound();
            }
            await _newsRepo.UpdateNewsAsync(id, model);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNews([FromRoute] int id)
        {
            await _newsRepo.DeleteNewsAsync(id);
            return Ok();
        }
    }
}
