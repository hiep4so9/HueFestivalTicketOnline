using AutoMapper;
using HueFestivalTicketOnline.Data;
using HueFestivalTicketOnline.Models;
using HueFestivalTicketOnline.Repositories.IRepository;
using Microsoft.EntityFrameworkCore;

namespace HueFestivalTicketOnline.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public UserRepository(DataContext context, IMapper mapper) 
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<int> AddUserAsync(UserDTO model)
        {
            var newUser = _mapper.Map<User>(model);
            _context.Users!.Add(newUser);
            await _context.SaveChangesAsync();

            return newUser.userID;
        }

/*        public async Task DeleteUserAsync(int id)
        {
            var deleteUser = _context.Users!.SingleOrDefault(b => b.userID == id);
            if (deleteUser != null)
            {
                _context.Users!.Remove(deleteUser);
                await _context.SaveChangesAsync();
            }
        }*/

        public async Task<List<UserDTO>> GetAllUsersAsync()
        {
            var users = await _context.Users!.ToListAsync();
            return _mapper.Map<List<UserDTO>>(users);
        }

        public async Task<UserDTO> GetUserAsync(int id)
        {
            var users = await _context.Users!.FindAsync(id);
            return _mapper.Map<UserDTO>(users);
        }

        public async Task UpdateUserAsync(int id, UserDTO model)
        {
            if (id == model.userID)
            {
                var updateUser = _mapper.Map<User>(model);
                _context.Users!.Update(updateUser);
                await _context.SaveChangesAsync();
            }
        }
    }
}
