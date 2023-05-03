using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HueFestivalTicketOnline.Models
{
    [Table("User")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int userID { get; set; }
        [Required]
        [StringLength(16)]
        public string? username { get; set; }
        [Required]
        [StringLength(16)]
        public string? password { get; set; }
        [StringLength(50)]
        public string? userImage { get; set; }
        [Required]
        public bool isActive { get; set; }
        [StringLength(100)]
        public string? address { get; set; }
        [StringLength(50)]
        public string? name { get; set; }
        [Phone]
        public string? phone { get; set; }
        public DateTime create_at { get; set; }
        public DateTime update_at { get; set; }

        public virtual ICollection<User_Role>? User_Roles { get; set; }
    }
}
