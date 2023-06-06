using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;

namespace TibaSchool.BL.VModels
{
    public class EventVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Title Required")]
        public string Title { get; set; }

        [Required(ErrorMessage ="Description Required")]
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string? ImageName { get; set; }
        public IFormFile? Image { get; set; }
    }   

}
