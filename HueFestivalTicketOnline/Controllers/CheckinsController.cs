using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;
using ZXing;
using ZXing.Windows.Compatibility;

namespace HueFestivalTicketOnline.Controllers
{
    [Route("api/[controller]")]
    [ApiController, Authorize]
    public class CheckinsController : ControllerBase
    {
        [HttpPost("qrcode")]
        public IActionResult DecodeQRCode(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("No file uploaded.");
            }

            using (var stream = file.OpenReadStream())
            {
                var reader = new BarcodeReader();
                var result = reader.Decode(new BitmapLuminanceSource(new Bitmap(stream)));

                if (result != null)
                {
                    string decodedData = result.Text;
                    return Ok(decodedData);
                }
                else
                {
                    return BadRequest("Unable to decode QR code.");
                }
            }
        }
    }
}
