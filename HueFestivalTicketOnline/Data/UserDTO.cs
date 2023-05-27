using System.ComponentModel.DataAnnotations;

namespace HueFestivalTicketOnline.Data
{
    public class UserDTO
    {
        public int userID { get; set; }
        public string? username { get; set; }
        public string? password { get; set; } = string.Empty;

        public string? phone { get; set; }
        public string? Email { get; set; }
        public bool isActive { get; set; }
        public string? name { get; set; }

        public string RefreshToken { get; set; } = string.Empty;
        public DateTime TokenCreated { get; set; }
        public DateTime TokenExpires { get; set; }

        public string? VerificationToken { get; set; }
        public DateTime? VerifyAt { get; set; }
        public string PasswordResetToken { get; set; } = string.Empty;
        public DateTime? ResetTokenExpries { get; set; }

    }
}
