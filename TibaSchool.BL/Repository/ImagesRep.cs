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
    public class ImagesRep : IImages
    {

        #region Prop
        private readonly ApplicationDbContext db;

        #endregion

        #region Ctor
        public ImagesRep(ApplicationDbContext db)
        {
            this.db = db;
        }
        #endregion

        #region Methods
        public async Task<IEnumerable<Images>> GetAllAsync(Expression<Func<Images, bool>> filter = null)
        {
            if (filter != null)
            {
                return await db.Images.Where(filter).ToListAsync();
            }
            else
            {
                return await db.Images.ToListAsync();
            }
        }
       
        public async Task CreateAsync(Images obj)
        {
            await db.Images.AddAsync(obj);
            await db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var oldData = await db.Images.FindAsync(id);
            db.Images.Remove(oldData);
            await db.SaveChangesAsync();
        }

        public async Task UpdateAsync(Images obj)
        {
            db.Entry(obj).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }
    #endregion

    }
}
