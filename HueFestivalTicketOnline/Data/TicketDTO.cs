namespace HueFestivalTicketOnline.Data
{
    public class TicketDTO
    {
        public int ticketID { get; set; }
        public string? ticketName { get; set; }
        public bool status { get; set; }
        public int price { get; set; }
        public DateTime create_at { get; set; }
        public DateTime update_at { get; set; }
        public int customerID { get; set; }
        public int userID { get; set; }
        public int locationID { get; set; }
        public int eventID { get; set; }
        public int ticketTypeID { get; set; }
    }
}
