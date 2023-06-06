using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TibaSchool.DAL.Entity;

namespace TibaSchool.BL.VModels
{
    public class VideoVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name Required")]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "Path Required")]
        public string Path { get; set; }

        public string? ImageName { get; set; }

        [Required(ErrorMessage = "Image Required")]
        public IFormFile? Image { get; set; }
        
        [Required(ErrorMessage = "Folder Required")]
        public int FolderId { get; set; }
        public virtual VideoFolder? VideoFolder { get; set; }
    }
}
