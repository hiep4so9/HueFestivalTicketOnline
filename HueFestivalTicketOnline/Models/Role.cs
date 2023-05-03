using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HueFestivalTicketOnline.Models
{
    [Table("Role")]
    public class Role
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int roleID { get; set; }
        [MaxLength(50)]
        public string? roleName { get; set; }
        public string? description { get; set; }

        public virtual ICollection<User_Role>? User_Roles { get; set; }
        public virtual ICollection<Role_Permission>? Role_Permissions { get; set; }
    }
}
