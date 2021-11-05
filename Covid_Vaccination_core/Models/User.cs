using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Covid_Vaccination_core.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Adharno { get; set; }
        [Required]
        public string Phoneno { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public int Bday { get; set; }
        [Required]
        public int Bmonth { get; set; }
        [Required]
        public int Byear { get; set; }
    }
}
