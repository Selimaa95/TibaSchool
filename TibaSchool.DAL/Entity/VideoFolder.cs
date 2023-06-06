using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TibaSchool.DAL.Entity
{
    public class VideoFolder
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageName { get; set; }
        public IEnumerable<Video> Videos { get; set; }
    }
}
