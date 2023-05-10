using HueFestivalTicketOnline.Data;

namespace HueFestivalTicketOnline.Repositories.IRepository
{
    public interface IArtistRepository
    {
        public Task<List<ArtistDTO>> GetAllArtistsAsync();
        public Task<ArtistDTO> GetArtistAsync(int id);
        public Task<int> AddArtistAsync(ArtistDTO model);
        public Task UpdateArtistAsync(int id, ArtistDTO model);
        public Task DeleteArtistAsync(int id);
    }
}
