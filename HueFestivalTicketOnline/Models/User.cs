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
        [StringLength(255)]
        public string? userImage { get; set; }
        [Required]
        public bool isActive { get; set; }
        [StringLength(100)]
        public string? address { get; set; }    
        [StringLength(50)]
        public string? name { get; set; }
        public string? phone { get; set; }

        public string? Email { get; set; }
        public DateTime create_at { get; set; }
        public DateTime update_at { get; set; }

        public string RefreshToken { get; set; } = string.Empty;
        public DateTime TokenCreated { get; set; }
        public DateTime TokenExpires { get; set; }

        public string? VerificationToken { get; set; }
        public DateTime? VerifyAt { get; set; }
        public string PasswordResetToken { get; set; } = string.Empty;
        public DateTime? ResetTokenExpries { get; set; }

        public virtual ICollection<User_Role>? User_Roles { get; set; }

    }
}
