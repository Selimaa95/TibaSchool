using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TibaSchool.DAL.Entity;

namespace TibaSchool.DAL.DataBase
{
    public class ApplicationDbContext : IdentityDbContext
    {
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> opt) : base(opt)
        {                   
        }

        public DbSet<Event> Event { get; set; }
        public DbSet<Folder> Folder { get; set; }
        public DbSet<Album> Album { get; set; }
        public DbSet<Images> Images { get; set; }
        public DbSet<VideoFolder> videoFolders { get; set; }
        public DbSet<Video> Video { get; set; }
        public DbSet<Account> Account { get; set; }



    }
}
