using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TibaSchool.BL.Interface;
using TibaSchool.DAL.DataBase;
using TibaSchool.DAL.Entity;

namespace TibaSchool.BL.Repository
{
    public class AccountRep : IAccountRep
    {

        #region Prop

        private readonly ApplicationDbContext db;
        #endregion

        #region Ctor

        public AccountRep(ApplicationDbContext db)
        {
            this.db = db;
        }

        #endregion

        #region Logic

        public async Task<Account> GetUser(string username, string password)
        {
            var data = await db.Account.Where(x => x.UserName == username && x.Password == password).FirstOrDefaultAsync();
            
            return data;
        }
       
            
        
        #endregion
    }
}
