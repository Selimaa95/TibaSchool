using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TibaSchool.DAL.Entity;

namespace TibaSchool.BL.Interface
{
    public interface IAccountRep
    {
        Task<Account> GetUser(string username, string password);
    }
}
