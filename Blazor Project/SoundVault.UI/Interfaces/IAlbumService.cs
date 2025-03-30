using SoundVault.Model.Entities;

namespace SoundVault.UI.Interfaces
{
    public interface IAlbumService
    {
        Task<IEnumerable<Album>> GetAll();
        Task<Album> GetById(int id);
        Task Save(Album genres);
        Task Update(Album album);
        Task Delete(int id);
    }
}
