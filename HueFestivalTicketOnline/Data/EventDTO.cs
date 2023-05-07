using HueFestivalTicketOnline.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace HueFestivalTicketOnline.Data
{
    public class EventDTO
    {
        public int eventID { get; set; }
        public string? eventName { get; set; }
        public string? eventContent { get; set; }
        public DateTime create_at { get; set; }
        public DateTime update_at { get; set; }
        public int eventTypeID { get; set; }
    }
}
