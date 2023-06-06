using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TibaSchool.DAL.Entity;

namespace TibaSchool.BL.VModels
{
    public class ImagesVM
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public IEnumerable<IFormFile>? ImagesList { get; set; }
        public int AlbumId { get; set; }
        public virtual Album? Album { get; set; }

    }
    

}
