using HueFestivalTicketOnline.Data;
using HueFestivalTicketOnline.Helpers;
using HueFestivalTicketOnline.Models;
using HueFestivalTicketOnline.Prototypes;
using HueFestivalTicketOnline.Repositories.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HueFestivalTicketOnline.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventImagesController : ControllerBase
    {
        private readonly IEventImageRepository _eventImageRepo;
        private readonly ILogger<EventImagesController> _logger;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public EventImagesController(IEventImageRepository repo, ILogger<EventImagesController>  logger,  IWebHostEnvironment webHostEnvironment)
        {
            _eventImageRepo = repo;
            _logger = logger;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet, Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllEventImages(int page = 1, int pageSize = 10)
        {
            _logger.LogInformation("get");
            try
            {
                var eventPictures = await _eventImageRepo.GetAllEventImagesAsync();
                if (eventPictures != null && eventPictures.Count() > 0)
                {

                    foreach (var item in eventPictures)
                    {
                        item.eventImageName = "http://localhost:7254/api/EventImages/get-image-by-id?id=" + item.eventImageID;
                    }
                }
                var paginatedPictures = Pagination.Paginate(eventPictures, page, pageSize);

                var totalPictures = eventPictures.Count;
                var totalPages = Pagination.CalculateTotalPages(totalPictures, pageSize);

                var paginationInfo = new
                {
                    TotalPictures = totalPictures,
                    Page = page,
                    PageSize = pageSize,
                    TotalPages = totalPages
                };

                return Ok(new { Pictures = paginatedPictures, Pagination = paginationInfo });
            }
            catch (System.Exception e)
            {
                _logger.LogError(e.ToString());
                return BadRequest();
            }
        }

        [HttpGet("get-image-by-id"), Authorize(Roles = "User")]
        public async Task<IActionResult> GetEventImageById(int id)
        {
            var images = await _eventImageRepo.GetEventImageAsync(id);
            var image = System.IO.File.OpenRead(_webHostEnvironment.WebRootPath + "\\Images\\" + images.eventImageName);
            return File(image, "image/jpeg");
        }


        [HttpPost, Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddNewEventImage(EventImageDTO model)
        {
            try
            {
                var newEventImageId = await _eventImageRepo.AddEventImageAsync(model);
                var eventImage = await _eventImageRepo.GetEventImageAsync(newEventImageId);
                return eventImage == null ? NotFound() : Ok(eventImage);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}"), Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateEventImage(int id, [FromBody] EventImageDTO model)
        {
            if (id != model.eventImageID)
            {
                return NotFound();
            }
            await _eventImageRepo.UpdateEventImageAsync(id, model);
            return Ok();
        }

        [HttpDelete("{id}"), Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteEventImage([FromRoute] int id)
        {
            await _eventImageRepo.DeleteEventImageAsync(id);
            return Ok();
        }

        [HttpPost("upload"), Authorize(Roles = "User")]
        public async Task<IActionResult> Upload([FromForm] FileUpload obj)
        {
            if (obj.Files!.Length > 0)
            {
                try
                {
                    if (!Directory.Exists(_webHostEnvironment.WebRootPath + "\\Images\\"))
                    {
                        Directory.CreateDirectory(_webHostEnvironment.WebRootPath + "\\Images\\");
                    }
                    Guid id = Guid.NewGuid();
                    using (FileStream fileStream = System.IO.File.Create(_webHostEnvironment.WebRootPath + "\\Images\\" + id + obj.Files.FileName))
                    {
                        obj.Files.CopyTo(fileStream);
                        await fileStream.FlushAsync();
                        var eventPicture = new EventImageDTO
                        {
                            eventImageName = id + obj.Files.FileName,
                        };
                        await _eventImageRepo.AddEventImageAsync(eventPicture);
                        return Ok(new ApiResponse
                        {
                            Data = "\\Images\\" + obj.Files.FileName,
                            Message = "upload success",
                            Success = true
                        });
                    }
                }
                catch (System.Exception ex)
                {

                    return BadRequest(new ApiResponse
                    {
                        Data = null,
                        Message = ex.ToString(),
                        Success = false
                    });
                }
            }
            else
            {
                return BadRequest(new ApiResponse
                {
                    Data = null,
                    Message = "upload fail",
                    Success = false
                });
            }
        }
    }
}
