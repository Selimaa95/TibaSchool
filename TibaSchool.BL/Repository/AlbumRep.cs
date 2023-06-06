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
    public class AlbumRep : IAlbum
    {
        #region Prop
        private readonly ApplicationDbContext db;

        #endregion

        #region Ctor
        public AlbumRep(ApplicationDbContext db)
        {
            this.db = db;
        }
        #endregion

        #region Methods

        public async Task<IEnumerable<Album>> GetAllAsync(Expression<Func<Album, bool>> filter)
        {
            if (filter != null)
            {
                return await db.Album.Where(filter).ToListAsync();
            }
            else
            {
                return await db.Album.ToListAsync();
            }
        }

        public async Task<Album> GetByIdAsync(int id)
        {
            var data = await db.Album.FindAsync(id);
            return data;
        }
        
        public async Task CreateAsync(Album obj)
        {
            await db.Album.AddAsync(obj);
            await db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var oldData = await db.Album.FindAsync(id);
            db.Album.Remove(oldData);
            await db.SaveChangesAsync();
        }


        public async Task UpdateAsync(Album obj)
        {
            db.Entry(obj).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }
        #endregion
    }
}
