using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HueFestivalTicketOnline.Models
{
    [Table("Ticket")]
    public class Ticket
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ticketID { get; set; }
        public string? ticketName { get; set; }
        public bool status { get; set; }
        public int price { get; set; }
        public DateTime create_at { get; set; }
        public DateTime update_at { get; set; }


        [ForeignKey("customerID")]
        public Customer? Customer { get; set; }

        [ForeignKey("userID")]
        public User? User { get; set; }

        [ForeignKey("locationID")]
        public Location? Location { get; set; }

        [ForeignKey("eventID")]
        public Event? Event { get; set; }

        [ForeignKey("ticketTypeID")]
        public TicketType? TicketType { get; set; }
    }
}
