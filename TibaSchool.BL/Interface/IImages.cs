using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TibaSchool.DAL.Entity;

namespace TibaSchool.BL.Interface
{
    public interface IImages
    {
        Task<IEnumerable<Images>> GetAllAsync(Expression<Func<Images, bool>> filter = null);
        //Task<Images> GetByIdAsync(Expression<Func<Images, bool>> filter = null);
        Task CreateAsync(Images obj);
        Task UpdateAsync(Images obj);
        Task DeleteAsync(int id);
    }
}
