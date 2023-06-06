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
    public class VideoFolderVM
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? ImageName { get; set; }

        public IFormFile? Image { get; set; }
        public IEnumerable<Video>? Videos { get; set; }
    }
}
