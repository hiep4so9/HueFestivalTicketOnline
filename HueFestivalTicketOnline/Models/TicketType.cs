using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HueFestivalTicketOnline.Models
{
    [Table("TicketType")]
    public class TicketType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ticketTypeID { get; set; }
        [Required]
        [StringLength(50)]
        public string? ticketTypeName { get; set; }
    }
}
