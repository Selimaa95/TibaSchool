using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TibaSchool.DAL.Entity;

namespace TibaSchool.BL.Interface
{
    public interface IAlbum
    {
        Task<IEnumerable<Album>> GetAllAsync(Expression<Func<Album, bool>> filter = null);
        Task<Album> GetByIdAsync(int id);
        Task CreateAsync(Album obj);
        Task UpdateAsync(Album obj);
        Task DeleteAsync(int id);
    }
}
