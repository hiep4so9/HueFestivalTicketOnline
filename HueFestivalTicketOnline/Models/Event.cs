using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HueFestivalTicketOnline.Models
{
    [Table("Event")]
    public class Event
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int eventID { get; set; }
        public string? eventName { get; set; }
        public string? eventContent { get; set; }
        public DateTime create_at { get; set; }
        public DateTime update_at { get; set; }
        public int eventTypeID { get; set; }

        [ForeignKey("eventTypeID")]
        public EventType? EventType { get; set; }
        public virtual ICollection<Artists_Invited>? Artists_Inviteds { get; set; }
        public virtual ICollection<Event_Images>? Event_Images { get; set; }
        public virtual ICollection<Events_Locations>? Events_Locations { get; set; }
    }
}
