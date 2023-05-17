using HueFestivalTicketOnline.Data;
using HueFestivalTicketOnline.Models;

namespace HueFestivalTicketOnline.Repositories.IRepository
{
    public interface IUserRepository
    {
        public Task<List<UserDTO>> GetAllUsersAsync();
        public Task<UserDTO> GetUserAsync(int id);
        public Task<int> AddUserAsync(UserDTO model);
        public Task UpdateUserAsync(int id, UserDTO model);
        Task<bool> CheckUserName(string username);
/*        Task<User> GetUserByUsernamePasswordAsync(string username, string password);*/
        /*public Task DeleteUserAsync(int id);*/
    }
}
