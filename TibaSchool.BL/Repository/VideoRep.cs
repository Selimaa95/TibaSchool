using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TibaSchool.BL.Interface;
using TibaSchool.DAL.DataBase;
using TibaSchool.DAL.Entity;

namespace TibaSchool.BL.Repository
{
    public class VideoRep : IVideo
    {
        #region Prop
        private readonly ApplicationDbContext db;

        #endregion

        #region Ctor
        public VideoRep(ApplicationDbContext db)
        {
            this.db = db;
        }
        #endregion
        
        #region Methods
        public async Task<IEnumerable<Video>> GetAllAsync(Expression<Func<Video, bool>> filter = null)
        {
            if(filter != null)
            {
                return await db.Video.Where(filter).ToListAsync();
            }
            else
            {
                return await db.Video.ToListAsync();
            }
        }

        public async Task<Video> GetByIdAsync(Expression<Func<Video, bool>> filter)
        {
            var data = await db.Video.Where(filter).FirstOrDefaultAsync();

            return data;
        }

        public async Task CreateAsync(Video obj)
        {
            await db.Video.AddAsync(obj);
            await db.SaveChangesAsync();
        }

        public async Task DeleteAsync(Video obj)
        {
            db.Video.Remove(obj);
            await db.SaveChangesAsync();
        }

        public async Task UpdateAsync(Video obj)
        {
            db.Entry(obj).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }

        #endregion
    }
}

