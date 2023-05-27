using HueFestivalTicketOnline.Data;
using Microsoft.AspNetCore.Mvc;
using System.Drawing.Imaging;
using System.Drawing;
using HueFestivalTicketOnline.Repositories.IRepository;
using QRCoder;
using Microsoft.EntityFrameworkCore;

namespace HueFestivalTicketOnline.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuyTicketController : ControllerBase
    {
        private readonly IEmailRepository _emailRepository;
        private readonly ITicketRepository _ticketRepository;
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly DataContext _context;
        private readonly IUserRepository _userRepository;
        private readonly IEventRepository _eventRepository;
        private readonly ILocationRepository _locationRepository;

        public BuyTicketController(ILocationRepository locationRepository, IEmailRepository emailRepository, ITicketRepository ticketRepository, IWebHostEnvironment hostingEnvironment, IUserRepository userRepository, IEventRepository eventRepository, DataContext context)
        {
            _locationRepository = locationRepository;
            _eventRepository = eventRepository;
            _userRepository = userRepository;
            _ticketRepository = ticketRepository;
            _emailRepository = emailRepository;
            _hostingEnvironment = hostingEnvironment;
            _context = context;


        }
        [HttpPost]
        public async Task<IActionResult> BuyTicket(string email, TicketDTO ticket)
        {
            var user = await _userRepository.GetUserAsync(ticket.userID);
            var events = await _eventRepository.GetEventAsync(ticket.eventID);
            var location = await _locationRepository.GetLocationAsync(ticket.locationID);
            var newTicketId = await _ticketRepository.AddTicketAsync(ticket);
            var newEmail = new EmailDTO
            {
                Subject = "Mua vé tham gia sự kiện",
                To = email,
                Body = "<h1>Đặt vé thành công</h1>"
                + "<p>Xin chào " + user.name + "." +  "<br>"
                + "Chúc mừng bạn đã đặt vé tham dự sự kiện " + events.eventName + " được diễn ra tại " + location.locationName + " thành công!</p>"
                + "<p>Dưới đây là mã vé của bạn dùng để checkin khi vào cổng.</p>"
            };  
            string publicPath = _hostingEnvironment.WebRootPath;
            string qrFolderPath = Path.Combine(publicPath, "QR");
            var data = new
            {
                TicketName = ticket.ticketName ,
                TicketTypeName = _context.TicketTypes.Where(x => x.ticketTypeID == ticket.ticketTypeID).Select(x => x.ticketTypeName).FirstOrDefault(),
                EventName = _context.Events.Where(x => x.eventID == ticket.eventID).Select(x => x.eventName).FirstOrDefault(),
                Location = _context.Locations.Where(x => x.locationID == ticket.locationID).Select(x => x.locationName).FirstOrDefault(),
                Customer = _context.Customers.Where(x => x.customerID == ticket.customerID).Select(x => x.Name).FirstOrDefault()
            }.ToString();
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(data, QRCodeGenerator.ECCLevel.Q);
            var qrCode = new QRCode(qrCodeData);

            using (Bitmap bitmap = qrCode.GetGraphic(20))
            {
                string qrFilePath = Path.Combine(qrFolderPath, "qr_code_" + Guid.NewGuid() + ".png");

                bitmap.Save(qrFilePath, ImageFormat.Png);
                await _emailRepository.SendEmailAsync(newEmail, qrFilePath);

            }
            return Ok();
        }
    }
}
