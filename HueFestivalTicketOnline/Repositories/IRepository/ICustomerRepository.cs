using HueFestivalTicketOnline.Data;

namespace HueFestivalTicketOnline.Repositories.IRepository
{
    public interface ICustomerRepository
    {
        public Task<List<CustomerDTO>> GetAllCustomersAsync();
        public Task<CustomerDTO> GetCustomerAsync(int id);
        public Task<int> AddCustomerAsync(CustomerDTO model);
        public Task UpdateCustomerAsync(int id, CustomerDTO model);
        public Task DeleteCustomerAsync(int id);
    }
}
