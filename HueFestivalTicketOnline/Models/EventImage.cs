using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HueFestivalTicketOnline.Models
{
    [Table("EventImage")]
    public class EventImage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int eventImageID { get; set; }
        [StringLength(50)]
        public string? eventImageName { get; set; }

        public virtual ICollection<Event_Images>? Event_Images { get; set; }
    }
}
