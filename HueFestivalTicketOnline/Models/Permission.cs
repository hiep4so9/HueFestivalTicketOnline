using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HueFestivalTicketOnline.Models
{
    [Table("Permission")]
    public class Permission
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int permissionID { get; set; }
        [Required]
        [StringLength(50)]
        public string? permissionName { get; set; }
        public string? description { get; set; }
        public virtual ICollection<Role_Permission>? Role_Permissions { get; set; }

    }
}
