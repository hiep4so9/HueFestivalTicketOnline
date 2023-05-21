using System.ComponentModel.DataAnnotations;

namespace HueFestivalTicketOnline.Data
{
    public class UserDTO
    {
        public int userID { get; set; }
        public string? username { get; set; }
        public string? password { get; set; }
        public string? PasswordResetToken { get; set; }

        public string? phone { get; set; }
        public string? Email { get; set; }
        public string? name { get; set; }
/*        public string? userImage { get; set; }
        public bool isActive { get; set; }
        public string? address { get; set; }
        */
    }
}
