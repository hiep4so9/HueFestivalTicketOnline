using AutoMapper;
using HueFestivalTicketOnline.Data;
using HueFestivalTicketOnline.Model;
using HueFestivalTicketOnline.Models;
using HueFestivalTicketOnline.Repositories.IRepository;
using Microsoft.EntityFrameworkCore;

namespace HueFestivalTicketOnline.Repositories
{
    public class ArtistRepository : IArtistRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public ArtistRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<int> AddArtistAsync(ArtistDTO model)
        {
            var newArtist = _mapper.Map<Artist>(model);
            _context.Artists!.Add(newArtist);
            await _context.SaveChangesAsync();

            return newArtist.artistID;
        }

        public async Task DeleteArtistAsync(int id)
        {
            var deleteArtist = _context.Artists!.SingleOrDefault(b => b.artistID == id);
            if (deleteArtist != null)
            {
                _context.Artists!.Remove(deleteArtist);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<ArtistDTO>> GetAllArtistsAsync()
        {
            var Artists = await _context.Artists!.ToListAsync();
            return _mapper.Map<List<ArtistDTO>>(Artists);
        }

        public async Task<ArtistDTO> GetArtistAsync(int id)
        {
            var Artists = await _context.Artists!.FindAsync(id);
            return _mapper.Map<ArtistDTO>(Artists);
        }

        public async Task UpdateArtistAsync(int id, ArtistDTO model)
        {
            if (id == model.artistID)
            {
                var updateArtist = _mapper.Map<Artist>(model);
                _context.Artists!.Update(updateArtist);
                await _context.SaveChangesAsync();
            }
        }
    }
}
