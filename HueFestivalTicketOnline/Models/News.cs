using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HueFestivalTicketOnline.Models
{
    [Table("News")]
    public class News
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int newsID { get; set; }
        [StringLength(50)]
        public string? newName { get; set; }
        public string? newsContent { get; set; }
        public DateTime create_at { get; set; }
        public DateTime update_at { get; set; }
        public int eventID { get; set; }

        [ForeignKey("eventID")]
        public Event? Event { get; set; }
    }
}
