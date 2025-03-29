using SoundVault.Model.Entities;
using System.Reflection;

namespace SoundVault.UI.Interfaces
{
    public interface IGenderService
    {
        Task<IEnumerable<Gender>> GetAll();
        Task<Gender> GetById(int id);
        Task Save(Gender gender);
        Task Delete(int id);
    }
}
