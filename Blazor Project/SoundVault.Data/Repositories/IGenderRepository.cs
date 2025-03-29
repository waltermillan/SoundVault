using SoundVault.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundVault.Data.Repositories
{
    public interface IGenderRepository
    { 
        Task<IEnumerable<Gender>> GetAll();
        Task<Gender> GetById(int id);
        Task<bool> Add(Gender gender);
        Task<bool> Update(Gender gender);
        Task<bool> Delete(int id);   
    }
}
