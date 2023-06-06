using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TibaSchool.DAL.Entity;

namespace TibaSchool.BL.Interface
{
    public interface IEvent
    {
        Task<IEnumerable<Event>> GetAllAsync(Expression<Func<Event, bool>> filter = null);
        Task<Event> GetByIdAsync(Expression<Func<Event, bool>> filter = null);
        Task CreateAsync(Event obj);
        Task UpdateAsync(Event obj);
        Task DeleteAsync(Event obj);
        Task<IEnumerable<Event>> GetMainEventsAsync();
    }
}
