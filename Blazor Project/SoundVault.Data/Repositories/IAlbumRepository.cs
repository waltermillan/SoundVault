using SoundVault.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundVault.Data.Repositories
{
    public interface IAlbumRepository
    { 
        Task<IEnumerable<Album>> GetAll();
        Task<Album> GetById(int id);
        Task<bool> Add(Album album);
        Task<bool> Update(Album album);
        Task<bool> Delete(int id);   
    }
}
