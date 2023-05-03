using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HueFestivalTicketOnline.Models
{
    [Table("Customer")]
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int customerID { get; set; }
        [StringLength(50)]
        public string? Name { get; set; }
        public DateTime birthday { get; set; }
        [StringLength(20)]
        public string? identityCardNumber { get; set; }
        [StringLength(50)]
        public string? paymentInfo { get; set; }
    }
}
