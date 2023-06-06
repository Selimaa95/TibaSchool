using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TibaSchool.BL.VModels
{
    public class MailVM
    {
        [Required(ErrorMessage ="Name Required")]
        public string Name { get; set; }
        [Required(ErrorMessage = ("Email Required"))]
        [EmailAddress(ErrorMessage ="Email Invalid")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone Number Required")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Message Required")]
        public string Message { get; set; }
    }
}
