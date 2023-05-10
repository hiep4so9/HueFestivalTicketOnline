using System.ComponentModel.DataAnnotations.Schema;

namespace HueFestivalTicketOnline.Data
{
    public class Events_LocationsDTO
    {
        public int locationID { get; set; }
        public int eventID { get; set; }
        public int ticketQuantity { get; set; }
        public DateTime start_at { get; set; }
        public DateTime end_at { get; set; }
        public DateTime create_at { get; set; }
        public DateTime update_at { get; set; }
    }
}
