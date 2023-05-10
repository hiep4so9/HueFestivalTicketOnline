using AutoMapper;
using HueFestivalTicketOnline.Data;
using HueFestivalTicketOnline.Models;
using HueFestivalTicketOnline.Repositories.IRepository;
using Microsoft.EntityFrameworkCore;

namespace HueFestivalTicketOnline.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public CustomerRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<int> AddCustomerAsync(CustomerDTO model)
        {
            var newCustomer = _mapper.Map<Customer>(model);
            _context.Customers!.Add(newCustomer);
            await _context.SaveChangesAsync();

            return newCustomer.customerID;
        }

        public async Task DeleteCustomerAsync(int id)
        {
            var deleteCustomer = _context.Customers!.SingleOrDefault(b => b.customerID == id);
            if (deleteCustomer != null)
            {
                _context.Customers!.Remove(deleteCustomer);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<CustomerDTO>> GetAllCustomersAsync()
        {
            var Customers = await _context.Customers!.ToListAsync();
            return _mapper.Map<List<CustomerDTO>>(Customers);
        }

        public async Task<CustomerDTO> GetCustomerAsync(int id)
        {
            var Customers = await _context.Customers!.FindAsync(id);
            return _mapper.Map<CustomerDTO>(Customers);
        }

        public async Task UpdateCustomerAsync(int id, CustomerDTO model)
        {
            if (id == model.customerID)
            {
                var updateCustomer = _mapper.Map<Customer>(model);
                _context.Customers!.Update(updateCustomer);
                await _context.SaveChangesAsync();
            }
        }
    }
}
