using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TibaSchool.BL.VModels
{
    public class LoginVM
    {
        [Required(ErrorMessage = "User Name Required")]
        [MaxLength(50, ErrorMessage = "Min Len 50")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password Required")]
        [MinLength(6, ErrorMessage = "Min Len 6")]
        public string Password { get; set; }
    }
}
