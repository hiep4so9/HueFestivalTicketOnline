using HueFestivalTicketOnline.Data;
using HueFestivalTicketOnline.Helpers;
using HueFestivalTicketOnline.Repositories.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HueFestivalTicketOnline.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepo;

        public CustomersController(ICustomerRepository repo)
        {
            _customerRepo = repo;
        }

        [HttpGet, Authorize]
        public async Task<IActionResult> GetAllCustomers(int page = 1, int pageSize = 10)
        {
            try
            {
                var allCustomers = await _customerRepo.GetAllCustomersAsync();
                var paginatedCustomers = Pagination.Paginate(allCustomers, page, pageSize);

                var totalCustomers = allCustomers.Count;
                var totalPages = Pagination.CalculateTotalPages(totalCustomers, pageSize);

                var paginationInfo = new
                {
                    TotalCustomers = totalCustomers,
                    Page = page,
                    PageSize = pageSize,
                    TotalPages = totalPages
                };

                return Ok(new { Customers = paginatedCustomers, Pagination = paginationInfo });
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}"), Authorize]
        public async Task<IActionResult> GetCustomerById(int id)
        {
            var customer = await _customerRepo.GetCustomerAsync(id);
            return customer == null ? NotFound() : Ok(customer);
        }

        [HttpPost, Authorize]
        public async Task<IActionResult> AddNewCustomer(CustomerDTO model)
        {
            try
            {
                var newCustomerId = await _customerRepo.AddCustomerAsync(model);
                var customer = await _customerRepo.GetCustomerAsync(newCustomerId);
                return customer == null ? NotFound() : Ok(customer);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}"), Authorize]
        public async Task<IActionResult> UpdateCustomer(int id, [FromBody] CustomerDTO model)
        {
            if (id != model.customerID)
            {
                return NotFound();
            }
            await _customerRepo.UpdateCustomerAsync(id, model);
            return Ok();
        }

        [HttpDelete("{id}"), Authorize]
        public async Task<IActionResult> DeleteCustomer([FromRoute] int id)
        {
            await _customerRepo.DeleteCustomerAsync(id);
            return Ok();
        }
    }
}
