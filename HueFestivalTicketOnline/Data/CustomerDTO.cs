namespace HueFestivalTicketOnline.Data
{
    public class CustomerDTO
    {
        public int customerID { get; set; }
        public string? Name { get; set; }
        public DateTime birthday { get; set; }
        public string? identityCardNumber { get; set; }
        public string? paymentInfo { get; set; }
    }
}
