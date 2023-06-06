using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TibaSchool.DAL.Entity;

namespace TibaSchool.BL.Interface
{
    public interface IVideoFolder
    {
        Task<IEnumerable<VideoFolder>> GetAllAsync(Expression<Func<VideoFolder, bool>> filter = null);
        Task<VideoFolder> GetByIdAsync(int FolderId);
        Task CreateAsync(VideoFolder obj);
        Task UpdateAsync(VideoFolder obj);
        Task DeleteAsync(int id);
    }
}
