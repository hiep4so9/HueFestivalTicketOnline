using System.ComponentModel.DataAnnotations;

namespace HueFestivalTicketOnline.Data
{
    public class NewsDTO
    {
        public int newsID { get; set; }
        public string? newName { get; set; }
        public string? newsContent { get; set; }
        public DateTime create_at { get; set; }
        public DateTime update_at { get; set; }
        public int eventID { get; set; }
    }
}
