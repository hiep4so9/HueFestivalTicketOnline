using AutoMapper;
using HueFestivalTicketOnline.Data;
using HueFestivalTicketOnline.Models;
using HueFestivalTicketOnline.Repositories.IRepository;
using HueOnlineTicketFestival.Prototypes;
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

        public async Task<bool> CheckUserName(string userName)
        {

            var result = await _context.Users.CountAsync(x => x.username == userName) > 0;
            Console.WriteLine(result);
            return result;

        }

        //Create login by username and password
        public async Task<UserDTO?> Login(string userName, string password)
        {
            var user = await _context.Users.SingleOrDefaultAsync(x => x.username == userName);
            if (user == null)
            {
                return null;
            }

            if (password == null)
            {
                return null;
            }
            return _mapper.Map<UserDTO>(user);
        }

        public async Task<int> VerifyEmail(string token)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.VerificationToken == token);

            if (user == null)
            {
                return -1;
            }
            user.VerifyAt = DateTime.Now;
            try
            {
                await _context.SaveChangesAsync();
                return 1;
            }
            catch (DbUpdateException)
            {
                return -1;
            }
        }

        public async Task<int> ForgotPassword(string email)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
            if (user == null)
            {
                return -1;
            }

            user.PasswordResetToken = jwtHandler.CreateRandomToken();
            user.ResetTokenExpries = DateTime.Now.AddDays(1);
            await _context.SaveChangesAsync();
            return 1;
        }

        public async Task<int> ResetPassword(string token, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.PasswordResetToken == token);
            if (user == null || user.ResetTokenExpries < DateTime.Now)
            {
                return -1;
            }
            string passwordHash = password;

            user.password = passwordHash;
            user.PasswordResetToken = token;
            user.ResetTokenExpries = null;

            await _context.SaveChangesAsync();
            return 1;
        }

    }
}
