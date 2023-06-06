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
    public class VideoEditDeleteVM
    {
        public int Id { get; set; }

        public string? Name { get; set; }
        
        public string? Path { get; set; }

        public string? ImageName { get; set; }

        public IFormFile? Image { get; set; }
        
        public int? FolderId { get; set; }
        public virtual VideoFolder? VideoFolder { get; set; }
    }
}
