using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HueFestivalTicketOnline.Models
{
    [Table("Location")]
    public class Location
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int locationID { get; set; }
        [StringLength(50)]
        public string? locationName { get; set; }
        [StringLength(50)]
        public string? description { get; set; }

        public virtual ICollection<Events_Locations>? Events_Locations { get; set; }
    }
}
