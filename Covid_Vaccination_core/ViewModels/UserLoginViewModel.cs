using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Covid_Vaccination_core.ViewModels
{
    public class UserLoginViewModel
    {
        [Required]
        public string Phoneno { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
