using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TibaSchool.DAL.Entity;

namespace TibaSchool.BL.Interface
{
    public interface IVideo
    {
        Task<IEnumerable<Video>> GetAllAsync(Expression<Func<Video, bool>> filter = null);
        Task<Video> GetByIdAsync(Expression<Func<Video, bool>> filter = null);
        Task CreateAsync(Video obj);
        Task UpdateAsync(Video obj);
        Task DeleteAsync(Video obj);
    }
}
