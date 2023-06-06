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
    public class FolderRep : IFolder
    {
        #region Prop
        private readonly ApplicationDbContext db;

        #endregion

        #region Ctor
        public FolderRep(ApplicationDbContext db)
        {
            this.db = db;
        }
        #endregion

        #region Methods

        public async Task<IEnumerable<Folder>> GetAllAsync(Expression<Func<Folder, bool>> filter = null)
        {
            if (filter != null)
            {
                return await db.Folder.Where(filter).ToListAsync();
            }
            else
            {
                return await db.Folder.ToListAsync();
            }
        }

        public async Task<Folder> GetByIdAsync(int FolderId)
        {
            var data = await db.Folder.FindAsync(FolderId);

            return data;
        }

        public async Task CreateAsync(Folder obj)
        {
            await db.Folder.AddAsync(obj);
            await db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var oldData = await db.Folder.FindAsync(id);
            db.Folder.Remove(oldData);
            await db.SaveChangesAsync();
        }


        public async Task UpdateAsync(Folder obj)
        {
           db.Entry(obj).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }
        #endregion
    }   
}
