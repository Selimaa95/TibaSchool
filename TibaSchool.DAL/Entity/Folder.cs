using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TibaSchool.DAL.Entity
{
    public class Folder
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public string ImageName { get; set; }

        public virtual IEnumerable<Album> Albums { get; set; } 
    }
}
