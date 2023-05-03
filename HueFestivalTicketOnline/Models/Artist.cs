using HueFestivalTicketOnline.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HueFestivalTicketOnline.Model
{
    [Table("Artist")]
    public class Artist
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int artistID { get; set; }

        [MaxLength(50)]
        public string? artistName { get; set; }

        public ICollection<Artists_Invited>? Artists_Inviteds { get; set; }

    }
}
