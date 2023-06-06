using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TibaSchool.DAL.Entity;

namespace TibaSchool.BL.Interface
{
    public interface IFolder
    {
        Task<IEnumerable<Folder>> GetAllAsync(Expression<Func<Folder, bool>> filter = null);
        Task<Folder> GetByIdAsync(int FolderId);
        Task CreateAsync(Folder obj);
        Task UpdateAsync(Folder obj);
        Task DeleteAsync(int id);
    }
}
