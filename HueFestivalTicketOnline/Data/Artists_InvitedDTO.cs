using System.ComponentModel.DataAnnotations.Schema;

namespace HueFestivalTicketOnline.Data
{
    public class Artists_InvitedDTO
    {
        public int artistID { get; set; }
        public int eventID { get; set; }
    }
}
