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
    public class ImgFolderVM
    {
        [Required(ErrorMessage = "Field Required")]
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Name Required")]
        public string Name { get; set; }
        public string? ImageName { get; set; }

        [Required(ErrorMessage ="Image Required")]
        public IFormFile Image { get; set; }
        
        [Required(ErrorMessage = "Folder Required")]
        public int FolderId { get; set; }

        [Required(ErrorMessage = "Album Required")]
        public int AlbumId { get; set; }

        [Required(ErrorMessage = "Image List Required")]
        public IEnumerable<IFormFile> ImagesList { get; set; }

        public virtual Album? Album { get; set; }
        public virtual Folder? Folder { get; set; }
        public virtual IEnumerable<Images>? Images { get; set; }
        public virtual IEnumerable<Album>? Albums { get; set; }
    }
}
