using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TibaSchool.DAL.Entity;

namespace TibaSchool.BL.VModels
{
    public class ImgFolderEditDeleteVM
    {
        
        public int? Id { get; set; }

        public string? Name { get; set; }
        public string? ImageName { get; set; }

        public IFormFile? Image { get; set; }

        public int? FolderId { get; set; }

        public int? AlbumId { get; set; }

        public IEnumerable<IFormFile>? ImagesList { get; set; }

        public virtual Album? Album { get; set; }
        public virtual Folder? Folder { get; set; }
        public virtual IEnumerable<Images>? Images { get; set; }
        public virtual IEnumerable<Album>? Albums { get; set; }
    }
}
