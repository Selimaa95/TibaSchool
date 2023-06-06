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
    public class VideoFolderRep : IVideoFolder
    {
        #region Prop
        private readonly ApplicationDbContext db;

        #endregion

        #region Ctor
        public VideoFolderRep(ApplicationDbContext db)
        {
            this.db = db;
        }
        #endregion

        #region Methods

        public async Task<IEnumerable<VideoFolder>> GetAllAsync(Expression<Func<VideoFolder, bool>> filter = null)
        {
            if(filter != null)
            {
                return await db.videoFolders.Where(filter).ToListAsync();
            }
            else
            {
                return await db.videoFolders.ToListAsync();
            }
        }
        public async Task<VideoFolder> GetByIdAsync(int FolderId)
        {
            var data = await db.videoFolders.FindAsync(FolderId);

            return data;
        }

        public async Task CreateAsync(VideoFolder obj)
        {
            await db.videoFolders.AddAsync(obj);
            await db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var oldData = await db.videoFolders.FindAsync(id);
            db.videoFolders.Remove(oldData);
            await db.SaveChangesAsync();
        }

        public async Task UpdateAsync(VideoFolder obj)
        {
            db.Entry(obj).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }
        #endregion
    }
}
