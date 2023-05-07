using System.ComponentModel.DataAnnotations;

namespace HueFestivalTicketOnline.Data
{
    public class LocationDTO
    {
        public int locationID { get; set; }
        public string? locationName { get; set; }
        public string? description { get; set; }
    }
}
