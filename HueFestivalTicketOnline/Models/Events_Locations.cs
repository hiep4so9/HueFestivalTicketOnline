using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HueFestivalTicketOnline.Models
{
    [Table("Events_Locations")]
    public class Events_Locations
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int locationID { get; set; }
        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int eventID { get; set; }
        public int ticketQuantity { get; set; }
        public DateTime start_at { get; set; }
        public DateTime end_at { get; set; }
        public DateTime create_at { get; set; }
        public DateTime update_at { get; set; }

        public Location? Location { get; set; }
        public Event? Event { get; set; }
    }
}
