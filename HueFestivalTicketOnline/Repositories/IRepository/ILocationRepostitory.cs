using HueFestivalTicketOnline.Data;

namespace HueFestivalTicketOnline.Repositories.IRepository
{
    public interface ILocationRepostitory
    {
        public Task<List<LocationDTO>> GetAllLocationsAsync();
        public Task<LocationDTO> GetLocationAsync(int id);
        public Task<int> AddLocationAsync(LocationDTO model);
        public Task UpdateLocationAsync(int id, LocationDTO model);
        public Task DeleteLocationAsync(int id);
    }
}
