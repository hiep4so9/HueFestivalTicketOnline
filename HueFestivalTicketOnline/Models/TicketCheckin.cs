using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HueFestivalTicketOnline.Models
{
    [Table("TicketCheckin")]
    public class TicketCheckin
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ticketCheckinID { get; set; }
        public DateTime create_at { get; set; }
        public DateTime update_at { get; set; }
        public int ticketID { get; set; }

        [ForeignKey("ticketID")]
        public Ticket? Ticket { get; set; }
    }
}
