using HueFestivalTicketOnline.Data;

namespace HueFestivalTicketOnline.Repositories.IRepository
{
    public interface IUserRepository
    {
        public Task<List<UserDTO>> GetAllUsersAsync();
        public Task<UserDTO> GetUserAsync(int id);
        public Task<int> AddUserAsync(UserDTO model);
        public Task UpdateUserAsync(int id, UserDTO model);
        /*public Task DeleteUserAsync(int id);*/
    }
}
