using System.ComponentModel.DataAnnotations;

namespace HueFestivalTicketOnline.Data
{
    public class RoleDTO
    {
        public int roleID { get; set; }
        public string? roleName { get; set; }
        public string? description { get; set; }
    }
}
