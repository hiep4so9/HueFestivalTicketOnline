namespace HueFestivalTicketOnline.Models
{
    public class FileUpload
    {
        public IFormFile? Files { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
