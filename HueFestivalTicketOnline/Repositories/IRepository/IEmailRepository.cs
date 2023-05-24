using HueFestivalTicketOnline.Data;

namespace HueFestivalTicketOnline.Repositories.IRepository
{
    public interface IEmailRepository
    {
        Task SendEmailAsync(EmailDTO request, string filepath = null!);
    }
}
