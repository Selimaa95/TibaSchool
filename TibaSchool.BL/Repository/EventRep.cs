using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TibaSchool.BL.Helper;
using TibaSchool.BL.Interface;
using TibaSchool.DAL.DataBase;
using TibaSchool.DAL.Entity;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace TibaSchool.BL.Repository
{
    public class EventRep : IEvent
    {
        #region Prop
        private readonly ApplicationDbContext db;

        #endregion

        #region Ctor

        public EventRep(ApplicationDbContext db)
        {
            this.db = db;
        }
        #endregion

        #region Methods

        public async Task<IEnumerable<Event>> GetAllAsync(Expression<Func<Event, bool>> filter)
        {
            if (filter != null)
            {
                return await db.Event.Where(filter).ToListAsync();
            }
            else
            {
                return await db.Event.ToListAsync();
            }

        }

        public async Task<IEnumerable<Event>> GetMainEventsAsync()
        {
            return await db.Event.OrderByDescending(x => x.Id).Take(3).ToListAsync();
        }

        public async Task<Event> GetByIdAsync(Expression<Func<Event, bool>> filter)
        {
            var data = await db.Event.Where(filter).FirstOrDefaultAsync();

            return data;
        }

        public async Task CreateAsync(Event obj)
        {
            await db.AddAsync(obj);
            await db.SaveChangesAsync();
        }

        public async Task UpdateAsync(Event obj)
        {
            db.Entry(obj).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }

        public async Task DeleteAsync(Event obj)
        {
            db.Event.Remove(obj);
            await db.SaveChangesAsync();
        }
        #endregion
    }
}
