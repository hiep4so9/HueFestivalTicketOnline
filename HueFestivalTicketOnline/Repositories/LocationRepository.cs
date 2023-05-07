using AutoMapper;
using HueFestivalTicketOnline.Data;
using HueFestivalTicketOnline.Models;
using HueFestivalTicketOnline.Repositories.IRepository;
using Microsoft.EntityFrameworkCore;

namespace HueFestivalTicketOnline.Repositories
{
    public class LocationRepository : ILocationRepostitory
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public LocationRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<int> AddLocationAsync(LocationDTO model)
        {
            var newLocation = _mapper.Map<Location>(model);
            _context.Locations!.Add(newLocation);
            await _context.SaveChangesAsync();

            return newLocation.locationID;
        }

        public async Task DeleteLocationAsync(int id)
        {
            var deleteLocation = _context.Locations!.SingleOrDefault(b => b.locationID == id);
            if (deleteLocation != null)
            {
                _context.Locations!.Remove(deleteLocation);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<LocationDTO>> GetAllLocationsAsync()
        {
            var locations = await _context.Locations!.ToListAsync();
            return _mapper.Map<List<LocationDTO>>(locations);
        }

        public async Task<LocationDTO> GetLocationAsync(int id)
        {
            var locations = await _context.Locations!.FindAsync(id);
            return _mapper.Map<LocationDTO>(locations);
        }

        public async Task UpdateLocationAsync(int id, LocationDTO model)
        {
            if (id == model.locationID)
            {
                var updateLocation = _mapper.Map<Location>(model);
                _context.Locations!.Update(updateLocation);
                await _context.SaveChangesAsync();
            }
        }
    }
}
