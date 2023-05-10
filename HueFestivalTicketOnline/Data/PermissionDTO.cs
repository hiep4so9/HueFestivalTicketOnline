using System.ComponentModel.DataAnnotations;

namespace HueFestivalTicketOnline.Data
{
    public class PermissionDTO
    {
        public int permissionID { get; set; }
        public string? permissionName { get; set; }
        public string? description { get; set; }
    }
}
