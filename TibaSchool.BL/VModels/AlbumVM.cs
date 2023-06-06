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
    public class AlbumVM
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? ImageName { get; set; }
        public IFormFile? Image { get; set; }
        public int FolderId { get; set; }
        public virtual Folder? Folder { get; set; }
        public virtual IEnumerable<Images>? Images { get; set; }
    }
}
